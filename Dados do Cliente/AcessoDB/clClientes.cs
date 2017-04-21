using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class clClientes
    {
        //propiedades
        public string banco { get; set; }
        public int cliCodigo { get; set; }
        public string cliNome { get; set; }
        public string cliEndereco { get; set; }
        public string cliNumero { get; set; }
        public string cliBairro { get; set; }
        public string cliCidade { get; set; }
        public string cliEstado { get; set; }
        public string cliCEP { get; set; }
        public string cliCelular { get; set; }
        public string cliCPF { get; set; }
        public void Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbClientes");

            strQuery.Append(" ( ");

            strQuery.Append(" cliNome ");
            strQuery.Append(", cliEndereco ");
            strQuery.Append(", cliNumero ");
            strQuery.Append(", cliBairro ");
            strQuery.Append(", cliCidade ");
            strQuery.Append(", cliEstado ");
            strQuery.Append(", cliCEP ");
            strQuery.Append(", cliCelular ");
            strQuery.Append(", cliCPF ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append("'" + cliNome + "'");
            strQuery.Append(",'" + cliEndereco + "'");
            strQuery.Append(",'" + cliNumero + "'");
            strQuery.Append(",'" + cliBairro + "'");
            strQuery.Append(",'" + cliCidade + "'");
            strQuery.Append(",'" + cliEstado + "'");
            strQuery.Append(",'" + cliCEP + "'");
            strQuery.Append(",'" + cliCelular + "'");
            strQuery.Append(",'" + cliCPF + "'");

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
            strQuery.Append("UPDATE tbClientes");

            strQuery.Append(" SET ");

            strQuery.Append(" cliNome = '" + cliNome + "'");
            strQuery.Append(", cliEndereco = '" + cliEndereco + "'");
            strQuery.Append(", cliNumero = '" + cliNumero + "'");
            strQuery.Append(", cliBairro = '" + cliBairro + "'");
            strQuery.Append(", cliCidade = '" + cliCidade + "'");
            strQuery.Append(", cliEstado = '" + cliEstado + "'");
            strQuery.Append(", cliCEP = '" + cliCEP + "'");
            strQuery.Append(", cliCelular = '" + cliCelular + "'");
            strQuery.Append(", cliCPF = '" + cliCPF + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" cliCodigo = " + cliCodigo);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbClientes ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" cliCodigo = " + cliCodigo);

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
            strQuery.Append(" FROM tbClientes ");
           if (Campo != string.Empty && Filtro != string.Empty)
            {
                strQuery.Append(" WHERE ");
                strQuery.Append(Campo + " LIKE '" + "%" + Filtro + "%" + "'");
            }
            strQuery.Append(" ORDER BY cliNome ");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataSet(strQuery.ToString());
        }
        public SqlDataReader PesquisarCodigo(int cliCodigo)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbClientes ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" cliCodigo = " + cliCodigo);

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
        public SqlDataReader PesquisarCPF(string CPF)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbClientes ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" cliCPF = '" + CPF + "'");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
        public SqlDataReader CarregarClientes()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT cliNome ");
            strQuery.Append(" FROM tbClientes ");
            strQuery.Append(" ORDER BY cliNome ");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
        public SqlDataReader PesquisarEndereco(string cliNome)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT cliEndereco ");
            strQuery.Append(" FROM tbClientes ");
            strQuery.Append(" WHERE cliNome = '" + cliNome + "'");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
    }
}
