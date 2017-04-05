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
            if (txtNome3.Text == "")
            {
                errError.SetError(lblNome3, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblNome3, "");
            }
            if (txtSenha3.Text == "")
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
            clUsuarios clUsuarios = new clUsuarios();

            //carrega as propriedades
            clUsuarios.usrNome = txtNome3.Text;
            clUsuarios.usrSenha = txtSenha3.Text;
            if (chkbClientes.Checked == true)
            {
                clUsuarios.usrClientes = "1";
            }
            else
            {
                clUsuarios.usrClientes = "0";
            }
            if (chkbProdutos.Checked == true)
            {
                clUsuarios.usrProdutos = "1";
            }
            else
            {
                clUsuarios.usrProdutos = "0";
            }
            if (chkbUsuarios.Checked == true)
            {
                clUsuarios.usrUsuarios = "1";
            }
            else
            {
                clUsuarios.usrUsuarios = "0";
            }
            if (chkbFornecedores.Checked == true)
            {
                clUsuarios.usrFornecedores = "1";
            }
            else
            {
                clUsuarios.usrFornecedores = "0";
            }

            //variável com a string de conexão com o banco
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            if (txtCodigo3.Text == "")
            {
                clUsuarios.Gravar();
            }
            else
            {
                clUsuarios.usrCod = Convert.ToInt32(txtCodigo3.Text);
                clUsuarios.Alterar();
            }

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            Limpar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Usuário Incluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvUsuarios.DataSource = clUsuarios.PesquisarGrid(campo, txtFiltro3.Text).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }

        private void tstSair3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstExcluir3_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtCodigo3.Text == "")
            {
                return;
            }

            //pergunta para o usuário se ele confirma a exclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a exclusão do Usuário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clUsuarios clUsuarios = new clUsuarios();

            //variável com a string de conexão com o banco
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;
            clUsuarios.usrCod = Convert.ToInt32(txtCodigo3.Text);
            clUsuarios.Excluir();

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            Limpar();

            //mensagem de confirmação da exclusão
            MessageBox.Show("Usuário excluido com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Limpar()
        {

            //limpa todos os campos do formulário
            foreach (Control ctrl in grpUsuarios.Controls)
            {
                //textbox
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
                //combobox
                if (ctrl is ComboBox)
                {
                    ((ComboBox)(ctrl)).Text = string.Empty;
                }
                //maskedtextbox
                if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)(ctrl)).Text = string.Empty;
                }
            }
        }

        private void txtFiltro3_TextChanged(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            //verifica se existe itens na grid
            if (dgvUsuarios.RowCount == 0)
            {
                return;
            }

            //carrega a tela com todos os dados do cliente
            SqlDataReader drReader;
            clUsuarios clUsuarios = new clUsuarios();
            clUsuarios.banco = Properties.Settings.Default.conexaoDB;
            drReader = clUsuarios.Pesquisar(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value));

            if (drReader.Read())
            {
                //transfere os dados do banco de dados para os campos do formulário
                txtCodigo3.Text = drReader["usrCod"].ToString();
                txtNome3.Text = drReader["usrNome"].ToString();
                txtSenha3.Text = drReader["usrSenha"].ToString();
                if (Convert.ToBoolean(drReader["usrClientes"].ToString()) == true)
                {
                    chkbClientes.Checked = true;
                }
                else
                {
                    chkbClientes.Checked = false;
                }
                if (Convert.ToBoolean(drReader["usrProdutos"].ToString()) == true)
                {
                    chkbProdutos.Checked = true;
                }
                else
                {
                    chkbProdutos.Checked = false;
                }
                if (Convert.ToBoolean(drReader["usrUsuarios"].ToString()) == true)
                {
                    chkbUsuarios.Checked = true;
                }
                else
                {
                    chkbUsuarios.Checked = false;
                }

                //habilita o frame e envia o cursor para o campo nome
                tabControl1.SelectedTab = tabPage2;
                txtNome3.Focus();
            }
            drReader.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }

        private void frmUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
