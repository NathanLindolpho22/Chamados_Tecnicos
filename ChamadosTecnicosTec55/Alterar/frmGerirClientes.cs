using ChamadosTecnicosTec55.Adicionar;
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

namespace ChamadosTecnicosTec55.Alterar
{
    public partial class frmGerirClientes : Form
    {
        string _conexao = ChamadosTecnicosTec55.Properties.Settings.Default.Conexao;
       
        public frmGerirClientes()
        {
            InitializeComponent();

        }
        
        // Busca no DAO o Cliente
        private void ListarCliente()
        {
            // Chama o Cliente DAO 
            ClienteDao clientedao = new ClienteDao(_conexao);
            // Captura o valor digitado na barra texto TXB
            string busca = txbBuscar.Text.ToString();
            // Chama o Metodo BuscaCliente do objeto 
            DataSet ds = new DataSet();
            ds = clientedao.BuscaCliente(busca);
            // Defini o DataSource do DataGridView
            dgvCliente.DataSource = ds;
            // DEFINI O MEMBRO DO DATASET 
            dgvCliente.DataMember = "Clientes";
        }

        private void frmGerirClientes_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var frmaddCliente = new frmAdicionarCliente();
            frmaddCliente.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txbBuscar.Text != "")
            {
                ListarCliente();
            }
            else
            {
                MessageBox.Show("Digite algo para buscar");
            }
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Verifique se algum linha está selecionada no DGV
            if(dgvCliente.SelectedRows.Count > 0)
            {
                // obtém o código do cliente da linha selecionada
                int codigo = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);

                var frmAlteraCliente = new frmAlterarCliente(codigo);
                frmAlteraCliente.ShowDialog();

                // Apos a tela fechar listar os clientes cadastrados 
                ListarCliente();
            }
            else
            {
                // Exibe uma mensagem de Aviso se nenhuma linha estiver selecionada
                MessageBox.Show("Selecione um registro para alteração");
            }
        }
    }
}
