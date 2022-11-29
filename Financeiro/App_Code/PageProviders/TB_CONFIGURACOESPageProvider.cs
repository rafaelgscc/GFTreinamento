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
	public class TB_CONFIGURACOESPageProvider : GeneralProvider
	{
		public Treinamento_TB_CONTADataProvider ComboBox1Provider;
		public Treinamento_TB_CARTEIRADataProvider ComboBox2Provider;

		public TB_CONFIGURACOESPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_CONFIGURACOESDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CONFIGURACOES", "TB_CONFIGURACOES");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox1Provider = new Treinamento_TB_CONTADataProvider(MainProvider, "TB_CONTA", "Treinamento", "", "TB_CONFIGURACOES_ComboBox1ProviderAlias");
			ComboBox1Provider.PageProvider = this;
			ComboBox1Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox2Provider = new Treinamento_TB_CARTEIRADataProvider(MainProvider, "TB_CARTEIRA", "Treinamento", "", "TB_CONFIGURACOES_ComboBox2ProviderAlias");
			ComboBox2Provider.PageProvider = this;
			ComboBox2Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_CONFIGURACOESItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox1Provider)
			{
				return new Treinamento_TB_CONTAItem(Provider.DataBaseName, "CT_NOME", "CT_ID");
			}
			else if (Provider == ComboBox2Provider)
			{
				return new Treinamento_TB_CARTEIRAItem(Provider.DataBaseName, "CAR_NOME", "CAR_ID");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["CT_NOME"].GetValue().ToString();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["CAR_NOME"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["CT_ID"].GetValue();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["CAR_ID"].GetValue();
			}
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
			MainProvider.DataProvider.FindRecord("PK_TB_CONFIGURACOES", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "CONFIG_ID") });
		}
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox1Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "CT_ID", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox2Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "CAR_ID", Value } });
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
				if (Provider == ComboBox1Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "CT_NOME";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "CT_ID", " CT_NOME", false);
					return Total > 0;
				}
				else if (Provider == ComboBox2Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "CAR_NOME";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "CAR_ID", " CAR_NOME", false);
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



		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["CONFIG_CONTA_TRANSF_PADRAOField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Conta padrão para transferências não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
