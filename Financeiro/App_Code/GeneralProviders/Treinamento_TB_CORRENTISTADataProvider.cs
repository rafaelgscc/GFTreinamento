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
	public partial class Treinamento_TB_CORRENTISTAItem : GeneralDataProviderItem
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

		public Treinamento_TB_CORRENTISTAItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public Treinamento_TB_CORRENTISTAItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private Treinamento_TB_CORRENTISTAItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("COR_ID", new LongField("COR_ID", "", null, false));
			if (AllFields || Contains(FieldNames, "COR_NOME")) NewFields.Add("COR_NOME", new TextField("COR_NOME", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_CPF")) NewFields.Add("COR_CPF", new TextField("COR_CPF", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_FISICA")) NewFields.Add("COR_FISICA", new BooleanField("COR_FISICA", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_CNPJ")) NewFields.Add("COR_CNPJ", new TextField("COR_CNPJ", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_JURIDICA")) NewFields.Add("COR_JURIDICA", new BooleanField("COR_JURIDICA", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_ENDERECO")) NewFields.Add("COR_ENDERECO", new TextField("COR_ENDERECO", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_BAIRRO")) NewFields.Add("COR_BAIRRO", new TextField("COR_BAIRRO", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_CIDADE")) NewFields.Add("COR_CIDADE", new TextField("COR_CIDADE", "", null, true));
			if (AllFields || Contains(FieldNames, "COR_EMAIL")) NewFields.Add("COR_EMAIL", new TextField("COR_EMAIL", "", null, true));
			
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
	public class Treinamento_TB_CORRENTISTADataProvider : GeneralDataProvider
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
			return Treinamento_TB_CORRENTISTAItem.CreateItemFields(true); 
		}
	
		public Treinamento_TB_CORRENTISTADataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CORRENTISTA":
					CreateParameter("COR_ID");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CORRENTISTA":
					CreateParameter("COR_ID");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( Treinamento_TB_CORRENTISTAItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "COR_ID" };
		}			
	}
}
