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
	public partial class TB_CENTRO_DE_CUSTO_Grid : GeneralDataPage
	{
		protected TB_CENTRO_DE_CUSTO_GridPageProvider PageProvider;
	

		public long CC_IDField = 0;
		public string CC_NOMEField = "";
		
		public override string FormID { get { return "34739"; } }
		public override string TableName { get { return "TB_CENTRO_DE_CUSTO"; } }
		public override string DatabaseName { get { return "Treinamento"; } }
		public override string PageName { get { return "TB_CENTRO_DE_CUSTO_Grid.aspx"; } }
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
			PageProvider = new TB_CENTRO_DE_CUSTO_GridPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}

		public override void GridRebind()
		{
			Grid_TB_CENTRO_DE_CUSTO.CurrentPageIndex = 0;
			Grid_TB_CENTRO_DE_CUSTO.DataSource = null;
			Grid_TB_CENTRO_DE_CUSTO.Rebind();
		}


		protected void Grid_TB_CENTRO_DE_CUSTO_PreRender(object sender, EventArgs e)
		{
			if (Grid_TB_CENTRO_DE_CUSTO.MasterTableView.Items.Count == 0)
			{
				if (Grid_TB_CENTRO_DE_CUSTO.MasterTableView.IsItemInserted == false)
				{
					Grid_TB_CENTRO_DE_CUSTO.ShowHeader = false;
				}
				else
				{
					Grid_TB_CENTRO_DE_CUSTO.ShowHeader = true;
				}
			}
			else
			{
				Grid_TB_CENTRO_DE_CUSTO.ShowHeader = true;
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
					CC_IDField = long.Parse(Item["CC_ID"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				CC_IDField = 0;
				}
			}
			catch
			{
				CC_IDField = 0;
			}
			try
			{
				if (Item != null)
				{
					CC_NOMEField = Item["CC_NOME"].GetFormattedValue();
				}
				else
				{
				CC_NOMEField = "";
				}
			}
			catch
			{
				CC_NOMEField = "";
			}
			PageProvider.AliasVariables.Add("CC_IDField", CC_IDField);
			PageProvider.AliasVariables.Add("CC_NOMEField", CC_NOMEField);
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
				case "Grid_TB_CENTRO_DE_CUSTO":
					if (PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.DataProvider.Item == null)
						Item = PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.GetDataProviderItem();
					else
						Item = PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.DataProvider.Item;
					PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.RaiseSetRelationFields(PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider, Item);
					Item.SetFieldValue(Item["CC_NOME"], PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.GridData["CC_NOME"]);
					PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider.Validate(Item);
					}
					break;
			}

			return Item;
		}

		public override void setGridPerm()
		{
			if (!PageOperations.AllowInsert)
			{
				Grid_TB_CENTRO_DE_CUSTO.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
			}
			if (Grid_TB_CENTRO_DE_CUSTO.Columns[0] is GridEditCommandColumn && !PageOperations.AllowUpdate)
			{
				Grid_TB_CENTRO_DE_CUSTO.Columns[0].Visible = false;
			}
			if (Grid_TB_CENTRO_DE_CUSTO.Columns.Count != 0 && Grid_TB_CENTRO_DE_CUSTO.Columns[Grid_TB_CENTRO_DE_CUSTO.Columns.Count - 1] is GridButtonColumn && (Grid_TB_CENTRO_DE_CUSTO.Columns[Grid_TB_CENTRO_DE_CUSTO.Columns.Count - 1] as GridButtonColumn).CommandName == "Delete" && !PageOperations.AllowDelete)
			{
				Grid_TB_CENTRO_DE_CUSTO.Columns[Grid_TB_CENTRO_DE_CUSTO.Columns.Count - 1].Visible = false;
			}
		}

		protected void Grid_TB_CENTRO_DE_CUSTO_ItemCreated(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
			{
				if (Grid_TB_CENTRO_DE_CUSTO.Columns[0].ColumnType == "GridEditCommandColumn" && PageOperations.AllowUpdate)
				{
					if (Grid_TB_CENTRO_DE_CUSTO.Columns[0].HeaderStyle.Width == 20 && Grid_TB_CENTRO_DE_CUSTO.Columns[0].Visible == true)
					{
						Grid_TB_CENTRO_DE_CUSTO.Columns[0].HeaderStyle.Width = 70; 
					}
					else
					{
						Grid_TB_CENTRO_DE_CUSTO.Columns[0].HeaderStyle.Width = 20; 
					}
				}
				GridEditableItem editableItem = (GridEditableItem)e.Item;
				TextBox txt;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn_CC_NOME") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				txt.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn_CC_NOME_Validation]]");
				txt.Attributes.Add("data-validation-message", "Nome do centro de custos0 não pode ser vazio!");
				AjaxPanel.ResponseScripts.Add("jQuery(\"#Grid_TB_CENTRO_DE_CUSTO\").validationEngine();");
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		
		
		protected void Grid_TB_CENTRO_DE_CUSTO_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridPagerItem)
			{
				GridPagerItem pager = (GridPagerItem)e.Item;
				RadComboBox PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
				PageSizeComboBox.Visible = false;
				Label ChangePageSizeLabel = (Label)pager.FindControl("ChangePageSizeLabel");
				ChangePageSizeLabel.Visible = false;
			}
		}
		
		protected void Grid_TB_CENTRO_DE_CUSTO_ItemCommand(object source, GridCommandEventArgs e)
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
							string UrlPage = ResolveUrl("~/centro-de-custo");
							UrlPage += "/editar";
							UrlPage += "/" + (Convert.ToInt32(Provider.DataProvider.Item["CC_ID"].GetValue())).ToString();
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
			Grid_TB_CENTRO_DE_CUSTO.MasterTableView.ClearEditItems();
			Grid_TB_CENTRO_DE_CUSTO.MasterTableView.IsItemInserted = false;
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
				case "Grid_TB_CENTRO_DE_CUSTO":
					return PageProvider.TB_CENTRO_DE_CUSTO_Grid_Grid_TB_CENTRO_DE_CUSTOProvider;
			}
			return null;
		}
	}
}
