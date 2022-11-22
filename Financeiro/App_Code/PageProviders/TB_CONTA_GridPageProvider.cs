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
	public class TB_CONTA_GridPageProvider : GeneralProvider
	{
		public TB_CONTA_Grid_Grid_TB_CONTAGridDataProvider TB_CONTA_Grid_Grid_TB_CONTAProvider;

		public TB_CONTA_GridPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_CONTADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CONTA", "TB_CONTA_Grid");
			MainProvider.DataProvider.PageProvider = this;
			TB_CONTA_Grid_Grid_TB_CONTAProvider = new TB_CONTA_Grid_Grid_TB_CONTAGridDataProvider(this);
			TB_CONTA_Grid_Grid_TB_CONTAProvider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_CONTA_Grid_Grid_TB_CONTAProvider_SetRelationFields);
		}


		private void TB_CONTA_Grid_Grid_TB_CONTAProvider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_CONTA_Grid_Grid_TB_CONTAProvider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_CONTAItem(MainProvider.DatabaseName);
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
	public class TB_CONTA_Grid_Grid_TB_CONTAGridDataProvider : GeneralGridProvider
	{
		public string CT_NOMEField;
		public long GC_IDField;
		public string CT_IDField;
		
		public Treinamento_TB_GRUPO_CONTADataProvider GridColumn_GC_IDProvider;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private Treinamento_TB_CONTADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as Treinamento_TB_CONTADataProvider;
			}
		}

		public TB_CONTA_GridPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_CONTA"; } }

		public override string DatabaseName { get { return "Treinamento"; } }

		public override string FormID { get { return "34745"; } }
		
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["CT_NOMEField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_CT_NOME", "Nome da conta não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["GC_IDField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_GC_ID", "ID do Grupo não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_CONTA_Grid_Grid_TB_CONTAGridDataProvider(TB_CONTA_GridPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new Treinamento_TB_CONTADataProvider(this, TableName, DatabaseName, "PK_TB_CONTA", "TB_CONTA_Grid_Grid_TB_CONTA");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			GridColumn_GC_IDProvider = new Treinamento_TB_GRUPO_CONTADataProvider(MainProvider, "TB_GRUPO_CONTA", "Treinamento", "", "TB_CONTA_Grid_GridColumn_GC_IDProviderAlias");
			GridColumn_GC_IDProvider.PageProvider = this;
			GridColumn_GC_IDProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}
		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		if (Provider == GridColumn_GC_IDProvider)
		{
			if (Item != null)
			{
				return Provider.Item["GC_NOME"].GetFormattedValue();
			}
		}
			return "";
		}

		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			if (string.IsNullOrEmpty(FieldId)) return "";
			DataTable dt;
			DataAccessObject Dao;
			Dictionary<string, object> filter;
			switch (GridColumnId)
			{
				case "GridColumn_GC_ID":
					filter = new Dictionary<string, object>() { { "GC_ID", FieldId } };
					Dao = Utility.GetDAO("Treinamento");
					GridColumn_GC_IDProvider.FindRecord(filter);
					if (GridColumn_GC_IDProvider.PageNumber != 0)
					{
						var retval = "";
						if (GridColumn_GC_IDProvider.Item["GC_NOME"].Value != null) retval +=  GridColumn_GC_IDProvider.Item["GC_NOME"].Value.ToString();
						return System.Net.WebUtility.HtmlEncode(retval);
					}
					return "";
				default:
					return "";
			}
		}

		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == GridColumn_GC_IDProvider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "GC_ID", Value } });
					return Provider.Item;
				}
			
			}
			catch
			{
			}
			return null;
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			return FillCombo(Provider, ComboBox, NumberOfItems, TextFilter, AllowFilter, null);
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			try
			{
			var Dao = Provider.Dao;
				if (Provider == GridColumn_GC_IDProvider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "GC_NOME";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "GC_ID", " GC_NOME", false);
					return Total > 0;
				}
			}
			catch
			{
			}
			return false;
		}
		
		public bool FillCombo(List<RadComboBoxDataItem> ComboBoxDataItem, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem);
		}

		public Treinamento_TB_CONTAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as Treinamento_TB_CONTAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_CONTA_Grid_Grid_TB_CONTA")
			{
				return new Treinamento_TB_CONTAItem(DatabaseName);
			}
			else if (Provider.Name == "TB_CONTA_Grid_GridColumn_GC_IDProviderAlias")
			{
				return new Treinamento_TB_GRUPO_CONTAItem(MainProvider.DatabaseName, "GC_ID", "GC_NOME");
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_CONTA_GridPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			CT_NOMEField = Convert.ToString(Item["CT_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CT_NOMEField"))
			{
				AliasVariables["CT_NOMEField"] = CT_NOMEField;
			}
			else
			{
				AliasVariables.Add("CT_NOMEField" ,CT_NOMEField);
			}
			GC_IDField = Convert.ToInt64(Item["GC_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("GC_IDField"))
			{
				AliasVariables["GC_IDField"] = GC_IDField;
			}
			else
			{
				AliasVariables.Add("GC_IDField" ,GC_IDField);
			}
			CT_IDField = Convert.ToString(Item["CT_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CT_IDField"))
			{
				AliasVariables["CT_IDField"] = CT_IDField;
			}
			else
			{
				AliasVariables.Add("CT_IDField" ,CT_IDField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
		}

	}

}
