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
using System.Text.RegularExpressions;

namespace GsmReader
{

    public partial class Form2 : Form
    {
        string lp_location = "C:\\Program Files\\GRAPHISOFT\\ARCHICAD 20\\LP_XMLConverter.exe";
        string[] destination_location= new string[4];
        string currentXmlFolder = "";
        List<IDictionary<string, GsmXmlParameter>> ParamList = new List<IDictionary<string, GsmXmlParameter>>();
        IDictionary<string, GsmXmlParameter> mainParamList = new Dictionary<string, GsmXmlParameter>();
        IDictionary<string, GsmXmlParameter> missingParamList = new Dictionary<string, GsmXmlParameter>();
        IDictionary<string, string> script3dList = new Dictionary<string, string>();
        IDictionary<string, string> groupList = new Dictionary<string, string>();
        IDictionary<string, string> materials = new Dictionary<string, string>();
        int mainFileIndex = 0;
        string mainScript3D;
        XmlDocument xmlDoc;
        GsmXmlReader mainXmlDoc;
        static List<FileInfo> files = new List<FileInfo>();  // List that will hold the files and subfiles in path
        static List<DirectoryInfo> folders = new List<DirectoryInfo>(); // List that hold direcotries that cannot be accessed
        public Form2()
        {
            InitializeComponent();
            checkMainFile();
            type_list.Items.Add("Element");
            type_list.Items.Add("Main");
            type_list.Items.Add("Exclude");

            material.Items.Add("None");
            material.Items.Add("Frame");
            material.Items.Add("Seat");
            material.Items.Add("Back");
        }

        private void add_file1_location_Click(object sender, EventArgs e)
        {
            selectXmlFile(file1_location);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectXmlFile(file2_location);
        }
        private void add_file3_location_Click(object sender, EventArgs e)
        {
            selectXmlFile(file3_location);
        }
        private void gsm_dialog(TextBox element)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "gsm files (*.gsm)|*.gsm|All files (*.*)|*.*";
                //ofd.InitialDirectory = @"D:\";
                ofd.Title = "Select a gsm file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    element.Text = ofd.FileName;


                }
            }
            catch
            {

            }
        }

        private void selectXmlFile(TextBox element)
        {
            gsm_dialog(element);
            if (element.Text != "")
            {
                string location_name = element.Text;
                string destination_name = location_name.Replace("gsm", "xml");
                if(!File.Exists(destination_name))
                {
                    convertToXml(location_name,destination_name);
                }
                if (Regex.IsMatch(element.Name, @"[\d]"))
                {
                    var indexArr = Regex.Matches(element.Name, @"[\d]");
                    int index = Int32.Parse(indexArr[0].Value.ToString());
                    destination_location[index] = destination_name;
                }
                else
                {
                    MessageBox.Show(element.Name + " - " + Regex.IsMatch(element.Name, @"[\d]"));
                }
            }
        }
        private void convertToXml(string selected_file, string destination_location)
        {
            string programPath = "\"\"" + lp_location + "\" ";
            string sourceLocation = "\"" + selected_file + "\"";
            string destinationLocation = "\"" + destination_location + "\"\"";
            string operation = " libpart2xml -compatibility 18 ";
            string command_line = programPath + operation + sourceLocation + " " + destinationLocation;
            executeLpShellCommand(command_line);
        }
        private void convertToXml2(string selected_file)
        {
            string destination_location = selected_file.Replace("gsm", "xml");
            string programPath = "\"\"" + lp_location + "\" ";
            string sourceLocation = "\"" + selected_file + "\"";
            string destinationLocation = "\"" + destination_location + "\"\"";
            string operation = " libpart2xml -compatibility 18 ";
            string command_line = programPath + operation + sourceLocation + " " + destinationLocation;
            if (!File.Exists(destination_location))
            {
                executeLpShellCommand(command_line);
            }else if(MessageBox.Show("File " + destination_location + " exists! Replace?", "Message", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                executeLpShellCommand(command_line);
                console_output.Text += "\r\nReplacing File " + destination_location;
            }
            if (File.Exists(destination_location))
            {
                var index = file_list_table.Rows.Add();
                var row = file_list_table.Rows[index];
                row.Cells["file_name"].Value = Path.GetFileName(destination_location);
                row.Cells["type_list"].Value = "Element";
                row.Cells["material"].Value = "None";
            }
                
        }
        private void convertToGsm(string selected_file, string destination_location)
        {
            string programPath = "\"\"" + lp_location + "\" ";
            string sourceLocation = "\"" + selected_file + "\"";
            string destinationLocation = "\"" + destination_location + "\"\"";
            string operation = " xml2libpart ";
            string command_line = programPath + operation + sourceLocation + " " + destinationLocation;
            executeLpShellCommand(command_line);
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
            console_output.Text += s;
        }
        private void mix_gsm_button_Click(object sender, EventArgs e)
        {
            checkMainFile();
            if (mainFileIndex != 0)
            {
                //string Text1 = get3dScript(mainFileIndex);
                string text3dScript = "Gosub \"Routine 1\"\r\n";
                text3dScript += "Gosub \"Routine 2\"\r\n";
                text3dScript += "Gosub \"Routine 3\"\r\n";
                text3dScript += "END\r\n";
                for (var i = 1; i < 4; i++)
                {
                    text3dScript += "\"Routine "+i.ToString()+"\":\r\n";
                    text3dScript += get3dScript(i).Replace("hotspot 0, 0 ,0, 1", "");
                    //
                    text3dScript += "\r\nRETURN\r\n";
                }
                //System.IO.File.WriteAllText(@"C:\Users\Bogdan\test.txt", text3dScript);

                mainXmlDoc.set3dScript(text3dScript);
                mainParamList = ParamList[mainFileIndex];
                mainXmlDoc.filePath = destination_location[mainFileIndex].Replace(".xml", "_mixed.xml");
                foreach (IDictionary<string, GsmXmlParameter> parameters_list in ParamList) {

                    
                    foreach (var parameter in parameters_list)
                    {
                        if (!mainParamList.ContainsKey(parameter.Key))
                        {
                            console_output.Text += "key "+ parameter.Key+ "doesn't exist\r\n";
                            missingParamList[parameter.Key] =  parameter.Value;
                            parameter.Value.prev_xml_node = mainXmlDoc.getSimilarParameterXmlNode(parameter.Value.prev_xml_node);
                            mainXmlDoc.insertParameter(parameter.Value);
                            //console_output.Text += "value is " + parameter.Value.inner_xml + "doesn't exist\r\n";
                        }
                        
                    }
                    }                

            }
            else
            {
                MessageBox.Show(mainFileIndex.ToString());
            }
        }

        private string get3dScript(int index)
        {
            string destination_name = destination_location[index];
            string location_name = Path.GetFileName(destination_location[index]).Replace("xml", "gsm");
                if (!File.Exists(destination_location[index]))
                {
                    convertToXml(location_name, destination_location[index]);
            }
    
            if (destination_location.Length>2) {
                GsmXmlReader reader = new GsmXmlReader(destination_location[index]);
                ParamList.Add( reader.getParameters().xml_parameters);
                ParamList.Insert(index, reader.getParameters().xml_parameters);
                if (index == mainFileIndex)
                {
                    mainXmlDoc = reader;
                }
            return reader.get3dScript().script3dText;
            }else{
                MessageBox.Show("No path found" + index.ToString()+"\r\n");
                return "";
            }
        }

        private XmlDocument openXmlFile(string fileName,string node_name)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            return xmlDoc;
        }
        private void checkMainFile()
        {
            if (sel_file1.Checked)
            {
                mainFileIndex = 1;
            }
            if (sel_file2.Checked)
            {
                mainFileIndex = 2;
            }
            if (sel_file3.Checked)
            {
                mainFileIndex = 3;
            }
        }
        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void convert_to_gsm_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "gsm files (*.xml)|*.xml|All files (*.*)|*.*";
                //ofd.InitialDirectory = @"D:\";
                ofd.Title = "Select location";
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string location_name = ofd.FileName;
                    //string location_name = mainXmlDoc.filePath;
                    
                    string destination_name = location_name.Replace("xml", "gsm");
                    convertToGsm(location_name, destination_name);

                }
            }
            catch
            {

            }

        }

        private void parameter_mix_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void choose_folder_Click(object sender, EventArgs e)
        {
            gsm_dialog(folder_path);
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(folder_path.Text));
            currentXmlFolder = Path.GetDirectoryName(folder_path.Text);
            FullDirList(di, "*");

        }
        private void FullDirList(DirectoryInfo dir, string searchPattern)
        {
            // Console.WriteLine("Directory {0}", dir.FullName);
            // list the files
            try
            {
                foreach (FileInfo f in dir.GetFiles(searchPattern))
                {
                    //Console.WriteLine("File {0}", f.FullName);
                      if (Path.GetExtension(f.FullName) == ".gsm"&&f.FullName.IndexOf("_mixed")<0)
                    {
                        console_output.Text += "\r\nFile {0}" + f.FullName;
                        convertToXml2(f.FullName);
                        files.Add(f);
                    }

                }
            }
            catch
            {
                console_output.Text += "Directory {0}  \n could not be accessed!!!!"+ dir.FullName;
                return;  // We alredy got an error trying to access dir so dont try to access it again
            }

            // process each directory
            // If I have been able to see the files in the directory I should also be able 
            // to look at its directories so I dont think I should place this in a try catch block
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                folders.Add(d);
                FullDirList(d, searchPattern);
            }

        }

        private void mix_gsm_button2_Click(object sender, EventArgs e)
        {
                mix_files();
            
        }

        public void mix_files()
        {
            var i = 0;
            bool foundMain = false;
            string elementsScript3D = "";
            script3dList.Clear();
            materials.Clear();

            foreach (DataGridViewRow r in file_list_table.Rows)
            {
                if (r.Cells["type_list"].Value != null)
                {
                    string fileName = r.Cells["file_name"].Value.ToString();
                    string filePath = currentXmlFolder + "\\" + fileName;
                    if (r.Cells["type_list"].Value.ToString() == "Main")
                    {
                        mainFileIndex = i;
                        foundMain = true;
                        mainScript3D = get3dScript2(filePath, i) + "\r\nEND";

                    }
                    else if (fileName.IndexOf("_mixed") < 0)
                    {
                        string indexName = Path.GetFileNameWithoutExtension(fileName);
                        elementsScript3D += "\r\n\"" + indexName + "\":\r\n";
                        script3dList[indexName] = get3dScript2(filePath, i);
                        materials[indexName] = r.Cells["material"].Value.ToString();

                        foreach (var parameter in ParamList[mainFileIndex])
                        {
                            if (parameter.Key == "materialAttribute_2")
                            {
                                output(parameter.Key.ToString());
                                GsmXmlParameter matParameter1 = new GsmXmlParameter("mat_"+ materials[indexName], "Material", "mat_" + materials[indexName], "20", parameter.Value.inner_xml);
                                matParameter1.prev_xml_node = mainXmlDoc.getSimilarParameterXmlNode(parameter.Value.prev_xml_node);
                                mainXmlDoc.insertParameter2(matParameter1);
                            }
                            //if (!mainParamList.ContainsKey(parameter.Key))
                            //{
                            //    console_output.Text += "key " + parameter.Key + "doesn't exist\r\n";
                            //    missingParamList[parameter.Key] = parameter.Value;
                            //    parameter.Value.prev_xml_node = mainXmlDoc.getSimilarParameterXmlNode(parameter.Value.prev_xml_node);
                            //    mainXmlDoc.insertParameter(parameter.Value);
                            //    //console_output.Text += "value is " + parameter.Value.inner_xml + "doesn't exist\r\n";
                            //}

                        }

                        elementsScript3D += script3dList[indexName].Replace("hotspot 0, 0 ,0, 1", "");
                        elementsScript3D += "\r\nRETURN\r\n";
                       
                        //text3dScript += "\"Routine " + i.ToString() + "\":\r\n";
                        //text3dScript += get3dScript(i).Replace("hotspot 0, 0 ,0, 1", "");
                        //text3dScript += "\r\nRETURN\r\n";
                    }
                }


                i++;
            }

            int nFiles = i;

            int cc = 0;
            groupList.Clear();
            string[] elements = script3dList.Keys.ToArray();
            if (mainScript3D != null) {
                output("Make some grouping");
                foreach (Match m in Regex.Matches(mainScript3D, "\"(group(.*?))\"\r\n"))
                {
                    if (m.Index > nFiles)
                    {
                        groupList[elements[i+cc]] = m.Value.ToString();
                        output(m.Value.ToString());
                        cc++;
                    }


                }
                output("done grouping");
            }
            if (!foundMain)
            {
                MessageBox.Show("No main file selected!. Select a file to be main!");
            }
            else
            {
                string pattern = "(.*?)(?:(endgroup))";
                //var mm = false;
                foreach (KeyValuePair<string, string> scriptus3d in script3dList)
                {
                    //output(scriptus3d.Key);
                    //mm = Regex.IsMatch(mainScript3D, scriptus3d.Key+ pattern, RegexOptions.Singleline);
                    Regex rgx = new Regex(scriptus3d.Key + pattern, RegexOptions.Singleline);
                    mainScript3D = rgx.Replace(mainScript3D, "gosub \"" + scriptus3d.Key + "\"\r\nendgroup\r\n");
                    //if (mm)
                    //{
                    //    var result = Regex.Match(mainScript3D, scriptus3d.Key + pattern, RegexOptions.Singleline).Value;
                    //    mainScript3D=
                    //}
                }
                int p = 0;
                foreach (Match m in Regex.Matches(mainScript3D, @"creategroupwithmaterial\s\(\""group_[A-z0-9]+\""\,[\s]+\d+\,[\s]+\d+,[\s]+(\d+)\)"))
                {
                    string routineName = elements[p].ToString();
                    string materialName = materials[routineName];
                    string originalString = (m.Value.ToString());
                    string toReplace = originalString.Replace((m.Groups[1].ToString()), "mat_"+materialName);
                    mainScript3D = mainScript3D.Replace(m.Value.ToString(), toReplace);
                    p++;
                }
                    //var mm = Regex.IsMatch(mainScript3D, "Rhino_Object_1(.*?)(?:(\r\n){ 2,}| (endgroup) |$)", RegexOptions.Singleline);
                    //  var mm = Regex.IsMatch(mainScript3D, @"\Rhino_Object_1(.*?)(?:(\r\n){ 2,}| (endgroup) |$)", RegexOptions.Singleline);
                    //MessageBox.Show(mm.ToString());
                    mainScript3D = mainScript3D.Replace("    call    \"", "");
                string fullText = mainScript3D + elementsScript3D;
                fullText = fullText.Replace("rh_nurbsbody_smoothness = rh_nurbsbodySmoothnessLevel[gs_iSmoothnessLevel]", "rh_surface_mat = materialAttribute_1\r\nrh_show_edges_3d=0\r\nrh_smoothe_edges_3d=0\r\nrh_show_edges_2d=0\r\nrh_nurbsbody_smoothness=10\r\nrh_show_hotlines_3d=0");
                fullText = fullText.Replace("xform	rh_xform[1][1]", "dim rh_xform[3][3]\r\nrh_xform = tmp_rh_xform\r\nxform	rh_xform[1][1]");
                mainXmlDoc.set3dScript(fullText);
                string ui_path = Environment.CurrentDirectory + @"\files\interface_sample.txt";
                output("the folder is " + ui_path);
                string uiScriptText = System.IO.File.ReadAllText(ui_path);
                mainXmlDoc.setInterface(uiScriptText);
                string newPath = mainXmlDoc.filePath.Replace(".xml", "_mixed.xml");
                mainXmlDoc.saveXml(newPath);
                convertToGsm(newPath, newPath.Replace("xml", "gsm"));
                MessageBox.Show(newPath + " was succesfully created and mixed");
            }
        }
        private void checkMainFile2()
        {
            
        }
        private void output(string text)
        {
            console_output.Text += "\r\n" + text;
        }
        private string get3dScript2(string filePath,int index)
        {
            if (File.Exists(filePath))
            {
                GsmXmlReader reader = new GsmXmlReader(filePath);
                ParamList.Add(reader.getParameters().xml_parameters);
                ParamList.Insert(index, reader.getParameters().xml_parameters);
                if (index == mainFileIndex)
                {
                    mainXmlDoc = reader;
                }
                return reader.get3dScript().script3dText;
            }else
            {
                MessageBox.Show("File : " + filePath + " not found!");
            }
            return "";           
        }
    }
}
