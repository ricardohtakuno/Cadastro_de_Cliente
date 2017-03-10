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
            //abre o formulário agenda
            //utilizando formulário MDI
            Form frmProduto = new frmProduto();
            frmProduto.MdiParent = this;
            frmProduto.Show();
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            //encerra o sistema
            Close();
        }
    }
}
