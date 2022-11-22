using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;

namespace PROJETO
{
	public static class SequenceUtility
	{
		private static DatabaseConfig Dc;

		public static string SessionID
		{
			get
			{
				if (HttpContext.Current.Session["SESSION_ID"] == null)
				{
					HttpContext.Current.Session["SESSION_ID"] = (System.Web.HttpContext.Current.Session.SessionID + Guid.NewGuid().ToString()).Substring(0, 30);
				}
				return HttpContext.Current.Session["SESSION_ID"].ToString();
			}
		}

		public static string IndexFormat(string Str, params string[] Parameters)
		{
			int Index = 0;
			int Pos = -1;
			while((Pos = Str.IndexOf("{#}")) != -1)
			{
				Str = Str.Substring(0, Pos) + Parameters[Index] + Str.Substring(Pos + 3);
				Index++;
			}
			return Str;		
		}

		public static string PegaSequencia(string Banco, string Tabela, string Campo, object ValorPadrao, int Sequencia)
		{
			string Value = "";

			if (ValorPadrao != null && !string.IsNullOrEmpty(ValorPadrao.ToString())) Value = ValorPadrao.ToString();

			if (string.IsNullOrEmpty(Value.Trim())) Value = Sequencia.ToString();

			if (Dc == null)
			{
				Dc = new DatabaseConfig(HttpContext.Current.Server.MapPath("~/Databases/"));
				Dc.LoadXmlFile();
			}
			
			string FDType = Dc.DataBases[Banco].Tables[Tabela].Fields[Campo].Type;
			string FDMask = Dc.DataBases[Banco].Tables[Tabela].Fields[Campo].Masc;
			int FDsize = Dc.DataBases[Banco].Tables[Tabela].Fields[Campo].Size;

			if (FDMask == null) FDMask = "";

			DataAccessObject dao = Utility.GetDAO(Banco);

			DataTable SeqTab = dao.RunSql(IndexFormat("SELECT TOP 1 * FROM [SYS~Sequencial] WHERE [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' ", Tabela, Campo)).Tables[0];

			int ret;
			if (SeqTab.Rows.Count == 0)
			{
				ret = dao.ExecuteNonQuery(IndexFormat("INSERT INTO [SYS~Sequencial] " +
															"([PW~Projeto], [SYS~Tabela], [SYS~Campo], [SYS~Valor], [SYS~ValorAnterior], [SYS~Estacao], [SYS~Identificacao], [SYS~Pendentes]) VALUES ('', '{#}', '{#}', '{#}', '{#}', '{#}', '{#}', {#})", 
															Tabela, Campo, Value, "", HttpContext.Current.Server.MachineName, SessionID, "1"));
				if (ret == 0) throw new Exception("Error getting sequence");
			}
			else
			{
				string CurrentValue = SeqTab.Rows[0]["SYS~Valor"].ToString();
				if (string.IsNullOrEmpty(CurrentValue))
				{
					Value = Sequencia.ToString();
				}
				else
				{
					if (FDType == "Data" || FDType =="Data/Hora")
					{
						if (CurrentValue.IndexOf('.') != -1)
						{
							Value = Convert.ToDateTime(CurrentValue.Substring(0, CurrentValue.IndexOf('.'))).AddDays(Sequencia).ToString();
						}
						else
						{
							Value = Convert.ToDateTime(CurrentValue).AddDays(Sequencia).ToString();

						}
					}
					else
					{
						Value = (Convert.ToInt32(CurrentValue) + 1).ToString();
					}
				}
					
				string S = IndexFormat("UPDATE [SYS~Sequencial] SET [SYS~ValorAnterior] = [SYS~Valor] WHERE  [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' ", Tabela, Campo);
                ret = dao.ExecuteNonQuery(S);

                S = IndexFormat("UPDATE [SYS~Sequencial] SET [SYS~Valor] = '{#}', [SYS~Pendentes] = [SYS~Pendentes] + 1, [SYS~Estacao] = '{#}', [SYS~Identificacao] = '{#}' WHERE  [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' ", Value, HttpContext.Current.Server.MachineName, SessionID, Tabela, Campo);
                ret = dao.ExecuteNonQuery(S);
														
				if (ret == 0) throw new Exception("Error updating sequence");
			}
			if (FDMask.Equals(new string('9', FDsize)))
			{
				Value = Value.PadLeft(FDsize, '0');
			}
			else if (FDMask.Equals(new string('#', FDsize)))
			{
				Value = Value.PadLeft(FDsize, ' ');
			}
			return Value;
		}

		public static void ConfirmaSequencia(string Banco, string Tabela, string Campo)
		{

			DataAccessObject dao = Utility.GetDAO(Banco);

			DataTable SeqTab = dao.RunSql(IndexFormat("SELECT TOP 1 * FROM [SYS~Sequencial] WHERE [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' AND [SYS~Pendentes] > 0 ", Tabela, Campo)).Tables[0];

			if (SeqTab.Rows.Count > 0)
			{
				dao.ExecuteNonQuery(IndexFormat("UPDATE [SYS~Sequencial] SET [SYS~Pendentes] = [SYS~Pendentes] - 1 WHERE [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' AND [SYS~Pendentes] > 0 ", Tabela, Campo));
			}
		}

		public static void VoltaSequencia(string Banco, string Tabela, string Campo)
		{

			DataAccessObject dao = Utility.GetDAO(Banco);

			DataTable SeqTab = dao.RunSql(IndexFormat("SELECT TOP 1 * FROM [SYS~Sequencial] WHERE [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' ", Tabela, Campo)).Tables[0];

			if (SeqTab.Rows.Count > 0)
			{
				string Upd = "";
				if (SeqTab.Rows[0]["SYS~Estacao"].Equals(HttpContext.Current.Server.MachineName) && SeqTab.Rows[0]["SYS~Identificacao"].Equals(SessionID))  //foi a própria estação
				{
					Upd = ", [SYS~Valor] = [SYS~ValorAnterior], [SYS~Identificacao] = ''";
				}
				dao.ExecuteNonQuery(IndexFormat("UPDATE [SYS~Sequencial] SET [SYS~Pendentes] = [SYS~Pendentes] - 1{#} WHERE [SYS~Tabela] = '{#}' AND [SYS~Campo] = '{#}' AND [SYS~Pendentes] > 0 ", Upd, Tabela, Campo));
			}
		}

	}
}
