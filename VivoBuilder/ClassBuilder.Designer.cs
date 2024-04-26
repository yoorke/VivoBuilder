namespace VivoBuilder
{
    partial class ClassBuilder
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
            this.lstDatabaseTables = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkCreateReferences = new System.Windows.Forms.CheckBox();
            this.chkCreateBaseClasses = new System.Windows.Forms.CheckBox();
            this.btnSelectFramework = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelectSolution = new System.Windows.Forms.Button();
            this.txtSolutionFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLanguageTableSuffix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnGenerateClasses = new System.Windows.Forms.Button();
            this.tbcGeneratedClasses = new System.Windows.Forms.TabControl();
            this.tbpModelClasses = new System.Windows.Forms.TabPage();
            this.tbpModelViewClasses = new System.Windows.Forms.TabPage();
            this.txtModelViewClasses = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamespaceModelView = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClassContent = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClassNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbcGeneratedClasses.SuspendLayout();
            this.tbpModelViewClasses.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDatabaseTables
            // 
            this.lstDatabaseTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstDatabaseTables.FormattingEnabled = true;
            this.lstDatabaseTables.Location = new System.Drawing.Point(0, 0);
            this.lstDatabaseTables.Name = "lstDatabaseTables";
            this.lstDatabaseTables.Size = new System.Drawing.Size(229, 479);
            this.lstDatabaseTables.TabIndex = 0;
            this.lstDatabaseTables.SelectedIndexChanged += new System.EventHandler(this.lstDatabaseTables_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.btnSelectSolution);
            this.groupBox1.Controls.Add(this.txtSolutionFilename);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtLanguageTableSuffix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNamespace);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 553);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkCreateReferences);
            this.groupBox6.Controls.Add(this.chkCreateBaseClasses);
            this.groupBox6.Controls.Add(this.btnSelectFramework);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(793, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(331, 107);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Export options";
            // 
            // chkCreateReferences
            // 
            this.chkCreateReferences.AutoSize = true;
            this.chkCreateReferences.Location = new System.Drawing.Point(159, 58);
            this.chkCreateReferences.Name = "chkCreateReferences";
            this.chkCreateReferences.Size = new System.Drawing.Size(110, 17);
            this.chkCreateReferences.TabIndex = 12;
            this.chkCreateReferences.Text = "Create references";
            this.chkCreateReferences.UseVisualStyleBackColor = true;
            // 
            // chkCreateBaseClasses
            // 
            this.chkCreateBaseClasses.AutoSize = true;
            this.chkCreateBaseClasses.Location = new System.Drawing.Point(21, 58);
            this.chkCreateBaseClasses.Name = "chkCreateBaseClasses";
            this.chkCreateBaseClasses.Size = new System.Drawing.Size(121, 17);
            this.chkCreateBaseClasses.TabIndex = 11;
            this.chkCreateBaseClasses.Text = "Create base classes";
            this.chkCreateBaseClasses.UseVisualStyleBackColor = true;
            // 
            // btnSelectFramework
            // 
            this.btnSelectFramework.Location = new System.Drawing.Point(273, 27);
            this.btnSelectFramework.Name = "btnSelectFramework";
            this.btnSelectFramework.Size = new System.Drawing.Size(36, 20);
            this.btnSelectFramework.TabIndex = 10;
            this.btnSelectFramework.Text = "...";
            this.btnSelectFramework.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Framework location:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 9;
            // 
            // btnSelectSolution
            // 
            this.btnSelectSolution.Location = new System.Drawing.Point(555, 31);
            this.btnSelectSolution.Name = "btnSelectSolution";
            this.btnSelectSolution.Size = new System.Drawing.Size(36, 20);
            this.btnSelectSolution.TabIndex = 7;
            this.btnSelectSolution.Text = "...";
            this.btnSelectSolution.UseVisualStyleBackColor = true;
            this.btnSelectSolution.Click += new System.EventHandler(this.btnSelectSolution_Click);
            // 
            // txtSolutionFilename
            // 
            this.txtSolutionFilename.Location = new System.Drawing.Point(357, 31);
            this.txtSolutionFilename.Name = "txtSolutionFilename";
            this.txtSolutionFilename.Size = new System.Drawing.Size(192, 20);
            this.txtSolutionFilename.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Solution:";
            // 
            // txtLanguageTableSuffix
            // 
            this.txtLanguageTableSuffix.Location = new System.Drawing.Point(129, 60);
            this.txtLanguageTableSuffix.Name = "txtLanguageTableSuffix";
            this.txtLanguageTableSuffix.Size = new System.Drawing.Size(135, 20);
            this.txtLanguageTableSuffix.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Language table suffix:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(129, 31);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(135, 20);
            this.txtNamespace.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnGenerateClasses);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 479);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1127, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1040, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGenerateClasses
            // 
            this.btnGenerateClasses.Location = new System.Drawing.Point(12, 19);
            this.btnGenerateClasses.Name = "btnGenerateClasses";
            this.btnGenerateClasses.Size = new System.Drawing.Size(128, 23);
            this.btnGenerateClasses.TabIndex = 0;
            this.btnGenerateClasses.Text = "Generate classes";
            this.btnGenerateClasses.UseVisualStyleBackColor = true;
            this.btnGenerateClasses.Click += new System.EventHandler(this.btnGenerateClasses_Click);
            // 
            // tbcGeneratedClasses
            // 
            this.tbcGeneratedClasses.Controls.Add(this.tbpModelClasses);
            this.tbcGeneratedClasses.Controls.Add(this.tbpModelViewClasses);
            this.tbcGeneratedClasses.Location = new System.Drawing.Point(902, 171);
            this.tbcGeneratedClasses.Name = "tbcGeneratedClasses";
            this.tbcGeneratedClasses.SelectedIndex = 0;
            this.tbcGeneratedClasses.Size = new System.Drawing.Size(111, 71);
            this.tbcGeneratedClasses.TabIndex = 3;
            this.tbcGeneratedClasses.SelectedIndexChanged += new System.EventHandler(this.tbcGeneratedClasses_SelectedIndexChanged);
            // 
            // tbpModelClasses
            // 
            this.tbpModelClasses.Location = new System.Drawing.Point(4, 22);
            this.tbpModelClasses.Name = "tbpModelClasses";
            this.tbpModelClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModelClasses.Size = new System.Drawing.Size(103, 45);
            this.tbpModelClasses.TabIndex = 0;
            this.tbpModelClasses.Text = "Model";
            this.tbpModelClasses.UseVisualStyleBackColor = true;
            // 
            // tbpModelViewClasses
            // 
            this.tbpModelViewClasses.Controls.Add(this.txtModelViewClasses);
            this.tbpModelViewClasses.Controls.Add(this.groupBox4);
            this.tbpModelViewClasses.Location = new System.Drawing.Point(4, 22);
            this.tbpModelViewClasses.Name = "tbpModelViewClasses";
            this.tbpModelViewClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModelViewClasses.Size = new System.Drawing.Size(103, 45);
            this.tbpModelViewClasses.TabIndex = 1;
            this.tbpModelViewClasses.Text = "ModelView";
            this.tbpModelViewClasses.UseVisualStyleBackColor = true;
            // 
            // txtModelViewClasses
            // 
            this.txtModelViewClasses.Location = new System.Drawing.Point(0, 0);
            this.txtModelViewClasses.Multiline = true;
            this.txtModelViewClasses.Name = "txtModelViewClasses";
            this.txtModelViewClasses.Size = new System.Drawing.Size(890, 332);
            this.txtModelViewClasses.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtNamespaceModelView);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, -12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(97, 54);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(319, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(324, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Project:";
            // 
            // txtNamespaceModelView
            // 
            this.txtNamespaceModelView.Location = new System.Drawing.Point(79, 24);
            this.txtNamespaceModelView.Name = "txtNamespaceModelView";
            this.txtNamespaceModelView.Size = new System.Drawing.Size(160, 20);
            this.txtNamespaceModelView.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Namespace:";
            // 
            // txtClassContent
            // 
            this.txtClassContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClassContent.Location = new System.Drawing.Point(229, 54);
            this.txtClassContent.Multiline = true;
            this.txtClassContent.Name = "txtClassContent";
            this.txtClassContent.Size = new System.Drawing.Size(898, 371);
            this.txtClassContent.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbProjects);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtClassNamespace);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(229, 425);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(898, 54);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(319, 23);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(324, 21);
            this.cmbProjects.TabIndex = 3;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Project:";
            // 
            // txtClassNamespace
            // 
            this.txtClassNamespace.Location = new System.Drawing.Point(79, 24);
            this.txtClassNamespace.Name = "txtClassNamespace";
            this.txtClassNamespace.Size = new System.Drawing.Size(162, 20);
            this.txtClassNamespace.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Namespace:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbType);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(229, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(898, 54);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Set type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(13, 19);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(256, 21);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // ClassBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 679);
            this.Controls.Add(this.txtClassContent);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbcGeneratedClasses);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lstDatabaseTables);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClassBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClassBuilder";
            this.Load += new System.EventHandler(this.ClassBuilder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tbcGeneratedClasses.ResumeLayout(false);
            this.tbpModelViewClasses.ResumeLayout(false);
            this.tbpModelViewClasses.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstDatabaseTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLanguageTableSuffix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerateClasses;
        private System.Windows.Forms.TabControl tbcGeneratedClasses;
        private System.Windows.Forms.TabPage tbpModelClasses;
        private System.Windows.Forms.TextBox txtClassContent;
        private System.Windows.Forms.TabPage tbpModelViewClasses;
        private System.Windows.Forms.TextBox txtModelViewClasses;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClassNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamespaceModelView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectSolution;
        private System.Windows.Forms.TextBox txtSolutionFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSelectFramework;
        private System.Windows.Forms.CheckBox chkCreateReferences;
        private System.Windows.Forms.CheckBox chkCreateBaseClasses;
    }
}