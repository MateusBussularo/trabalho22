using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho2
{
    public partial class Form3 : Form
    {
        private int id;
        public Form3()
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
        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("CPF", "senha");

            usuario.Cpf = maskedTextBox1.Text;
            usuario.Senha = trabalho2.Senha.CalculateMD5Hash(textBox2.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.InsertUsuario(usuario);

            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            id = int.Parse(listView1.Items[index].SubItems[0].Text);
            maskedTextBox1.Text = listView1.Items[index].SubItems[1].Text;
            textBox2.Text = listView1.Items[index].SubItems[2].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
