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
    public partial class Form1 : Form
    {
       
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private string destination_location;
        private bool file_loaded = false;
        private int recentAddedRow = 0;
        private bool is_hidden ;
        public Form1()
        {
            InitializeComponent();
            prepare_parameterType();

            delete_parameter.Text = "X";
            add_parameter.Text = "+";
            //lp_location.Text = "C:\\Program Files\\GRAPHISOFT\\ArchiCAD 18\\LP_XMLConverter.exe";
            lp_location.Text = "C:\\Program Files\\GRAPHISOFT\\ARCHICAD 20\\LP_XMLConverter.exe";
            //triggering the add row
            this.parameter_table.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.parameter_table_RowsAdded);

        }

        private void prepare_parameterType()
        {
            // parameter type variable
            parameter_type.Items.Add("PenColor");
            parameter_type.Items.Add("String");
            parameter_type.Items.Add("Integer");
            parameter_type.Items.Add("Length");
            parameter_type.Items.Add("Boolean");
            parameter_type.Items.Add("Title");
            parameter_type.Items.Add("FillPattern");
            parameter_type.Items.Add("Material");
            parameter_type.Items.Add("RealNum");
            parameter_type.Items.Add("LineType");
            parameter_type.Items.Add("Separator");

            parameter_visibility.Items.Add("On");
            parameter_visibility.Items.Add("Hidden");
        }

        private void open_gsm_button_Click(object sender, EventArgs e)
        {

            if (destination_location != null)
            {
                convertToXml();
                if (File.Exists(destination_location))
                {
                    openXmlFile(destination_location);
                }else
                {
                    MessageBox.Show("Xml conversion failed");
                }
               
                
            }
            else
            {
                MessageBox.Show("Please Select a File");
            }

        }

        private void convertToXml()
        {
            string programPath = "\"\"" + lp_location.Text + "\" ";
            string sourceLocation = "\"" + selected_file.Text + "\"";
            string destinationLocation = "\"" + destination_location + "\"\"";
            string operation = " libpart2xml -compatibility 18 ";
            string command_line = programPath + operation + sourceLocation + " " + destinationLocation;
            executeLpShellCommand(command_line);
        }
        public void convertToGsm(string name="")
        {
            string gsmFileName = "";
            if (name == "")
            {
                gsmFileName = selected_file.Text;
            }else
            {
                gsmFileName = Path.GetDirectoryName(selected_file.Text) + "\\" + name+".gsm";
            }
            string programPath = "\"\"" + lp_location.Text + "\" ";
            string sourceLocation = "\"" + destination_location + "\"";
            string destinationLocation = "\"" + gsmFileName + "\"\"";
            string operation = " xml2libpart ";
            string command_line = programPath + operation + sourceLocation + " " + destinationLocation;
            MessageBox.Show(command_line);
            executeLpShellCommand(command_line);
        }
        private void parameter_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void executeLpShellCommand(string command_line)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            var proc = Process.Start(psi);
            proc.StandardInput.WriteLine(@"CMD /c " + command_line);
            proc.StandardInput.WriteLine("exit");
            string s = proc.StandardOutput.ReadToEnd();
            console_output.Text = s;
        }

        private void openXmlFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            //string xmlcontents = doc.InnerXml;
            //console_output.Text = doc.InnerXml;
            XmlNode Parameters = doc.SelectSingleNode("/Symbol/ParamSection/Parameters");
            XmlNodeList parametersList = Parameters.ChildNodes;
            var count = 0;
            foreach (XmlNode parameter in parametersList)
            {
                if (parameter != null && parameter.Name != "#comment") {
                    //XmlAttribute element = parameter.Attributes["Name"];
                    //console_output.Text += "\r\n Name" + element.Value;
                    //console_output.Text += 1;
                    XmlAttribute param_name = parameter.Attributes["Name"];
                    var index = parameter_table.Rows.Add();
                    var row = parameter_table.Rows[index];
                    row.Cells["parameter_name"].Value = param_name.Value;
                    XmlNode ParameterValue = parameter.LastChild;
                    row.Cells["parameter_value"].Value = ParameterValue.InnerText.Replace('"', ' ').Trim();
                    row.Cells["parameter_visibility"].Value = "On";
                    is_hidden = false;
                    try
                    {
                        row.Cells["parameter_type"].Value = parameter.Name;
                       
                        //console_output.Text += "\r\n Name " + parameter.Name +"  "+ parameter_type.Items.IndexOf(parameter.Name);
                    }
                    catch
                    {

                    }
                    var ParameterList = parameter.ChildNodes;
                    foreach (XmlNode paramDescrElement in ParameterList)
                    {
                        if (paramDescrElement != null && paramDescrElement.Name == "Description")
                        {
                            row.Cells["parameter_label"].Value =  paramDescrElement.InnerText.Replace('"', ' ').Trim();
                        }
                        if (paramDescrElement != null && paramDescrElement.Name == "Flags")
                        {
                            setFlags(row,paramDescrElement);
                        }
                    }
                    setStyles(parameter.Name, row);
                    count++;
                }

            }
            if (count > 1)
            {
                file_loaded = true;
            }
    
        }
        private void setStyles(string type,DataGridViewRow row)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            if (type == "Title")
            {
                style.Font = new Font(parameter_table.Font, FontStyle.Bold);
                row.DefaultCellStyle = style;
            }
            if (is_hidden ==true)
            {
                style.Font = new Font(parameter_table.Font, FontStyle.Italic);
                style.ForeColor = Color.Red;
                row.DefaultCellStyle = style;
            }

        }
        private void setFlags(DataGridViewRow row,XmlNode paramDescrElement)
        {
            XmlNodeList flagList = paramDescrElement.ChildNodes;
            foreach (XmlNode flag in flagList)
            {
                
                if (flag.Name== "ParFlg_Hidden") {
                    row.Cells["parameter_visibility"].Value = "Hidden";
                    is_hidden = true;
                }
                
                //MessageBox.Show(flag.Name);
            }
        }
    
        //moves rows down
        private void move_down_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount =
           parameter_table.GetCellCount(DataGridViewElementStates.Selected);
            if (parameter_table.AreAllCellsSelected(true))
            {
                MessageBox.Show("All cells are selected", "Selected Cells");
            }
            else if (parameter_table.SelectedRows.Count>0)
            {

                int nrTotal = parameter_table.SelectedRows.Count;
                List<DataGridViewRow> items = new List<DataGridViewRow>();
                 foreach (DataGridViewRow r in parameter_table.SelectedRows)
                {
                    items.Add(r);
                }
                 foreach (DataGridViewRow r in items)
                {
                    var rowIndex = r.Index;
                    moveRowDown(rowIndex);
                    //console_output.Text += "\r\n Name" + rowIndex + " Total :" + nrTotal;
                }


            }
            else
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedCellCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(parameter_table.SelectedCells[i].RowIndex.ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedCellCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Cells");
            }
            
        }
        private void moveRowUp(int rowIndex)
        {
            DataGridViewRow selectedRow = parameter_table.Rows[rowIndex];
            parameter_table.Rows.Remove(selectedRow);
            parameter_table.Rows.Insert(rowIndex - 1, selectedRow);
            parameter_table.ClearSelection();
        }
        private void moveRowDown(int rowIndex)
        {
            DataGridViewRow selectedRow = parameter_table.Rows[rowIndex];
            parameter_table.Rows.Remove(selectedRow);
            parameter_table.Rows.Insert(rowIndex + 1, selectedRow);
            parameter_table.ClearSelection();
        }

        private void choose_lp_conv_location_Click(object sender, EventArgs e)
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
        //select gsm file from dialog
        private void Button1_Click(object sender, EventArgs e)
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
                    string destination_name = Path.GetFileName(selected_file.Text).Replace("gsm","xml");
                    destination_location = Path.GetDirectoryName(selected_file.Text)+"\\"+ destination_name;
                    convert_name.Text = Path.GetFileNameWithoutExtension(destination_location);
                }
            }
            catch
            {

            }
        }
        private void parameter_table_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            // Update the labels to reflect changes to the selection.
            //
            if (file_loaded)
            {
                recentAddedRow = e.RowIndex;
            }
        }
        private void add_row_Click(object sender, EventArgs e)
        {
            //var n_rows = parameter_table.RowCount;
            //DataGridViewRow row = (DataGridViewRow)parameter_table.Rows[n_rows-2].Clone();
            //parameter_table.Rows.Add(row);

            if (destination_location != null&&recentAddedRow>0)
            {
                if (!File.Exists(destination_location))
                {
                    convertToXml();
                }
                DataGridViewRow row = parameter_table.Rows[recentAddedRow-1];
                bool data_validator = checkRowValues(row);
                if (data_validator)
                {
                    addXmlParameterRow(destination_location, row);
                }
            }
            else
            {
                MessageBox.Show("Could not add new row");
            }
       
        }

        private bool checkRowValues(DataGridViewRow row)
        {
            bool status = true;
            status = checkParameter(row, "parameter_name");
            status = checkParameter(row, "parameter_type");
            status = checkParameter(row, "parameter_label");
            status = checkParameter(row, "parameter_value");
            return status;
        }
        private bool checkParameter(DataGridViewRow row,string key)
        {
            if (row.Cells[key].Value == null)
            {
                MessageBox.Show("Please complete " + key);
                return false;
            }
                return true;
        }
        private void addXmlParameterRow(string destination_location, DataGridViewRow row)
        {
            //openXmlFile(destination_location);
            XmlDocument doc = new XmlDocument();
            doc.Load(destination_location);
            //string xmlcontents = doc.InnerXml;
            //console_output.Text = doc.InnerXml;
            XmlNode Parameters = doc.SelectSingleNode("/Symbol/ParamSection/Parameters");
            XmlNodeList parametersList = Parameters.ChildNodes;
            string param_type = row.Cells["parameter_type"].Value.ToString();
            string param_value = row.Cells["parameter_value"].Value.ToString();
            XmlElement xmlElement = doc.CreateElement(param_type);
            xmlElement.SetAttribute("Name", row.Cells["parameter_name"].Value.ToString());
            
            XmlElement xmlElementDescr = doc.CreateElement("Description");
            XmlElement xmlElementValue = doc.CreateElement("Value");
            if (param_type != null&& param_type == "String")
            {
                XmlCDataSection CDataValue = doc.CreateCDataSection(param_value);
                xmlElementValue.AppendChild(CDataValue);
            }
            else {
            xmlElementValue.InnerText = param_value;
            }
            XmlCDataSection CData = doc.CreateCDataSection(row.Cells["parameter_label"].Value.ToString());
            xmlElementDescr.AppendChild(CData);
            xmlElement.AppendChild(xmlElementDescr);
            xmlElement.AppendChild(xmlElementValue);
            //xmlElement.InnerText = "Test";
            XmlNode last_parameter = Parameters.LastChild;
            Parameters.InsertAfter(xmlElement, last_parameter);
            try
            {
                doc.Save(destination_location);
                MessageBox.Show("Parameter Added To Xml");
            }
            catch
            {
                MessageBox.Show("Couldn't not update Xml file");
            }
            

            //var count = 0;
        }
        //not working
        private void parameter_table_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = parameter_table.DoDragDrop(
                    parameter_table.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }
        //not working
        private void parameter_table_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = parameter_table.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        //not working
        private void parameter_table_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //not working
        private void parameter_table_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = parameter_table.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                parameter_table.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                parameter_table.Rows.RemoveAt(rowIndexFromMouseDown);
                parameter_table.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }

        private void convert_back_Click(object sender, EventArgs e)
        {
            versionForm versionForm = new versionForm(this);

            // Show the version form
            versionForm.ShowDialog();
        }

        private void open_location_Click(object sender, EventArgs e)
        {
           string path = Path.GetDirectoryName(destination_location);
            ProcessStartInfo StartInformation = new ProcessStartInfo();

            StartInformation.FileName = path;

            Process process = Process.Start(StartInformation);

            //process.EnableRaisingEvents = true;
        }
    }

}
