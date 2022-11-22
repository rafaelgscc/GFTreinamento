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
	public class TB_CARTEIRA_GridPageProvider : GeneralProvider
	{
		public TB_CARTEIRA_Grid_Grid_TB_CARTEIRAGridDataProvider TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider;

		public TB_CARTEIRA_GridPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_CARTEIRADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CARTEIRA", "TB_CARTEIRA_Grid");
			MainProvider.DataProvider.PageProvider = this;
			TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider = new TB_CARTEIRA_Grid_Grid_TB_CARTEIRAGridDataProvider(this);
			TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider_SetRelationFields);
		}


		private void TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_CARTEIRA_Grid_Grid_TB_CARTEIRAProvider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_CARTEIRAItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_CARTEIRA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "CAR_ID") });
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
	public class TB_CARTEIRA_Grid_Grid_TB_CARTEIRAGridDataProvider : GeneralGridProvider
	{
		public string CAR_NOMEField;
		public long CAR_IDField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private Treinamento_TB_CARTEIRADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as Treinamento_TB_CARTEIRADataProvider;
			}
		}

		public TB_CARTEIRA_GridPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_CARTEIRA"; } }

		public override string DatabaseName { get { return "Treinamento"; } }

		public override string FormID { get { return "34737"; } }
		
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["CAR_NOMEField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_CAR_NOME", "Nome da Carteira não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_CARTEIRA_Grid_Grid_TB_CARTEIRAGridDataProvider(TB_CARTEIRA_GridPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new Treinamento_TB_CARTEIRADataProvider(this, TableName, DatabaseName, "PK_TB_CARTEIRA", "TB_CARTEIRA_Grid_Grid_TB_CARTEIRA");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public Treinamento_TB_CARTEIRAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as Treinamento_TB_CARTEIRAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_CARTEIRA_Grid_Grid_TB_CARTEIRA")
			{
				return new Treinamento_TB_CARTEIRAItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_CARTEIRA_GridPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			CAR_NOMEField = Convert.ToString(Item["CAR_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CAR_NOMEField"))
			{
				AliasVariables["CAR_NOMEField"] = CAR_NOMEField;
			}
			else
			{
				AliasVariables.Add("CAR_NOMEField" ,CAR_NOMEField);
			}
			CAR_IDField = Convert.ToInt64(Item["CAR_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CAR_IDField"))
			{
				AliasVariables["CAR_IDField"] = CAR_IDField;
			}
			else
			{
				AliasVariables.Add("CAR_IDField" ,CAR_IDField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_CARTEIRA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "CAR_ID") });
		}

	}

}
