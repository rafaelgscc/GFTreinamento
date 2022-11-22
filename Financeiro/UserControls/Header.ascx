<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="PROJETO.Header" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvinci_button.css") %>" type="text/css" media="screen" title="no title" charset="utf-8" />
	<telerik:RadCodeBlock ID="CustomHeaderCodeBlock" runat="server">
			<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/Bootstrap_ButtonStyle.css") %>" type="text/css" media="screen" title="no title" charset="utf-8" />
			<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/Bootstrap_Button_button_secondary.css")%>" type ="text/css" media="screen" title="no title" charset="utf-8" />
	</telerik:RadCodeBlock>
	<div id="Form1" runat="server" class="MainDiv c_Header_Form1 c_Header_Form1">
			<div id="LayoutContainer1" runat="server" class="container-fluid c_Header_LayoutContainer1 c_Header_LayoutContainer1">
				<div id="LayoutRow1" class="row c_Header_LayoutRow1 c_Header_LayoutRow1">
					<div id="LayoutCol1" class="col col-12 c_Header_LayoutCol1 c_Header_LayoutCol1">
						<telerik:RadButton id="Button15" runat="server" ButtonType="SkinnedButton" class="c_Header_Button15 button-secondary"
							CssClass="c_Header_Button15 button-secondary gvBtnSidebar" CommandName="Button15" OnClientClicking="___Button15_OnClientClick"
							RenderMode="Lightweight" TabIndex="1">
							<ContentTemplate>
								<span class="gvText"></span>
								<span class="fas fa-bars gvBtnSidebar c_Header_Button15_icon gvIcon"></span>
							</ContentTemplate>
						</telerik:RadButton>
					</div>
				</div>
			</div>
	</div>
<script type="text/javascript">
		function ___Button15_OnClientClick(sender, args)
		{
			LayoutController.toggle();
			args.set_cancel(true);
			return false;
		}
</script>
