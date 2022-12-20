using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        private void button1_Click(object sender, EventArgs e)
        {
           // if(text_name == "")
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(
   //   "insert into sampletbl values(" + "'" + text_name.Text + "'," + txt_age.Text + ")" + "@");


          "insert into tbl_Employee values (" + text_code.Text + ",'" + txt_name.Text
            + "','" + dtp_dob.Value.ToString() + "','" + dtp_doj.Value.ToString()
            + "','" + cmb_dpt.SelectedItem.ToString() + "','"
                + txt_reportto.Text + "','" + txt_Contact.Text + "','" + txt_resigned.Text + "','" + dtp_resignDate .Value.ToString() + "')" + "@");



            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[65536];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg(returndata);
            MessageBox.Show(returndata);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            clientSocket.Connect("127.0.0.1", 8888);
            label1.Text = "Client Socket Program - Server Connected ...";
        }
        public void msg(string mesg)
        {
            richTextBox1.Text = richTextBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // if(text_name == "")
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(
          //   "insert into sampletbl values(" + "'" + text_name.Text + "'," + txt_age.Text + ")" + "@");


          "Fetch " + txt_Code2.Text + "@");



            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[65536];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

             
            List<string> numbers = returndata.Split(',').ToList<string>();
            txt_empName2.Text = numbers[0];
            cmb_dept2.SelectedItem = numbers[1];
            txt_report2.Text =   numbers[2];
            txt_Contact2.Text = numbers[3];
            txt_resigned2.Text = numbers[4];

            MessageBox.Show(returndata);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // if(text_name == "")
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(
          //   "insert into sampletbl values(" + "'" + text_name.Text + "'," + txt_age.Text + ")" + "@");


          "update tbl_Employee set EmpName='" + txt_empName2.Text +
                        "',Department='" + cmb_dept2.SelectedItem.ToString() +
                        "',Report_To='" + txt_report2.Text +
                        "',Contact_No='" + txt_Contact2.Text +
                        "',Resigned='" + txt_resigned2.Text + 
                        "' where EmpCode="+ txt_Code2.Text +"@");


            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[65536];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            MessageBox.Show(returndata);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // if(text_name == "")
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(
          //   "insert into sampletbl values(" + "'" + text_name.Text + "'," + txt_age.Text + ")" + "@");


          "delete from tbl_Employee where EmpCode=" + txt_EmpCode3.Text + "@");


            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[65536];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            MessageBox.Show(returndata);
        }
    }
}
