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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void tstSalva3_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (lblSenha3.Text == "")
            {
                errError.SetError(lblSenha3, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblSenha3, "");
            }

            //pergunta para o usuário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clUsuarios clProduto = new clUsuarios();

            //carrega as propriedades
            clUsuarios. = txtNome3.Text;
            clUsuarios. = txtSenha3.Text;

            //variável com a string de conexão com o banco
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            if (txtCodigo3.Text == "")
            {
                clUsuarios.Gravar();
            }
            else
            {
                clUsuarios. = Convert.ToInt32(txtCodigo3.Text);
                clUsuarios.Alterar();
            }

            //atualiza o datagridview
            

            //limpa a tela
            limpar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Produto Incluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void Pesquisar()
        {
            string campo = "";

            //seleciona o campo de pesquisa
            if (cboOpcao3.Text == "Codigo")
            {
                campo = "usrCod";
            }
            else if (cboOpcao3.Text == "Nome")
            {
                campo = "usrNome";
            }

            //carrega o datagridview com os clientes cadastrados
            clUsuarios clUsuarios = new clUsuarios();
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;
            dgvUsuarios.DataSource = clUsuarios.Pesquisar(campo, txtFiltro3.Text).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }
    }
}
