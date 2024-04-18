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
    public partial class frmAlterarCliente : Form
    {
        // Chamaaa a conexão 
        string _conexao = ChamadosTecnicosTec55.Properties.Settings.Default.Conexao;


        public frmAlterarCliente(int codigo)
        {
            InitializeComponent();

            //Verifica se o codigo é maior qeu zero

            if(codigo > 0)
            {
                // Cria uma instancia do objeto Cliente
                Cliente cliente = new Cliente();
                ClienteDao clienteDao = new ClienteDao(_conexao);

                cliente = clienteDao.ObtemCliente(codigo);

                // Se o cliente nao foi encontrado
                if(cliente != null )
                {
                    MessageBox.Show("Cliente nao encontrado!");
                    this.Close();
                }

                txtCod.Text = cliente.CodigoCliente.ToString();
                txtNome.Text = cliente.Nome;
                txtProfissao.Text = cliente.Profissao;
                txtSetor.Text = cliente.Setor;
                txtObs.Text = cliente.Obs;


            }




        }
    }
}
