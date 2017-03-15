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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //fecha formulário
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //verifica se o nome do usuário foi digitado
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Nome do Usuário Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                return;
            }

            //verifica se a senha do usuário foi digitado
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Senha do Usuário Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return;
            }

            //verifica se o usuário e senha existem no banco de dados
            SqlDataReader drReader;
            clUsuarios clUsuarios = new clUsuarios();
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;
            drReader = clUsuarios.Pesquisar(txtUsuario.Text, txtSenha.Text);
            if (!drReader.Read())
            {
                MessageBox.Show("Acesso Negado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //abre o formulário principal
                frmPrincipal frmPrincipal = new frmPrincipal();
                frmPrincipal.Show();
            }

            //fecha o DataReader
            drReader.Close();
        }
    }
}
