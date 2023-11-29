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

namespace trabalho2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.prontuario.ToString());
                item.SubItems.Add(usuario.Cpf);
                item.SubItems.Add(usuario.Senha);

                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(maskedTextBox1.Text, textBox1.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            if (usuarioDAO.Loginuser(usuario))
            {
                MessageBox.Show("Login bem-sucedido!",
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("CPF ou senha incorretos!",
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
