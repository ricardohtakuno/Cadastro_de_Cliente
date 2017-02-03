using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class clAcessoDB
    {
        //variável para receber a string de conexão
        public string vConexao = "";

        //método responsável pro abrir a conexão com o banco de dados
        public SqlConnection AbreBanco()
        {
            //Abre a conexão com a Base de Dados
            SqlConnection conn = new SqlConnection(vConexao);
            conn.Open();
            return conn;
        }
        //método responsável por fechar a conexão com o banco de dados
        public void FechaBanco(SqlConnection conn)
        {
            //Fecha a conexão com a Base de Dados
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //método responsavel pro executar comandos (INSERT, UPDATE, DELETE) no banco de dados
        public void ExecutaComando(string strQuery)
        {
            //cria o objeto de conexão
            SqlConnection conn = new SqlConnection();
            try
            {
                //abre o banco de dados
                conn = AbreBanco();

                //cria o objeto de comando
                SqlCommand cmdComando = new SqlCommand();
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = conn;

                //passa os valores da query Sql, tipo do comando, conexão  e executa o comando
                cmdComando.ExecuteNonQuery();
            }
            //tratamento de excessões
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //em caso de erro ou não, o finally é executado para fechar a conexão com o banco de dados
                FechaBanco(conn);
            }
        }
    }

}

