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
using System.Configuration;
using System.Linq;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public partial class TB_CORRENTISTA : GeneralDataPage
	{
		protected TB_CORRENTISTAPageProvider PageProvider;
	

		public string COR_NOMEField = "";
		public bool COR_FISICAField;
		public bool COR_JURIDICAField;
		public string COR_CPFField = "";
		public string COR_CNPJField = "";
		public string COR_ENDERECOField = "";
		public string COR_BAIRROField = "";
		public string COR_CIDADEField = "";
		public string COR_EMAILField = "";
		public long COR_IDField = 0;
		
		public override string FormID { get { return "34752"; } }
		public override string TableName { get { return "TB_CORRENTISTA"; } }
		public override string DatabaseName { get { return "Treinamento"; } }
		public override string PageName { get { return "TB_CORRENTISTA.aspx"; } }
		public override string ProjectID { get { return "A439855"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamAcao = "";
		public string ParamCOR_ID = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCOR_ID))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("COR_ID") + " = " + Dao.ToSql(ParamCOR_ID.ToString(), FieldType.Integer);
				}
				else
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
				}
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new TB_CORRENTISTAPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			try { if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = RouteData.Values["ParamAcao"].ToString();} catch {} 
			try { if (string.IsNullOrEmpty(ParamCOR_ID)) ParamCOR_ID = RouteData.Values["ParamCOR_ID"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCOR_ID)) ParamCOR_ID = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
			ErrorLabel = labError;
			if (!PageInsert )
				DisableEnableContros(false);

			base.OnInit(e);
		}
		

		/// <summary>
		/// Carrega os objetos de Item de acordo com os controles
		/// </summary>
		public override void UpdateItemFromControl(GeneralDataProviderItem  Item)
		{
			// só vamos permitir a carga dos itens de acordo com os controles de tela caso esteja ocorrendo
			// um postback pois em caso contrário a página está sendo aberta em modo de inclusão/edição
			// e dessa forma não teve alteração de usuário nos dados do formulário
			if (PageState != FormStateEnum.Navigation && this.IsPostBack)
			{
				Item.SetFieldValue(Item["COR_NOME"], RadTextBox_COR_NOME.Text, false);
				Item.SetFieldValue(Item["COR_FISICA"], RadCheckBox_COR_FISICA.Checked);
				Item.SetFieldValue(Item["COR_JURIDICA"], RadCheckBox_COR_JURIDICA.Checked);
				Item.SetFieldValue(Item["COR_CPF"], RadTextBox_COR_CPF.Text, false);
				Item.SetFieldValue(Item["COR_CNPJ"], RadTextBox_COR_CNPJ.Text, false);
				Item.SetFieldValue(Item["COR_ENDERECO"], RadTextBox_COR_ENDERECO.Text, false);
				Item.SetFieldValue(Item["COR_BAIRRO"], RadTextBox_COR_BAIRRO.Text, false);
				Item.SetFieldValue(Item["COR_CIDADE"], RadTextBox_COR_CIDADE.Text, false);
				Item.SetFieldValue(Item["COR_EMAIL"], RadTextBox_COR_EMAIL.Text, false);
			}
			InitializeAlias(Item);
		}

		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da página
		/// </summary>

		public override GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			GeneralDataProviderItem Item = PageProvider.GetDataProviderItem(DataProvider);
			if (PageState != FormStateEnum.Navigation)
			{
				Item.SetFieldValue(Item["COR_NOME"], RadTextBox_COR_NOME.Text, false);
				Item.SetFieldValue(Item["COR_FISICA"], RadCheckBox_COR_FISICA.Checked);
				Item.SetFieldValue(Item["COR_JURIDICA"], RadCheckBox_COR_JURIDICA.Checked);
				Item.SetFieldValue(Item["COR_CPF"], RadTextBox_COR_CPF.Text, false);
				Item.SetFieldValue(Item["COR_CNPJ"], RadTextBox_COR_CNPJ.Text, false);
				Item.SetFieldValue(Item["COR_ENDERECO"], RadTextBox_COR_ENDERECO.Text, false);
				Item.SetFieldValue(Item["COR_BAIRRO"], RadTextBox_COR_BAIRRO.Text, false);
				Item.SetFieldValue(Item["COR_CIDADE"], RadTextBox_COR_CIDADE.Text, false);
				Item.SetFieldValue(Item["COR_EMAIL"], RadTextBox_COR_EMAIL.Text, false);
			}
			else
			{
				Item = PageProvider.MainProvider.DataProvider.SelectItem(PageNumber, FormPositioningEnum.Current);
			}
			if (EnableValidation)
			{
				InitializeAlias(Item);
				if (PageState == FormStateEnum.Insert)
				{
					FillAuxiliarTables();
				}
				PageProvider.Validate(Item); 
			}
			if (Item!=null) PageErrors.Add(Item.Errors);
			return Item;
		}
		
		public string mostrarEOcultar901018368()
		{
			return (bool.Parse((COR_FISICAField).ToString())?"flex":"none !important");
		}
		public string mostrarEOcultar902349818()
		{
			return (bool.Parse((COR_JURIDICAField).ToString())?"flex":"none !important");
		}


		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(RadTextBox_COR_NOME);
			Utility.SetControlTabOnEnter(RadCheckBox_COR_FISICA);
			Utility.SetControlTabOnEnter(RadCheckBox_COR_JURIDICA);
			Utility.SetControlTabOnEnter(RadTextBox_COR_ENDERECO);
			Utility.SetControlTabOnEnter(RadTextBox_COR_BAIRRO);
			Utility.SetControlTabOnEnter(RadTextBox_COR_CIDADE);
			Utility.SetControlTabOnEnter(RadTextBox_COR_EMAIL);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_COR_NOME.Attributes.Add("EnableEdit", "True");
			RadCheckBox_COR_FISICA.Attributes.Add("EnableEdit", "True");
			RadCheckBox_COR_JURIDICA.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_CPF.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_CNPJ.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_ENDERECO.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_BAIRRO.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_CIDADE.Attributes.Add("EnableEdit", "True");
			RadTextBox_COR_EMAIL.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
				RadTextBox_COR_NOME.Text = "";
				RadCheckBox_COR_FISICA.Checked = false;
				RadCheckBox_COR_JURIDICA.Checked = false;
				RadTextBox_COR_CPF.Text = "";
				RadTextBox_COR_CNPJ.Text = "";
				RadTextBox_COR_ENDERECO.Text = "";
				RadTextBox_COR_BAIRRO.Text = "";
				RadTextBox_COR_CIDADE.Text = "";
				RadTextBox_COR_EMAIL.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
		}

		public override void PageEdit()
		{
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label_COR_NOME.Text = Label_COR_NOME.Text.Replace("<", "&lt;");
			Label_COR_NOME.Text = Label_COR_NOME.Text.Replace(">", "&gt;");
			Label_COR_CPF.Text = Label_COR_CPF.Text.Replace("<", "&lt;");
			Label_COR_CPF.Text = Label_COR_CPF.Text.Replace(">", "&gt;");
			Label_COR_CNPJ.Text = Label_COR_CNPJ.Text.Replace("<", "&lt;");
			Label_COR_CNPJ.Text = Label_COR_CNPJ.Text.Replace(">", "&gt;");
			Label_COR_ENDERECO.Text = Label_COR_ENDERECO.Text.Replace("<", "&lt;");
			Label_COR_ENDERECO.Text = Label_COR_ENDERECO.Text.Replace(">", "&gt;");
			Label_COR_BAIRRO.Text = Label_COR_BAIRRO.Text.Replace("<", "&lt;");
			Label_COR_BAIRRO.Text = Label_COR_BAIRRO.Text.Replace(">", "&gt;");
			Label_COR_CIDADE.Text = Label_COR_CIDADE.Text.Replace("<", "&lt;");
			Label_COR_CIDADE.Text = Label_COR_CIDADE.Text.Replace(">", "&gt;");
			Label_COR_EMAIL.Text = Label_COR_EMAIL.Text.Replace("<", "&lt;");
			Label_COR_EMAIL.Text = Label_COR_EMAIL.Text.Replace(">", "&gt;");
			try{ LayoutCol30.Style["display"] = mostrarEOcultar901018368();} catch { }
			try{ LayoutCol32.Style["display"] = mostrarEOcultar902349818();} catch { }
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_NOME.Text = Item["COR_NOME"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_NOME.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_NOME.Text = "" ;
			}
			try
			{
				RadCheckBox_COR_FISICA.Attributes.Add("OnClick","InitiateEditAuto();");
				RadCheckBox_COR_FISICA.Checked = (Item["COR_FISICA"].Value != null && Convert.ToBoolean(Item["COR_FISICA"].Value));
			}
			catch { RadCheckBox_COR_FISICA.Checked = false;}
			try
			{
				RadCheckBox_COR_JURIDICA.Attributes.Add("OnClick","InitiateEditAuto();");
				RadCheckBox_COR_JURIDICA.Checked = (Item["COR_JURIDICA"].Value != null && Convert.ToBoolean(Item["COR_JURIDICA"].Value));
			}
			catch { RadCheckBox_COR_JURIDICA.Checked = false;}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_CPF.Text = Item["COR_CPF"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_CPF.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_CPF.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_CNPJ.Text = Item["COR_CNPJ"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_CNPJ.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_CNPJ.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_ENDERECO.Text = Item["COR_ENDERECO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_ENDERECO.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_ENDERECO.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_BAIRRO.Text = Item["COR_BAIRRO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_BAIRRO.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_BAIRRO.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_CIDADE.Text = Item["COR_CIDADE"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_CIDADE.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_CIDADE.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_COR_EMAIL.Text = Item["COR_EMAIL"].GetFormattedValue();
				}
				else
				{
					RadTextBox_COR_EMAIL.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_COR_EMAIL.Text = "" ;
			}
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		/// <summary>
		/// Define apelidos da Página
		/// </summary>
		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			
			try
			{
				if (Item != null)
				{
					COR_NOMEField = Item["COR_NOME"].GetFormattedValue();
				}
				else
				{
					COR_NOMEField = "";
				}
			}
			catch
			{
				COR_NOMEField = "";
			}
			try
			{
				COR_FISICAField = Convert.ToBoolean(Item["COR_FISICA"].Value);
			}
			catch
			{
				COR_FISICAField = false;
			}
			try
			{
				COR_JURIDICAField = Convert.ToBoolean(Item["COR_JURIDICA"].Value);
			}
			catch
			{
				COR_JURIDICAField = false;
			}
			try
			{
				if (Item != null)
				{
					COR_CPFField = Item["COR_CPF"].GetFormattedValue();
				}
				else
				{
					COR_CPFField = "";
				}
			}
			catch
			{
				COR_CPFField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_CNPJField = Item["COR_CNPJ"].GetFormattedValue();
				}
				else
				{
					COR_CNPJField = "";
				}
			}
			catch
			{
				COR_CNPJField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_ENDERECOField = Item["COR_ENDERECO"].GetFormattedValue();
				}
				else
				{
					COR_ENDERECOField = "";
				}
			}
			catch
			{
				COR_ENDERECOField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_BAIRROField = Item["COR_BAIRRO"].GetFormattedValue();
				}
				else
				{
					COR_BAIRROField = "";
				}
			}
			catch
			{
				COR_BAIRROField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_CIDADEField = Item["COR_CIDADE"].GetFormattedValue();
				}
				else
				{
					COR_CIDADEField = "";
				}
			}
			catch
			{
				COR_CIDADEField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_EMAILField = Item["COR_EMAIL"].GetFormattedValue();
				}
				else
				{
					COR_EMAILField = "";
				}
			}
			catch
			{
				COR_EMAILField = "";
			}
			try
			{
				if (Item != null)
				{
					COR_IDField = long.Parse(Item["COR_ID"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				COR_IDField = 0;
				}
			}
			catch
			{
				COR_IDField = 0;
			}
			PageProvider.AliasVariables.Add("COR_NOMEField", COR_NOMEField);
			PageProvider.AliasVariables.Add("COR_FISICAField", COR_FISICAField);
			PageProvider.AliasVariables.Add("COR_JURIDICAField", COR_JURIDICAField);
			PageProvider.AliasVariables.Add("COR_CPFField", COR_CPFField);
			PageProvider.AliasVariables.Add("COR_CNPJField", COR_CNPJField);
			PageProvider.AliasVariables.Add("COR_ENDERECOField", COR_ENDERECOField);
			PageProvider.AliasVariables.Add("COR_BAIRROField", COR_BAIRROField);
			PageProvider.AliasVariables.Add("COR_CIDADEField", COR_CIDADEField);
			PageProvider.AliasVariables.Add("COR_EMAILField", COR_EMAILField);
			PageProvider.AliasVariables.Add("COR_IDField", COR_IDField);
			PageProvider.AliasVariables.Add("ParamAcao", ParamAcao);
			PageProvider.AliasVariables.Add("ParamCOR_ID", ParamCOR_ID);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				if ((ParamAcao == "incluir"))
				{
			AjaxPanel.ResponseScripts.Add("sweetAlert_SweetAlertIncluir();");
				}
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_2 = true;
			try
			{
				if ((ParamAcao == "editar"))
				{
			AjaxPanel.ResponseScripts.Add("sweetAlert_SweetAlertEditar();");
				}
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
	}
}
