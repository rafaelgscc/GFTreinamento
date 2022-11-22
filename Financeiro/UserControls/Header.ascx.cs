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

	public partial class Header : UserControl, IHeader
	{
		public HeaderPositionEnum Position { get; set; }
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
			InitializeHeader();
			try
            {
                InitializePageContent();
            }
            catch (Exception ex)
            {
            }
		}

		private void InitializeHeader()
		{

			UserControlsHelper.RemoveClass(Form1, "gvFull");
			UserControlsHelper.AddClass(Form1, "gvHeader");

			if (SidebarControl != null && SidebarControl.Mode == SidebarModeEnum.Full)
			{
				UserControlsHelper.AddClass(Form1, "gvHeaderSidebar");
				if ((!SidebarControl.AutoOpen && SidebarControl.Opened != "true") || SidebarControl.Opened == "false")
				{
					UserControlsHelper.AddClass(Form1, "gvFull");
				}
			}
			else if (SidebarControl == null || this.Position == HeaderPositionEnum.Fixed)
			{
				UserControlsHelper.AddClass(Form1, "gvFull");
			}
			else if (SidebarControl != null && SidebarControl.Mode == SidebarModeEnum.Inside && this.Position == HeaderPositionEnum.Dynamic)
			{
				UserControlsHelper.AddClass(Form1, "gvHeaderSidebar");
			}

			if (Position == HeaderPositionEnum.Fixed)
			{
				UserControlsHelper.AddClass(Form1, "gvFixedHeader");
				if (ContainerControl != null) ContainerControl.Style["margin-top"] = "var(--headerHeight)";
			}

			if (!IsPostBack)
			{
				if (!string.IsNullOrEmpty(Transition))
				{
					Form1.Style["transition"] = "all " + Transition;
				}

				// sidebar will register container
				if (!string.IsNullOrEmpty(Container) && SidebarControl == null && ContainerControl != null)
				{
					UserControlsHelper.AddClass(ContainerControl, "gvLayoutContainer");
					ContainerControl.Style["transition"] = "all " + Transition;
				}
			}

			string script = string.Format("LayoutController.registerHeader({{ header: '#{0}', position: '{1}', container: '#{2}' }});", Form1.ClientID, Position.ToString().ToLower(), Container);
			UserControlsHelper.RegisterEndScript(this.Page, "initializeHeader", script);		
		}

		protected override void OnInit(EventArgs e)
        {
			if (Position == HeaderPositionEnum.Dynamic && !string.IsNullOrEmpty(Container))
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
				ContainerControl.Parent.Controls.AddAt(ContainerControl.Parent.Controls.IndexOf(ContainerControl), this);
			}
		}

		private void Page_PreRenderComplete(object sender, EventArgs e)
		{
			UserControlsHelper.RegisterCss(this.Page, "~/Styles/Header.css?sv=1.0_20221122174321");
		}

		public void ShowFormulas()
		{
		}

		private void InitializePageContent()
		{
			ShowFormulas();
		}



	}
}
