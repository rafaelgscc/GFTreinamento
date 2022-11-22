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
	public partial class TB_CONTA_Grid : GeneralDataPage
	{
		protected TB_CONTA_GridPageProvider PageProvider;
	

		public string CT_IDField = "";
		public string CT_NOMEField = "";
		public long GC_IDField = 0;
		
		public override string FormID { get { return "34745"; } }
		public override string TableName { get { return "TB_CONTA"; } }
		public override string DatabaseName { get { return "Treinamento"; } }
		public override string PageName { get { return "TB_CONTA_Grid.aspx"; } }
		public override string ProjectID { get { return "A439855"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		



		
		public override void CreateProvider()
		{
			PageProvider = new TB_CONTA_GridPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}

		public override void GridRebind()
		{
			Grid_TB_CONTA.CurrentPageIndex = 0;
			Grid_TB_CONTA.DataSource = null;
			Grid_TB_CONTA.Rebind();
		}


		protected void Grid_TB_CONTA_PreRender(object sender, EventArgs e)
		{
			if (Grid_TB_CONTA.MasterTableView.Items.Count == 0)
			{
				if (Grid_TB_CONTA.MasterTableView.IsItemInserted == false)
				{
					Grid_TB_CONTA.ShowHeader = false;
				}
				else
				{
					Grid_TB_CONTA.ShowHeader = true;
				}
			}
			else
			{
				Grid_TB_CONTA.ShowHeader = true;
			}
		}

		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
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
				DataProvider.SetCurrentTableSequence(Item);
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
		}
		
		public override void DisableEnableContros(bool Action)
		{
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
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
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
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
					CT_IDField = Item["CT_ID"].GetFormattedValue();
				}
				else
				{
				CT_IDField = "";
				}
			}
			catch
			{
				CT_IDField = "";
			}
			try
			{
				if (Item != null)
				{
					CT_NOMEField = Item["CT_NOME"].GetFormattedValue();
				}
				else
				{
				CT_NOMEField = "";
				}
			}
			catch
			{
				CT_NOMEField = "";
			}
			try
			{
				if (Item != null)
				{
					GC_IDField = long.Parse(Item["GC_ID"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				GC_IDField = 0;
				}
			}
			catch
			{
				GC_IDField = 0;
			}
			PageProvider.AliasVariables.Add("CT_IDField", CT_IDField);
			PageProvider.AliasVariables.Add("CT_NOMEField", CT_NOMEField);
			PageProvider.AliasVariables.Add("GC_IDField", GC_IDField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		
		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da grid
		/// </summary>
		public override GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string GridId)
		{
			GeneralDataProviderItem Item = null;
			switch (GridId)
			{
				case "Grid_TB_CONTA":
					if (PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.DataProvider.Item == null)
						Item = PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.GetDataProviderItem();
					else
						Item = PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.DataProvider.Item;
					PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.RaiseSetRelationFields(PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider, Item);
					Item.SetFieldValue(Item["CT_NOME"], PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.GridData["CT_NOME"]);
					Item.SetFieldValue(Item["GC_ID"], PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.GridData["GC_ID"]);
					PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.Validate(Item);
					}
					break;
			}

			return Item;
		}

		public override void setGridPerm()
		{
			if (!PageOperations.AllowInsert)
			{
				Grid_TB_CONTA.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
			}
			if (Grid_TB_CONTA.Columns[0] is GridEditCommandColumn && !PageOperations.AllowUpdate)
			{
				Grid_TB_CONTA.Columns[0].Visible = false;
			}
			if (Grid_TB_CONTA.Columns.Count != 0 && Grid_TB_CONTA.Columns[Grid_TB_CONTA.Columns.Count - 1] is GridButtonColumn && (Grid_TB_CONTA.Columns[Grid_TB_CONTA.Columns.Count - 1] as GridButtonColumn).CommandName == "Delete" && !PageOperations.AllowDelete)
			{
				Grid_TB_CONTA.Columns[Grid_TB_CONTA.Columns.Count - 1].Visible = false;
			}
		}

		protected void Grid_TB_CONTA_ItemCreated(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
			{
				if (Grid_TB_CONTA.Columns[0].ColumnType == "GridEditCommandColumn" && PageOperations.AllowUpdate)
				{
					if (Grid_TB_CONTA.Columns[0].HeaderStyle.Width == 20 && Grid_TB_CONTA.Columns[0].Visible == true)
					{
						Grid_TB_CONTA.Columns[0].HeaderStyle.Width = 70; 
					}
					else
					{
						Grid_TB_CONTA.Columns[0].HeaderStyle.Width = 20; 
					}
				}
				GridEditableItem editableItem = (GridEditableItem)e.Item;
				TextBox txt;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn_CT_NOME") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 146;
				txt.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn_CT_NOME_Validation]]");
				txt.Attributes.Add("data-validation-message", "Nome da conta não pode ser vazio!");
				AjaxPanel.ResponseScripts.Add("jQuery(\"#Grid_TB_CONTA\").validationEngine();");
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		private void PrepareCombo(RadComboBox cbo, string FieldTextName, string FieldValueName, GeneralDataProviderItem row, bool AutoCryptDecript)
		{
			if (row != null)
			{
				cbo.SelectedValue = row[FieldValueName].Value.ToString();
				var _text = "";
				var i = 0;
				foreach (var item in FieldTextName.Split('+'))
				{
					var _field = item.Replace("[", "").Replace("]", "").Trim();
					if (i % 2 == 0)
					{
						if (row[_field].Value != null)
						{
							if (!AutoCryptDecript)
								_text += row[_field].Value.ToString();
							else
								_text += Crypt.Decripta(row[_field].Value.ToString());
						}
					}
					else
					{
						_text += _field.Substring(1, 1);
					}
					i++;
				}
				cbo.Text = _text;
			}
			cbo.Attributes.Add("AllowFilter", "False");
		}
		
		
		
		protected void Grid_TB_CONTA_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridPagerItem)
			{
				GridPagerItem pager = (GridPagerItem)e.Item;
				RadComboBox PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
				PageSizeComboBox.Visible = false;
				Label ChangePageSizeLabel = (Label)pager.FindControl("ChangePageSizeLabel");
				ChangePageSizeLabel.Visible = false;
			}
			if (e.Item.IsInEditMode)
			{
				GridEditableItem item = (GridEditableItem)e.Item;
				if (!(item is IGridInsertItem))
				{
					Utility.SelectGridComboItem(PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.GridColumn_GC_IDProvider, item, "GridColumn_GC_ID", "GC_ID");
				}
			}
		}
		private void FillGridComboValues(string GridId, Hashtable newValues, GridTableRow item)
		{
			RadComboBox cbo;
			switch (GridId)
			{
				case "Grid_TB_CONTA":
					cbo = (RadComboBox)item.FindControl("GridColumn_GC_ID_ComboBox");
					newValues["GC_ID"] = cbo.SelectedValue;
					break;
				}
		}
		
		protected void Grid_TB_CONTA_ItemCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
			if (e.CommandName == RadGrid.InitInsertCommandName)// If insert mode, disallow edit
			{
				Grid.MasterTableView.ClearEditItems();
			}
			if (e.CommandName == RadGrid.FilterCommandName)
			{
				Grid.MasterTableView.ShowHeader = true;
				Grid.ShowGroupPanel = false;
				Grid.ShowFooter = false;
				Grid.ShowStatusBar = false;
			}
			if (e.CommandName == RadGrid.EditCommandName) // If edit mode, disallow insert
			{
				e.Item.OwnerTableView.IsItemInserted = false;
			}
			if (e.CommandName == RadGrid.ExpandCollapseCommandName) // Allow Expand/Collapse one row at a time
			{
				foreach (GridItem item in e.Item.OwnerTableView.Items)
				{
					if (item.Expanded && item != e.Item)
					{
						item.Expanded = false;
					}
				}
			}
			if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
				e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
			{
				Grid.AllowPaging = false;
				Grid.ExportSettings.IgnorePaging = true;
				Grid.ExportSettings.OpenInNewWindow = true;
			}
			if (e.Item is GridDataItem && !(e.Item is GridDataInsertItem) && e.CommandName != "Cancel" && e.CommandName != "Update" && e.CommandName != "Insert")
			{
				GeneralGridProvider Provider = GetGridProvider(Grid);
				Hashtable CurrentValues = new Hashtable();
				GridDataItem item = (GridDataItem)e.Item;
				if (e.CommandArgument != null && e.CommandArgument.ToString() != "")
				{
					int index = 0;
					if (int.TryParse(e.CommandArgument.ToString(), out index)) item = e.Item.OwnerTableView.Items[index];
				}
				item.ExtractValues(CurrentValues);
				Label lab;
				lab = item["GridColumn_GC_ID"].FindControl("GridColumn_GC_ID_Label") as Label;
				CurrentValues["GC_ID"] = lab.Attributes["Value"];
				foreach (string key in item.OwnerTableView.DataKeyNames)
				{
					if(Provider.DataProvider.Item.GetFieldAliasByFieldName(key) != "")
						CurrentValues[Provider.DataProvider.Item.GetFieldAliasByFieldName(key)] = item.GetDataKeyValue(key);
					else
						CurrentValues[key] = item.GetDataKeyValue(key);
				}
				Provider.SelectItem(this, Grid.ID, CurrentValues);
		
				switch (e.CommandName)
				{
					case "GridColumn2":
						bool ActionSucceeded_GridColumn2_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/conta");
							UrlPage += "/editar";
							try
							{
								if (!IsPostBack)
								{
									ClientScript.RegisterStartupScript(this.GetType(), "OnLinkClick_Browser", "<script>NavigateBrowser('" + UrlPage + "');</script>");
								}
								else
								{
									AjaxPanel.ResponseScripts.Add("NavigateBrowser('" + UrlPage + "');");
								}
							}
							catch(Exception ex)
							{
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn2_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
				}
			}
		}

		public override void RefreshOnNavigation()
		{
			Grid_TB_CONTA.MasterTableView.ClearEditItems();
			Grid_TB_CONTA.MasterTableView.IsItemInserted = false;
		}

		protected void Grid_Init(object sender, EventArgs e)
		{
			RadGrid Grid = (RadGrid)sender;
			GridFilterMenu menu = Grid.FilterMenu;
			int i = 0;
			while (i < menu.Items.Count)
			{
				if (menu.Items[i].Value == "Between" || menu.Items[i].Value == "NotBetween")
				{
					menu.Items.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		protected void Grid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			int TotalRecords = 0;
			string GridFilter = "";
			RadGrid Grid = (RadGrid)source;


			
			if (Grid.MasterTableView.SortExpressions.Count > 0)
			{
				string orderBy = "";
				foreach (GridSortExpression sort in Grid.MasterTableView.SortExpressions)
				{
					orderBy += GetGridProvider(Grid).DataProvider.Dao.PoeColAspas(sort.FieldName) + " " + sort.SortOrderAsString() + ", ";
				}
				GetGridProvider(Grid).DataProvider.OrderBy = orderBy.Remove(orderBy.Length - 2);
			}
			Grid.DataSource = GetGridProvider(Grid).DataProvider.SelectItems(Grid.CurrentPageIndex, Grid.PageSize, out TotalRecords);
			Grid.VirtualItemCount = TotalRecords;
		}
		 
		protected void Grid_UpdateCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Tuple<Hashtable, Hashtable> GridValues = FillGridValues(editableItem, Grid);
			FillGridComboValues(Grid.ID, GridValues.Item1, e.Item);
			GetGridProvider(Grid).UpdateItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, GridValues.Item1), GridValues.Item2);
			 if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			Grid.DataSource = null;
            Grid.Rebind();
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_InsertCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Hashtable newValues = new Hashtable();
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			FillGridComboValues(Grid.ID, newValues, e.Item);
			GetGridProvider(Grid).InsertItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, newValues));
			if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_DeleteCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
            DeleteGrid(Grid, false, (GridEditableItem)e.Item);
			if (GetGridProvider(Grid).PageErrors != null)
			{
				e.Canceled = true;
				PageErrors.Add(GetGridProvider(Grid).PageErrors);
				return;
			}
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		public override void DeleteChildItens()
        {
            base.DeleteChildItens();
        }

		public void DeleteGrid(RadGrid Grid, bool DeleteAllItems, GridEditableItem SingleItem)
        {
			int StartIndex = 0;
            if (!DeleteAllItems) StartIndex = SingleItem.ItemIndex;
            else
            {
                Grid.DataSource = null;
                Grid.CurrentPageIndex = 0;
                Grid.Rebind();
            }
            while (Grid.Items.Count != 0 && PageErrors.Count == 0)
            {
                for (int i = StartIndex; Grid.MasterTableView.Items.Count > i; i++)
                {
                    switch (Grid.ID)
                    {
					}
                    Tuple<Hashtable, Hashtable> GridValues = FillGridValues(Grid.MasterTableView.Items[i], Grid);
                    GetGridProvider(Grid).DeleteItem(this, Grid.ID, GridValues.Item1, GridValues.Item2);
					if(GetGridProvider(Grid).PageErrors != null) PageErrors.Add(GetGridProvider(Grid).PageErrors);
                    if (!DeleteAllItems) break;
                }
				Grid.DataSource = null;
				if (DeleteAllItems) Grid.CurrentPageIndex = 0;
                if (!DeleteAllItems && Grid.Items.Count == 1 && Grid.CurrentPageIndex > 0) Grid.CurrentPageIndex--;
                Grid.Rebind();
				if (!DeleteAllItems) break;
            }
		}

		private Tuple<Hashtable, Hashtable> FillGridValues(GridEditableItem editableItem, RadGrid Grid)
		{
			Hashtable newValues = new Hashtable();
			editableItem.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			Hashtable oldValues = newValues.Clone() as Hashtable;
			foreach (string key in Grid.MasterTableView.DataKeyNames)
			{
				string FdAlias = (from f in GetGridProvider(Grid).DataProvider.Item.Fields where f.Value.Name == key select f.Key).FirstOrDefault();
				if (!newValues.ContainsKey(key)) newValues.Add(key, editableItem.GetDataKeyValue(key));
				if (!oldValues.ContainsKey(FdAlias))
				{
					oldValues.Add(FdAlias, editableItem.GetDataKeyValue(key));
				}
				else
				{
					oldValues[FdAlias] = editableItem.GetDataKeyValue(key);
				}
			}
			return new Tuple<Hashtable, Hashtable>(newValues, oldValues);
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid_TB_CONTA":
					return PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider;
			}
			return null;
		}
		protected void ___Grid_TB_CONTA_GridColumn_GC_ID_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.FillCombo(PageProvider.TB_CONTA_Grid_Grid_TB_CONTAProvider.GridColumn_GC_IDProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
	}
}
