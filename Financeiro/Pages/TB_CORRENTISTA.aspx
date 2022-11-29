<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="TB_CORRENTISTA.aspx.cs" Inherits="PROJETO.DataPages.TB_CORRENTISTA" Culture="auto" UICulture="auto"%>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadCheckBox_checkbox_toggle_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_primary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/TB_CORRENTISTA.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/sweetAlert.css") %>" type="text/css" media="screen" title="no title"/>
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
<script type="text/javascript">
	function sweetAlert_SweetAlertIncluir(customMessage, customTitle, customPosition, sender)
	{
	   Swal.fire({
	       icon:  'success' ,
	       title: customTitle === undefined ? 'Salvo com sucesso!' : customTitle,
	       text: customMessage === undefined ? '' : customMessage,
	       showCloseButton:  true,
	       showCancelButton: true,
	       showConfirmButton:true,
	       confirmButtonText:'Novo' ,
	       cancelButtonText: 'Voltar a Lista' ,
	       reverseButtons:true,
	       timer:0,
	       timerProgressBar:true,
	       focusConfirm:true,
	       focusCancel:false,
	       position: customPosition === undefined ? 'center' : customPosition,
	       allowEscapeKey:true,
	       allowEnterKey:true,
	       allowOutsideClick:true,
	   }).then(function(result) {
		   if (result.value) { 
	         ___SweetAlertIncluir_OnConfirmClick(sender)
		   }
		   else if (result.dismiss === Swal.DismissReason.cancel) { 
	         ___SweetAlertIncluir_OnCancelClick(sender)
		   }
	   });
	}
	function sweetAlert_SweetAlertEditar(customMessage, customTitle, customPosition, sender)
	{
	   Swal.fire({
	       icon:  'success' ,
	       title: customTitle === undefined ? 'Salvo com sucesso!' : customTitle,
	       text: customMessage === undefined ? '' : customMessage,
	       showCloseButton:  true,
	       showCancelButton: false,
	       showConfirmButton:true,
	       confirmButtonText:'Ok' ,
	       cancelButtonText: 'Voltar a Lista' ,
	       reverseButtons:true,
	       timer:0,
	       timerProgressBar:true,
	       focusConfirm:true,
	       focusCancel:false,
	       position: customPosition === undefined ? 'center' : customPosition,
	       allowEscapeKey:true,
	       allowEnterKey:true,
	       allowOutsideClick:true,
	   }).then(function(result) {
		   if (result.value) { 
	         ___SweetAlertEditar_OnConfirmClick(sender)
		   }
	   });
	}
</script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/TB_CORRENTISTA_USER.js??sv=1.0_20221129105949") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/sweetAlert.js") %>"></script>
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
			var UrlPage = '<%= ResolveUrl("~/lista-correntista") %>';
			NavigateBrowser(UrlPage);
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox_COR_NOME_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_CPF_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_CNPJ_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_ENDERECO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_BAIRRO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_CIDADE_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_COR_EMAIL_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___Button19_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/lista-correntista") %>';
			NavigateBrowser(UrlPage);
			args.set_cancel(true);
			return false;
		}
		function ___Button18_OnClientClick(sender, args)
		{
			Save(this);
			args.set_cancel(true);
			return false;
		}
		function ___SweetAlertIncluir_OnConfirmClick(sender)
		{
			var UrlPage = '<%= ResolveUrl("~/correntista") %>';
			UrlPage += "/incluir";
			NavigateBrowser(UrlPage);
		}
		function ___SweetAlertIncluir_OnCancelClick(sender)
		{
			var UrlPage = '<%= ResolveUrl("~/lista-correntista") %>';
			NavigateBrowser(UrlPage);
		}
		function ___SweetAlertEditar_OnConfirmClick(sender)
		{
			var UrlPage = '<%= ResolveUrl("~/lista-correntista") %>';
			NavigateBrowser(UrlPage);
		}
		function RadTextBox_COR_NOME_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="containerDefault container-fluid c_LayoutContainer1">
						<div id="LayoutRow6" class="row c_LayoutRow6">
							<div id="LayoutCol22" class="col col-12 c_LayoutCol22">
								<div id="LayoutRow9" class="row c_LayoutRow9 card flex-row">
									<div id="LayoutCol23" class="col col-12 c_LayoutCol23 card-header">
										<div id="LayoutRow8" class="row c_LayoutRow8">
											<div id="LayoutCol25" class="col col-12 c_LayoutCol25">
												<telerik:RadButton id="Button22" runat="server" ButtonType="SkinnedButton" CssClass="c_Button22 button-clean-primary"
													CommandName="Button22" OnClientClicking="___Button22_OnClientClick" RenderMode="Lightweight" TabIndex="10">
													<ContentTemplate>
														<span class="gvText"></span>
														<span class="fas fa-angle-left c_Button22_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
												<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Detalhes de Correntista" />
											</div>
										</div>
									</div>
									<div id="LayoutCol21" class="col col-12 c_LayoutCol21 card-body">
										<div id="LayoutRow7" class="row c_LayoutRow7">
											<div id="LayoutCol29" class="col col-12 col-md-6 c_LayoutCol29">
												<telerik:RadLabel id="Label_COR_NOME" runat="server" CssClass="c_Label_COR_NOME" Text="<%$ Resources: Label_COR_NOME %>" />
												<telerik:RadTextBox id="RadTextBox_COR_NOME" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_NOME textbox-default"
													data-validation-engine="validate[funcCall[RadTextBox_COR_NOME_Validation]]"
													data-validation-message="Nome do Correntista não pode ser vazio!" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
													ForeColor="#333333" MaxLength="100" onkeydown="___RadTextBox_COR_NOME_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
													TabIndex="9" TextMode="SingleLine" WrapperCssClass="c_RadTextBox_COR_NOME_wrapper" />
											</div>
											<div id="LayoutCol31" class="col col-12 col-md-6 c_LayoutCol31">
												<telerik:RadCheckBox id="RadCheckBox_COR_FISICA" runat="server" AutoPostBack="True" Checked="False"
													CssClass="RadCheckBox_COR_FISICA c_RadCheckBox_COR_FISICA checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="2"
													Text="<%$ Resources: RadCheckBox_COR_FISICA %>" />
												<telerik:RadCheckBox id="RadCheckBox_COR_JURIDICA" runat="server" AutoPostBack="True" Checked="False"
													CssClass="RadCheckBox_COR_JURIDICA c_RadCheckBox_COR_JURIDICA checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="4"
													Text="<%$ Resources: RadCheckBox_COR_JURIDICA %>" />
											</div>
											<div id="LayoutCol30" runat="server" class="col col-12 col-md-6 c_LayoutCol30">
												<telerik:RadLabel id="Label_COR_CPF" runat="server" CssClass="c_Label_COR_CPF" Text="<%$ Resources: Label_COR_CPF %>" />
												<telerik:RadTextBox id="RadTextBox_COR_CPF" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_CPF textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="14"
													onkeydown="___RadTextBox_COR_CPF_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_CPF_wrapper" />
											</div>
											<div id="LayoutCol32" runat="server" class="col col-12 col-md-6 c_LayoutCol32">
												<telerik:RadLabel id="Label_COR_CNPJ" runat="server" CssClass="c_Label_COR_CNPJ" Text="<%$ Resources: Label_COR_CNPJ %>" />
												<telerik:RadTextBox id="RadTextBox_COR_CNPJ" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_CNPJ textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="18"
													onkeydown="___RadTextBox_COR_CNPJ_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_CNPJ_wrapper" />
											</div>
											<div id="LayoutCol34" class="col col-12 col-md-6 c_LayoutCol34">
												<telerik:RadLabel id="Label_COR_ENDERECO" runat="server" CssClass="c_Label_COR_ENDERECO" Text="<%$ Resources: Label_COR_ENDERECO %>" />
												<telerik:RadTextBox id="RadTextBox_COR_ENDERECO" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_ENDERECO textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="100"
													onkeydown="___RadTextBox_COR_ENDERECO_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="5" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_ENDERECO_wrapper" />
											</div>
											<div id="LayoutCol35" class="col col-12 col-md-6 c_LayoutCol35">
												<telerik:RadLabel id="Label_COR_BAIRRO" runat="server" CssClass="c_Label_COR_BAIRRO" Text="<%$ Resources: Label_COR_BAIRRO %>" />
												<telerik:RadTextBox id="RadTextBox_COR_BAIRRO" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_BAIRRO textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="100"
													onkeydown="___RadTextBox_COR_BAIRRO_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_BAIRRO_wrapper" />
											</div>
											<div id="LayoutCol36" class="col col-12 col-md-6 c_LayoutCol36">
												<telerik:RadLabel id="Label_COR_CIDADE" runat="server" CssClass="c_Label_COR_CIDADE" Text="<%$ Resources: Label_COR_CIDADE %>" />
												<telerik:RadTextBox id="RadTextBox_COR_CIDADE" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_CIDADE textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="100"
													onkeydown="___RadTextBox_COR_CIDADE_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="7" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_CIDADE_wrapper" />
											</div>
											<div id="LayoutCol37" class="col col-12 col-md-6 c_LayoutCol37">
												<telerik:RadLabel id="Label_COR_EMAIL" runat="server" CssClass="c_Label_COR_EMAIL" Text="<%$ Resources: Label_COR_EMAIL %>" />
												<telerik:RadTextBox id="RadTextBox_COR_EMAIL" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_COR_EMAIL textbox-default"
													EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="100"
													onkeydown="___RadTextBox_COR_EMAIL_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="8" TextMode="SingleLine"
													WrapperCssClass="c_RadTextBox_COR_EMAIL_wrapper" />
											</div>
											<div id="LayoutCol28" class="col col-12 c_LayoutCol28">
												<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
											</div>
											<div id="LayoutCol18" class="col col-12 c_LayoutCol18">
												<telerik:RadButton id="Button19" runat="server" ButtonType="SkinnedButton"
													CssClass="c_Button19 button-rounded-primary gvButtonIconText gvButtonAlignIconLeft" CommandName="Button19"
													OnClientClicking="___Button19_OnClientClick" RenderMode="Lightweight" TabIndex="11" Text="<%$ Resources: Button19 %>">
													<ContentTemplate>
														<span class="gvText">Cancelar</span>
														<span class="fas fa-times c_Button19_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
												<telerik:RadButton id="Button18" runat="server" ButtonType="SkinnedButton"
													CssClass="c_Button18 button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="Button18"
													OnClientClicking="___Button18_OnClientClick" RenderMode="Lightweight" TabIndex="12" Text="<%$ Resources: Button18 %>">
													<ContentTemplate>
														<span class="gvText">Salvar</span>
														<span class="fas fa-save c_Button18_icon gvIcon"></span>
													</ContentTemplate>
												</telerik:RadButton>
											</div>
										</div>
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox_COR_CPF').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function COR_NOME() { return document.getElementById('RadTextBox_COR_NOME').value; }
		function COR_FISICA() { return COR_FISICA.checked; }
		function COR_JURIDICA() { return COR_JURIDICA.checked; }
		function COR_CPF() { return document.getElementById('RadTextBox_COR_CPF').value; }
		function COR_CNPJ() { return document.getElementById('RadTextBox_COR_CNPJ').value; }
		function COR_ENDERECO() { return document.getElementById('RadTextBox_COR_ENDERECO').value; }
		function COR_BAIRRO() { return document.getElementById('RadTextBox_COR_BAIRRO').value; }
		function COR_CIDADE() { return document.getElementById('RadTextBox_COR_CIDADE').value; }
		function COR_EMAIL() { return document.getElementById('RadTextBox_COR_EMAIL').value; }
		function EnableButtons()
		{
				try
				{
					var __PAGESTATE = "";
					var __PAGENUMBER = 0;
					var __PAGECOUNT = 0;
					var __ISPARAMETER = "";
					var __PERMISSION = "";
					var __ALLOWINSERT = "true";
					var __ALLOWUPDATE = "true";
					var __ALLOWREMOVE = "true";
					try { __ISPARAMETER = document.getElementById("__TABLEPARAMETER").value.toLowerCase(); } catch (e) { }
					try { __PERMISSION = document.getElementById("__PERMISSION").value; } catch (e) { }
					try { __ALLOWINSERT = __PERMISSION.toString().substr(__PERMISSION.indexOf("Insert:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Insert:")) - __PERMISSION.indexOf("Insert:") - 7).toLowerCase(); } catch (e) { }
					try { __ALLOWUPDATE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Edit:") + 5, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Edit:")) - __PERMISSION.indexOf("Edit:") - 5).toLowerCase(); } catch (e) { }
					try { __ALLOWREMOVE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Remove:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Remove:")) - __PERMISSION.indexOf("Remove:") - 7).toLowerCase(); } catch (e) { }
					try { __PAGESTATE = document.getElementById("__PAGESTATE").value.toLowerCase(); } catch (e) { }
					try { __PAGENUMBER = parseInt(document.getElementById("__PAGENUMBER").value); } catch (e) { }
					try { __PAGECOUNT = parseInt(document.getElementById("__PAGECOUNT").value); } catch (e) { }
						$find("Button18").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"))));
					try
					{
						if (getParentPage() != null && getParentPage() != self)
						{
							getParentPage().EnableButtons();
						}
					}
					catch (ex)
					{
					}
				}
				catch (ex)
				{
				}
		}

		function LoadEditAuto() {
				$j("#RadTextBox_COR_NOME").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_CPF").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_CNPJ").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_ENDERECO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_BAIRRO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_CIDADE").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_COR_EMAIL").bind("keydown", InitiateEditAuto);
				$j("#RadCheckBox_COR_FISICA").bind("change", InitiateEditAuto);
				$j("#RadCheckBox_COR_JURIDICA").bind("change", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

