using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.Data.SqlClient;

namespace Dados_do_Cliente.Formularios
{
    public partial class frmGerais : Form
    {
        public frmGerais()
        {
            InitializeComponent();
        }

        private void frmGerais_Load(object sender, EventArgs e)
        {
            //variável do tipo dataReader
            SqlDataReader drReader;

            //instancia a classe de clientes
            clClientes clClientes = new clClientes();

            //passa a string de conexao para a classe de clientes
            clClientes.banco = Properties.Settings.Default.conexaoDB;

            //carrega a lista de clientes
            drReader = clClientes.CarregarClientes();
            while (drReader.Read())
            {
                cboClientes.Items.Add(drReader["cliNome"].ToString());
            }

            //fecha o dataReader
            drReader.Close();
        }

        private void cboClientes_TextChanged(object sender, EventArgs e)
        {
            //variável do tipo dataReader
            SqlDataReader drReader;

            //instancia a classe de clientes
            clClientes clClientes = new clClientes();

            //passa a string de conexao para a classe de clientes
            clClientes.banco = Properties.Settings.Default.conexaoDB;

            //seleciona o endereço do cliente
            drReader = clClientes.PesquisarEndereco(cboClientes.Text);
            if (drReader.Read())
            {
                txtendereco.Text = drReader["cliEndereco"].ToString();
            }

            //fecha o dataReader
            drReader.Close();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            clGerais clGerais = new clGerais();
            txtTexto.Text = clGerais.RemoveAcentos(txtTexto.Text);
        }
    }
}
