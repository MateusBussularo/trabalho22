using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trabalho2
{
    public partial class Form4 : Form
    {
        public Form4()
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
        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("CPF",  "senha");

            usuario.prontuario = Int32.Parse(textBox3.Text);
            usuario.Cpf = maskedTextBox1.Text;
            usuario.Senha = textBox2.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.UpdateUsuario(usuario);

            UpdateListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox3.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeletUsuario(id);
            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            maskedTextBox1.Text = listView1.Items[index].SubItems[1].Text;
            textBox2.Text = listView1.Items[index].SubItems[2].Text;
            textBox3.Text = listView1.Items[index].SubItems[0].Text;

        }
    }
}
