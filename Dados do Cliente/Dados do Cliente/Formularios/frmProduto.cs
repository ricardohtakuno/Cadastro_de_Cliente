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
            clProduto.Gravar();

            //mensagem de confirmação da inclusão
            MessageBox.Show("Produto Incluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tstSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
