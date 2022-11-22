using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PROJETO;
using PROJETO.AccessControl;
using PROJETO.DataProviders;
using COMPONENTS;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using COMPONENTS.Data;
using System.Text;
using System.Xml;
using Telerik.Web.UI;


namespace PROJETO
{

	public partial class Access : System.Web.UI.Page
	{
		public string TxtLoginNameField
		{
			get
			{
				return RadTextBox10.Text;
			}
		}
		
		public string txtUserNameField
		{
			get
			{
				return txtUserName.Text;
			}
		}
		

		private GMembershipProvider vgMembership = ((GMembershipProvider)Membership.Providers["GMembershipProvider"]);
		private Site SiteConfig = new Site();
		private Hashtable _ErrorList;
		private string vgGrupoLogado;
		public LoginGroupItem CurrentGroup;
		public string ProjectID { get { return "A439855"; } }

		/// <summary>
		/// Lista de erros que devem ser mostrados
		/// </summary>
		public Hashtable ErrorList
		{
			get
			{
				return _ErrorList;
			}
			set
			{
				_ErrorList = value;
			}
		}
		protected override void OnInit(EventArgs e)
		{
			if (!IsPostBack)
			{
			}
			base.OnInit(e);
		}
		
		protected override void InitializeCulture()
		{
			Utility.SetThreadCulture();
		}		

		/// <summary>
		/// DeclaraÃ§ao de variaveis e implementação de estilo na pagina
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			ErrorList = new Hashtable();
			ShowError();
			Utility.CheckAuthentication(this);
			if (!IsPostBack)
			{
				ClearGroupChecks();
				FillGroupsListBox();
				FillGridAccess();
				RadTextBox21.Focus();

				EnableGroupButtons(false, false, true, true);
				EnableUserButtons(false, false, true, true);
				EnablePasswordButtons(true, true);
			}
			vgGrupoLogado = HttpContext.Current.Session["vgGroupID"].ToString();
			CurrentGroup = vgMembership.GetGroupByID(vgGrupoLogado);
			if (CurrentGroup != null)
			{
				if (!(bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					ListBox15.Enabled = false;
					ListBox16.Enabled = false;
					RadTextBox10.Enabled = false;
					txtUserName.Enabled = false;
					txtPassword.Enabled = false;
					txtPasswordConfirm.Enabled = false;
					txtObservation.Enabled = false;
					EnableUserButtons(false, false, false, false);

					ListBox13.Enabled = false;
					RadTextBox24.Enabled = false;
					RadCheckBox6.Enabled = false;
					ListBox14.Enabled = false;
					CheckBox10.Enabled = false;
					CheckBox8.Enabled = false;
					CheckBox7.Enabled = false;
					CheckBox9.Enabled = false;

					EnableGroupButtons(false, false, false, false);
				}
			}
		}
		

		/// <summary>
		/// Coloca os textbox checados ou nao de acordo com o grupo e pagina passado no parametro
		/// </summary>
		/// <param name="vgGrupoId">Id do grupo que esta selecionado</param>
		/// <param name="vgPaginaNome">Nome da pagina selecionada</param>
		public void SetGroupChecks(string vgGrupoId, string vgPaginaNome)
		{
			CheckBox7.Checked = vgMembership.TestIfCanSee(ProjectID, vgGrupoId, vgPaginaNome);
			CheckBox8.Checked = vgMembership.TestIfCanEdit(ProjectID, vgGrupoId, vgPaginaNome);
			CheckBox10.Checked = vgMembership.TestIfCanAdd(ProjectID, vgGrupoId, vgPaginaNome);
			CheckBox9.Checked = vgMembership.TestIfCanRemove(ProjectID, vgGrupoId, vgPaginaNome);
		}

		/// <summary>
		/// Limpa todos os campos para fazer um insert ou algo do tipo
		/// </summary>
		public void ClearGroupChecks()
		{
			CheckBox7.Checked = false;
			CheckBox8.Checked = false;
			CheckBox10.Checked = false;
			CheckBox9.Checked = false;

			CheckBox7.Enabled = false;
			CheckBox8.Enabled = false;
			CheckBox10.Enabled = false;
			CheckBox9.Enabled = false;

			ListBox14.SelectedIndex = -1;
		}

		/// <summary>
		/// Mostra os erros ocorridos na pagina em relaÃ§ao a banco de dados
		/// </summary>
		public void ShowError()
		{
			string vgText = "";
			foreach (string vgKey in ErrorList.Keys)
			{
				vgText += ErrorList[vgKey].ToString() + "<br />";
			}
			Label69.Visible = true;
			Label69.Text = vgText;
		}

		/// <summary>
		/// Enche a lista de paginas com todas as paginas do xml
		/// </summary>
		private void FillGridAccess()
		{
			ListBox14.Items.Clear();
			XmlDocument doc = new XmlDocument();
			doc.Load(Server.MapPath(@"~/Xmls/") + "pages.xml");

			foreach (XmlNode mPage in doc.FirstChild.NextSibling.ChildNodes)
			{
			    RadListBoxItem Li = new RadListBoxItem();
				Li.Value = mPage.Attributes["Name"].Value;
				Li.Text = mPage.Attributes["Title"].Value;
				ListBox14.Items.Add(Li);
			}
		}

		/// <summary>
		/// Enche a lista de usuarios de acordo com o grupo escolhido
		/// </summary>
		private void FillUserListBox()
		{
			ListBox16.Items.Clear();
            if (ListBox15.SelectedItem == null) return;			
			DataTable dt = vgMembership.GetAllUsersByGroup(ListBox15.SelectedItem.Value);
			
			foreach (DataRow dr in dt.Rows)
			{
				RadListBoxItem li = new RadListBoxItem(Crypt.Decripta(dr[GMembershipProvider.Default.UserLoginField].ToString()), dr[GMembershipProvider.Default.UserLoginField].ToString());
				li.Value = dr["LOGIN_USER_LOGIN"].ToString();
				ListBox16.Items.Add(li);
			}
		}

		/// <summary>
		/// Enche a list de grupos com os grupos que estao no banco
		/// </summary>
		private void FillGroupsListBox()
		{
			FillGroupsListBox(false);
		}

		/// <summary>
		/// Enche a list de grupos com os grupos que estao no banco
		/// </summary>
		private void FillGroupsListBox(bool JustUser)
		{
			if (!JustUser) ListBox13.Items.Clear();
			ListBox15.Items.Clear();
			DataTable dt = vgMembership.GetAllGroups();
			foreach (DataRow dr in dt.Rows)
			{
				RadListBoxItem li = new RadListBoxItem(Crypt.Decripta(dr[GMembershipProvider.Default.GroupNameField].ToString()), dr[GMembershipProvider.Default.GroupIdField].ToString());
				RadListBoxItem li2 = new RadListBoxItem(Crypt.Decripta(dr[GMembershipProvider.Default.GroupNameField].ToString()), dr[GMembershipProvider.Default.GroupIdField].ToString());
				if (!JustUser) ListBox13.Items.Add(li);
				ListBox15.Items.Add(li2);
			}
		}

		/// <summary>
		/// Decripta o registo que veio do banco de acordo com o nome do campo
		/// </summary>
		/// <param name="Ds">Data set com os registros</param>
		/// <param name="FieldName"></param>
		private void DecryptDataSetField(ref DataSet Ds, string FieldName)
		{
			foreach (DataRow Dr in Ds.Tables[0].Rows)
			{
				Dr[FieldName] = Crypt.Decripta(Dr[FieldName].ToString());
			}
		}

		/// <summary>
		/// ao mudar de grupo selecionado ele coloca as permissÃµes e arruma a toolbar de acordo com o grupo escolhido
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ChangedGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					LoginGroupItem item = vgMembership.GetGroupByID(ListBox13.SelectedItem.Value);
			
					if ((bool)item.Fields["IsAdmin"].Value)
					{
						ListBox14.Enabled = false;
						CheckBox10.Enabled = false;
						CheckBox8.Enabled = false;
						CheckBox9.Enabled = false;
						CheckBox7.Enabled = false;
						CheckBox10.Checked = false;
						CheckBox8.Checked = false;
						CheckBox9.Checked = false;
						CheckBox7.Checked = false;
						RadCheckBox6.Checked = true;
                        if (item.Fields["Name"].Value.ToString() != CurrentGroup.Fields["Name"].Value.ToString())
						{
                            RadCheckBox6.Enabled = true;
                            EnableGroupButtons(true, true, true, true);
						}
						else
						{
                            RadCheckBox6.Enabled = false;
                            EnableGroupButtons(false, false, false, true);
						}
						RadTextBox24.Text = Crypt.Decripta(item.Fields["Name"].GetFormattedValue());
						RadTextBox24.Focus();
					}
					else
					{
						ListBox14.Enabled = true;
						CheckBox10.Enabled = false;
						CheckBox8.Enabled = false;
						CheckBox9.Enabled = false;
						CheckBox7.Enabled = false;
						EnableGroupButtons(true, true, true, true);
						RadTextBox24.Text = Crypt.Decripta(item.Fields["Name"].GetFormattedValue());
						RadCheckBox6.Checked = (bool)item.Fields["IsAdmin"].Value;
						RadCheckBox6.Enabled = true;
						RadTextBox24.Focus();
						ChangedPagesPermission();
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// Troca a senha do usuário que está logado
		/// </summary>
		public void ChangeUserPassword()
		{
			if (vgMembership.ValidateUser(Crypt.Decripta(HttpContext.Current.Session["vgUserLogin"].ToString()), RadTextBox21.Text.ToUpper()) == true)
			{
				if (RadTextBox22.Text != "")
				{
					if (RadTextBox23.Text != "")
					{
						if (RadTextBox22.Text.ToUpper() == RadTextBox23.Text.ToUpper())
						{
							vgMembership.ChangePassword(Crypt.Decripta(HttpContext.Current.Session["vgUserLogin"].ToString()), "", RadTextBox22.Text.ToUpper());
							OpenAlert("Salvo com sucesso!");
						}
						else
						{
							ErrorList.Add("ConfirmTrcaSenhaErrada", "Confirmação de senha invalida!");
						}
					}
					else
					{
						ErrorList.Add("SenhaAtualErrada", "Confirmação de senha tem que ser preenchida!");
					}
				}
				else
				{
					ErrorList.Add("SenhaAtualErrada", "Senha nova tem que ser preenchida!");
				}
			}
			else
			{
				if (RadTextBox21.Text != "")
				{
					ErrorList.Add("SenhaAtualErrada", "Senha atual errada!");
				}
				else
				{
					ErrorList.Add("SenhaAtualErrada", "Senha atual tem que ser preenchida!");
				}
			}
			ShowError();
		}

		/// <summary>
		/// Abre uma janela com uma mensagem
		/// </summary>
		/// <param name="text">mensagem a ser escrita no alert</param>
		public void OpenAlert(string text)
		{
			AjaxPanel1.ResponseScripts.Add("alert('" + text + "');");
		}

		/// <summary>
		/// Cancela a mudanÃ§a de senha
		/// </summary>
		private void CancelPasswordChanges()
		{
			RadTextBox21.Text = "";
			RadTextBox22.Text = "";
			RadTextBox23.Text = "";
		}

		/// <summary>
		/// Efetiva a nova senha
		/// </summary>
		private void SavePasswordChanges()
		{
			ChangeUserPassword();
		}

		public void UpdateGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					LoginGroupItem item = new LoginGroupItem();
					item.Fields["Name"].SetValue(Crypt.Encripta(RadTextBox24.Text));
					item.Fields["Id"].SetValue(ListBox13.SelectedValue);

					item.Fields["IsAdmin"].SetValue(RadCheckBox6.Checked);
			
					ListBox13.Items[ListBox13.SelectedIndex].Text = RadTextBox24.Text;

					ListBox13.Items[ListBox13.SelectedIndex].Value = Crypt.Encripta(RadTextBox24.Text);
					FillGroupsListBox(true);
					vgMembership.UpdateGroup(item);
				}
			}
			catch
			{
			
			}
		}
		private void SaveGroupChanges()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ViewState["Insert"] == null || (bool)ViewState["Insert"] == false)
					{
						UpdateGroup();
						if (ListBox14.SelectedItem != null)
						{
							LoginGroupItem item = new LoginGroupItem();
							FillGroupsListBox();
							InsertPageAccess(ListBox14.SelectedItem.Value, Crypt.Encripta(RadTextBox24.Text));
							SetGroupChecks(ListBox13.SelectedValue, ListBox14.SelectedItem.Value);
						}
					}
					else
					{
						CreateGroup();
						ClearGroupChecks();
						ViewState["Insert"] = false;
					}
					ViewState["SalvaPaginas"] = true;
					ShowError();
				}
			}
			catch
			{
			}
		}

		private void RemoveGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ListBox13.SelectedValue != "")
					{
						DeleteGroup();
						ClearGroupChecks();
					}
				}
			}
			catch
			{
			
			}
		}

		private void InsertGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					ViewState["Insert"] = true;
					RadTextBox24.Enabled = true;
					EnableGroupButtons(true, true, false, false);
					ListBox13.Enabled = false;
					RadTextBox24.Focus();
					RadTextBox24.Text = "";
					RadCheckBox6.Checked = false;
				}
			}
			catch
			{
			}
		}

		private void CancelGroupChanges()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ListBox14.SelectedItem != null)
					{
						SetGroupChecks(ListBox13.SelectedValue, ListBox14.SelectedItem.Value);
					}
					ViewState["SalvaPaginas"] = true;
					ViewState["Insert"] = false;
					EnableGroupButtons(false, false, true, true);
					ListBox13.Enabled = true;
				}
			}
			catch
			{
			
			}
		}

		private void SaveUserChanges()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ViewState["IncluiUsuario"] != null && (bool)ViewState["IncluiUsuario"] == true)
					{
						CreateUser();
					}
					else if (ListBox16.SelectedIndex >= 0)
					{
						UpdateUser();
					}
					ShowError();
				}
			}
			catch
			{
			}
		}

		private void RemoveUser()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ListBox16.SelectedValue != "")
					{
						DeleteUser();
					}
					ViewState["IncluiUsuario"] = false;
				}
			}
			catch
			{
			}
		}

		private void InsertUser()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					RadTextBox10.Focus();
					EnableUserButtons(true, true, false, false);
					ListBox16.Enabled = false;
					ListBox15.Enabled = false;
					RadTextBox10.Text = "";
					txtPasswordConfirm.Text = "";
					txtPassword.Text = "";
					txtObservation.Text = "";
					txtUserName.Text = "";
					ListBox16.SelectedIndex = -1;
					ViewState["IncluiUsuario"] = true;
					txtPasswordConfirm.Enabled = true;
					RadTextBox10.Enabled = true;
					txtPassword.Enabled = true;
					txtObservation.Enabled = true;
				}
			}
			catch
			{
			}
		}
		
		private void CancelUserChanges()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					if (ViewState["IncluiUsuario"] != null && (bool)ViewState["IncluiUsuario"] == true)
					{
						RadTextBox10.Text = "";
						txtUserName.Text = "";
						txtPasswordConfirm.Text = "";
						txtPassword.Text = "";
						txtObservation.Text = "";
						ViewState["IncluiUsuario"] = false;
					}
					else if (ListBox16.SelectedIndex != -1 && ListBox16.SelectedValue != null)
					{
						LoginUserItem vgUser = vgMembership.GetUser(Crypt.Encripta(ListBox16.SelectedItem.Text));
						RadTextBox10.Text = Crypt.Decripta(vgUser.Fields["Login"].GetFormattedValue());
						txtUserName.Text = Crypt.Decripta(vgUser.Fields["Name"].GetFormattedValue());

						txtObservation.Text = Crypt.Decripta(vgUser.Fields["Obs"].GetFormattedValue());
					}
					EnableUserButtons(true, true, true, true);
					ListBox16.Enabled = true;
					ListBox15.Enabled = true;
					txtPasswordConfirm.Enabled = true;
					RadTextBox10.Enabled = true;
					txtPassword.Enabled = true;
					txtObservation.Enabled = true;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// Update um registo de usuario
		/// </summary>
		private void UpdateUser()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					string vgPass = "";
					if (txtPassword.Text != "")
					{
						if (txtPassword.Text == txtPasswordConfirm.Text)
						{


							vgPass = txtPassword.Text.ToUpper();

						}
						else
						{
							ErrorList.Add("SenhaErrada", "Confirmação de senha invalida");
							return;
						}
					}
					try
					{
						LoginUserItem item = new LoginUserItem();
						
						item.Fields["Group"].SetValue(ListBox15.SelectedValue);

						item.Fields["Login"].SetValue(Crypt.Encripta(RadTextBox10.Text));

						item.Fields["Id"].SetValue(ListBox16.SelectedValue);
						if (vgPass != "")
						{
							item.Fields["Password"].SetValue(Crypt.Encripta(vgPass));
						}
						else
						{
							LoginUserItem OldItem = vgMembership.GetUser(ListBox16.SelectedValue);
							item.Fields["Password"].SetValue(OldItem.Fields["Password"].GetFormattedValue());
						}
						item.Fields["Obs"].SetValue(Crypt.Encripta(txtObservation.Text));
						item.Fields["Name"].SetValue(Crypt.Encripta(txtUserName.Text.ToUpper()));
						vgMembership.UpdateUser(item);
						ListBox16.Items[ListBox16.SelectedIndex].Text = RadTextBox10.Text;
						ListBox16.Enabled = true;
						ListBox15.Enabled = true;
						EnableUserButtons(true, true, true, true);
					}
					catch (Exception e)
					{
						ErrorList.Add("UpdateUserError", e.Message);
					}
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// Metodo usado para inserir um grupo no banco de dados
		/// </summary>
		private void CreateGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{		
					if (RadTextBox24.Text == "")
					{
						ErrorList.Add("GrupoInvalido", "Nome do grupo tem que ser preenchido");
						return;
					}
					try
					{
						LoginGroupItem item = new LoginGroupItem();
						item.Fields["Id"].SetValue(RadTextBox24.Text);
						item.Fields["Name"].SetValue(Crypt.Encripta(RadTextBox24.Text));
						item.Fields["IsAdmin"].SetValue(RadCheckBox6.Checked);
						vgMembership.GroupProvider.DataProvider.InsertItem(item);
						FillGroupsListBox();
						FillUserListBox();
						ListBox13.SelectedValue = ListBox13.FindItemByText(RadTextBox24.Text).Value;
						ListBox15.SelectedValue = ListBox13.SelectedValue;
						ViewState["Insert"] = false;
						EnableGroupButtons(true, true, true, true);
						ListBox13.Enabled = true;
					}
					catch (Exception e)
					{
						ErrorList.Add("dadosError", e.Message);
					}
				}
			}
			catch
			{
			
			}
			
		}

		/// <summary>
		/// Exclui um grupo de usuarios e enche os lists a treview de menus de acordo com os menus q sobraram
		/// O grupo de admininstrador nao pode ser excluido
		/// </summary>
		private void DeleteGroup()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					LoginGroupItem item = vgMembership.GetGroupByID(ListBox13.SelectedItem.Value);
                 if (item.Fields["Name"].Value.ToString()  == CurrentGroup.Fields["Name"].Value.ToString())
					{
						ErrorList.Add("GrupoAdminExcluido", "O grupo Administrador nÃ£o pode ser excluido");
						return;
					}
					vgMembership.DeleteGroup(ListBox13.SelectedValue);
					RadTextBox24.Text = "";
					FillGroupsListBox();
					FillUserListBox();
				}
			}
			catch
			{

			}
		}
		/// <summary>
		/// Exclui usuario do banco de dados
		/// </summary>
		private void DeleteUser()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{		
					if (ListBox16.SelectedItem.Text == Crypt.Decripta(HttpContext.Current.Session["vgUserLogin"].ToString()))
					{
						ErrorList.Add("ExcluirUltimoAdmin", "Usuário corrente não pode ser excluido!");
					}
					else	
					{
						vgMembership.DeleteUser(Crypt.Encripta(ListBox16.SelectedItem.Text));
					FillUserListBox();
						txtObservation.Text = "";
						RadTextBox10.Text = "";
					}
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// Insere um usuario no banco de dados
		/// </summary>
		private void CreateUser()
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{		
					if (ListBox15.SelectedIndex == -1)
					{
						ErrorList.Add("UsuarioGrupoInvalido", "Escolha um grupo");
					}
					else
					{
					if (RadTextBox10.Text == "")
					{
						ErrorList.Add("UsuarioNomeInvalido", "Nome do Login de usuário tem que ser preenchido");
					}

					if (txtUserName.Text == "")
					{
						ErrorList.Add("UsuarioNomeInvalido", "Nome Completo do usuário tem que ser preenchido");
					}

					if (txtPassword.Text == "")
					{
						ErrorList.Add("UsuarioSenhaInvalido", "Senha do usuário tem que ser preenchido");
					}
					if (txtPasswordConfirm.Text == "")
					{
						ErrorList.Add("UsuarioCsenhaInvalido", "Confirmação de senha tem que ser preenchido");
					}
					}
					if (ErrorList.Count > 0)
					{
						return;
					}
					if (txtPassword.Text != txtPasswordConfirm.Text)
					{
						ErrorList.Add("SenhaEconfirmacaoDif", "Confirmação de senha invalida");
					}
					if (ErrorList.Count > 0)
					{
						return;
					}
					try
					{
						LoginUserItem item = new LoginUserItem();


						item.Fields["Login"].SetValue(Crypt.Encripta(RadTextBox10.Text.ToUpper()));

						item.Fields["Id"].SetValue(ListBox16.SelectedValue);



						item.Fields["Password"].SetValue(Crypt.Encripta(txtPassword.Text.ToUpper()));

						item.Fields["Group"].SetValue(ListBox15.SelectedValue);

						item.Fields["Obs"].SetValue(Crypt.Encripta(txtObservation.Text));
						item.Fields["Name"].SetValue(Crypt.Encripta(txtUserName.Text));
						if (vgMembership.CreateUser(item) == 0)
						{
							throw new Exception("Erro na criação do usuario");
						}
						FillUserListBox();
						ListBox16.Enabled = true;
						ListBox15.Enabled = true;
						ListBox16.SelectedIndex = ListBox16.Items.Count - 1;
						EnableUserButtons(false, false, true, true);
					}
					catch (Exception ex)
					{
						ErrorList.Add("ErroDeCriacao", ex.Message);
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// Habilita ou desabilita os botÃµes de grupos
		/// </summary>
		private void EnableGroupButtons(bool SaveButton, bool CancelButton, bool RemoveButton, bool AddButton)
		{
			Button26.Enabled = AddButton;
			butGroupSave3.Enabled = SaveButton;
			butGroupCancel3.Enabled = CancelButton;
			butGroupRemove3.Enabled = RemoveButton;
		}

		/// <summary>
		/// Habilita ou desabilita os botÃµes de usuarios
		/// </summary>
		private void EnableUserButtons(bool SaveButton, bool CancelButton, bool RemoveButton, bool AddButton)
		{
			butUserNew.Enabled = AddButton;
			butUserSave.Enabled = SaveButton;
			butUserCancel.Enabled = CancelButton;
			butUserRemove.Enabled = RemoveButton;
		}

		/// <summary>
		/// Habilita ou desabilita os botÃµes de senha
		/// </summary>
		private void EnablePasswordButtons(bool SaveButton, bool CancelButton)
		{
			butPWSave2.Enabled = SaveButton;
		}
		/// <summary>
		/// Coloca permissÃ£o para os grupos de acordo com a pagina 
		/// </summary>
		/// <param name="vgPagina"></param>
		/// <param name="vgGrupo"></param>
		private void InsertPageAccess(string vgPagina, string vgGrupo)
		{
			try
			{
				if (CurrentGroup != null && (bool)CurrentGroup.Fields["IsAdmin"].Value)
				{
					string ViewChecked = "1";
					string EditChecked = "1";
					string AddChecked = "1";
					string RemoveChecked = "1";
					if (CheckBox7.Checked == false)
						ViewChecked = "0";
					if (CheckBox8.Checked == false)
						EditChecked = "0";
					if (CheckBox10.Checked == false)
						AddChecked = "0";
					if (CheckBox9.Checked == false)
						RemoveChecked = "0";
					vgMembership.InsertPerm(vgGrupo, vgPagina, ViewChecked, EditChecked, AddChecked, RemoveChecked, ProjectID);
				}
			}
			catch
			{
			}
			
		}
		/// <summary>
		/// Quando mudar de grupo na pagina de inserção de usuarios mostrar os novos usuarios na list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ChangedGroupUser()
		{
			FillUserListBox();
			EnableUserButtons(false, false, true, true);
			txtPasswordConfirm.Enabled = false;
			RadTextBox10.Enabled = false;
			txtPassword.Enabled = false;
			txtObservation.Enabled = false;

			txtPasswordConfirm.Text = "";
			RadTextBox10.Text = "";
			txtPassword.Text = "";
			txtObservation.Text = "";
			txtUserName.Text = "";
		}

		/// <summary>
		/// Metodo que mostra o registro do usuario selecionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ChangedUser()
		{
			if(ListBox16.SelectedItem != null)
			{
				LoginUserItem vgUser = vgMembership.GetUser(Crypt.Encripta(ListBox16.SelectedItem.Text));
				RadTextBox10.Text = Crypt.Decripta(vgUser.Fields["Login"].GetFormattedValue());
				txtUserName.Text = Crypt.Decripta(vgUser.Fields["Name"].GetFormattedValue());
				txtObservation.Text = Crypt.Decripta(vgUser.Fields["Obs"].GetFormattedValue());
				txtPasswordConfirm.Enabled = true;
				txtPasswordConfirm.Text = "";
				txtObservation.Enabled = true;
				txtPassword.Text = "";
				RadTextBox10.Enabled = true;
				txtPassword.Enabled = true;

				ViewState["IncluiUsuario"] = false;
				EnableUserButtons(true, true, true, true);
			}
		}

		/// <summary>
		/// Metodo que coloca as permições de acordo com a página que foi clicada
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ChangedPagesPermission()
		{
			CheckBox7.Enabled = true;
			CheckBox8.Enabled = true;
			CheckBox10.Enabled = true;
			CheckBox9.Enabled = true;
			if (ViewState["UltimaPagina"] != null && ViewState["UltimaPagina"].ToString() != "" && ViewState["UltimaPagina"].ToString() != ListBox14.SelectedItem.Value)
			{
				InsertPageAccess(ViewState["UltimaPagina"].ToString(), ListBox13.SelectedValue);
			}
			ViewState["UltimaPagina"] = ListBox14.SelectedItem.Value;
			SetGroupChecks(ListBox13.SelectedValue, ListBox14.SelectedItem.Value);
		}

		protected void ___butPWSave2_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				SavePasswordChanges();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___ListBox13_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				ChangedGroup();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___Button26_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				InsertGroup();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___ListBox14_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				ChangedPagesPermission();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butGroupSave3_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				SaveGroupChanges();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butGroupRemove3_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				RemoveGroup();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butGroupCancel3_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				CancelGroupChanges();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___ListBox15_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				ChangedGroupUser();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___ListBox16_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				ChangedUser();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butUserNew_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				InsertUser();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butUserRemove_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				RemoveUser();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butUserSave_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				SaveUserChanges();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

		protected void ___butUserCancel_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				CancelUserChanges();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
			}
		}

	}
}

