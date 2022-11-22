<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" ValidateRequest="false" CodeFile="LoginPage.aspx.cs" Inherits="PROJETO.LoginPage" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>


	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/LoginPage.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css??sv=1.0_20221122174320") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css??sv=1.0_20221122174320") %>" type="text/css" media="screen" title="no title"/>
	<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=1.0_20221122174320") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=1.0_20221122174320") %>" type="text/css" media="screen" title="no title"/>  
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js??sv=1.0_20221122174320") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=1.0_20221122174320") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=1.0_20221122174320") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=1.0_20221122174320") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js??sv=1.0_20221122174320") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=1.0_20221122174320") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=1.0_20221122174320") %>"></script>

			<script type="text/javascript" src="<%= ResolveUrl("~/JS/LoginPage_USER.js??sv=1.0_20221122174320") %>"></script>
		<script type="text/javascript">
			function OnLoginSucceded()
			{
				 ___Form1_OnLoginSucceded();
			}
			function TryLogin(PageToRedirect, RefreshControlsID)
			{
				document.forms[0].RefreshControlsIDHidden.value = RefreshControlsID;
				document.forms[0].PageToRedirectHidden.value = PageToRedirect;
			}
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
		
	<script type="text/javascript">
		function ___Form1_OnLoginSucceded()
		{
			var UrlPage = '<%= ResolveUrl("~/home") %>';
			Navigate(UrlPage, false);
			return false;
		}
		function ___txtUser_onkeydown(event,vgWin)
		{
		}
		function ___txtSenha_onkeydown(event,vgWin)
		{
		}
	</script>
		<form id="Form1" runat="server" class="c_Form1" defaultButton="BtnLogin">
		<input type="hidden" name="PageToRedirectHidden" value="" />
		<input type="hidden" name="RefreshControlsIDHidden" value="" />
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
				<telerik:RadAjaxPanel id="ajxMainAjaxPanel" runat="server" CssClass="c_ajxMainAjaxPanel" LoadingPanelID="___ajxMainAjaxPanel_AjaxLoading">
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1 div-secondary">
					</div>
					<div id="LayoutContainer1" runat="server" class="container c_LayoutContainer1">
						<div id="LayoutRow1" class="row c_LayoutRow1">
							<div id="LayoutCol1" class="col col-12 c_LayoutCol1">
								<div id="Div2" runat="server" class="c_Div2 div-transparent">
									<asp:Image id="Image1" runat="server" class="c_Image1" ImageUrl="~/Images/Gvinci/Logo-Horizontal.png" />
								</div>
							</div>
						</div>
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol9" class="col col-10 offset-1 offset-md-1 c_LayoutCol9">
								<div id="LayoutRow6" class="row c_LayoutRow6 card flex-row">
									<div id="LayoutCol10" class="col col-7 c_LayoutCol10">
										<telerik:RadLabel id="Label8" runat="server" CssClass="c_Label8" Text="<%$ Resources: Label8 %>" />
										<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" Text="<%$ Resources: Label10 %>" />
										<asp:Image id="Image2" runat="server" class="c_Image2" ImageUrl="~/Images/SistemaDefault/backloginl.png" />
										<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" Text="<%$ Resources: Label9 %>" />
										<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
									</div>
									<div id="LayoutCol11" class="col col-12 col-md-5 c_LayoutCol11 card-body">
										<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
										<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" Text="<%$ Resources: Label13 %>" />
										<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
										<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
										<telerik:RadTextBox id="txtUser" runat="server" AutoPostBack="False" CssClass="c_txtUser textbox-default"
											EmptyMessageStyle-ForeColor="#828282" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333"
											MaxLength="0" placeholder="<%$ Resources: txtUser %>" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
											WrapperCssClass="c_txtUser_wrapper" />
										<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
										<telerik:RadTextBox id="txtSenha" runat="server" AutoPostBack="False" CssClass="c_txtSenha textbox-default"
											EmptyMessageStyle-ForeColor="#828282" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333"
											MaxLength="0" placeholder="<%$ Resources: txtSenha %>" ReadOnly="False" RenderMode="Lightweight" TabIndex="2" TextMode="Password"
											WrapperCssClass="c_txtSenha_wrapper" />
										<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
										<telerik:RadButton id="BtnLogin" runat="server" ButtonType="SkinnedButton"
											CssClass="c_BtnLogin button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="BtnLogin" OnClick="___BtnLogin_OnClick"
											RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: BtnLogin %>">
											<ContentTemplate>
												<span class="gvText">Acessar</span>
												<span class="fas fa-sign-in-alt c_BtnLogin_icon gvIcon"></span>
											</ContentTemplate>
										</telerik:RadButton>
										<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" Text="<%$ Resources: Label14 %>" />
										<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" Text="<%$ Resources: Label15 %>" />
									</div>
								</div>
							</div>
						</div>
					</div>
					<telerik:RadAjaxLoadingPanel ID="___ajxMainAjaxPanel_AjaxLoading" runat="server">
					</telerik:RadAjaxLoadingPanel>
				</telerik:RadAjaxPanel>
		</form>
		
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
<script type="text/javascript">
	ShowClientFormulas();

	function ShowClientFormulas()
	{
	}
	var $j = jQuery.noConflict();
	$j(document).ready(SetFocusFirstField());
	function SetFocusFirstField()
	{
		try
		{
			{
				window.focus();
				setTimeout("var $j = jQuery.noConflict();$j('#txtUser').first().focus();", 200);
			}
		}
		catch (e)
		{
		}
	}
		function AtxtUser() { return document.getElementById('txtUser').value; }
		function AtxtSenha() { return document.getElementById('txtSenha').value; }

</script>
</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>
