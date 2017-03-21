using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace GsmReader
{
    public partial class versionForm : Form
    {
        public Form1 masterForm;
        public versionForm(Form1 form1)
        {
            masterForm = form1;
            InitializeComponent();
            lp_location.Text = masterForm.lp_location.Text;
            selected_file.Text = masterForm.selected_file.Text;
            convert_name.Text = masterForm.convert_name.Text.Replace("_xml","_gsm");
        }

        private void convert_to_gsm_Click(object sender, EventArgs e)
        {
            masterForm.lp_location = lp_location;
            masterForm.selected_file = selected_file;
            masterForm.convertToGsm(convert_name.Text);
        }

        private void choose_lp_conv_location_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd2 = new OpenFileDialog();
                ofd2.Filter = "lp converter (LP_XMLConverter.exe)|LP_XMLConverter.exe|All files (*.*)|*.*";
                ofd2.InitialDirectory = @"C:\Program Files\GRAPHISOFT\ARCHICAD 20";
                ofd2.Title = "Select a the Lp xml converter application";
                if (ofd2.ShowDialog() == DialogResult.OK)
                {

                    lp_location.Text = ofd2.FileName;
                }
            }
            catch
            {

            }
        }

        private void select_file_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "gsm files (*.gsm)|*.gsm|All files (*.*)|*.*";
                //ofd.InitialDirectory = @"D:\";
                ofd.Title = "Select a gsm file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selected_file.Text = ofd.FileName;
                }
            }
            catch
            {

            }
        }
    }
}
