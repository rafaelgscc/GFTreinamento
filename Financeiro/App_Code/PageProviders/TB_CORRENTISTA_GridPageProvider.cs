using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class TB_CORRENTISTA_GridPageProvider : GeneralProvider
	{
		public TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAGridDataProvider TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider;

		public TB_CORRENTISTA_GridPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_CORRENTISTADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CORRENTISTA", "TB_CORRENTISTA_Grid");
			MainProvider.DataProvider.PageProvider = this;
			TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider = new TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAGridDataProvider(this);
			TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider_SetRelationFields);
		}


		private void TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAProvider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_CORRENTISTAItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_CORRENTISTA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "COR_ID") });
		}


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAGridDataProvider : GeneralGridProvider
	{
		public string COR_NOMEField;
		public string COR_CIDADEField;
		public string COR_EMAILField;
		public long COR_IDField;
		public string COR_CPFField;
		public bool COR_FISICAField;
		public string COR_CNPJField;
		public bool COR_JURIDICAField;
		public string COR_ENDERECOField;
		public string COR_BAIRROField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private Treinamento_TB_CORRENTISTADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as Treinamento_TB_CORRENTISTADataProvider;
			}
		}

		public TB_CORRENTISTA_GridPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_CORRENTISTA"; } }

		public override string DatabaseName { get { return "Treinamento"; } }

		public override string FormID { get { return "34751"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["COR_NOMEField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_COR_NOME", "Nome do Correntista não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTAGridDataProvider(TB_CORRENTISTA_GridPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new Treinamento_TB_CORRENTISTADataProvider(this, TableName, DatabaseName, "PK_TB_CORRENTISTA", "TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTA");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public Treinamento_TB_CORRENTISTAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as Treinamento_TB_CORRENTISTAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_CORRENTISTA_Grid_Grid_TB_CORRENTISTA")
			{
				return new Treinamento_TB_CORRENTISTAItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_CORRENTISTA_GridPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			COR_NOMEField = Convert.ToString(Item["COR_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_NOMEField"))
			{
				AliasVariables["COR_NOMEField"] = COR_NOMEField;
			}
			else
			{
				AliasVariables.Add("COR_NOMEField" ,COR_NOMEField);
			}
			COR_CIDADEField = Convert.ToString(Item["COR_CIDADE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_CIDADEField"))
			{
				AliasVariables["COR_CIDADEField"] = COR_CIDADEField;
			}
			else
			{
				AliasVariables.Add("COR_CIDADEField" ,COR_CIDADEField);
			}
			COR_EMAILField = Convert.ToString(Item["COR_EMAIL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_EMAILField"))
			{
				AliasVariables["COR_EMAILField"] = COR_EMAILField;
			}
			else
			{
				AliasVariables.Add("COR_EMAILField" ,COR_EMAILField);
			}
			COR_IDField = Convert.ToInt64(Item["COR_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_IDField"))
			{
				AliasVariables["COR_IDField"] = COR_IDField;
			}
			else
			{
				AliasVariables.Add("COR_IDField" ,COR_IDField);
			}
			COR_CPFField = Convert.ToString(Item["COR_CPF"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_CPFField"))
			{
				AliasVariables["COR_CPFField"] = COR_CPFField;
			}
			else
			{
				AliasVariables.Add("COR_CPFField" ,COR_CPFField);
			}
			COR_FISICAField = Convert.ToBoolean(Item["COR_FISICA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_FISICAField"))
			{
				AliasVariables["COR_FISICAField"] = COR_FISICAField;
			}
			else
			{
				AliasVariables.Add("COR_FISICAField" ,COR_FISICAField);
			}
			COR_CNPJField = Convert.ToString(Item["COR_CNPJ"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_CNPJField"))
			{
				AliasVariables["COR_CNPJField"] = COR_CNPJField;
			}
			else
			{
				AliasVariables.Add("COR_CNPJField" ,COR_CNPJField);
			}
			COR_JURIDICAField = Convert.ToBoolean(Item["COR_JURIDICA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_JURIDICAField"))
			{
				AliasVariables["COR_JURIDICAField"] = COR_JURIDICAField;
			}
			else
			{
				AliasVariables.Add("COR_JURIDICAField" ,COR_JURIDICAField);
			}
			COR_ENDERECOField = Convert.ToString(Item["COR_ENDERECO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_ENDERECOField"))
			{
				AliasVariables["COR_ENDERECOField"] = COR_ENDERECOField;
			}
			else
			{
				AliasVariables.Add("COR_ENDERECOField" ,COR_ENDERECOField);
			}
			COR_BAIRROField = Convert.ToString(Item["COR_BAIRRO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("COR_BAIRROField"))
			{
				AliasVariables["COR_BAIRROField"] = COR_BAIRROField;
			}
			else
			{
				AliasVariables.Add("COR_BAIRROField" ,COR_BAIRROField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_CORRENTISTA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "COR_ID") });
		}

	}

}
