using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
   public class clProduto
    {
        //propridades
        public string banco { get; set; }
        public int proCodigo { get; set; }
        public string proDescricao { get; set; }
        public string proMarca { get; set; }
        public string proPreco { get; set; }
        public string proData { get; set; }

        public void Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbProdutos");

            strQuery.Append(" ( ");

            strQuery.Append(" proDescricao ");
            strQuery.Append(", proMarca ");
            strQuery.Append(", proPreco ");
            strQuery.Append(", proData ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append(" '" + proDescricao + "'");
            strQuery.Append(",'" + proMarca + "'");
            strQuery.Append(",'" + proPreco.Replace(",", ".") + "'");
            strQuery.Append(",'" + proData + "'");

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
            strQuery.Append("UPDATE tbProdutos");

            strQuery.Append(" SET ");

            strQuery.Append(" proDescricao = '" + proDescricao + "'");
            strQuery.Append(", proMarca = '" + proMarca + "'");
            strQuery.Append(", proPreco = '" + proPreco + "'");
            strQuery.Append(", proData = '" + proData + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" proCodigo = " + proCodigo);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbProdutos ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" proCodigo = " + proCodigo);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public DataSet Pesquisar(string Campo, string Filtro)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbProdutos ");
            if (Campo != string.Empty && Filtro != string.Empty)
            {
                strQuery.Append(" WHERE ");
                strQuery.Append(Campo + " LIKE '" + "%" + Filtro + "%" + "'");
            }
            strQuery.Append(" ORDER BY proDescricao ");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataSet(strQuery.ToString());
        }
        public SqlDataReader PesquisarCodigo(int proCodigo)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbProdutos ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" proCodigo = " + proCodigo);

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
    }
}
