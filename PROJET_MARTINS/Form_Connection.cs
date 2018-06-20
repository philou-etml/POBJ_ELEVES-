using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Projet_Bataille_Navale
{
    public partial class Form_Connection : Form
    {
        public delegate void ReceiverD();
        public ReceiverD myDelegate;
        int Compteur_Ticks = 100;
        bool TimeOutStatus = true;
        bool sendshearch = true;
        string message;
       
        Form_popupconnection popupconnection_Form = new Form_popupconnection();
       

        public Form_Connection()
        {
            // public delegate void ReceiverD();
            //public ReceiverD myDelegate;
            string UserName;
            UserName = Environment.UserName;
            InitializeComponent();
            lblSelectPort.Text = "Selection Port";
            lblUsername.Text = "Joueur: " + UserName;
            btnConnect.Text = "Connexion";
            string[] ports = SerialPort.GetPortNames();
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;
            myDelegate = new ReceiverD(read_Serial_buffer);

           
        


    }

        private void Form_Connection_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                // Configuration du port
                serialPort1.PortName = (string)cboPortNames.SelectedItem;
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;

                serialPort1.Open();

                timer1.Start();

                popupconnection_Form.ShowDialog();

                ShearchForPlayer();
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            message = serialPort1.ReadLine();
            lblUsername.Text = message;
            //listBox1.Invoke(myDelegate);
        }
        private void read_Serial_buffer ()
        {
            //listBox1.Items.Add(serialPort1.ReadExisting());
            //popupconnection_Form.ChangeText(message);
        }

        public void Close_Connection()
        {
            serialPort1.Close();
        }

        private void ShearchForPlayer()
        {
            bool connected = false;
            //serialPort1.Write("123456!");
            while ((connected == false) && (TimeOutStatus == true))
            {
                connected = LookForConnection();
            }
            if (connected)
            {               
                timer1.Stop();
                popupconnection_Form.CloseConnectionPopUp();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if (Compteur_Ticks > 0)
             {
                 Compteur_Ticks--;*/
                 ShearchForPlayer();
             /*}
             else
             {
                 Compteur_Ticks = 100;
                 TimeOutStatus = popupconnection_Form.ChangeTimeOutValue();
                 if (TimeOutStatus == false)
                 {
                     timer1.Stop();
                     popupconnection_Form.CloseConnectionPopUp();

                     this.Close_Connection();
                 }
             }*/
        }

        private bool LookForConnection()
        {
            return true;
        }
      
    }
}
