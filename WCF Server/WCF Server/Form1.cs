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
using System.ServiceModel;

namespace WCF_Server
{
    public partial class Form1 : Form
    {
        ServiceHost host;

        public Form1()
        {
            InitializeComponent();
            ServerState.Text = "Service Stop";
        }

        private void ServerStart_Click(object sender, EventArgs e)
        {
            try
            {
                string address = "net.tcp://localhost:8080/myAddress";

                NetTcpBinding binding = new NetTcpBinding();

                host = new ServiceHost(typeof(WCFService));

                host.AddServiceEndpoint(typeof(IWCFContract), binding, address);

                host.Open();

                ServerState.Text = "Service Start";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServiceStop_Click(object sender, EventArgs e)
        {
            try
            {
                host.Close();

                ServerState.Text = "Service Stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    [ServiceContract]
    public interface IWCFContract
    {
        [OperationContract]
        byte[] ReadDatabase();
        [OperationContract]
        bool InsertDatabase(string values);
        [OperationContract]
        bool UpdateDatabase(string values);
        [OperationContract]
        bool DeleteDatabase(string name);
    }

    public class WCFService : IWCFContract
    {
        public byte[] ReadDatabase()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=student;Uid=root;Pwd=Kuroneko82?!");
            string query = "SELECT * FROM student";

            connection.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            connection.Close();

            return DataPacket.Serialize(dataTable);
        }

        public bool InsertDatabase(string values)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost;Database=student;Uid=root;Pwd=Kuroneko82?!");
                string query = "INSERT INTO student (grade, cclass, no, name, score) VALUES (" + values + ")";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDatabase(string values)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost;Database=student;Uid=root;Pwd=Kuroneko82?!");
                string query = "UPDATE student SET " + values;

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDatabase(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost;Database=student;Uid=root;Pwd=Kuroneko82?!");
                string query = "DELETE FROM student WHERE name = '" + name + "'";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
