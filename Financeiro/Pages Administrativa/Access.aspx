<%@ Page Language="C#" EnableEventValidation="True" ValidateRequest="false" AutoEventWireup="true" CodeFile="Access.aspx.cs" Inherits="PROJETO.Access" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="..\UserControls\SidebarPage.ascx" TagName="tagSidebar" TagPrefix="tgSid" %>
<%@ Register Src="..\UserControls\Header.ascx" TagName="GHeader" TagPrefix="GHeader" %>
<%@ Register Src="..\UserControls\Footer.ascx" TagName="uc" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadCheckBox_checkbox_toggle_secondary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_primary.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Access.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=1.0_20221122174321") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=1.0_20221122174321") %>" type="text/css" media="screen" title="no title"/>		
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=1.0_20221122174321") %>" type="text/css" media="screen" title="no title"/>  
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=1.0_20221122174321") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js??sv=1.0_20221122174321") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=1.0_20221122174321") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=1.0_20221122174321") %>"></script>


		<script type ="text/javascript" >

			function openAlert(string) 
			{
				this.parent.parent.GAlert(string);
			}
			function TreeViewChanged()
			{
				var obj = window.event.srcElement;
				var treeNodeFound = false;
				var checkedState;
				if (obj.tagName == "INPUT" && obj.type == "checkbox")
				{
					//AcessosBar.EnableButton('Salvar');
					//AcessosBar.EnableButton('Cancelar');
					var treeNode = obj;
					checkedState = treeNode.checked;
					if (checkedState == true && obj.id == "MenuPermTvn0CheckBox")
					{
						return;
					}
					do 
					{
						obj = obj.parentElement;
					}
					while (obj.tagName != "TABLE")
					var parentTreeLevel = obj.rows[0].cells.length;
					var parentTreeNode = obj.rows[0].cells[0];
					var tables = obj.parentElement.getElementsByTagName("TABLE");
					var numTables = tables.length
					if (numTables >= 1)
					{
						for (i = 0; i < numTables; i++) 
						{
							if (tables[i] == obj) 
							{
								treeNodeFound = true;
								i++;
								if (i == numTables) 
								{
									return;
								}
							}
							if (treeNodeFound == true)
							{
								var childTreeLevel = tables[i].rows[0].cells.length;
								if (childTreeLevel > parentTreeLevel) 
								{
									var cell = tables[i].rows[0].cells[childTreeLevel - 1];
									var inputs = cell.getElementsByTagName("INPUT");
									inputs[0].checked = checkedState;
								}
								else 
								{
									return;
								}
							}
						}
					}
				}
			}
			function ___RadTextBox21_onkeydown(event,vgWin)
			{
				onTextChanged(event);
			}
			function ___RadTextBox23_onkeydown(event,vgWin)
			{
				onTextChanged(event);
			}
			function ___RadTextBox22_onkeydown(event,vgWin)
			{
				onTextChanged(event);
			}
			function ___RadTextBox24_onkeydown(event,vgWin)
			{
			}
			function ___RadTextBox10_onkeydown(event,vgWin)
			{
			}
			function ___txtUserName_onkeydown(event,vgWin)
			{
			}
			function ___txtPassword_onkeydown(event,vgWin)
			{
			}
			function ___txtPasswordConfirm_onkeydown(event,vgWin)
			{
			}
			function ___txtObservation_onkeydown(event,vgWin)
			{
			}
		</script>

		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=1.0_20221122174321") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=1.0_20221122174321") %>"></script>
		
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
	<script type="text/javascript" src="<%= ResolveUrl("~/JS/Access_USER.js??sv=1.0_20221122174321") %>"></script>
	</telerik:RadCodeBlock>
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
				<div id="LayoutContainer1" runat="server" class="containerDefault container c_LayoutContainer1">
					<div id="LayoutRow5" class="row c_LayoutRow5">
						<div id="LayoutCol36" class="col col-12 c_LayoutCol36">
							<div id="LayoutRow1" class="row c_LayoutRow1 card flex-row">
								<div id="LayoutCol33" class="col col-12 c_LayoutCol33 card-header">
									<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
								</div>
								<div id="LayoutCol34" class="col col-12 c_LayoutCol34 card-body">
									<div class="container-fluid">
										<telerik:RadTabStrip id="TabControl1" runat="server" Align="Left" AutoPostBack="False" CssClass="c_TabControl1 row"
											MultiPageID="TabControl1MultiPage" PerTabScrolling="False" RenderMode="Lightweight" ScrollButtonsPosition="Middle" ScrollChildren="True">
											<Tabs>
												<telerik:RadTab id="TabItem1" runat="server" CssClass="c_TabItem1" Selected="true" Text="<%$ Resources: TabPage1 %>">
												</telerik:RadTab>
												<telerik:RadTab id="TabItem2" runat="server" CssClass="c_TabItem2" Text="<%$ Resources: TabPage2 %>">
												</telerik:RadTab>
												<telerik:RadTab id="TabItem3" runat="server" CssClass="c_TabItem3" Text="<%$ Resources: TabPage3 %>">
												</telerik:RadTab>
											</Tabs>
										</telerik:RadTabStrip>
										<telerik:RadMultiPage runat="server" ID="TabControl1MultiPage" BorderColor="#000000" BorderWidth="0" BorderStyle="Solid" SelectedIndex="0" CssClass="row">
											<telerik:RadPageView id="TabPage1" runat="server" BackColor="#FCFCFC" CssClass="c_TabPage1 col-12">
												<div style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" class="container-fluid">
													<div id="LayoutRow2" class="row c_LayoutRow2">
														<div id="LayoutCol56" class="col col-12 c_LayoutCol56">
															<div id="LayoutRow14" class="row c_LayoutRow14 card flex-row">
																<div id="LayoutCol58" class="col col-12 c_LayoutCol58 card-header">
																	<telerik:RadLabel id="Label80" runat="server" CssClass="c_Label80" Text="<%$ Resources: Label80 %>" />
																</div>
																<div id="LayoutCol59" class="col col-12 c_LayoutCol59 card-body">
																	<div id="LayoutRow15" class="row c_LayoutRow15">
																		<div id="LayoutCol4" class="col col-12 col-lg-4 c_LayoutCol4">
																			<telerik:RadLabel id="Label70" runat="server" CssClass="c_Label70" Text="<%$ Resources: Label70 %>" />
																			<telerik:RadTextBox id="RadTextBox21" runat="server" AutoPostBack="False" CssClass="c_RadTextBox21 textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="1" TextMode="Password" WrapperCssClass="c_RadTextBox21_wrapper" />
																		</div>
																		<div id="LayoutCol6" class="col col-12 col-lg-4 c_LayoutCol6">
																			<telerik:RadLabel id="Label72" runat="server" CssClass="c_Label72" Text="<%$ Resources: Label72 %>" />
																			<telerik:RadTextBox id="RadTextBox23" runat="server" AutoPostBack="False" CssClass="c_RadTextBox23 textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="3" TextMode="Password" WrapperCssClass="c_RadTextBox23_wrapper" />
																		</div>
																		<div id="LayoutCol5" class="col col-12 col-lg-4 c_LayoutCol5">
																			<telerik:RadLabel id="Label71" runat="server" CssClass="c_Label71" Text="<%$ Resources: Label71 %>" />
																			<telerik:RadTextBox id="RadTextBox22" runat="server" AutoPostBack="False" CssClass="c_RadTextBox22 textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="2" TextMode="Password" WrapperCssClass="c_RadTextBox22_wrapper" />
																		</div>
																		<div id="LayoutCol8" class="col col-12 col-sm-6 col-lg-4 col-xxl-2 offset-0 offset-sm-6 offset-lg-8 offset-xxl-10 c_LayoutCol8">
																			<telerik:RadButton id="butPWSave2" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butPWSave2 button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="butPWSave2"
																				OnClick="___butPWSave2_OnClick" RenderMode="Lightweight" TabIndex="4" Text="<%$ Resources: butPWSave2 %>">
																				<ContentTemplate>
																					<span class="gvText">Salvar</span>
																					<span class="fas fa-save c_butPWSave2_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																	</div>
																	<telerik:RadLabel id="Label69" runat="server" CssClass="c_Label69" />
																	<telerik:RadAjaxPanel id="AjaxPanel1" runat="server" CssClass="c_AjaxPanel1" LoadingPanelID="___AjaxPanel1_AjaxLoading" />
																</div>
															</div>
														</div>
													</div>
												</div>
											</telerik:RadPageView>
											<telerik:RadPageView id="TabPage2" runat="server" BackColor="#FCFCFC" CssClass="c_TabPage2 col-12">
												<div style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" class="container-fluid">
													<div id="LayoutRow3" class="row c_LayoutRow3">
														<div id="LayoutCol40" class="col col-12 col-lg-6 col-xxl-4 c_LayoutCol40">
															<div id="LayoutRow8" class="row c_LayoutRow8 card flex-row">
																<div id="LayoutCol41" class="col col-12 c_LayoutCol41 card-header">
																	<telerik:RadLabel id="Label74" runat="server" CssClass="c_Label74" Text="<%$ Resources: Label74 %>" />
																</div>
																<div id="LayoutCol42" class="col col-12 c_LayoutCol42 card-body">
																	<div id="LayoutRow9" class="row c_LayoutRow9">
																		<div id="LayoutCol50" class="col col-12 c_LayoutCol50">
																			<telerik:RadListBox id="ListBox13" runat="server" AutoPostBack="True" CssClass="c_ListBox13" ForeColor="#383838" Height="165"
																				OnSelectedIndexChanged="___ListBox13_OnSelectedIndexChanged" RenderMode="Lightweight" SelectionMode="Single" TabIndex="10"
																				Width="342" />
																		</div>
																		<div id="LayoutCol44" class="col col-12 col-sm-6 col-lg-8 col-xxl-7 offset-0 offset-sm-6 offset-lg-4 offset-xxl-5 c_LayoutCol44">
																			<telerik:RadButton id="Button26" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_Button26 button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="Button26"
																				OnClick="___Button26_OnClick" RenderMode="Lightweight" TabIndex="11" Text="<%$ Resources: Button26 %>">
																				<ContentTemplate>
																					<span class="gvText">Novo Grupo</span>
																					<span class="fas fa-user-friends c_Button26_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<div id="LayoutCol47" class="col col-12 col-lg-6 col-xxl-4 c_LayoutCol47">
															<div id="LayoutRow10" class="row c_LayoutRow10 card flex-row">
																<div id="LayoutCol48" class="col col-12 c_LayoutCol48 card-header">
																	<telerik:RadLabel id="Label75" runat="server" CssClass="c_Label75" Text="<%$ Resources: Label75 %>" />
																</div>
																<div id="LayoutCol49" class="col col-12 c_LayoutCol49 card-body">
																	<div id="LayoutRow11" class="row c_LayoutRow11">
																		<div id="LayoutCol55" class="col col-12 c_LayoutCol55">
																			<telerik:RadListBox id="ListBox14" runat="server" AutoPostBack="True" CssClass="c_ListBox14" ForeColor="#383838" Height="110"
																				OnSelectedIndexChanged="___ListBox14_OnSelectedIndexChanged" RenderMode="Lightweight" SelectionMode="Single" TabIndex="12"
																				Width="342" />
																		</div>
																		<div id="LayoutCol25" class="col col-12 col-sm-6 c_LayoutCol25">
																			<telerik:RadCheckBox id="CheckBox8" runat="server" AutoPostBack="True" Checked="False"
																				CssClass="CheckBox8 c_CheckBox8 checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="14"
																				Text="<%$ Resources: CheckBox8 %>" />
																		</div>
																		<div id="LayoutCol22" class="col col-12 col-sm-6 c_LayoutCol22">
																			<telerik:RadCheckBox id="CheckBox7" runat="server" AutoPostBack="True" Checked="False"
																				CssClass="CheckBox7 c_CheckBox7 checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="13"
																				Text="<%$ Resources: CheckBox7 %>" />
																		</div>
																		<div id="LayoutCol23" class="col col-12 col-sm-6 c_LayoutCol23">
																			<telerik:RadCheckBox id="CheckBox10" runat="server" AutoPostBack="True" Checked="False"
																				CssClass="CheckBox10 c_CheckBox10 checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="16"
																				Text="<%$ Resources: CheckBox10 %>" />
																		</div>
																		<div id="LayoutCol24" class="col col-12 col-sm-6 c_LayoutCol24">
																			<telerik:RadCheckBox id="CheckBox9" runat="server" AutoPostBack="True" Checked="False"
																				CssClass="CheckBox9 c_CheckBox9 checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="15"
																				Text="<%$ Resources: CheckBox9 %>" />
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<div id="LayoutCol37" class="col col-12 col-xxl-4 c_LayoutCol37">
															<div id="LayoutRow6" class="row c_LayoutRow6 card flex-row">
																<div id="LayoutCol38" class="col col-12 c_LayoutCol38 card-header">
																	<telerik:RadLabel id="Label79" runat="server" CssClass="c_Label79" Text="<%$ Resources: Label79 %>" />
																</div>
																<div id="LayoutCol39" class="col col-12 c_LayoutCol39 card-body">
																	<div id="LayoutRow7" class="row c_LayoutRow7">
																		<div id="LayoutCol9" class="col col-12 c_LayoutCol9">
																			<telerik:RadLabel id="Label73" runat="server" CssClass="c_Label73" Text="<%$ Resources: Label73 %>" />
																			<telerik:RadTextBox id="RadTextBox24" runat="server" AutoPostBack="False" CssClass="c_RadTextBox24 textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="5" TextMode="SingleLine" WrapperCssClass="c_RadTextBox24_wrapper" />
																		</div>
																		<div id="LayoutCol10" class="col col-12 c_LayoutCol10">
																			<telerik:RadCheckBox id="RadCheckBox6" runat="server" AutoPostBack="True" Checked="False"
																				CssClass="RadCheckBox6 c_RadCheckBox6 checkbox-toggle-secondary" RenderMode="Lightweight" TabIndex="6"
																				Text="<%$ Resources: RadCheckBox6 %>" />
																		</div>
																		<div id="LayoutCol11" class="col col-12 col-sm-4 col-lg-3 col-xxl-4 offset-0 offset-sm-0 offset-lg-3 offset-xxl-0 c_LayoutCol11">
																			<telerik:RadButton id="butGroupSave3" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butGroupSave3 button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="butGroupSave3"
																				OnClick="___butGroupSave3_OnClick" RenderMode="Lightweight" TabIndex="7" Text="<%$ Resources: butGroupSave3 %>">
																				<ContentTemplate>
																					<span class="gvText">Salvar</span>
																					<span class="fas fa-save c_butGroupSave3_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																		<div id="LayoutCol13" class="col col-12 col-sm-4 col-lg-3 col-xxl-4 c_LayoutCol13">
																			<telerik:RadButton id="butGroupRemove3" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butGroupRemove3 button-rounded-primary gvButtonIconText gvButtonAlignIconLeft" CommandName="butGroupRemove3"
																				OnClick="___butGroupRemove3_OnClick" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: butGroupRemove3 %>">
																				<ContentTemplate>
																					<span class="gvText">Remover</span>
																					<span class="fas fa-minus-circle c_butGroupRemove3_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																		<div id="LayoutCol12" class="col col-12 col-sm-4 col-lg-3 col-xxl-4 c_LayoutCol12">
																			<telerik:RadButton id="butGroupCancel3" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butGroupCancel3 button-rounded-primary gvButtonIconText gvButtonAlignIconLeft" CommandName="butGroupCancel3"
																				OnClick="___butGroupCancel3_OnClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: butGroupCancel3 %>">
																				<ContentTemplate>
																					<span class="gvText">Cancelar</span>
																					<span class="fas fa-ban c_butGroupCancel3_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</telerik:RadPageView>
											<telerik:RadPageView id="TabPage3" runat="server" BackColor="#FCFCFC" CssClass="c_TabPage3 col-12">
												<div style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" class="container-fluid">
													<div id="LayoutRow4" class="row c_LayoutRow4">
														<div id="LayoutCol17" class="col col-12 col-lg-6 c_LayoutCol17">
															<div id="LayoutRow16" class="row c_LayoutRow16 card flex-row">
																<div id="LayoutCol60" class="col col-12 c_LayoutCol60 card-header">
																	<telerik:RadLabel id="Label81" runat="server" CssClass="c_Label81" Text="<%$ Resources: Label81 %>" />
																</div>
																<div id="LayoutCol61" class="col col-12 c_LayoutCol61 card-body">
																	<telerik:RadLabel id="Label76" runat="server" CssClass="c_Label76" Text="<%$ Resources: Label76 %>" />
																	<telerik:RadListBox id="ListBox15" runat="server" AutoPostBack="True" CssClass="c_ListBox15" ForeColor="#383838" Height="110"
																		OnSelectedIndexChanged="___ListBox15_OnSelectedIndexChanged" RenderMode="Lightweight" SelectionMode="Single" TabIndex="17"
																		Width="364" />
																	<telerik:RadLabel id="Label77" runat="server" CssClass="c_Label77" Text="<%$ Resources: Label77 %>" />
																	<telerik:RadListBox id="ListBox16" runat="server" AutoPostBack="True" CssClass="c_ListBox16" ForeColor="#383838" Height="110"
																		OnSelectedIndexChanged="___ListBox16_OnSelectedIndexChanged" RenderMode="Lightweight" SelectionMode="Single" TabIndex="18"
																		Width="364" />
																	<div id="LayoutRow17" class="row c_LayoutRow17">
																		<div id="LayoutCol19" class="col col-12 col-sm-6 col-xxl-4 offset-0 offset-sm-0 offset-lg-0 offset-xxl-4 c_LayoutCol19">
																			<telerik:RadButton id="butUserNew" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butUserNew button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="butUserNew"
																				OnClick="___butUserNew_OnClick" RenderMode="Lightweight" TabIndex="19" Text="<%$ Resources: butUserNew %>">
																				<ContentTemplate>
																					<span class="gvText">Novo Usuário</span>
																					<span class="fas fa-user c_butUserNew_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																		<div id="LayoutCol20" class="col col-12 col-sm-6 col-xxl-4 c_LayoutCol20">
																			<telerik:RadButton id="butUserRemove" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butUserRemove button-rounded-primary gvButtonIconText gvButtonAlignIconLeft" CommandName="butUserRemove"
																				OnClick="___butUserRemove_OnClick" RenderMode="Lightweight" TabIndex="20" Text="<%$ Resources: butUserRemove %>">
																				<ContentTemplate>
																					<span class="gvText">Remover</span>
																					<span class="fas fa-trash-alt c_butUserRemove_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<div id="LayoutCol21" class="col col-12 col-lg-6 c_LayoutCol21">
															<div id="LayoutRow18" class="row c_LayoutRow18 card flex-row">
																<div id="LayoutCol62" class="col col-12 c_LayoutCol62 card-header">
																	<telerik:RadLabel id="Label82" runat="server" CssClass="c_Label82" Text="<%$ Resources: Label82 %>" />
																</div>
																<div id="LayoutCol63" class="col col-12 c_LayoutCol63 card-body">
																	<div id="LayoutRow19" class="row c_LayoutRow19">
																		<div id="LayoutCol27" class="col col-12 col-xxl-6 c_LayoutCol27">
																			<telerik:RadLabel id="Label56" runat="server" CssClass="c_Label56" Text="<%$ Resources: Label56 %>" />
																			<telerik:RadTextBox id="RadTextBox10" runat="server" AutoPostBack="False" CssClass="c_RadTextBox10 textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="21" TextMode="SingleLine" WrapperCssClass="c_RadTextBox10_wrapper" />
																		</div>
																		<div id="LayoutCol32" class="col col-12 col-xxl-6 c_LayoutCol32">
																			<telerik:RadLabel id="Label78" runat="server" CssClass="c_Label78" Text="<%$ Resources: Label78 %>" />
																			<telerik:RadTextBox id="txtUserName" runat="server" AutoPostBack="False" CssClass="c_txtUserName textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="22" TextMode="SingleLine" WrapperCssClass="c_txtUserName_wrapper" />
																		</div>
																		<div id="LayoutCol31" class="col col-12 col-xxl-6 c_LayoutCol31">
																			<telerik:RadLabel id="Label57" runat="server" CssClass="c_Label57" Text="<%$ Resources: Label57 %>" />
																			<telerik:RadTextBox id="txtPassword" runat="server" AutoPostBack="False" CssClass="c_txtPassword textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="23" TextMode="Password" WrapperCssClass="c_txtPassword_wrapper" />
																		</div>
																		<div id="LayoutCol30" class="col col-12 col-xxl-6 c_LayoutCol30">
																			<telerik:RadLabel id="Label59" runat="server" CssClass="c_Label59" Text="<%$ Resources: Label59 %>" />
																			<telerik:RadTextBox id="txtPasswordConfirm" runat="server" AutoPostBack="False" CssClass="c_txtPasswordConfirm textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="24" TextMode="Password" WrapperCssClass="c_txtPasswordConfirm_wrapper" />
																		</div>
																		<div id="LayoutCol29" class="col col-12 c_LayoutCol29">
																			<telerik:RadLabel id="Label60" runat="server" CssClass="c_Label60" Text="<%$ Resources: Label60 %>" />
																			<telerik:RadTextBox id="txtObservation" runat="server" AutoPostBack="False" CssClass="c_txtObservation textbox-default"
																				EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0" ReadOnly="False"
																				RenderMode="Lightweight" TabIndex="25" TextMode="MultiLine" WrapperCssClass="c_txtObservation_wrapper" />
																		</div>
																		<div id="LayoutCol28" class="col col-12 col-sm-6 col-xxl-3 offset-0 offset-sm-0 offset-lg-0 offset-xxl-6 c_LayoutCol28">
																			<telerik:RadButton id="butUserSave" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butUserSave button-rounded-secondary gvButtonIconText gvButtonAlignIconLeft" CommandName="butUserSave"
																				OnClick="___butUserSave_OnClick" RenderMode="Lightweight" TabIndex="26" Text="<%$ Resources: butUserSave %>">
																				<ContentTemplate>
																					<span class="gvText">Salvar</span>
																					<span class="fas fa-save c_butUserSave_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																		<div id="LayoutCol26" class="col col-12 col-sm-6 col-xxl-3 c_LayoutCol26">
																			<telerik:RadButton id="butUserCancel" runat="server" ButtonType="SkinnedButton"
																				CssClass="c_butUserCancel button-rounded-primary gvButtonIconText gvButtonAlignIconLeft" CommandName="butUserCancel"
																				OnClick="___butUserCancel_OnClick" RenderMode="Lightweight" TabIndex="27" Text="<%$ Resources: butUserCancel %>">
																				<ContentTemplate>
																					<span class="gvText">Cancelar</span>
																					<span class="fas fa-ban c_butUserCancel_icon gvIcon"></span>
																				</ContentTemplate>
																			</telerik:RadButton>
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</telerik:RadPageView>
										</telerik:RadMultiPage>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			<GHeader:GHeader runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutHeader" Position="Fixed" Transition="300ms"/>
			<uc:uc runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutFooter" Position="Fixed" Transition="300ms"/>
			<tgSid:tagSidebar runat="server" AutoOpen="True" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutSidebar" Mode="Full" Position="Left" Transition="300ms"/>
		</form>
</body>
<script>
	var $j = jQuery.noConflict();
	$j(document).ready(SetFocusFirstField());
	function SetFocusFirstField()
	{
		try
		{
			{
				window.focus();
				setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox21').first().focus();", 200);
			}
		}
		catch (e)
		{
		}
	}
</script>
<script type ="text/javascript">
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
	function TxtLoginName() { return document.getElementById('RadTextBox10').value; }
	function __txtUserName() { return document.getElementById('txtUserName').value; }
</script>
</html>
