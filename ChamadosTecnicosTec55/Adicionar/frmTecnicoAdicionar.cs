using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamadosTecnicosTec55.Adicionar
{
    public partial class frmTecnicoAdicionar : Form
    {
        // Chamaaa a conexão 
        string _conexao = ChamadosTecnicosTec55.Properties.Settings.Default.Conexao;

        public frmTecnicoAdicionar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txbNome.Clear();
            txbEspecialidade.Clear();
            txbEmail.Clear();
            txbSenha.Clear();
            txbObs.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Chama o objeto Cliente
            Tecnico tecnico = new Tecnico();
            TecnicoDao tecnicodao = new TecnicoDao(_conexao);

            if (string.IsNullOrWhiteSpace(txbNome.Text) || string.IsNullOrWhiteSpace(txbObs.Text) || string.IsNullOrWhiteSpace(txbEspecialidade.Text) || string.IsNullOrWhiteSpace(txbSenha.Text) || string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                MessageBox.Show("CADE OS DADOSSS ??");
            }
            else
            {
                //TODA VEZ QUE MEXER  COM BD USAR TRU
                try
                {
                    //PREENCHER  O OBJETO CLIENTE
                    tecnico.Nome = txbNome.Text;
                    tecnico.Especialidade = txbEspecialidade.Text;
                    tecnico.Email = txbEmail.Text;
                    tecnico.Senha = txbEmail.Text;
                    tecnico.Obs = txbObs.Text;

                    //Chama o DAO para incluir o cliente
                    tecnicodao.IncluiTecnico(tecnico);

                    MessageBox.Show(" Cadastrado com sucesso!!!! ");

                    this.Close();

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao Cadrastrar" + ex, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


