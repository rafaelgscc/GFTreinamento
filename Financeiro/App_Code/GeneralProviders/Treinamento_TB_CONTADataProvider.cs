using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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
using Newtonsoft.Json;

namespace PROJETO.DataProviders
{
	public partial class Treinamento_TB_CONTAItem : GeneralDataProviderItem
	{
		private string DataBaseName;
				
		private DataAccessObject _Dao;
		public DataAccessObject Dao
		{
			get 
			{ 
				if (_Dao == null) _Dao = Utility.GetDAO(DataBaseName);
				return _Dao;
			}
		}

		public Treinamento_TB_CONTAItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public Treinamento_TB_CONTAItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private Treinamento_TB_CONTAItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			if (AllFields || Contains(FieldNames, "CT_ID")) NewFields.Add("CT_ID", new TextField("CT_ID", "", null, true));
			if (AllFields || Contains(FieldNames, "CT_NOME")) NewFields.Add("CT_NOME", new TextField("CT_NOME", "", null, true));
			if (AllFields || Contains(FieldNames, "GC_ID")) NewFields.Add("GC_ID", new LongField("GC_ID", "", null, true));
			
			if (!AllFields)
			{
				Dictionary<string, FieldBase> NewFieldsOrder = new Dictionary<string, FieldBase>();
				foreach (string Field in FieldNames)
				{
					NewFieldsOrder.Add(Field, NewFields[Field]);
				}
				NewFields = NewFieldsOrder; 
			}
			
			return NewFields;
		}
		
		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para inserir o registro na tabela</param>
		public override void Validate(GeneralDataProvider provider)
		{
		}
	}
	
	/// <summary>
	/// Classe de provider usada para acessar a tabela de produtos
	/// </summary>
	public class Treinamento_TB_CONTADataProvider : GeneralDataProvider
	{
		public FieldBase this[string ColumnName]
		{
			get
			{
				return Item[ColumnName];
			}
		}

		public override Dictionary<string, FieldBase> CreateItemFields()
		{
			return Treinamento_TB_CONTAItem.CreateItemFields(true); 
		}
	
		public Treinamento_TB_CONTADataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CONTA":
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CONTA":
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( Treinamento_TB_CONTAItem.CreateItemFields(false, GetUniqueKeyFields()));
		}
		
		public override void SetTableSequence(GeneralDataProviderItem Item)
		{
			Item.Fields["CT_ID"].SetValue(GetTableSequence());
			PageCurrentSequence = Item.Fields["CT_ID"].GetFormattedValue();
		}

		public override void SetCurrentTableSequence(GeneralDataProviderItem Item)
		{
			Item.Fields["CT_ID"].SetValue(PageCurrentSequence);
		}

		public override string GetTableSequence()
		{
			return SequenceUtility.PegaSequencia(DataBaseName, TableName, "CT_ID", null, 1);
		}
		
		public override void ConfirmTableSequence()
		{
			SequenceUtility.ConfirmaSequencia(DataBaseName, TableName, "CT_ID");
		}

		public override void RollbackTableSequence()
		{
			SequenceUtility.VoltaSequencia(DataBaseName, TableName, "CT_ID");
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] {  };
		}			
	}
}
