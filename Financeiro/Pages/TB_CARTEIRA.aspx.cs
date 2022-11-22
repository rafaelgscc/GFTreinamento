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
	public partial class TB_CARTEIRA : GeneralDataPage
	{
		protected TB_CARTEIRAPageProvider PageProvider;
	

		public string CAR_NOMEField = "";
		public long CAR_IDField = 0;
		
		public override string FormID { get { return "34738"; } }
		public override string TableName { get { return "TB_CARTEIRA"; } }
		public override string DatabaseName { get { return "Treinamento"; } }
		public override string PageName { get { return "TB_CARTEIRA.aspx"; } }
		public override string ProjectID { get { return "A439855"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamAcao = "";
		public string ParamCAR_ID = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCAR_ID))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("CAR_ID") + " = " + Dao.ToSql(ParamCAR_ID.ToString(), FieldType.Integer);
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
			PageProvider = new TB_CARTEIRAPageProvider(this);
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
			try { if (string.IsNullOrEmpty(ParamCAR_ID)) ParamCAR_ID = RouteData.Values["ParamCAR_ID"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCAR_ID)) ParamCAR_ID = "0";
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
				Item.SetFieldValue(Item["CAR_NOME"], RadTextBox_CAR_NOME.Text, false);
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
				Item.SetFieldValue(Item["CAR_NOME"], RadTextBox_CAR_NOME.Text, false);
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
		


		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(RadTextBox_CAR_NOME);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_CAR_NOME.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
				RadTextBox_CAR_NOME.Text = "";
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
			Label_CAR_NOME.Text = Label_CAR_NOME.Text.Replace("<", "&lt;");
			Label_CAR_NOME.Text = Label_CAR_NOME.Text.Replace(">", "&gt;");
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
					RadTextBox_CAR_NOME.Text = Item["CAR_NOME"].GetFormattedValue();
				}
				else
				{
					RadTextBox_CAR_NOME.Text = "" ;
				}
			}
			catch
			{
				RadTextBox_CAR_NOME.Text = "" ;
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
					CAR_NOMEField = Item["CAR_NOME"].GetFormattedValue();
				}
				else
				{
					CAR_NOMEField = "";
				}
			}
			catch
			{
				CAR_NOMEField = "";
			}
			try
			{
				if (Item != null)
				{
					CAR_IDField = long.Parse(Item["CAR_ID"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				CAR_IDField = 0;
				}
			}
			catch
			{
				CAR_IDField = 0;
			}
			PageProvider.AliasVariables.Add("CAR_NOMEField", CAR_NOMEField);
			PageProvider.AliasVariables.Add("CAR_IDField", CAR_IDField);
			PageProvider.AliasVariables.Add("ParamAcao", ParamAcao);
			PageProvider.AliasVariables.Add("ParamCAR_ID", ParamCAR_ID);
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
