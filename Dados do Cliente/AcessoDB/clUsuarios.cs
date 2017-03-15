using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class clUsuarios
    {
        //propridades
        public string banco { get; set; }
        public int usrCod { get; set; }
        public string usrNome { get; set; }
        public string usrSenha { get; set; }
        public string usrClientes { get; set; }
        public string usrProdutos { get; set; }

        public SqlDataReader Pesquisar(string usrNome, string usrSenha)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT usrNome, usrSenha ");
            strQuery.Append(" FROM tbUsuarios ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" usrNome = '" + usrNome + "'");
            strQuery.Append(" AND ");
            strQuery.Append(" usrSenha = '" + usrSenha + "'");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
    }
}