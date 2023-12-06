using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho2
{
    public partial class Form1 : Form
    {
        public Form1()
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

       


        

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
            pictureBox1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fomr = new Form3();
            fomr.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 fomr = new Form4(); 
            fomr.Show();    
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fomr = new Form2();
            fomr.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
