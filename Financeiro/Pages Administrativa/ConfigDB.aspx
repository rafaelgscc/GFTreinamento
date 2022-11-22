<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" CodeFile="ConfigDB.aspx.cs" Inherits="PROJETO.ConfigDB" Culture="auto" UICulture="auto"%>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadCheckBox_checkbox_toggle_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/ConfigDB.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
	<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=1.0_20221122174321") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=1.0_20221122174321") %>" type="text/css" media="screen" title="no title"/>  
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=1.0_20221122174321") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js??sv=1.0_20221122174321") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=1.0_20221122174321") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=1.0_20221122174321") %>"></script>


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/RadComboBoxHelper.js??sv=1.0_20221122174321") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/JS/ConfigDB_USER.js??sv=1.0_20221122174321") %>"></script>
	</telerik:RadCodeBlock>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
				<div id="LayoutContainer1" runat="server" class="container c_LayoutContainer1">
					<div id="LayoutRow2" class="row c_LayoutRow2">
						<div id="LayoutCol12" class="col col-12 col-md-8 col-lg-6 col-xl-4 offset-0 offset-md-2 offset-lg-3 offset-xl-4 c_LayoutCol12">
							<div id="LayoutRow1" class="row c_LayoutRow1 card flex-row">
								<div id="LayoutCol11" class="col col-12 c_LayoutCol11 card-header">
									<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Configuração de banco de dados" />
								</div>
								<div id="LayoutCol13" class="col col-12 c_LayoutCol13 card-body">
									<div id="LayoutRow3" class="row c_LayoutRow3">
										<div id="LayoutCol2" class="col col-12 c_LayoutCol2">
											<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
											<telerik:RadTextBox id="txtServer" runat="server" AutoPostBack="False" CssClass="c_txtServer textbox-default"
												EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
												RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine" WrapperCssClass="c_txtServer_wrapper" />
										</div>
										<div id="LayoutCol3" class="col col-12 c_LayoutCol3">
											<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" Text="<%$ Resources: Label10 %>" />
											<telerik:RadTextBox id="txtDataBase" runat="server" AutoPostBack="False" CssClass="c_txtDataBase textbox-default"
												EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
												RenderMode="Lightweight" TabIndex="2" TextMode="SingleLine" WrapperCssClass="c_txtDataBase_wrapper" />
										</div>
										<div id="LayoutCol4" class="col col-12 c_LayoutCol4">
											<telerik:RadCheckBox id="chkAutent" runat="server" AutoPostBack="True" Checked="False"
												CssClass="chkAutent c_chkAutent checkbox-toggle-secondary" OnCheckedChanged="___chkAutent_OnCheckedChanged" RenderMode="Lightweight"
												TabIndex="3" Text="<%$ Resources: chkAutent %>" />
										</div>
										<div id="LayoutCol5" class="col col-12 c_LayoutCol5">
											<telerik:RadLabel id="Label11" runat="server" CssClass="c_Label11" Text="<%$ Resources: Label11 %>" />
											<telerik:RadTextBox id="txtUser" runat="server" AutoPostBack="False" CssClass="c_txtUser textbox-default"
												EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
												RenderMode="Lightweight" TabIndex="4" TextMode="SingleLine" WrapperCssClass="c_txtUser_wrapper" />
										</div>
										<div id="LayoutCol6" class="col col-12 c_LayoutCol6">
											<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
											<telerik:RadTextBox id="txtPassword" runat="server" AutoPostBack="False" CssClass="c_txtPassword textbox-default"
												EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
												RenderMode="Lightweight" TabIndex="5" TextMode="Password" WrapperCssClass="c_txtPassword_wrapper" />
										</div>
										<div id="LayoutCol7" class="col col-12 c_LayoutCol7">
											<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
											<telerik:RadComboBox id="cboDataType" runat="server" AllowCustomText="False" AutoPostBack="False"
												CssClass="c_cboDataType combobox-default" CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True"
												EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#333333"
												LoadingMessage="<%$ Resources: cboDataType %>" MarkFirstMatch="true" MaxHeight="100"
												OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress" RenderMode="Lightweight" TabIndex="6" />
										</div>
										<div id="LayoutCol8" class="col col-12 c_LayoutCol8">
											<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" Text="<%$ Resources: Label9 %>" />
											<telerik:RadTextBox id="txtProvider" runat="server" AutoPostBack="False" CssClass="c_txtProvider textbox-default"
												EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
												RenderMode="Lightweight" TabIndex="7" TextMode="SingleLine" WrapperCssClass="c_txtProvider_wrapper" />
										</div>
										<div id="LayoutCol10" class="col col-12 c_LayoutCol10">
											<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
										</div>
										<div id="LayoutCol9" class="col col-12 c_LayoutCol9">
											<telerik:RadButton id="butCreate" runat="server" ButtonType="SkinnedButton" CssClass="c_butCreate button-rounded-secondary"
												CommandName="butCreate" OnClick="___butCreate_OnClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: butCreate %>">
											</telerik:RadButton>
										</div>
									</div>
								</div>
							</div>
							<telerik:RadAjaxPanel id="AjaxPanel1" runat="server" CssClass="c_AjaxPanel1" LoadingPanelID="___AjaxPanel1_AjaxLoading" />
						</div>
					</div>
				</div>
		</form>
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
	<script type="text/javascript">
		currentPath = "<%= Page.Request.Path %>";
		function OnLoginSucceded()
		{
			if(getParentPage() != self && getParentPage() != null)
			{
				getParentPage().OnLoginSucceded();
			}
		}
		function TryLogin(PageToRedirect, RefreshControlsID)
		{
			TryParentLogin(PageToRedirect, RefreshControlsID, false, '<%= ResolveUrl("~/Login") %>');
		}
		var $j = jQuery.noConflict();
		$j(document).ready(SetFocusFirstField());
		function SetFocusFirstField()
		{
			try
			{
				{
					window.focus();
					setTimeout("var $j = jQuery.noConflict();$j('#txtServer').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function __cboDataType() { return $find("<%= cboDataType.ClientID %>").get_value(); }
		function ___txtServer_onkeydown(event,vgWin)
		{
		}
		function ___txtDataBase_onkeydown(event,vgWin)
		{
		}
		function ___txtUser_onkeydown(event,vgWin)
		{
		}
		function ___txtPassword_onkeydown(event,vgWin)
		{
		}
		function ___txtProvider_onkeydown(event,vgWin)
		{
		}
		try
		{
			if(getParentPage() != self)
			{
				getParentPage().EnableButtons();
			}
		}
		catch (e)
		{
		}
		document.getElementById('txtPassword').value = document.getElementById('txtPassword').getAttribute('DefaultPassword');
	</script>
</telerik:RadCodeBlock>
</html>

