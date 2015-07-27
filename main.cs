using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace UserDB
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Database=userdb;Uid=root;password=;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand comand = conn.CreateCommand();
            comand.CommandText = "SELECT * FROM users";

            try {
                conn.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message+ "\n\nНет соединения с сервером");
            }
            MySqlDataReader reader = comand.ExecuteReader();

            

            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0} {1} | {2}", reader["f_name"], reader["l_name"], reader["post"]));
            }
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first_name = f_name.Text;
            string last_name = l_name.Text;
            string c_city = city.Text;
            string c_post = post.Text;
            string c_birth = birth.Text;
            



            string connString = "Server=localhost;Database=userdb;Uid=root;password=;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand comand = conn.CreateCommand();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nОбратитесь к вашему системному администратору");
            }

            comand.CommandText = "INSERT INTO users (id, f_name, l_name, city, post, birth) VALUES (NULL ,@first_name, @last_name, @c_city, @c_post, @c_birth)";
            comand.Parameters.AddWithValue("@f_name", first_name);
            comand.Parameters.AddWithValue("@l_name", last_name);
            comand.Parameters.AddWithValue("@c_city", c_city);
            comand.Parameters.AddWithValue("@с_post", c_post);
            comand.Parameters.AddWithValue("@с_birth", c_birth);
           
            try {
                comand.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
                //INSERT INTO  `userdb`.`users` (`id` ,`f_name` ,`l_name` ,`city` ,`post` ,`birth`)VALUES(NULL, 'Юрий', 'Бабанин', 'Новосибирск', 'Бухгалтер', '1995');

            //Добавить оклад и сделать его вывод в таблицу

            //listBox1.Items.Add(first_name + " " + last_name + " " + c_post + " " + c_h);
        }

        private void Setup(object sender, KeyEventArgs e)
        {
            if (f_name.Text == "/admin" && l_name.Text == "admin")
            {
                MessageBox.Show("ЗДЕСЬ БУДУТ НАСТРОЙКИ!");
                f_name.Clear();
                l_name.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = listBox1.SelectedItem.ToString();
             //ce = selected.ToArray;
            MessageBox.Show(selected);
        }
    }
}
