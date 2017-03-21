namespace GsmReader
{
    partial class versionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.convert_to_gsm = new System.Windows.Forms.Button();
            this.lp_location = new System.Windows.Forms.TextBox();
            this.choose_lp_conv_location = new System.Windows.Forms.Button();
            this.selected_file = new System.Windows.Forms.TextBox();
            this.select_file_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.convert_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // convert_to_gsm
            // 
            this.convert_to_gsm.Location = new System.Drawing.Point(204, 181);
            this.convert_to_gsm.Name = "convert_to_gsm";
            this.convert_to_gsm.Size = new System.Drawing.Size(121, 23);
            this.convert_to_gsm.TabIndex = 0;
            this.convert_to_gsm.Text = "Convert To Gsm";
            this.convert_to_gsm.UseVisualStyleBackColor = true;
            this.convert_to_gsm.Click += new System.EventHandler(this.convert_to_gsm_Click);
            // 
            // lp_location
            // 
            this.lp_location.Location = new System.Drawing.Point(23, 41);
            this.lp_location.Name = "lp_location";
            this.lp_location.Size = new System.Drawing.Size(320, 20);
            this.lp_location.TabIndex = 12;
            // 
            // choose_lp_conv_location
            // 
            this.choose_lp_conv_location.Location = new System.Drawing.Point(349, 38);
            this.choose_lp_conv_location.Name = "choose_lp_conv_location";
            this.choose_lp_conv_location.Size = new System.Drawing.Size(129, 23);
            this.choose_lp_conv_location.TabIndex = 11;
            this.choose_lp_conv_location.Text = "Selext lp_converter";
            this.choose_lp_conv_location.UseVisualStyleBackColor = true;
            this.choose_lp_conv_location.Click += new System.EventHandler(this.choose_lp_conv_location_Click_1);
            // 
            // selected_file
            // 
            this.selected_file.Location = new System.Drawing.Point(23, 79);
            this.selected_file.Name = "selected_file";
            this.selected_file.Size = new System.Drawing.Size(320, 20);
            this.selected_file.TabIndex = 13;
            // 
            // select_file_button
            // 
            this.select_file_button.Location = new System.Drawing.Point(349, 77);
            this.select_file_button.Name = "select_file_button";
            this.select_file_button.Size = new System.Drawing.Size(129, 23);
            this.select_file_button.TabIndex = 14;
            this.select_file_button.Text = "Gsm File Location";
            this.select_file_button.UseVisualStyleBackColor = true;
            this.select_file_button.Click += new System.EventHandler(this.select_file_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Convert Gsm File";
            // 
            // convert_name
            // 
            this.convert_name.Location = new System.Drawing.Point(138, 119);
            this.convert_name.Name = "convert_name";
            this.convert_name.Size = new System.Drawing.Size(205, 20);
            this.convert_name.TabIndex = 24;
            // 
            // versionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 230);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.convert_name);
            this.Controls.Add(this.select_file_button);
            this.Controls.Add(this.selected_file);
            this.Controls.Add(this.lp_location);
            this.Controls.Add(this.choose_lp_conv_location);
            this.Controls.Add(this.convert_to_gsm);
            this.Name = "versionForm";
            this.Text = "Choose Version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convert_to_gsm;
        internal System.Windows.Forms.TextBox lp_location;
        internal System.Windows.Forms.Button choose_lp_conv_location;
        internal System.Windows.Forms.TextBox selected_file;
        internal System.Windows.Forms.Button select_file_button;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox convert_name;
    }
}