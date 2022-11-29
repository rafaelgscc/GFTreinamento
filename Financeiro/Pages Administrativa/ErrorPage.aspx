<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" ValidateRequest="false" CodeFile="ErrorPage.aspx.cs" Inherits="PROJETO.ErrorPage" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>


	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
<style>
.lamp {
    position: absolute;
    left: 0px;
    right: 0px;
    top: 0px;
    margin: 0px auto;
    width: 300px;
    display: flex;
    flex-direction: column;
    align-items: center;
    transform-origin: center top;
    animation-timing-function: cubic-bezier(0.6, 0, 0.38, 1);
    animation: move 5.1s infinite;
  }
  
  @keyframes move {
    0% {
      transform: rotate(40deg);
    }
    50% {
      transform: rotate(-40deg);
    }
    100% {
      transform: rotate(40deg);
    }
  }
  
  .cable {
    width: 4px;
    height: 100px;
    background: white;
  }
  
  .cover {
    width: 200px;
    height: 80px;
    background: #EEEEEE;
    border-top-left-radius: 50%;
    border-top-right-radius: 50%;
    position: relative;
    z-index: 200;
  }
  
  .in-cover {
    width: 100%;
    max-width: 200px;
    height: 20px;
    border-radius: 100%;
    background: #AAA;
    position: absolute;
    left: 0px;
    right: 0px;
    margin: 0px auto;
    bottom: -9px;
    z-index: 100;
  }
  .in-cover .bulb {
    width: 50px;
    height: 50px;
    background: #F5D76E;
    border-radius: 50%;
    position: absolute;
    left: 0px;
    right: 0px;
    bottom: -20px;
    margin: 0px auto;
  }
  
  .light {
    width: 200px;
    height: 0px;
    border-bottom: 1080px solid rgba(100, 100, 100, 0.45);
    border-left: 50px solid transparent;
    border-right: 50px solid transparent;
    position: absolute;
    left: 0px;
    right: 0px;
    top: 170px;
    margin: 0px auto;
    z-index: 1;
  }
</style>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/ErrorPage.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css??sv=1.0_20221129105951") %>" type="text/css" media="screen" title="no title"/>
	<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=1.0_20221129105951") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=1.0_20221129105951") %>" type="text/css" media="screen" title="no title"/>  
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js??sv=1.0_20221129105951") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=1.0_20221129105951") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=1.0_20221129105951") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=1.0_20221129105951") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js??sv=1.0_20221129105951") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=1.0_20221129105951") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=1.0_20221129105951") %>"></script>

			<script type="text/javascript" src="<%= ResolveUrl("~/JS/ErrorPage_USER.js??sv=1.0_20221129105951") %>"></script>
		<script type="text/javascript">
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
		
	<script type="text/javascript">
	</script>
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
				<telerik:RadAjaxPanel id="AjaxPanel1" runat="server" CssClass="c_AjaxPanel1" LoadingPanelID="___AjaxPanel1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="container-fluid c_LayoutContainer1">
						<div id="LayoutRow1" class="row c_LayoutRow1">
							<div id="LayoutCol1" class="col col-12 col-md-8 offset-0 offset-md-2 c_LayoutCol1">
								<div class="c_container_Icon1">
									<i id="Icon1" class="fas fa-exclamation-triangle c_Icon1">
									</i>
								</div>
								<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
							</div>
							<div id="LayoutCol2" class="col col-12 col-md-10 offset-0 offset-md-1 c_LayoutCol2">
								<telerik:RadLabel id="labHttpErrorMessage" runat="server" CssClass="c_labHttpErrorMessage" Text="HTTP ERROR Message" />
								<telerik:RadLabel id="labHttpErrorCode" runat="server" CssClass="c_labHttpErrorCode" Text="HTTP ERROR CODE" />
							</div>
						</div>
					</div>
					<telerik:RadCodeBlock runat="server" ID="RCBHtmlCodeControl1">
					<div id="HtmlCodeControl1" class="c_HtmlCodeControl1">
						<div class="lamp">
						    <div class="cable"></div>
						    <div class="cover"></div>
						    <div class="in-cover">
						        <div class="bulb"></div>
						    </div>
						    <div class="light"></div>
						</div>
					</div>
					</telerik:RadCodeBlock>
					<telerik:RadAjaxLoadingPanel ID="___AjaxPanel1_AjaxLoading" runat="server">
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

</script>
</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>
