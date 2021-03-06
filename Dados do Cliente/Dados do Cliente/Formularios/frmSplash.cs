﻿using System;
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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //oculta o formulário de splash
            Hide();

            //desativa o timer
            timer1.Enabled = false;

            //cria a instância do formulário de login
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            //muda o ponteiro do mouse
            UseWaitCursor = true;
        }
    }
}
