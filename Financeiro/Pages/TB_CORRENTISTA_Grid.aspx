<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="TB_CORRENTISTA_Grid.aspx.cs" Inherits="PROJETO.DataPages.TB_CORRENTISTA_Grid" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="..\UserControls\SidebarPage.ascx" TagName="tagSidebar" TagPrefix="tgSid" %>
<%@ Register Src="..\UserControls\Header.ascx" TagName="GHeader" TagPrefix="GHeader" %>
<%@ Register Src="..\UserControls\Footer.ascx" TagName="uc" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_primary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Grid_grid_default.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/TB_CORRENTISTA_Grid.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=1.0_20221129105949") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=1.0_20221129105949") %>" type="text/css" media="screen" title="no title"/>  	
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=1.0_20221129105949") %>" type="text/css" media="screen" title="no title"/>
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=1.0_20221129105949") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=1.0_20221129105949") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=1.0_20221129105949") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Page.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/TB_CORRENTISTA_Grid_USER.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=1.0_20221129105949") %>" ></script>

		<script type="text/javascript">
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
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
	<script type="text/javascript">	   
		function RegisterClientValidateScript()
		{
			var $j = jQuery.noConflict();
			$j(document).ready(function() 
			{
				$j("#Form1").validationEngine()
			});
		}
		RegisterClientValidateScript();
		
	</script>
    <script type="text/javascript">
		var HasValidation = true;
	</script>
	<script type="text/javascript">
		function ___Form1_OnResponseEnd(sender, args)
		{
			OnResponseEnd(sender,args);
		}
		function ___Form1_OnRequestStart(sender, args)
		{
			OnRequestStart(sender,args);
		}
		function ___Button22_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/home") %>';
			NavigateBrowser(UrlPage);
			args.set_cancel(true);
			return false;
		}
		function ___Button18_OnClientClick(sender, args)
		{
			Refresh(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button19_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/correntista") %>';
			UrlPage += "/incluir";
			NavigateBrowser(UrlPage);
			args.set_cancel(true);
			return false;
		}
		function GridColumn_COR_NOME_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="containerDefault container-fluid c_LayoutContainer1">
						<div id="LayoutRow7" class="row c_LayoutRow7">
							<div id="LayoutCol11" class="col col-12 c_LayoutCol11">
								<div id="LayoutRow3" class="row c_LayoutRow3 card flex-row">
									<div id="LayoutCol9" class="col col-12 c_LayoutCol9 card-header">
										<div id="LayoutRow6" class="row c_LayoutRow6">
											<div id="LayoutCol19" class="col col-9 c_LayoutCol19">
												<telerik:RadButton id="Button22" runat="server" ButtonType="SkinnedButton" CssClass="c_Button22 button-clean-primary"
													CommandName="Button22" OnClientClicking="___Button22_OnClientClick" RenderMode="Lightweight" TabIndex="1">
													<ContentTemplate>
														<span class="gvText"></span>
														<span class="fas fa-angle-left c_Button22_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
												<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Lista de Correntista" />
											</div>
											<div id="LayoutCol21" class="col col-3 c_LayoutCol21">
												<telerik:RadButton id="Button18" runat="server" ButtonType="SkinnedButton" CssClass="c_Button18 button-rounded-primary"
													CommandName="Button18" OnClientClicking="___Button18_OnClientClick" RenderMode="Lightweight" TabIndex="2">
													<ContentTemplate>
														<span class="gvText"></span>
														<span class="fas fa-sync-alt c_Button18_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
												<telerik:RadButton id="Button19" runat="server" ButtonType="SkinnedButton"
													CssClass="c_Button19 button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="Button19"
													OnClientClicking="___Button19_OnClientClick" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: Button19 %>">
													<ContentTemplate>
														<span class="gvText">Novo</span>
														<span class="fas fa-plus-circle c_Button19_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
											</div>
										</div>
									</div>
									<div id="LayoutCol10" class="col col-12 c_LayoutCol10 card-body">
										<telerik:RadGrid id="Grid_TB_CORRENTISTA" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True"
											AllowSorting="True" AutoGenerateColumns="false" CssClass="c_Grid_TB_CORRENTISTA grid-default" CleanLayoutNoRecord="True"
											ClientSettings-ClientEvents-OnCommand="CheckValidation" EnableEmbeddedSkins="True" EnableHeaderContextMenu="False"
											EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
											OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid_TB_CORRENTISTA_ItemCommand" OnItemCreated="Grid_TB_CORRENTISTA_ItemCreated"
											OnItemDataBound="Grid_TB_CORRENTISTA_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource" OnPreRender="Grid_TB_CORRENTISTA_PreRender"
											OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Lightweight" ShowFooter="False" ShowGroupPanel="False" TabIndex="4"
											TableLayout="Fixed">
											<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="COR_ID" EditMode="InPlace" OnPreRender="Grid_TB_CORRENTISTA_PreRender">
												<Columns>
													<telerik:GridBoundColumn UniqueName="GridColumn_COR_NOME" runat="server" AllowFiltering="True" AllowSorting="true"
														AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="COR_NOME" EnableHeaderContextMenu="True" Exportable="True"
														FilterControlWidth="100%" FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn_COR_NOME"
														HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn_COR_NOME %>" ItemStyle-CssClass="c_GridColumn_COR_NOME"
														ItemStyle-Width="86" MaxLength="100" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
													<telerik:GridBoundColumn UniqueName="GridColumn_COR_CIDADE" runat="server" AllowFiltering="True" AllowSorting="true"
														AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="COR_CIDADE" EnableHeaderContextMenu="True" Exportable="True"
														FilterControlWidth="100%" FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn_COR_CIDADE"
														HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn_COR_CIDADE %>" ItemStyle-CssClass="c_GridColumn_COR_CIDADE"
														ItemStyle-Width="86" MaxLength="100" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
													<telerik:GridBoundColumn UniqueName="GridColumn_COR_EMAIL" runat="server" AllowFiltering="True" AllowSorting="true"
														AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="COR_EMAIL" EnableHeaderContextMenu="True" Exportable="True"
														FilterControlWidth="100%" FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn_COR_EMAIL"
														HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn_COR_EMAIL %>" ItemStyle-CssClass="c_GridColumn_COR_EMAIL"
														ItemStyle-Width="86" MaxLength="100" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
													<telerik:GridButtonColumn UniqueName="GridColumn2" runat="server" AutoPostBackOnFilter="False" ButtonType="LinkButton"
														CommandName="GridColumn2" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
														HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="93" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="86"
														ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn2 %>" />
													<telerik:GridButtonColumn Exportable="false" HeaderStyle-Width="25" ConfirmText="Deseja excluir o registro?" ConfirmDialogType="RadWindow" ConfirmTitle="Deletar" ButtonType="ImageButton" CommandName="Delete" UniqueName="Grid_TB_CORRENTISTA_DeleteColumn"/>
												</Columns>
												<CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
											</MasterTableView>
											<PagerStyle Mode="NextPrevAndNumeric" />
											<ClientSettings EnableRowHoverStyle="true">
												<ClientEvents />
											</ClientSettings>
										</telerik:RadGrid>
									</div>
								</div>
							</div>
						</div>
					</div>
			<GHeader:GHeader runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutHeader" Position="Fixed" Transition="300ms"/>
			<uc:uc runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutFooter" Position="Fixed" Transition="300ms"/>
			<tgSid:tagSidebar runat="server" AutoOpen="True" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutSidebar" Mode="Full" Position="Left" Transition="300ms"/>
			<telerik:RadAjaxLoadingPanel ID="___Form1_AjaxLoading" OnClientShowing="LayoutController.fixAjaxLoadingWidth" runat="server">
			</telerik:RadAjaxLoadingPanel>
			</telerik:RadAjaxPanel>
		</form>
		
	</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
	<script type="text/javascript">
		var $j = jQuery.noConflict();
		$j(document).ready(SetFocusFirstField());
		function SetFocusFirstField()
		{
			try
			{
				{
					window.focus();
					setTimeout("var $j = jQuery.noConflict();$j('#Button22').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

