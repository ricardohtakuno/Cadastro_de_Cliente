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
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtDescricao.Text == "")
            {
                errError.SetError(lblDescricao, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblDescricao, "");
            }

            //pergunta para o usuário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clProduto clProduto = new clProduto();

            //carrega as propriedades
            clProduto.proDescricao = txtDescricao.Text;
            clProduto.proMarca = txtMarca.Text;

            //tratamento de campo numérico
            decimal Preco;

            if (decimal.TryParse(txtPreco.Text, out Preco))
            {
                clProduto.proPreco = Convert.ToString(Preco);
            }
            else
            {
                clProduto.proPreco = "0";
            }

            //tratamento dp campo data
            clProduto.proData = String.Format("{0:yyyy-MM-dd}", dtpData.Value);

            //variável com a string de conexão com o banco
            clProduto.banco = Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            if (txtCodigo2.Text == "")
            {
                clProduto.Gravar();
            }
            else
            {
                clProduto.proCodigo = Convert.ToInt32(txtCodigo2.Text);
                clProduto.Alterar();
            }

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Produto Incluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstExcluir_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtCodigo2.Text == "")
            {
                return;
            }

            //pergunta para o usuário se ele confirma a exclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a exclusão do produto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clProduto clProduto = new clProduto();

            //variável com a string de conexão com o banco
            clProduto.banco = Properties.Settings.Default.conexaoDB;
            clProduto.proCodigo = Convert.ToInt32(txtCodigo2.Text);
            clProduto.Excluir();

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da exclusão
            MessageBox.Show("Produto excluido com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void limpar()
        {
            //limpa todos os campos do formulário
            foreach (Control ctrl in grpProdutos.Controls)
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

        private void txtFiltro2_TextChanged(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }
        public void Pesquisar()
        {
            string campo = "";

            //seleciona o campo de pesquisa
            if (cboOpcao2.Text == "Codigo")
            {
                campo = "proCodigo";
            }
            else if (cboOpcao2.Text == "Descricao")
            {
                campo = "proDescricao";
            }
            else if (cboOpcao2.Text == "Marca")
            {
                campo = "proMarca";
            }

            //carrega o datagridview com os clientes cadastrados
            clProduto clProduto = new clProduto();
            clProduto.banco = Properties.Settings.Default.conexaoDB;
            dgvProdutos.DataSource = clProduto.Pesquisar(campo, txtFiltro2.Text).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvProdutos.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            //verifica se existe itens na grid
            if (dgvProdutos.RowCount == 0)
            {
                return;
            }

            //carrega a tela com todos os dados do cliente
            SqlDataReader drReader;
            clProduto clProduto = new clProduto();
            clProduto.banco = Properties.Settings.Default.conexaoDB;
            drReader = clProduto.PesquisarCodigo(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[0].Value));

            if (drReader.Read())
            {
                //transfere os dados do banco de dados para os campos do formulário
                txtCodigo2.Text = drReader["proCodigo"].ToString();
                txtDescricao.Text = drReader["proDescricao"].ToString();
                txtMarca.Text = drReader["proMarca"].ToString();
                txtPreco.Text = drReader["proPreco"].ToString();

                //habilita o frame e envia o cursor para o campo nome
                tabControl1.SelectedTab = tabPage2;
                txtDescricao.Focus();
            }
            drReader.Close();
        }

        private void tstPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }

        private void frmProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
