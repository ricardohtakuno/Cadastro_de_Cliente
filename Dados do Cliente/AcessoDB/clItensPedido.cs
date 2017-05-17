using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clItensPedido
    {
        //propriedades
        public string banco { get; set; }
        public int ID_Item { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Produto { get; set; }
        public string Qtde { get; set; }
        public string Unitario { get; set; }
        public string Subtotal { get; set; }
        public void Gravar()
        {
            //variável utilizada para "concatenar" texto de forma estruturada
            StringBuilder strQuery = new StringBuilder();

            //montagem do INSERT
            strQuery.Append("INSERT INTO tbItensPedido");

            strQuery.Append(" ( ");

            strQuery.Append(" ID_Pedido ");
            strQuery.Append(", ID_Produto ");
            strQuery.Append(", Qtde ");
            strQuery.Append(", Unitario ");
            strQuery.Append(", Subtotal ");

            strQuery.Append(" ) ");

            strQuery.Append(" VALUES ( ");

            strQuery.Append("'" + ID_Pedido + "'");
            strQuery.Append(",'" + ID_Produto + "'");
            strQuery.Append(",'" + Qtde.Replace(",", ".") + "'");
            strQuery.Append(",'" + Unitario.Replace(",", ".") + "'");
            strQuery.Append(",'" + Subtotal.Replace(",", ".") + "'");
            
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
            strQuery.Append("UPDATE tbItensPedido");

            strQuery.Append(" SET ");

            strQuery.Append(" ID_Pedido = '" + ID_Pedido + "'");
            strQuery.Append(", ID_Produto = '" + ID_Produto + "'");
            strQuery.Append(", Qtde = '" + Qtde.Replace(",", ".") + "'");
            strQuery.Append(", Unitario = '" + Unitario.Replace(",", ".") + "'");
            strQuery.Append(", Subtotal = '" + Subtotal.Replace(",", ".") + "'");

            strQuery.Append(" WHERE ");

            strQuery.Append(" ID_Item = " + ID_Item);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
        public void Excluir()
        {
            StringBuilder strQuery = new StringBuilder();

            //montagem do delete
            strQuery.Append(" DELETE FROM tbItensPedido ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" ID_Item = " + ID_Item);

            //instancia a classe clAcessoDB e executa o comando
            clAcessoDB clAcessoDB = new clAcessoDB();
            clAcessoDB.vConexao = banco;
            clAcessoDB.ExecutaComando(strQuery.ToString());
        }
    }
}
