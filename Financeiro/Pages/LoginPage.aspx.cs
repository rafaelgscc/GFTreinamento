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
	public partial class LoginPage:Page
	{
		
		public string AtxtUserField
		{
			get
			{
				return txtUser.Text;
			}
		}
		
		public string AtxtSenhaField
		{
			get
			{
				return txtSenha.Text;
			}
		}
		

		protected override void OnLoad(EventArgs e)
		{
			try
			{

			
				InitializePageContent();
				Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this));
			}
			catch (Exception ex)
			{
			}
		}


		public void ShowFormulas()
		{
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label10.Text = Label10.Text.Replace("<", "&lt;");
			Label10.Text = Label10.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			Label12.Text = Label12.Text.Replace("<", "&lt;");
			Label12.Text = Label12.Text.Replace(">", "&gt;");
			Label13.Text = Label13.Text.Replace("<", "&lt;");
			Label13.Text = Label13.Text.Replace(">", "&gt;");
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label14.Text = Label14.Text.Replace("<", "&lt;");
			Label14.Text = Label14.Text.Replace(">", "&gt;");
			Label15.Text = Label15.Text.Replace("<", "&lt;");
			Label15.Text = Label15.Text.Replace(">", "&gt;");
		}

		private void InitializePageContent()
		{
			ShowFormulas();
		}


		public bool DoLogin()
		{
			string LoginError = "";
			bool RetVal = Utility.DoLogin(txtUser.Text , txtSenha.Text , this, ref LoginError, ajxMainAjaxPanel);
			if(!RetVal)
			{
				labError.Text = LoginError;
			}
			else
			{
				labError.Text = "";
			}
			InitializePageContent();
			return RetVal;
		}
			protected void ___BtnLogin_OnClick(object sender, EventArgs e)
			{
				bool ActionSucceeded_1 = true;
				try
				{
					ActionSucceeded_1 = DoLogin();
				}
				catch (Exception ex)
				{
					ActionSucceeded_1 = false;
				}
			}

		protected override void InitializeCulture()
		{
			Utility.SetThreadCulture();  
		}

	}

}
