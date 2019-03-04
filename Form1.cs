using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManager
{
    public partial class FrmPrintManager : Form
    {
        public FrmPrintManager()
        {
            InitializeComponent();

            this.Start();
        }

        public void Start()
        {
            PrintControl printControl = new PrintControl();
            printControl.getPrinters();
        }
    }
}
