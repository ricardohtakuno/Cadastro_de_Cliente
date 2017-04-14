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

namespace Dados_do_Cliente
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            PesquisarCEP(mskCEP.Text);

        }

        private void frmAgenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstSalvar_Click(object sender, EventArgs e)
        {
            //validação do conteúdo
            if (txtNome.Text == "")
            {
                errError.SetError(lblNome, "Campo Obrigatório");
                return;
            }
            else
            {
                errError.SetError(lblNome, "");
            }

            //pergunta para o usuário se ele confirma a inclusão do cadastro
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma a inclusão/alteração?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clClientes clClientes = new clClientes();

            //carrega as propriedades
            clClientes.cliNome = txtNome.Text;
            clClientes.cliEndereco = txtEndereco.Text;
            clClientes.cliNumero = txtNumero.Text;
            clClientes.cliBairro = txtBairro.Text;
            clClientes.cliCidade = txtCidade.Text;
            clClientes.cliEstado = cboEstado.Text;
            clClientes.cliCEP = mskCEP.Text;
            clClientes.cliCelular = mskCelular.Text;
            clClientes.cliCPF = mskCPF.Text;

            //variável com a string de conexão com o banco
            clClientes.banco = Properties.Settings.Default.conexaoDB;

            //chama o método gravar
            if (txtCodigo.Text == "")
            {
                clClientes.Gravar();
            }
            else
            {
                clClientes.cliCodigo = Convert.ToInt32(txtCodigo.Text);
                clClientes.Alterar();
            }

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Cliente Incluído/Alterado com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void PesquisarCEP(string CEP)
        {
            //pesquisa de CEP
            DataSet ds = new DataSet();

            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
            ds.ReadXml(xml);
            if (ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep completo" || ds.Tables[0].Rows[0]["resultado_txt"].ToString() == "sucesso - cep único")
            {
                txtEndereco.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString() + " " + ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                cboEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                txtNumero.Focus();
            }
            else
            {
                MessageBox.Show("CEP não Encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            resposta = MessageBox.Show("Confirma a exclusão do cliente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resposta.Equals(DialogResult.No))
            {
                return;
            }

            //instancia a classe de negócio
            clClientes clClientes = new clClientes();

            //variável com a string de conexão com o banco
            clClientes.banco = Properties.Settings.Default.conexaoDB;
            clClientes.cliCodigo = Convert.ToInt32(txtCodigo.Text);
            clClientes.Excluir();

            //atualiza o datagridview
            Pesquisar();

            //limpa a tela
            limpar();

            //mensagem de confirmação da exclusão
            MessageBox.Show("Cliente excluido com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void limpar()
        {
            //limpa todos os campos do formulário
            foreach (Control ctrl in grpClientes.Controls)
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //chama o método pesquisar
            Pesquisar();
        }
        private void Pesquisar()
        {
            string campo = "";

            //seleciona o campo de pesquisa
            if (cboOpcao.Text == "CÓDIGO")
            {
                campo = "cliCodigo";
            }
            else if (cboOpcao.Text == "NOME")
            {
                campo = "cliNome";
            }
            else if (cboOpcao.Text == "CELULAR")
            {
                campo = "cliCelular";
            }

            //carrega o datagridview com os clientes cadastrados
            clClientes clClientes = new clClientes();
            clClientes.banco = Properties.Settings.Default.conexaoDB;
            dgvClientes.DataSource = clClientes.Pesquisar(campo, txtFiltro.Text).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            //verifica se existe itens na grid
            if (dgvClientes.RowCount == 0)
            {
                return;
            }

            //carrega a tela com todos os dados do cliente
            SqlDataReader drReader;
            clClientes clClientes = new clClientes();
            clClientes.banco = Properties.Settings.Default.conexaoDB;
            drReader = clClientes.PesquisarCodigo(Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value));

            if (drReader.Read())
            {
                //transfere os dados do banco de dados para os campos do formulário
                txtCodigo.Text = drReader["cliCodigo"].ToString();
                txtNome.Text = drReader["cliNome"].ToString();
                txtEndereco.Text = drReader["cliEndereco"].ToString();
                txtNumero.Text = drReader["cliNumero"].ToString();
                txtBairro.Text = drReader["cliBairro"].ToString();
                txtCidade.Text = drReader["cliCidade"].ToString();
                cboEstado.Text = drReader["cliEstado"].ToString();
                mskCEP.Text = drReader["cliCEP"].ToString();
                mskCelular.Text = drReader["cliCelular"].ToString();

                //habilita o frame e envia o cursor para o campo nome
                tabControl1.SelectedTab = tabPage2;
                txtNome.Focus();
            }
            drReader.Close();
        }   
        
        private void btnValidar_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            string valor = mskCPF.Text;
            if (ValidaçãoCPF.IsCpf(valor))
            {
                mensagem = "O número é um CPF válido!";
            }
            else
            {
                mensagem = "O número é um CPF invalido!";
            }
            MessageBox.Show(mensagem, "Validação");
        }

    }
}
