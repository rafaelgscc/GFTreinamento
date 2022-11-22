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
	public class TB_CENTRO_DE_CUSTO_GridPageProvider : GeneralProvider
	{
		public TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOGridDataProvider TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider;

		public TB_CENTRO_DE_CUSTO_GridPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_CENTRO_DE_CUSTODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CENTRO_DE_CUSTO", "TB_CENTRO_DE_CUSTO_Grid");
			MainProvider.DataProvider.PageProvider = this;
			TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider = new TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOGridDataProvider(this);
			TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider_SetRelationFields);
		}


		private void TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_CENTRO_DE_CUSTOItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_CENTRO_DE_CUSTO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "CC_ID") });
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
	public class TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOGridDataProvider : GeneralGridProvider
	{
		public string CC_NOMEField;
		public long CC_IDField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private Treinamento_TB_CENTRO_DE_CUSTODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as Treinamento_TB_CENTRO_DE_CUSTODataProvider;
			}
		}

		public TB_CENTRO_DE_CUSTO_GridPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_CENTRO_DE_CUSTO"; } }

		public override string DatabaseName { get { return "Treinamento"; } }

		public override string FormID { get { return "34739"; } }
		
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["CC_NOMEField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_CC_NOME", "Nome do centro de custos0 não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOGridDataProvider(TB_CENTRO_DE_CUSTO_GridPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new Treinamento_TB_CENTRO_DE_CUSTODataProvider(this, TableName, DatabaseName, "PK_TB_CENTRO_DE_CUSTO", "TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTO");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public Treinamento_TB_CENTRO_DE_CUSTOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as Treinamento_TB_CENTRO_DE_CUSTOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTO")
			{
				return new Treinamento_TB_CENTRO_DE_CUSTOItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_CENTRO_DE_CUSTO_GridPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			CC_NOMEField = Convert.ToString(Item["CC_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CC_NOMEField"))
			{
				AliasVariables["CC_NOMEField"] = CC_NOMEField;
			}
			else
			{
				AliasVariables.Add("CC_NOMEField" ,CC_NOMEField);
			}
			CC_IDField = Convert.ToInt64(Item["CC_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CC_IDField"))
			{
				AliasVariables["CC_IDField"] = CC_IDField;
			}
			else
			{
				AliasVariables.Add("CC_IDField" ,CC_IDField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_CENTRO_DE_CUSTO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "CC_ID") });
		}

	}

}
