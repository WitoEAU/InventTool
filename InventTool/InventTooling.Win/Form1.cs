using InventTool.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventTooling.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var herramentalBL = new HerramentalBL();
            var listadeHerramental = herramentalBL.ObtenerHerramental();

            foreach (var herramental in listadeHerramental)
            {
                MessageBox.Show(herramental.Descripcion);
            }

        }
    }
}
