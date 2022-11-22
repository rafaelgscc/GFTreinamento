using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
/// <summary>
/// Summary description for UserControlsHelper
/// </summary>
namespace PROJETO
{
    public static class UserControlsHelper
    {

		public static Control GetControlByType<T>(Control Container)
		{
			Control result = (Container is T ? Container : null);

			if (result == null)
			{
				foreach (Control child in Container.Controls)
				{
					result = GetControlByType<T>(child);

					if (result != null)
					{
						break;
					}
				}
			}

			return result;
		}

		public static Control GetControlById(Control Container, string Id)
		{
			Control result = (Container.ClientID.Equals(Id) ? Container : null);

			if (result == null)
			{
				foreach (Control child in Container.Controls)
				{
					result = GetControlById(child, Id);
					if (result != null)
					{
						break;
					}
				}
			}

			return result;
		}

		public static Control CreateScript(string script)
		{
			LiteralControl ltr = new LiteralControl();
			ltr.Text = "\t<script>\r\n\t" + script + "\r\n\t</script>";
			return ltr;
		}

		public static void AddClass(HtmlControl control, string className)
		{
			string[] classes = control.Attributes["class"].Split(' ');
			if (!classes.Contains(className))
			{
				control.Attributes["class"] += " " + className;
			}
		}
		public static void RemoveClass(HtmlControl control, string className)
		{
			string[] classes = control.Attributes["class"].Split(' ');
			if (classes.Contains(className))
			{
				control.Attributes["class"] = string.Join(" ", classes.Where(c => !c.Equals(className)));
			}
		}

		public static void RegisterCss(Page page, string cssFileName)
		{
			RadCodeBlock codeBlock = new RadCodeBlock();
			HtmlLink style = new HtmlLink();
			style.Attributes["rel"] = "stylesheet";
			style.Href = page.ResolveUrl(cssFileName);
			codeBlock.Controls.Add(style);
			page.Header.Controls.Add(codeBlock);

		}

		public static void RegisterEndScript(Page page, string scriptKey, string script)
		{
			bool isRegistered = false;
			if (page.IsPostBack)
			{
				RadAjaxPanel panel = UserControlsHelper.GetControlByType<RadAjaxPanel>(page) as RadAjaxPanel;
				if (panel != null)
				{
					panel.ResponseScripts.Add(script);
					isRegistered = true;
				}
			}
			if (!isRegistered)
			{
				page.ClientScript.RegisterStartupScript(page.GetType(), scriptKey, "<script>" + script + "</script>");
			}
		}
	}
}
