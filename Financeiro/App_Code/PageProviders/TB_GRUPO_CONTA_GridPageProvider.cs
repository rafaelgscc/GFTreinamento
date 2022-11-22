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
	public class TB_GRUPO_CONTA_GridPageProvider : GeneralProvider
	{
		public TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAGridDataProvider TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider;

		public TB_GRUPO_CONTA_GridPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new Treinamento_TB_GRUPO_CONTADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_GRUPO_CONTA", "TB_GRUPO_CONTA_Grid");
			MainProvider.DataProvider.PageProvider = this;
			TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider = new TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAGridDataProvider(this);
			TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider_SetRelationFields);
		}


		private void TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAProvider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new Treinamento_TB_GRUPO_CONTAItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_GRUPO_CONTA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "GC_ID") });
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
	public class TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAGridDataProvider : GeneralGridProvider
	{
		public string GC_NOMEField;
		public long GC_IDField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private Treinamento_TB_GRUPO_CONTADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as Treinamento_TB_GRUPO_CONTADataProvider;
			}
		}

		public TB_GRUPO_CONTA_GridPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_GRUPO_CONTA"; } }

		public override string DatabaseName { get { return "Treinamento"; } }

		public override string FormID { get { return "34747"; } }
		
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["GC_NOMEField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn_GC_NOME", "Nome do Grupo de conta não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTAGridDataProvider(TB_GRUPO_CONTA_GridPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new Treinamento_TB_GRUPO_CONTADataProvider(this, TableName, DatabaseName, "PK_TB_GRUPO_CONTA", "TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTA");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public Treinamento_TB_GRUPO_CONTAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as Treinamento_TB_GRUPO_CONTAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_GRUPO_CONTA_Grid_Grid_TB_GRUPO_CONTA")
			{
				return new Treinamento_TB_GRUPO_CONTAItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_GRUPO_CONTA_GridPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			GC_NOMEField = Convert.ToString(Item["GC_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("GC_NOMEField"))
			{
				AliasVariables["GC_NOMEField"] = GC_NOMEField;
			}
			else
			{
				AliasVariables.Add("GC_NOMEField" ,GC_NOMEField);
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
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_GRUPO_CONTA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "GC_ID") });
		}

	}

}
