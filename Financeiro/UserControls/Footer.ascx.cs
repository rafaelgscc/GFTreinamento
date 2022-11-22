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

	public partial class Footer : UserControl, IFooter
	{
		public FooterPositionEnum Position { get; set; }
		public string Transition { get; set; }
		public string Container { get; set; }

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
		
		private ISidebar _sidebar;

		private ISidebar SidebarControl
		{
			get
			{
				if (this._sidebar == null) this._sidebar = UserControlsHelper.GetControlByType<ISidebar>(Page) as ISidebar;
				return this._sidebar;
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			InitializeFooter();
			try
            {
                InitializePageContent();
            }
            catch (Exception ex)
            {
            }
		}

		private void InitializeFooter()
		{

			UserControlsHelper.RemoveClass(Form1, "gvFull");
			UserControlsHelper.AddClass(Form1, "gvFooter");

			if (SidebarControl != null && SidebarControl.Mode == SidebarModeEnum.Full)
			{
				UserControlsHelper.AddClass(Form1, "gvFooterSidebar");
				if ((!SidebarControl.AutoOpen && SidebarControl.Opened != "true") || SidebarControl.Opened == "false")
				{
					UserControlsHelper.AddClass(Form1, "gvFull");
				}
			}
			else if (SidebarControl == null || this.Position == FooterPositionEnum.Fixed)
			{
				UserControlsHelper.AddClass(Form1, "gvFull");
			}
			else if (SidebarControl != null && SidebarControl.Mode == SidebarModeEnum.Inside && this.Position == FooterPositionEnum.Dynamic)
			{
				UserControlsHelper.AddClass(Form1, "gvFooterSidebar");
			}

			if (Position == FooterPositionEnum.Fixed)
			{
				UserControlsHelper.AddClass(Form1, "gvFixedFooter");
				if (ContainerControl != null) ContainerControl.Style["margin-bottom"] = "var(--footerHeight)";
			}

			if (!IsPostBack)
			{
				if (!string.IsNullOrEmpty(Transition))
				{
					Form1.Style["transition"] = "all " + Transition;
				}


				// sidebar or header will register container
				if (SidebarControl == null && HeaderControl == null && !string.IsNullOrEmpty(Container) && ContainerControl != null)
				{
					UserControlsHelper.AddClass(ContainerControl, "gvLayoutContainer");
					ContainerControl.Style["transition"] = "all " + Transition;
				}
			}

			string script = string.Format("LayoutController.registerFooter({{ footer: '#{0}', position: '{1}', container: '#{2}' }});", Form1.ClientID, Position.ToString().ToLower(), Container);
			UserControlsHelper.RegisterEndScript(this.Page, "initializeFooter", script);
		}

		protected override void OnInit(EventArgs e)
        {
			if (Position == FooterPositionEnum.Dynamic && !string.IsNullOrEmpty(Container))
			{
				this.Page.InitComplete += Page_InitComplete;
			}
			this.Page.PreRenderComplete += Page_PreRenderComplete;
		}

		private void Page_InitComplete(object sender, EventArgs e)
		{
			if (ContainerControl != null)
			{
				this.Parent.Controls.Remove(this);
				ContainerControl.Parent.Controls.AddAt(ContainerControl.Parent.Controls.IndexOf(ContainerControl) + 1, this);
			}
		}

		private void Page_PreRenderComplete(object sender, EventArgs e)
		{
			UserControlsHelper.RegisterCss(this.Page, "~/Styles/Footer.css?sv=1.0_20221122174321");
		}

		public void ShowFormulas()
		{
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
		}

		private void InitializePageContent()
		{
			ShowFormulas();
		}



	}
}
