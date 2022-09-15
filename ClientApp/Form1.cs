using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string userid = tbUserId.Text;
            string password = tbPassword.Text;

            if (userid == "" || password == "")
            {
                MessageBox.Show("���̵� / ��й�ȣ�� �Է��� �ּ���.");
                if (userid == "")
                {
                    tbUserId.Focus();
                    return;
                }
                if (password == "")
                {
                    tbPassword.Focus();
                    return;
                }
            }

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();
                string query = "SELECT id FROM member WHERE userid = '"+userid+"' AND password = '"+password+"'";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    MessageBox.Show("�α��� �Ǿ����ϴ�.");
                    Form3 form = new Form3();
                    form.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("�α��ο� �����Ͽ����ϴ�.\n���̵�/��й�ȣ�� Ȯ�����ּ���.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}