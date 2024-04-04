using ChamadosTecnicosTec55.Adicionar;
using ChamadosTecnicosTec55.Adicionar.Alterar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamadosTecnicosTec55
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            coresFormulario();
        }

        private void tecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formtecnico = new frmTecnicoAdicionar();
            // Define o Formulario pai
            formtecnico.MdiParent = this;
            formtecnico.Show();
        }

        private void fecharSoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("Você deseja sair mesmo???", "Sistema de Chamados", MessageBoxButtons.YesNo);
            if(msgbox == DialogResult.Yes) 
            { 
            Application.Exit();
            }
           
        }
        private void documentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo {FileName = @"https://www.tjsecurity.com.br/",UseShellExecute = true});
               
        }
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }
        public void coresFormulario()
        {
            foreach(Control ctrl in this.Controls)
            {
                try
                {
                    if (ctrl is MdiClient)
                    {
                        ctrl.BackColor = System.Drawing.Color.AliceBlue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
         
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formcliente = new frmAdicionarCliente();
            // Define o Formulario pai
            formcliente.MdiParent = this;
            formcliente.Show();
        }

        private void gestorDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formgestorcliente = new frmGerirClientes(); 
            // Define o Formulario pai
            formgestorcliente.MdiParent = this;
            formgestorcliente.Show();
        }
    }
}


