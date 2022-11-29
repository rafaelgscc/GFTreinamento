using System.Collections.Generic;

namespace PROJETO
{	
	public static class ProjectControlPermissions
	{
		private static Dictionary<string, Dictionary<string, string>>  _permissions;
		
		public static Dictionary<string, Dictionary<string, string>> Permissions
		{
			get
			{
				if (_permissions == null) FillPermissions();
				return _permissions;
			}		
		}
		
		private static void FillPermissions()
		{
			_permissions = new Dictionary<string, Dictionary<string, string>>();

			// Permissões para página: ~/Pages/TB_CONFIGURACOES.aspx
			_permissions["34753"] = new Dictionary<string, string>();
			_permissions["34753"]["$TITLE$"] =  "Configurações";
			_permissions["34753"]["$NAME$"] =  "TB_CONFIGURACOES";
			_permissions["34753"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34753"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34753"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34753"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34753 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_CORRENTISTA.aspx
			_permissions["34752"] = new Dictionary<string, string>();
			_permissions["34752"]["$TITLE$"] =  "Detalhes de Correntista";
			_permissions["34752"]["$NAME$"] =  "TB_CORRENTISTA";
			_permissions["34752"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34752"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34752"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34752"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34752 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_CORRENTISTA_Grid.aspx
			_permissions["34751"] = new Dictionary<string, string>();
			_permissions["34751"]["$TITLE$"] =  "Lista de Correntista";
			_permissions["34751"]["$NAME$"] =  "TB_CORRENTISTA_Grid";
			_permissions["34751"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34751"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34751"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34751"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34751 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid_TB_CORRENTISTA
			_permissions["34751"]["$3994$"] = "Grid_TB_CORRENTISTA";
			_permissions["34751"]["$3994$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["34751"]["$3994$"];
			

			// Permissões para página: ~/Pages/TB_GRUPO_CONTA.aspx
			_permissions["34748"] = new Dictionary<string, string>();
			_permissions["34748"]["$TITLE$"] =  "Detalhes de Grupo de conta";
			_permissions["34748"]["$NAME$"] =  "TB_GRUPO_CONTA";
			_permissions["34748"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34748"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34748"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34748"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34748 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_GRUPO_CONTA_Grid.aspx
			_permissions["34747"] = new Dictionary<string, string>();
			_permissions["34747"]["$TITLE$"] =  "Lista de Grupo de conta";
			_permissions["34747"]["$NAME$"] =  "TB_GRUPO_CONTA_Grid";
			_permissions["34747"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34747"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34747"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34747"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34747 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid_TB_GRUPO_CONTA
			_permissions["34747"]["$3994$"] = "Grid_TB_GRUPO_CONTA";
			_permissions["34747"]["$3994$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["34747"]["$3994$"];
			

			// Permissões para página: ~/Pages/TB_CONTA.aspx
			_permissions["34746"] = new Dictionary<string, string>();
			_permissions["34746"]["$TITLE$"] =  "Detalhes de Conta";
			_permissions["34746"]["$NAME$"] =  "TB_CONTA";
			_permissions["34746"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34746"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34746"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34746"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34746 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_CONTA_Grid.aspx
			_permissions["34745"] = new Dictionary<string, string>();
			_permissions["34745"]["$TITLE$"] =  "Lista de Conta";
			_permissions["34745"]["$NAME$"] =  "TB_CONTA_Grid";
			_permissions["34745"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34745"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34745"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34745"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34745 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid_TB_CONTA
			_permissions["34745"]["$2479524$"] = "Grid_TB_CONTA";
			_permissions["34745"]["$2479524$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["34745"]["$2479524$"];
			

			// Permissões para página: ~/Pages/TB_CENTRO_DE_CUSTO.aspx
			_permissions["34740"] = new Dictionary<string, string>();
			_permissions["34740"]["$TITLE$"] =  "Detalhes de Centro de Custo";
			_permissions["34740"]["$NAME$"] =  "TB_CENTRO_DE_CUSTO";
			_permissions["34740"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34740"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34740"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34740"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34740 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_CENTRO_DE_CUSTO_Grid.aspx
			_permissions["34739"] = new Dictionary<string, string>();
			_permissions["34739"]["$TITLE$"] =  "Lista de Centro de Custo";
			_permissions["34739"]["$NAME$"] =  "TB_CENTRO_DE_CUSTO_Grid";
			_permissions["34739"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34739"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34739"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34739"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34739 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid_TB_CENTRO_DE_CUSTO
			_permissions["34739"]["$3994$"] = "Grid_TB_CENTRO_DE_CUSTO";
			_permissions["34739"]["$3994$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["34739"]["$3994$"];
			

			// Permissões para página: ~/Pages/TB_CARTEIRA.aspx
			_permissions["34738"] = new Dictionary<string, string>();
			_permissions["34738"]["$TITLE$"] =  "Detalhes de Carteira";
			_permissions["34738"]["$NAME$"] =  "TB_CARTEIRA";
			_permissions["34738"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34738"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34738"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34738"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34738 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_CARTEIRA_Grid.aspx
			_permissions["34737"] = new Dictionary<string, string>();
			_permissions["34737"]["$TITLE$"] =  "Lista de Carteira";
			_permissions["34737"]["$NAME$"] =  "TB_CARTEIRA_Grid";
			_permissions["34737"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["34737"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["34737"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["34737"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 34737 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid_TB_CARTEIRA
			_permissions["34737"]["$3994$"] = "Grid_TB_CARTEIRA";
			_permissions["34737"]["$3994$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["34737"]["$3994$"];
			

			// Permissões para página: ~/Pages/LoginPage.aspx
			_permissions["33240"] = new Dictionary<string, string>();
			_permissions["33240"]["$TITLE$"] =  "Login";
			_permissions["33240"]["$NAME$"] =  "LoginPage";
			_permissions["33240"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 33240 (AspxModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/HomeAspx.aspx
			_permissions["34735"] = new Dictionary<string, string>();
			_permissions["34735"]["$TITLE$"] =  "Home";
			_permissions["34735"]["$NAME$"] =  "HomeAspx";
			_permissions["34735"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 34735 (AspxModule) - Controle: Form1
			

			// Permissões para página: ~/Pages Administrativa/ErrorPage.aspx
			_permissions["1305"] = new Dictionary<string, string>();
			_permissions["1305"]["$TITLE$"] =  "Página de erro";
			_permissions["1305"]["$NAME$"] =  "ErrorPage";
			_permissions["1305"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 1305 (AspxModule) - Controle: Form1
			

		}
	
	}
}
