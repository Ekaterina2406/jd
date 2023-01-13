using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace jd
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("OK!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
            $"INSERT INTO [Soobshenie202] (Kod_stancii_peredachi_informacii, Nomer_poezda, Stanciya_formirovaniya, Nomer_sostava, Kod_stancii_naznacheniya, Napravleniya_sledovaniya_poezda) VALUES (@Kod_stancii_peredachi_informacii, @Nomer_poezda, @Stanciya_formirovaniya, @Nomer_sostava, @Kod_stancii_naznacheniya, @Napravleniya_sledovaniya_poezda)", sqlConnection);

          
            command.Parameters.AddWithValue("Kod_stancii_peredachi_informacii", textBox1.Text);
            command.Parameters.AddWithValue("Nomer_poezda", textBox2.Text);
            command.Parameters.AddWithValue("Stanciya_formirovaniya", textBox3.Text);
            command.Parameters.AddWithValue("Nomer_sostava", textBox4.Text);
            command.Parameters.AddWithValue("Kod_stancii_naznacheniya", textBox5.Text);
            command.Parameters.AddWithValue("Napravleniya_sledovaniya_poezda", textBox6.Text);

            

            MessageBox.Show(command.ExecuteNonQuery().ToString());

            MessageBox.Show("ДАННЫЕ ДОБАВЛЕНЫ");
        }
    }
}
