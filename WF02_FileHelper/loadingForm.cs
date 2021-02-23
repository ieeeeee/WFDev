using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF02_FileHelper
{
    public partial class loadingForm : Form
    {
        public loadingForm(string loadingMsg)
        {
            InitializeComponent();
            this.lblOptMsg.Text = loadingMsg;
        }
        //public bool Increase(string loadingMsg)
        //{
        //    return false;
        //}
    }
}
