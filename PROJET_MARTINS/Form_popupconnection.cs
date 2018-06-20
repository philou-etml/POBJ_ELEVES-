using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Bataille_Navale
{
    public partial class Form_popupconnection : Form
    {
        private int TimeBeforeTimeOut = 30;
        public Form_popupconnection()
        {
            InitializeComponent();
            lbltimeout.Text = "30";
        }

        public void CloseConnectionPopUp()
        {
            this.Hide();
            TimeBeforeTimeOut = 31;
        }

        public bool ChangeTimeOutValue()
        {
            bool Status = true;           
            if ((TimeBeforeTimeOut+1) == 0)
            {
                Status = false;
            }
            else
            {
                lbltimeout.Text = TimeBeforeTimeOut.ToString();
                TimeBeforeTimeOut--;
            }

            return Status;        
        }

        public void ChangeText (string text)
        {
            //DebugLabel.Text = text;
        }
    }
}
