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
        public string usrUsuarios { get; set; }
        public void Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbUsuarios");

            strQuery.Append(" ( ");

            strQuery.Append(" usrNome ");
            strQuery.Append(", usrSenha ");
            strQuery.Append(", usrClientes ");
            strQuery.Append(", usrProdutos ");
            strQuery.Append(", usrUsuarios ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append(" '" + usrNome + "'");
            strQuery.Append(",'" + usrSenha + "'");
            strQuery.Append(",'" + usrClientes + "'");
            strQuery.Append(",'" + usrProdutos + "'");
            strQuery.Append(",'" + usrUsuarios + "'");

            strQuery.Append(" ); ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Alterar()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem de update
            strQuery.Append("UPDATE tbUsuarios");

            strQuery.Append(" SET ");

            strQuery.Append(" usrNome = '" + usrNome + "'");
            strQuery.Append(", usrSenha = '" + usrSenha + "'");
            strQuery.Append(", usrClientes = '" + usrClientes + "'");
            strQuery.Append(", usrProdutos = '" + usrProdutos + "'");
            strQuery.Append(", usrUsuarios = '" + usrUsuarios + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" usrCod = " + usrCod);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbUsuarios ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" usrCod = " + usrCod);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public DataSet PesquisarGrid(string Campo, string Filtro)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT usrCod Codigo, usrNome Nome, ");
            strQuery.Append(" usrClientes Clientes, usrProdutos Produtos, usrUsuarios Usuarios ");
            strQuery.Append(" FROM tbUsuarios ");
            if (Campo != string.Empty && Filtro != string.Empty)
            {
                strQuery.Append(" WHERE ");
                strQuery.Append(Campo + " LIKE '" + "%" + Filtro + "%" + "'");
            }
            strQuery.Append(" ORDER BY usrNome ");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataSet(strQuery.ToString());
        }
        //Sobrecarga de métodos é quando temos métodos com o mesmo nome mas com assinatura "argumentos" diferentes
        public SqlDataReader Pesquisar(int usrCod)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbUsuarios ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" usrCod = " + usrCod);

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
        public SqlDataReader Pesquisar(string usrNome, string usrSenha)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT usrNome, usrSenha, ");
            strQuery.Append(" usrClientes, usrProdutos, usrUsuarios ");
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