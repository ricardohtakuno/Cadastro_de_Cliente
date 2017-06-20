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

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            SqlDataReader drReader;

            //verifica se foi digitado alguma coisa
            if(txtCodProduto.Text == "")
            {
                Limpar();
                return;
            }

            //verifica se foi digitado número no código do produto
            int codProd;
            if(Int32.TryParse(txtCodProduto.Text, out codProd))
            {
                codProd = Convert.ToInt32(txtCodProduto.Text);
            }
            else
            {
                MessageBox.Show("Digite somente números.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Limpar();
                txtCodProduto.Focus();
                return;
            }

            //verifica se o produto está cadastrado
            clProduto clProduto = new clProduto();
            clProduto.banco = Properties.Settings.Default.conexaoDB;
            drReader = clProduto.PesquisarCodigo(Convert.ToInt32(txtCodProduto.Text));
            if(drReader.Read())
            {
                txtDescricao.Text = drReader["proDescricao"].ToString();
                txtUnitario.Text = drReader["proPreco"].ToString();
            }
            else
            {
                Limpar();
                txtCodProduto.Focus();
            }
            drReader.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            SqlDataReader drReader;
            int CodigoCliente = 0;

            //verifica se o cliente foi selecionado
            if (cboClientes.Text == "")
            {
                MessageBox.Show("Selecione o Cliente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cboClientes.Focus();
                return;
            }

            //verifica se o produto foi digitado
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Produto Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //verifica se o subtotal está zerado
            if (txtSubtotal.Text == "0,00" || txtSubtotal.Text == "")
            {
                MessageBox.Show("SubTotal Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //instancia as classes
            clClientes clClientes = new clClientes();
            clPedidos clPedidos = new clPedidos();
            clItensPedido clItensPedido = new clItensPedido();

            //verifica se o pedido já foi salvo
            if (txtCodigo.Text == "")
            {
                //Pergunta para o usuário se ele confirma a inclusão do pedido
                DialogResult resposta;
                resposta = MessageBox.Show("Confirma a Inclusão do Pedido?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resposta.Equals(DialogResult.Yes))
                {
                    //seleciona o código do cliente
                    clClientes.banco = Properties.Settings.Default.conexaoDB;
                    drReader = clClientes.PesquisarNome(cboClientes.Text);
                    if (drReader.Read())
                    {
                        CodigoCliente = Convert.ToInt32(drReader["cliCodigo"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Cliente Inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        drReader.Close();
                        return;
                    }
                    drReader.Close();

                    //carrega as propriedades do pedido
                    clPedidos.banco = Properties.Settings.Default.conexaoDB;
                    clPedidos.Data = String.Format("{0:yyyy-MM-dd}", dtpData.Value);
                    clPedidos.Cliente = CodigoCliente;
                    txtCodigo.Text = Convert.ToString(clPedidos.Gravar());

                    //carrega as propriedades do ítem
                    clItensPedido.banco = Properties.Settings.Default.conexaoDB;
                    clItensPedido.ID_Pedido = Convert.ToInt32(txtCodigo.Text);
                    clItensPedido.ID_Produto = Convert.ToInt32(txtCodProduto.Text);
                    clItensPedido.Qtde = txtQtde.Text;
                    clItensPedido.Unitario = txtUnitario.Text;
                    clItensPedido.Subtotal = txtSubtotal.Text;
                    clItensPedido.Gravar();

                    //atualiza a lista de itens inseridos
                    CarregarItens(Convert.ToInt32(txtCodigo.Text));

                    //totaliza o pedido
                    TotalPedido();

                    //limpa os campos
                    Limpar();
                    txtCodProduto.Focus();
                }
                else
                {
                    //carrega propriedades do item
                    clItensPedido.banco = Properties.Settings.Default.conexaoDB;
                    clItensPedido.ID_Pedido = Convert.ToInt32(txtCodigo.Text);
                    clItensPedido.ID_Produto = Convert.ToInt32(txtCodProduto.Text);
                    clItensPedido.Qtde = txtQtde.Text;
                    clItensPedido.Unitario = txtUnitario.Text;
                    clItensPedido.Subtotal = txtSubtotal.Text;
                    clItensPedido.Gravar();

                    //atualiza a lista de itens inseridos
                    CarregarItens(Convert.ToInt32(txtCodigo.Text));

                    //limpa os campos
                    Limpar();
                    txtCodProduto.Focus();
                }
            }
        }
        public void CarregarItens(int Pedido)
        {
            //carrega o datagridview com os itens do pedido
            clItensPedido clItensPedido = new clItensPedido();
            clItensPedido.banco = Properties.Settings.Default.conexaoDB;
            dgvItens.DataSource = clItensPedido.Pesquisar(Pedido).Tables[0];

            //comando utilizado para gerar um efeito "zebrado" no datagridview
            dgvItens.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Limpar()
        {
            //limpa os textbox's
            txtCodProduto.Text = "";
            txtDescricao.Text = "";
            txtUnitario.Text = "";
            txtQtde.Text = "";
            txtSubtotal.Text = "";
        }
        void SubTotal()
        {
            //verifica se a quantidade é numérico
            int Quantidade;
            if (!int.TryParse(txtQtde.Text, out Quantidade))
            {
                Quantidade = 0;
            }

            //verifica se o valor unitário é numérico
            decimal ValorUnitario;
            if (!decimal.TryParse(txtUnitario.Text, out ValorUnitario))
            {
                ValorUnitario = 0;
            }

            //calcula o subtotal do ítem
            txtSubtotal.Text = Convert.ToString(Quantidade * ValorUnitario);
        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {
            SubTotal();
        }
        public void TotalPedido()
        {
            SqlDataReader drReader;

            //instancia a classe
            clItensPedido clItensPedido = new clItensPedido();
            clItensPedido.banco = Properties.Settings.Default.conexaoDB;
            drReader = clItensPedido.TotalPedido(Convert.ToInt32(txtCodigo.Text));
            if (drReader.Read())
            {
                txtSubtotal.Text = drReader["Subtotal"].ToString();
            }
            else
            {
                txtSubtotal.Text = "0,00";
            }
            drReader.Close();
        }

        private void dgvPedidos_DoubleClick(object sender, EventArgs e)
        {
            //verifica se existe itens na grid
            if (dgvPedidos.RowCount == 0)
            {
                return;
            }

            //carrega a tela com todos os dados do cliente
            SqlDataReader drReader;
            clItensPedido clItensPedido = new clItensPedido();
            clItensPedido.banco = Properties.Settings.Default.conexaoDB;
            drReader = clItensPedido.PesquisarCodigo(Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value));

            if (drReader.Read())
            {
                //transfere os dados do banco de dados para os campos do formulário
                txtCodigo.Text = drReader["ID_Item"].ToString();
                dtpData.Text = drReader["Data"].ToString();
                cboClientes.Text = drReader["cli"].ToString();
                txtNumero.Text = drReader["cliNumero"].ToString();
                txtBairro.Text = drReader["cliBairro"].ToString();
                txtCidade.Text = drReader["cliCidade"].ToString();
                cboEstado.Text = drReader["cliEstado"].ToString();
                mskCEP.Text = drReader["cliCEP"].ToString();
                mskCelular.Text = drReader["cliCelular"].ToString();
                mskCPF.Text = drReader["cliCPF"].ToString();

                //habilita o frame e envia o cursor para o campo nome
                tabControl1.SelectedTab = tabPage2;
                txtNome.Focus();
            }
            drReader.Close();
        }
    }
}
