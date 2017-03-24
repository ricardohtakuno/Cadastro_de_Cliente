using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dados_do_Cliente.Formularios
{
    public partial class frmPrincipal : Form
    {
        //propriedades estáticas para receber informacões vindas de outro formulário
        public static Boolean Clientes { get; set; }
        public static Boolean Produtos { get; set; }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mnuAgenda_Click(object sender, EventArgs e)
        {
            //abre o formulário agenda
            //utilizando formulário MDI
            Form frmAgenda = new frmAgenda();
            frmAgenda.MdiParent = this;
            frmAgenda.Show();
        }

        private void mnuProdutos_Click(object sender, EventArgs e)
        {
            //abre o formulário Produtos
            //utilizando formulário MDI
            Form frmProduto = new frmProduto();
            frmProduto.MdiParent = this;
            frmProduto.Show();
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            //encerra o sistema
            Application.Exit();
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            //desabilita o menus bloqueados para o usuário
            if (Clientes == false)
            {
                mnuAgenda.Enabled = false;
            }
            if (Produtos == false)
            {
                mnuProdutos.Enabled = false;
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //encerra o sistema
            Application.Exit();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            //abre o formulário Usuários
            //utilizando formulário MDI
            Form frmUsuarios = new frmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }
    }
}
