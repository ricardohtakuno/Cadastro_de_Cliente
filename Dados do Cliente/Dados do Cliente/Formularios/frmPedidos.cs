using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Dados_do_Cliente.Formularios
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            //variável do tipo dataReader
            SqlDataReader drReader;

            //instancia a classe de clientes
            clPedidos clPedidos = new clPedidos();

            //passa a string de conexao para a classe de clientes
            clPedidos.banco = Properties.Settings.Default.conexaoDB;

            //carrega a lista de clientes
            drReader = clClientes.CarregarClientes();
            while (drReader.Read())
            {
                cboClientes.Items.Add(drReader["cliNome"].ToString());
            }

            //fecha o dataReader
            drReader.Close();
        }
    }
}
