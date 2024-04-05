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

namespace ChamadosTecnicosTec55.Adicionar.Alterar
{
    public partial class frmGerirClientes : Form
    {
        // Chamaaa a conexão 
        string _conexao = ChamadosTecnicosTec55.Properties.Settings.Default.Conexao;
        public frmGerirClientes()
        {
            InitializeComponent();
        }
        //Busca no DAO o Cliente
        private void ListarClientes()
        {
            //Chamar o Cliente DAO
            ClienteDao clientedao = new ClienteDao(_conexao);

            //Capturao valor digitado na barra texto TXB
            string busca = txtBusca.Text.ToString();

            //Chama o metodo BuscarCliente do objeto
            DataSet ds = new DataSet();
            ds = clientedao.BuscarCliente(busca);

            //Defini o datasource do DataGridView
            dgv1.DataSource = ds;

            //Define o Membro do DATASET
            dgv1.DataMember = "Clientes";

        }

        private void frmGerirClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }
    }
}
