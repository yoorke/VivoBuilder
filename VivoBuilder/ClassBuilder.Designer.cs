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
            this.txtLanguageTableSuffix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerateClasses = new System.Windows.Forms.Button();
            this.tbcGeneratedClasses = new System.Windows.Forms.TabControl();
            this.tbpModelClasses = new System.Windows.Forms.TabPage();
            this.txtModelClasses = new System.Windows.Forms.TextBox();
            this.tbpModelViewClasses = new System.Windows.Forms.TabPage();
            this.txtModelViewClasses = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbcGeneratedClasses.SuspendLayout();
            this.tbpModelClasses.SuspendLayout();
            this.tbpModelViewClasses.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDatabaseTables
            // 
            this.lstDatabaseTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstDatabaseTables.FormattingEnabled = true;
            this.lstDatabaseTables.Location = new System.Drawing.Point(0, 0);
            this.lstDatabaseTables.Name = "lstDatabaseTables";
            this.lstDatabaseTables.Size = new System.Drawing.Size(229, 472);
            this.lstDatabaseTables.TabIndex = 0;
            this.lstDatabaseTables.SelectedIndexChanged += new System.EventHandler(this.lstDatabaseTables_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLanguageTableSuffix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNamespace);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 546);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
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
            this.groupBox2.Location = new System.Drawing.Point(0, 472);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1127, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            this.tbcGeneratedClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGeneratedClasses.Location = new System.Drawing.Point(229, 0);
            this.tbcGeneratedClasses.Name = "tbcGeneratedClasses";
            this.tbcGeneratedClasses.SelectedIndex = 0;
            this.tbcGeneratedClasses.Size = new System.Drawing.Size(898, 472);
            this.tbcGeneratedClasses.TabIndex = 3;
            this.tbcGeneratedClasses.SelectedIndexChanged += new System.EventHandler(this.tbcGeneratedClasses_SelectedIndexChanged);
            // 
            // tbpModelClasses
            // 
            this.tbpModelClasses.Controls.Add(this.txtModelClasses);
            this.tbpModelClasses.Location = new System.Drawing.Point(4, 22);
            this.tbpModelClasses.Name = "tbpModelClasses";
            this.tbpModelClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModelClasses.Size = new System.Drawing.Size(890, 446);
            this.tbpModelClasses.TabIndex = 0;
            this.tbpModelClasses.Text = "Model";
            this.tbpModelClasses.UseVisualStyleBackColor = true;
            // 
            // txtModelClasses
            // 
            this.txtModelClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModelClasses.Location = new System.Drawing.Point(3, 3);
            this.txtModelClasses.Multiline = true;
            this.txtModelClasses.Name = "txtModelClasses";
            this.txtModelClasses.Size = new System.Drawing.Size(884, 440);
            this.txtModelClasses.TabIndex = 0;
            // 
            // tbpModelViewClasses
            // 
            this.tbpModelViewClasses.Controls.Add(this.txtModelViewClasses);
            this.tbpModelViewClasses.Location = new System.Drawing.Point(4, 22);
            this.tbpModelViewClasses.Name = "tbpModelViewClasses";
            this.tbpModelViewClasses.Size = new System.Drawing.Size(890, 446);
            this.tbpModelViewClasses.TabIndex = 1;
            this.tbpModelViewClasses.Text = "ModelView";
            this.tbpModelViewClasses.UseVisualStyleBackColor = true;
            // 
            // txtModelViewClasses
            // 
            this.txtModelViewClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModelViewClasses.Location = new System.Drawing.Point(0, 0);
            this.txtModelViewClasses.Multiline = true;
            this.txtModelViewClasses.Name = "txtModelViewClasses";
            this.txtModelViewClasses.Size = new System.Drawing.Size(890, 446);
            this.txtModelViewClasses.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1045, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ClassBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 646);
            this.Controls.Add(this.tbcGeneratedClasses);
            this.Controls.Add(this.lstDatabaseTables);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClassBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClassBuilder";
            this.Load += new System.EventHandler(this.ClassBuilder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tbcGeneratedClasses.ResumeLayout(false);
            this.tbpModelClasses.ResumeLayout(false);
            this.tbpModelClasses.PerformLayout();
            this.tbpModelViewClasses.ResumeLayout(false);
            this.tbpModelViewClasses.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox txtModelClasses;
        private System.Windows.Forms.TabPage tbpModelViewClasses;
        private System.Windows.Forms.TextBox txtModelViewClasses;
        private System.Windows.Forms.Button btnExport;
    }
}