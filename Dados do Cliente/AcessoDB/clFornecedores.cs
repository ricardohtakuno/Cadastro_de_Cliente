using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clFornecedores
    {
        //propriedades
        public string banco { get; set; }
        public int CodigoFornecedor { get; set; }
        public string NomeDaEmpresa { get; set; }
        public string NomeDoContato { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public void Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbFornecedores");

            strQuery.Append(" ( ");

            strQuery.Append(" NomeDaEmpresa ");
            strQuery.Append(", NomeDoContato ");
            strQuery.Append(", Endereco ");
            strQuery.Append(", Bairro ");
            strQuery.Append(", Numero ");
            strQuery.Append(", Cidade ");
            strQuery.Append(", Estado ");
            strQuery.Append(", CEP ");
            strQuery.Append(", Telefone ");
            strQuery.Append(", CPF ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append(" '" + NomeDaEmpresa + "'");
            strQuery.Append(",'" + NomeDoContato + "'");
            strQuery.Append(",'" + Endereco + "'");
            strQuery.Append(",'" + Bairro + "'");
            strQuery.Append(",'" + Numero + "'");
            strQuery.Append(",'" + Cidade + "'");
            strQuery.Append(",'" + Estado + "'");
            strQuery.Append(",'" + CEP + "'");
            strQuery.Append(",'" + Telefone + "'");
            strQuery.Append(",'" + CPF + "'");

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
            strQuery.Append("UPDATE tbFornecedores");

            strQuery.Append(" SET ");

            strQuery.Append(" NomeDaEmpresa = '" + NomeDaEmpresa + "'");
            strQuery.Append(", NomeDoContato = '" + NomeDoContato + "'");
            strQuery.Append(", Endereco = '" + Endereco + "'");
            strQuery.Append(", Bairro = '" + Bairro + "'");
            strQuery.Append(", Numero = '" + Numero + "'");
            strQuery.Append(", Cidade = '" + Cidade + "'");
            strQuery.Append(", Estado = '" + Estado + "'");
            strQuery.Append(", Cep = '" + CEP + "'");
            strQuery.Append(", Telefone = '" + Telefone + "'");
            strQuery.Append(", CPF = '" + CPF + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" CodigoFornecedor = " + CodigoFornecedor);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbFornecedores ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" CodigoFornecedor = " + CodigoFornecedor);

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
            strQuery.Append(" FROM tbFornecedores ");
            if (Campo != string.Empty && Filtro != string.Empty)
            {
                strQuery.Append(" WHERE ");
                strQuery.Append(Campo + " LIKE '" + "%" + Filtro + "%" + "'");
            }
            strQuery.Append(" ORDER BY CodigoFornecedor ");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataSet(strQuery.ToString());
        }
        public SqlDataReader PesquisarCodigo(int CodigoFornecedor)
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do select
            strQuery.Append(" SELECT * ");
            strQuery.Append(" FROM tbFornecedores ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" CodigoFornecedor = " + CodigoFornecedor);

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
            strQuery.Append(" FROM tbFornecedores ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" CPF = '" + CPF + "'");

            //executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.RetornaDataReader(strQuery.ToString());
        }
    }
}
