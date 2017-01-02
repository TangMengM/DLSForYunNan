namespace DLS
{
    partial class frmDLSSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDLSSimulation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParameterOpen = new System.Windows.Forms.Button();
            this.btnParameterSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.RichTextBox();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnProjectPath = new System.Windows.Forms.Button();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtxtState = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnDemandOpen = new System.Windows.Forms.Button();
            this.btnDemandSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDemand = new System.Windows.Forms.RichTextBox();
            this.cbx_risk = new System.Windows.Forms.ComboBox();
            this.cbx_scene = new System.Windows.Forms.ComboBox();
            this.btn_copydata = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_outTransfer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParameterOpen);
            this.groupBox1.Controls.Add(this.btnParameterSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtParameter);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2.参数设置";
            // 
            // btnParameterOpen
            // 
            this.btnParameterOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnParameterOpen.Image")));
            this.btnParameterOpen.Location = new System.Drawing.Point(210, 251);
            this.btnParameterOpen.Name = "btnParameterOpen";
            this.btnParameterOpen.Size = new System.Drawing.Size(27, 27);
            this.btnParameterOpen.TabIndex = 8;
            this.btnParameterOpen.UseVisualStyleBackColor = true;
            this.btnParameterOpen.Click += new System.EventHandler(this.btnParameterOpen_Click);
            // 
            // btnParameterSave
            // 
            this.btnParameterSave.Image = ((System.Drawing.Image)(resources.GetObject("btnParameterSave.Image")));
            this.btnParameterSave.Location = new System.Drawing.Point(243, 251);
            this.btnParameterSave.Name = "btnParameterSave";
            this.btnParameterSave.Size = new System.Drawing.Size(27, 27);
            this.btnParameterSave.TabIndex = 8;
            this.btnParameterSave.UseVisualStyleBackColor = true;
            this.btnParameterSave.Click += new System.EventHandler(this.btnParameterSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-143, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "参数设置";
            // 
            // txtParameter
            // 
            this.txtParameter.BackColor = System.Drawing.SystemColors.Window;
            this.txtParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParameter.Location = new System.Drawing.Point(6, 20);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(262, 225);
            this.txtParameter.TabIndex = 6;
            this.txtParameter.Text = "5\n0 1 2 3 4 \n0.8 0.7 0.8 0.1 0\n3\n2019 2020\n0\n1";
            this.txtParameter.MouseHover += new System.EventHandler(this.txtParameter_MouseHover);
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(120, 90);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(100, 28);
            this.btnSimulation.TabIndex = 16;
            this.btnSimulation.Text = "空间布局模拟";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnProjectPath);
            this.groupBox5.Controls.Add(this.txtProjectPath);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 61);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "1.工程位置";
            // 
            // btnProjectPath
            // 
            this.btnProjectPath.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectPath.Image")));
            this.btnProjectPath.Location = new System.Drawing.Point(245, 21);
            this.btnProjectPath.Name = "btnProjectPath";
            this.btnProjectPath.Size = new System.Drawing.Size(27, 27);
            this.btnProjectPath.TabIndex = 8;
            this.btnProjectPath.UseVisualStyleBackColor = true;
            this.btnProjectPath.Click += new System.EventHandler(this.btnProjectPath_Click);
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Location = new System.Drawing.Point(26, 23);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(211, 21);
            this.txtProjectPath.TabIndex = 8;
            this.txtProjectPath.Text = "D:\\";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-143, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "参数设置";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtxtState);
            this.groupBox6.Location = new System.Drawing.Point(309, 284);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(402, 104);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "5.状态窗口";
            // 
            // rtxtState
            // 
            this.rtxtState.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rtxtState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtState.Location = new System.Drawing.Point(3, 17);
            this.rtxtState.Name = "rtxtState";
            this.rtxtState.ReadOnly = true;
            this.rtxtState.Size = new System.Drawing.Size(396, 84);
            this.rtxtState.TabIndex = 18;
            this.rtxtState.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnDemandOpen);
            this.groupBox7.Controls.Add(this.btnDemandSave);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtDemand);
            this.groupBox7.Location = new System.Drawing.Point(307, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(410, 129);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "3.用地需求";
            // 
            // btnDemandOpen
            // 
            this.btnDemandOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnDemandOpen.Image")));
            this.btnDemandOpen.Location = new System.Drawing.Point(372, 20);
            this.btnDemandOpen.Name = "btnDemandOpen";
            this.btnDemandOpen.Size = new System.Drawing.Size(27, 27);
            this.btnDemandOpen.TabIndex = 8;
            this.btnDemandOpen.UseVisualStyleBackColor = true;
            this.btnDemandOpen.Click += new System.EventHandler(this.btnDemandOpen_Click);
            // 
            // btnDemandSave
            // 
            this.btnDemandSave.Image = ((System.Drawing.Image)(resources.GetObject("btnDemandSave.Image")));
            this.btnDemandSave.Location = new System.Drawing.Point(372, 53);
            this.btnDemandSave.Name = "btnDemandSave";
            this.btnDemandSave.Size = new System.Drawing.Size(27, 27);
            this.btnDemandSave.TabIndex = 8;
            this.btnDemandSave.UseVisualStyleBackColor = true;
            this.btnDemandSave.Click += new System.EventHandler(this.btnDemandSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-143, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "参数设置";
            // 
            // txtDemand
            // 
            this.txtDemand.BackColor = System.Drawing.SystemColors.Window;
            this.txtDemand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDemand.Location = new System.Drawing.Point(8, 20);
            this.txtDemand.Name = "txtDemand";
            this.txtDemand.Size = new System.Drawing.Size(358, 95);
            this.txtDemand.TabIndex = 6;
            this.txtDemand.Text = "118 394 711 208 306\n115 390 684 208 340";
            // 
            // cbx_risk
            // 
            this.cbx_risk.FormattingEnabled = true;
            this.cbx_risk.Location = new System.Drawing.Point(6, 17);
            this.cbx_risk.Name = "cbx_risk";
            this.cbx_risk.Size = new System.Drawing.Size(126, 20);
            this.cbx_risk.TabIndex = 19;
            this.cbx_risk.Text = "高风险";
            // 
            // cbx_scene
            // 
            this.cbx_scene.FormattingEnabled = true;
            this.cbx_scene.Location = new System.Drawing.Point(168, 17);
            this.cbx_scene.Name = "cbx_scene";
            this.cbx_scene.Size = new System.Drawing.Size(121, 20);
            this.cbx_scene.TabIndex = 20;
            this.cbx_scene.Text = "基准情景";
            // 
            // btn_copydata
            // 
            this.btn_copydata.Location = new System.Drawing.Point(14, 90);
            this.btn_copydata.Name = "btn_copydata";
            this.btn_copydata.Size = new System.Drawing.Size(100, 28);
            this.btn_copydata.TabIndex = 21;
            this.btn_copydata.Text = "情景参数提取 ";
            this.btn_copydata.UseVisualStyleBackColor = true;
            this.btn_copydata.Click += new System.EventHandler(this.btn_copydata_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbx_scene);
            this.groupBox8.Controls.Add(this.cbx_risk);
            this.groupBox8.Location = new System.Drawing.Point(8, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(298, 46);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "情景选择";
            // 
            // btn_outTransfer
            // 
            this.btn_outTransfer.Location = new System.Drawing.Point(226, 90);
            this.btn_outTransfer.Name = "btn_outTransfer";
            this.btn_outTransfer.Size = new System.Drawing.Size(100, 28);
            this.btn_outTransfer.TabIndex = 22;
            this.btn_outTransfer.Text = "结果输出";
            this.btn_outTransfer.UseVisualStyleBackColor = true;
            this.btn_outTransfer.Click += new System.EventHandler(this.btn_outTransfer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.btn_outTransfer);
            this.groupBox2.Controls.Add(this.btn_copydata);
            this.groupBox2.Controls.Add(this.btnSimulation);
            this.groupBox2.Location = new System.Drawing.Point(309, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 131);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4.情景选择";
            // 
            // frmDLSSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(721, 394);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.Name = "frmDLSSimulation";
            this.Text = "空间布局模拟";
            this.Load += new System.EventHandler(this.frmDLSParemeters_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtParameter;
        private System.Windows.Forms.Button btnParameterSave;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProjectPath;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Button btnParameterOpen;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtxtState;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDemandOpen;
        private System.Windows.Forms.Button btnDemandSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtDemand;
        private System.Windows.Forms.ComboBox cbx_risk;
        private System.Windows.Forms.ComboBox cbx_scene;
        private System.Windows.Forms.Button btn_copydata;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_outTransfer;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}