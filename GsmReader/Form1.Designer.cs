namespace GsmReader
{
    partial class Form1
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
            this.parameter_table = new System.Windows.Forms.DataGridView();
            this.parameter_id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parameter_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameter_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.parameter_label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameter_visibility = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.parameter_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete_parameter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.add_parameter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Label2 = new System.Windows.Forms.Label();
            this.console_output = new System.Windows.Forms.TextBox();
            this.open_gsm_button = new System.Windows.Forms.Button();
            this.work_location = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.selected_file = new System.Windows.Forms.TextBox();
            this.lp_location = new System.Windows.Forms.TextBox();
            this.select_file_button = new System.Windows.Forms.Button();
            this.choose_lp_conv_location = new System.Windows.Forms.Button();
            this.move_up = new System.Windows.Forms.Button();
            this.move_down = new System.Windows.Forms.Button();
            this.add_row = new System.Windows.Forms.Button();
            this.convert_back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.convert_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.parameter_table)).BeginInit();
            this.SuspendLayout();
            // 
            // parameter_table
            // 
            this.parameter_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parameter_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parameter_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameter_id,
            this.parameter_name,
            this.parameter_type,
            this.parameter_label,
            this.parameter_visibility,
            this.parameter_value,
            this.delete_parameter,
            this.add_parameter});
            this.parameter_table.Location = new System.Drawing.Point(29, 147);
            this.parameter_table.Name = "parameter_table";
            this.parameter_table.Size = new System.Drawing.Size(831, 281);
            this.parameter_table.TabIndex = 16;
            this.parameter_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.parameter_table_CellContentClick);
            // 
            // parameter_id
            // 
            this.parameter_id.FillWeight = 50F;
            this.parameter_id.HeaderText = "Id";
            this.parameter_id.Name = "parameter_id";
            this.parameter_id.Width = 50;
            // 
            // parameter_name
            // 
            this.parameter_name.FillWeight = 250F;
            this.parameter_name.HeaderText = "Parameter Name";
            this.parameter_name.Name = "parameter_name";
            this.parameter_name.Width = 150;
            // 
            // parameter_type
            // 
            this.parameter_type.DataPropertyName = "type_list";
            this.parameter_type.HeaderText = "Type";
            this.parameter_type.Name = "parameter_type";
            // 
            // parameter_label
            // 
            this.parameter_label.FillWeight = 200F;
            this.parameter_label.HeaderText = "Label";
            this.parameter_label.Name = "parameter_label";
            this.parameter_label.Width = 200;
            // 
            // parameter_visibility
            // 
            this.parameter_visibility.FillWeight = 70F;
            this.parameter_visibility.HeaderText = "Visible";
            this.parameter_visibility.Name = "parameter_visibility";
            this.parameter_visibility.Width = 70;
            // 
            // parameter_value
            // 
            this.parameter_value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parameter_value.FillWeight = 150F;
            this.parameter_value.HeaderText = "Value";
            this.parameter_value.Name = "parameter_value";
            // 
            // delete_parameter
            // 
            this.delete_parameter.FillWeight = 50F;
            this.delete_parameter.HeaderText = "delete";
            this.delete_parameter.Name = "delete_parameter";
            this.delete_parameter.Text = "X";
            this.delete_parameter.ToolTipText = "delete parameter";
            this.delete_parameter.UseColumnTextForButtonValue = true;
            this.delete_parameter.Width = 50;
            // 
            // add_parameter
            // 
            this.add_parameter.FillWeight = 50F;
            this.add_parameter.HeaderText = "add";
            this.add_parameter.Name = "add_parameter";
            this.add_parameter.Text = "add";
            this.add_parameter.ToolTipText = "insert parameter";
            this.add_parameter.UseColumnTextForButtonValue = true;
            this.add_parameter.Width = 50;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(26, 474);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Console";
            // 
            // console_output
            // 
            this.console_output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console_output.Location = new System.Drawing.Point(29, 490);
            this.console_output.Multiline = true;
            this.console_output.Name = "console_output";
            this.console_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console_output.Size = new System.Drawing.Size(831, 78);
            this.console_output.TabIndex = 14;
            // 
            // open_gsm_button
            // 
            this.open_gsm_button.Location = new System.Drawing.Point(399, 92);
            this.open_gsm_button.Name = "open_gsm_button";
            this.open_gsm_button.Size = new System.Drawing.Size(75, 23);
            this.open_gsm_button.TabIndex = 13;
            this.open_gsm_button.Text = "Open";
            this.open_gsm_button.UseVisualStyleBackColor = true;
            this.open_gsm_button.Click += new System.EventHandler(this.open_gsm_button_Click);
            // 
            // work_location
            // 
            this.work_location.AutoSize = true;
            this.work_location.Location = new System.Drawing.Point(17, 52);
            this.work_location.Name = "work_location";
            this.work_location.Size = new System.Drawing.Size(56, 13);
            this.work_location.TabIndex = 11;
            this.work_location.Text = "Select File";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "LP Converter";
            // 
            // selected_file
            // 
            this.selected_file.Location = new System.Drawing.Point(101, 49);
            this.selected_file.Name = "selected_file";
            this.selected_file.Size = new System.Drawing.Size(320, 20);
            this.selected_file.TabIndex = 9;
            // 
            // lp_location
            // 
            this.lp_location.Location = new System.Drawing.Point(101, 18);
            this.lp_location.Name = "lp_location";
            this.lp_location.Size = new System.Drawing.Size(320, 20);
            this.lp_location.TabIndex = 10;
            // 
            // select_file_button
            // 
            this.select_file_button.Location = new System.Drawing.Point(427, 47);
            this.select_file_button.Name = "select_file_button";
            this.select_file_button.Size = new System.Drawing.Size(47, 23);
            this.select_file_button.TabIndex = 7;
            this.select_file_button.Text = "...";
            this.select_file_button.UseVisualStyleBackColor = true;
            this.select_file_button.Click += new System.EventHandler(this.Button1_Click);
            // 
            // choose_lp_conv_location
            // 
            this.choose_lp_conv_location.Location = new System.Drawing.Point(427, 16);
            this.choose_lp_conv_location.Name = "choose_lp_conv_location";
            this.choose_lp_conv_location.Size = new System.Drawing.Size(47, 23);
            this.choose_lp_conv_location.TabIndex = 8;
            this.choose_lp_conv_location.Text = "...";
            this.choose_lp_conv_location.UseVisualStyleBackColor = true;
            this.choose_lp_conv_location.Click += new System.EventHandler(this.choose_lp_conv_location_Click);
            // 
            // move_up
            // 
            this.move_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.move_up.Location = new System.Drawing.Point(722, 449);
            this.move_up.Name = "move_up";
            this.move_up.Size = new System.Drawing.Size(56, 23);
            this.move_up.TabIndex = 17;
            this.move_up.Text = "Up";
            this.move_up.UseVisualStyleBackColor = true;
            // 
            // move_down
            // 
            this.move_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.move_down.Location = new System.Drawing.Point(794, 449);
            this.move_down.Name = "move_down";
            this.move_down.Size = new System.Drawing.Size(56, 23);
            this.move_down.TabIndex = 18;
            this.move_down.Text = "Down";
            this.move_down.UseVisualStyleBackColor = true;
            this.move_down.Click += new System.EventHandler(this.move_down_Click);
            // 
            // add_row
            // 
            this.add_row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add_row.Location = new System.Drawing.Point(630, 449);
            this.add_row.Name = "add_row";
            this.add_row.Size = new System.Drawing.Size(75, 23);
            this.add_row.TabIndex = 19;
            this.add_row.Text = "Add Row";
            this.add_row.UseVisualStyleBackColor = true;
            this.add_row.Click += new System.EventHandler(this.add_row_Click);
            // 
            // convert_back
            // 
            this.convert_back.Location = new System.Drawing.Point(480, 92);
            this.convert_back.Name = "convert_back";
            this.convert_back.Size = new System.Drawing.Size(101, 23);
            this.convert_back.TabIndex = 21;
            this.convert_back.Text = "Convert Back";
            this.convert_back.UseVisualStyleBackColor = true;
            this.convert_back.Click += new System.EventHandler(this.convert_back_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Convert Name";
            // 
            // convert_name
            // 
            this.convert_name.Location = new System.Drawing.Point(101, 89);
            this.convert_name.Name = "convert_name";
            this.convert_name.Size = new System.Drawing.Size(189, 20);
            this.convert_name.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 604);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.convert_name);
            this.Controls.Add(this.convert_back);
            this.Controls.Add(this.add_row);
            this.Controls.Add(this.move_down);
            this.Controls.Add(this.move_up);
            this.Controls.Add(this.parameter_table);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.console_output);
            this.Controls.Add(this.open_gsm_button);
            this.Controls.Add(this.work_location);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.selected_file);
            this.Controls.Add(this.lp_location);
            this.Controls.Add(this.select_file_button);
            this.Controls.Add(this.choose_lp_conv_location);
            this.Name = "Form1";
            this.Text = "Gsm To Xml Converter";
            ((System.ComponentModel.ISupportInitialize)(this.parameter_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView parameter_table;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox console_output;
        internal System.Windows.Forms.Button open_gsm_button;
        internal System.Windows.Forms.Label work_location;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox selected_file;
        internal System.Windows.Forms.TextBox lp_location;
        internal System.Windows.Forms.Button select_file_button;
        internal System.Windows.Forms.Button choose_lp_conv_location;
        private System.Windows.Forms.Button move_up;
        private System.Windows.Forms.Button move_down;
        private System.Windows.Forms.Button add_row;
        private System.Windows.Forms.Button convert_back;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox convert_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parameter_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameter_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn parameter_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameter_label;
        private System.Windows.Forms.DataGridViewComboBoxColumn parameter_visibility;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameter_value;
        private System.Windows.Forms.DataGridViewButtonColumn delete_parameter;
        private System.Windows.Forms.DataGridViewButtonColumn add_parameter;
    }
}

