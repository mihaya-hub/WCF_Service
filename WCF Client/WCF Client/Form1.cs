using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace WCF_Client
{
    public partial class Form1 : Form
    {
        IWCFContract channel;

        public Form1()
        {
            InitializeComponent();
        }

        private void WCFServiceConnect()
        {
            ChannelFactory<IWCFContract> factory = new ChannelFactory<IWCFContract>();

            string address = "net.tcp://localhost:8080/myAddress";

            factory.Endpoint.Address = new EndpointAddress(address);

            factory.Endpoint.Binding = new NetTcpBinding();

            factory.Endpoint.Contract.ContractType = typeof(IWCFContract);

            channel = factory.CreateChannel();
        }

        private void WCFServiceClose()
        {
            ((ICommunicationObject)channel).Close();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();

                WCFServiceConnect();

                byte[] data = channel.ReadDatabase();
                DataTable dataTable = (DataTable)DataPacket.Deserialize(data);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    dataGridView1.Rows.Add(row.ItemArray);
                }

                WCFServiceClose();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count != 1) return;

                WCFServiceConnect();

                string values = "";
                DataGridViewRow row = dataGridView1.SelectedCells[0].OwningRow;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    values += "'" + row.Cells[i].Value.ToString();
                    if (i + 1 != row.Cells.Count) values += "', ";
                    else values += "'";
                }

                if (channel.InsertDatabase(values))
                {
                    MessageBox.Show("입력 되었습니다.");
                }
                else
                {
                    MessageBox.Show("입력 실패");
                }

                WCFServiceClose();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count != 1) return;

                WCFServiceConnect();

                string values = "";
                DataGridViewRow row = dataGridView1.SelectedCells[0].OwningRow;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    values += row.Cells[i].OwningColumn.Name + " = '" + row.Cells[i].Value.ToString();
                    if (i + 1 != row.Cells.Count) values += "', ";
                    else values += "' WHERE name = '" + row.Cells["name"].Value + "'";
                }

                if (channel.UpdateDatabase(values))
                {
                    MessageBox.Show("수정 되었습니다.");
                }
                else
                {
                    MessageBox.Show("수정 실패");
                }

                WCFServiceClose();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count != 1) return;

                WCFServiceConnect();

                DataGridViewRow row = dataGridView1.SelectedCells[0].OwningRow;

                if (channel.DeleteDatabase((string)row.Cells["name"].Value))
                {
                    dataGridView1.Rows.Remove(row);
                    MessageBox.Show("삭제 되었습니다.");
                }
                else
                {
                    MessageBox.Show("삭제 실패");
                }

                WCFServiceClose();
            }
            catch
            {
                MessageBox.Show("연결 실패");
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
    }
}