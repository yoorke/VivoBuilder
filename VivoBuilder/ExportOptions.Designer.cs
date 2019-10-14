namespace VivoBuilder
{
    partial class ExportOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectSolution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolutionFilename = new System.Windows.Forms.TextBox();
            this.grpProjects = new System.Windows.Forms.GroupBox();
            this.cmbModelView = new System.Windows.Forms.ComboBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBusinessLogic = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBusinessLogicInterfaces = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbWebAPI = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.grpProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectSolution);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSolutionFilename);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solution";
            // 
            // btnSelectSolution
            // 
            this.btnSelectSolution.Location = new System.Drawing.Point(556, 26);
            this.btnSelectSolution.Name = "btnSelectSolution";
            this.btnSelectSolution.Size = new System.Drawing.Size(38, 20);
            this.btnSelectSolution.TabIndex = 2;
            this.btnSelectSolution.Text = "...";
            this.btnSelectSolution.UseVisualStyleBackColor = true;
            this.btnSelectSolution.Click += new System.EventHandler(this.btnSelectSolution_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filename:";
            // 
            // txtSolutionFilename
            // 
            this.txtSolutionFilename.Location = new System.Drawing.Point(82, 27);
            this.txtSolutionFilename.Name = "txtSolutionFilename";
            this.txtSolutionFilename.Size = new System.Drawing.Size(468, 20);
            this.txtSolutionFilename.TabIndex = 0;
            // 
            // grpProjects
            // 
            this.grpProjects.Controls.Add(this.cmbWebAPI);
            this.grpProjects.Controls.Add(this.label6);
            this.grpProjects.Controls.Add(this.cmbBusinessLogicInterfaces);
            this.grpProjects.Controls.Add(this.label5);
            this.grpProjects.Controls.Add(this.cmbBusinessLogic);
            this.grpProjects.Controls.Add(this.label4);
            this.grpProjects.Controls.Add(this.cmbModelView);
            this.grpProjects.Controls.Add(this.cmbModel);
            this.grpProjects.Controls.Add(this.label3);
            this.grpProjects.Controls.Add(this.label2);
            this.grpProjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProjects.Location = new System.Drawing.Point(0, 84);
            this.grpProjects.Name = "grpProjects";
            this.grpProjects.Size = new System.Drawing.Size(619, 212);
            this.grpProjects.TabIndex = 1;
            this.grpProjects.TabStop = false;
            this.grpProjects.Text = "Projects";
            // 
            // cmbModelView
            // 
            this.cmbModelView.FormattingEnabled = true;
            this.cmbModelView.Location = new System.Drawing.Point(82, 70);
            this.cmbModelView.Name = "cmbModelView";
            this.cmbModelView.Size = new System.Drawing.Size(468, 21);
            this.cmbModelView.TabIndex = 7;
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(82, 32);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(468, 21);
            this.cmbModel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Model view:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Model:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 330);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(468, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 356);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(468, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BL:";
            // 
            // cmbBusinessLogic
            // 
            this.cmbBusinessLogic.FormattingEnabled = true;
            this.cmbBusinessLogic.Location = new System.Drawing.Point(82, 103);
            this.cmbBusinessLogic.Name = "cmbBusinessLogic";
            this.cmbBusinessLogic.Size = new System.Drawing.Size(468, 21);
            this.cmbBusinessLogic.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "IBL:";
            // 
            // cmbBusinessLogicInterfaces
            // 
            this.cmbBusinessLogicInterfaces.FormattingEnabled = true;
            this.cmbBusinessLogicInterfaces.Location = new System.Drawing.Point(82, 136);
            this.cmbBusinessLogicInterfaces.Name = "cmbBusinessLogicInterfaces";
            this.cmbBusinessLogicInterfaces.Size = new System.Drawing.Size(468, 21);
            this.cmbBusinessLogicInterfaces.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "WebAPI:";
            // 
            // cmbWebAPI
            // 
            this.cmbWebAPI.FormattingEnabled = true;
            this.cmbWebAPI.Location = new System.Drawing.Point(82, 168);
            this.cmbWebAPI.Name = "cmbWebAPI";
            this.cmbWebAPI.Size = new System.Drawing.Size(468, 21);
            this.cmbWebAPI.TabIndex = 13;
            // 
            // ExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 396);
            this.Controls.Add(this.grpProjects);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "ExportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpProjects.ResumeLayout(false);
            this.grpProjects.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectSolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolutionFilename;
        private System.Windows.Forms.GroupBox grpProjects;
        private System.Windows.Forms.ComboBox cmbModelView;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmbBusinessLogic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWebAPI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBusinessLogicInterfaces;
        private System.Windows.Forms.Label label5;
    }
}