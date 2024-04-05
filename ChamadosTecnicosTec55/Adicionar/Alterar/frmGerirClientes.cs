﻿using Data;
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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //para buscar cliente pode ser tambem:
            //if(txbBuscar.text != "")
            //{
            //ListarCliente();
            //}

            //else
            //{
            //MessageBox.Show("Digite algo para buscar");
            //}


                {
                    string pesquisa = txtBusca.Text;
                    string query = "SELECT * FROM Clientes WHERE Nome like @pesquisa"; 

                    try
                    {
                        using (var conexaoBd = new SqlConnection(_conexao))
                        using (var comando = new SqlCommand(query, conexaoBd))
                        using (var adaptador = new SqlDataAdapter(comando))
                        {
                            string parametroPesquisa = $"%{pesquisa}%";
                            comando.Parameters.AddWithValue("@pesquisa", parametroPesquisa);
                            conexaoBd.Open();
                            var dsClientes = new DataSet();
                            adaptador.Fill(dsClientes, "Clientes");

                       
                            dgv1.DataSource = dsClientes.Tables["Clientes"];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                
            }
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender, e);
            }

        }
    }
}


