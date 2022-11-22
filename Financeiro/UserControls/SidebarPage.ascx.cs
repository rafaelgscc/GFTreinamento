using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using COMPONENTS;

namespace PROJETO
{

	public partial class SidebarPage : UserControl, ISidebar
	{
		public SidebarPositionEnum Position { get; set; }
		private SidebarModeEnum _Mode;
		public SidebarModeEnum Mode 
		{ 
			get
			{
				if (_Mode == SidebarModeEnum.Inside && (
					(FooterControl != null && FooterControl.Position == FooterPositionEnum.Dynamic) || 
					(HeaderControl != null && HeaderControl.Position == HeaderPositionEnum.Dynamic)))
				{
					return SidebarModeEnum.Full;
				}
				return _Mode;
			}
			set
			{
				_Mode = value;
			}
		}
		public bool AutoOpen { get; set; }
		public string Transition { get; set; }
		public string Container { get; set; }

		public string Opened
		{
			get
			{
				return Sidebar_ClientState.Value;
			}
			set
			{
				Sidebar_ClientState.Value = value;
			}
		}

		private IFooter footer;

		private HtmlControl _container;

		private HtmlControl ContainerControl
		{
			get
			{
				if (this._container == null) this._container = UserControlsHelper.GetControlById(Page, Container) as HtmlControl;
				return this._container;
			}
		}

		private IHeader _header;

		private IHeader HeaderControl
		{
			get
			{
				if (this._header == null) this._header = UserControlsHelper.GetControlByType<IHeader>(Page) as IHeader;
				return this._header;
			}
		}

		private IFooter _footer;

		private IFooter FooterControl
		{
			get
			{
				if (this._footer == null) this._footer = UserControlsHelper.GetControlByType<IFooter>(Page) as IFooter;
				return this._footer;
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			InitializeSidebar();
			try
            {
                InitializePageContent();
            }
            catch (Exception ex)
            {
            }
		}

		private void InitializeSidebar()
		{
			string headerHeight = "";
			string footerHeight = "";

			if (Mode == SidebarModeEnum.Inside)
			{
				if (HeaderControl != null)
				{
					Form1.Style["margin-top"] = "var(--headerHeight)";
					headerHeight = " - var(--headerHeight)";
				}
				if (FooterControl != null)
				{
					Form1.Style["margin-bottom"] = "var(--footerHeight)";
					footerHeight = " - var(--footerHeight)";
				}
			}

			__MainDiv.Style["height"] = "calc(100vh" + headerHeight + footerHeight + ")";

			if (!string.IsNullOrEmpty(Transition))
			{
				Form1.Style["transition"] = "all " + Transition;
			}

			if (AutoOpen)
			{
				UserControlsHelper.AddClass(Form1, "auto");
			}

			UserControlsHelper.RemoveClass(Form1, "opened");
			UserControlsHelper.RemoveClass(Form1, "closed");
			UserControlsHelper.AddClass(Form1, "gvSidebar");

			if (Opened == "false")
			{
				UserControlsHelper.AddClass(Form1, "closed");
			}

			if (!string.IsNullOrEmpty(Container))
			{
				if (ContainerControl != null)
				{
					UserControlsHelper.AddClass(ContainerControl, "gvLayoutContainer");

					ContainerControl.Style["transition"] = "all " + Transition;

					if (Opened == "false" || (!AutoOpen && Opened != "true"))
					{
						UserControlsHelper.AddClass(ContainerControl, "gvFull");
					}
					else
					{
						UserControlsHelper.RemoveClass(ContainerControl, "gvFull");
					}
				}
			}

			string script = string.Format("LayoutController.registerSidebar({{ sidebar: '#{0}', clientState: '#{1}', mode: '{2}', autoOpen: {3}, container: '#{4}' }});", Form1.ClientID, Sidebar_ClientState.ClientID, Mode.ToString().ToLower(), AutoOpen.ToString().ToLower(), Container);
			UserControlsHelper.RegisterEndScript(this.Page, "initializeSidebar", script);
		}

		protected override void OnInit(EventArgs e)
        {
			this.Page.PreRenderComplete += Page_PreRenderComplete;
			string argument = Page.Request["__EVENTTARGET"];
			if (argument == "LOGOFF")
			{
				SessionClose();
			}
			if (!IsPostBack)
            {
				HttpCookie sidebarCookie = Request.Cookies["SideBarCookie"];
				if (sidebarCookie != null && !string.IsNullOrEmpty(sidebarCookie.Value))
				{
					this.Opened = sidebarCookie.Value;
				}
			}
		}

		private void Page_PreRenderComplete(object sender, EventArgs e)
		{
			UserControlsHelper.RegisterCss(this.Page, "~/Styles/SidebarPage.css?sv=1.0_20221122174321");
		}

		public void ShowFormulas()
		{
			try { Label2.Text = (EnvironmentVariable.LoggedNameUser).ToString(); }
			catch { Label2.Text = ""; }
			Label2.Text = Label2.Text.Replace(double.NaN.ToString(), "");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
		}

		private void InitializePageContent()
		{
			ShowFormulas();
		}


		private void SessionClose()
		{
			FormsAuthentication.SignOut();
			Response.Redirect(Utility.StartPageName);
			Session.Clear();
		}

	}
}
