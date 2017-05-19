using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clPedidos
    {
        //propriedades
        public string banco { get; set; }
        public int ID_Pedido { get; set; }
        public string Data { get; set; }
        public int Cliente { get; set; }
        public int Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbPedidos");

            strQuery.Append(" ( ");

            strQuery.Append(" Data ");
            strQuery.Append(", Cliente ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append("'" + Data + "'");
            strQuery.Append(",'" + Cliente + "'");

            strQuery.Append(" ); ");

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            return clAcessoDB.ExecutaComandoRetorno(strQuery.ToString());
        }
        public void Alterar()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem de update
            strQuery.Append("UPDATE tbPedidos");

            strQuery.Append(" SET ");

            strQuery.Append(" Data = '" + Data + "'");
            strQuery.Append(", Cliente = '" + Cliente + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" ID_Pedido = " + ID_Pedido);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbPedidos ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" ID_Pedido = " + ID_Pedido);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
    }
}
