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
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtNomeDaEmpresa.Text == "")
            {
                errError.SetError(lblNomeDaEmpresa, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblNomeDaEmpresa, "");
            }

            //pergunta para o usuário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão/alteração?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clFornecedores clFornecedores = new clFornecedores();

            //carrega as propriedades
            clFornecedores.NomeDaEmpresa = txtNomeDaEmpresa.Text;
            clFornecedores.NomeDoContato = txtNomeDoContato.Text;
            clFornecedores.Endereco = txtEndereco.Text;
            clFornecedores.Bairro = txtBairro.Text;
            clFornecedores.Cidade = txtCidade.Text;
            clFornecedores.Estado = cboEstado.Text;
            clFornecedores.CEP = mskCEP.Text;
            clFornecedores.Telefone = mskTelefone.Text;

            //variável com a string de conexão com o banco
            clFornecedores.banco = Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            if (txtCodigo.Text == "")
            {
                clFornecedores.Gravar();
            }
            else
            {
                clFornecedores.CodigoFornecedor = Convert.ToInt32(txtCodigo.Text);
                clFornecedores.Alterar();
            }

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Fornecedor Incluído/Alterado com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstExcluir_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtCodigo.Text == "")
            {
                return;
            }

            //pergunta para o usuário se ele confirma a exclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a exclusão do Fornecedor?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clFornecedores clFornecedores = new clFornecedores();

            //variável com a string de conexão com o banco
            clFornecedores.banco = Properties.Settings.Default.conexaoDB;
            clFornecedores.CodigoFornecedor = Convert.ToInt32(txtCodigo.Text);
            clFornecedores.Excluir();

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da exclusão
            MessageBox.Show("Fornecedor excluido com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        public void PesquisarCEP(string CEP)
        {
            //pesquisa de CEP
            DataSet ds = new DataSet();

            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
            ds.ReadXml(xml);
            if (ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep completo" || ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep único")
            {
                txtEndereco.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString() + " " + ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["Bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["Cidade"].ToString();
                cboEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                txtNumero.Focus();
            }
            else
            {
                MessageBox.Show("CEP não Encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void limpar()
        {
            //limpa todos os campos do formulário
            foreach (Control ctrl in grpFornecedor.Controls)
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

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }
        public void Pesquisar()
        {
            string campo = "";

            //seleciona o campo de pesquisa
            if (cboOpcao4.Text == "CÓDIGO")
            {
                campo = "CodigoFornecedor";
            }
            else if (cboOpcao4.Text == "NOME DA EMPRESA")
            {
                campo = "NomeDaEmpresa";
            }
            else if (cboOpcao4.Text == "TELEFONE")
            {
                campo = "Telefone";
            }

            //carrega o datagridview com os clientes cadastrados
            clFornecedores clFornecedores = new clFornecedores();
            clFornecedores.banco = Properties.Settings.Default.conexaoDB;
            dgvFornecedor.DataSource = clFornecedores.Pesquisar(campo, txtFiltro4.Text).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvFornecedor.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }

        private void dgvFornecedor_DoubleClick(object sender, EventArgs e)
        {
            //verifica se existe itens na grid
            if (dgvFornecedor.RowCount == 0)
            {
                return;
            }

            //carrega a tela com todos os dados do cliente
            SqlDataReader drReader;
            clFornecedores clFornecedores = new clFornecedores();
            clFornecedores.banco = Properties.Settings.Default.conexaoDB;
            drReader = clFornecedores.PesquisarCodigo(Convert.ToInt32(dgvFornecedor.CurrentRow.Cells[0].Value));

            if (drReader.Read())
            {
                //transfere os dados do banco de dados para os campos do formulário
                txtCodigo.Text = drReader["CodigoFornecedor"].ToString();
                txtNomeDaEmpresa.Text = drReader["NomeDaEmpresa"].ToString();
                txtEndereco.Text = drReader["Endereco"].ToString();
                txtNumero.Text = drReader["Numero"].ToString();
                txtBairro.Text = drReader["Bairro"].ToString();
                txtCidade.Text = drReader["Cidade"].ToString();
                cboEstado.Text = drReader["Estado"].ToString();
                mskCEP.Text = drReader["CEP"].ToString();
                mskTelefone.Text = drReader["Telefone"].ToString();

                //habilita o frame e envia o cursor para o campo nome
                tabControl1.SelectedTab = tabPage2;
                txtNomeDaEmpresa.Focus();
            }
            drReader.Close();
        }

        private void txtFiltro4_TextChanged(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            PesquisarCEP(mskCEP.Text);
        }
    }
}
