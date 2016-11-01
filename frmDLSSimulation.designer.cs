﻿namespace DLS
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
            this.cmbRstraint = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParameterOpen = new System.Windows.Forms.Button();
            this.btnParameterSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRstraint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBoundary = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBoundary = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RegressionResult = new System.Windows.Forms.ListBox();
            this.btnRemoveX = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddX = new System.Windows.Forms.Button();
            this.btnAddY = new System.Windows.Forms.Button();
            this.lsbLayerDriverFactor = new System.Windows.Forms.ListBox();
            this.lsbLayerLandUse = new System.Windows.Forms.ListBox();
            this.lsbLayerAll = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnProjectPath = new System.Windows.Forms.Button();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateInputData = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRstraint
            // 
            this.cmbRstraint.FormattingEnabled = true;
            this.cmbRstraint.Location = new System.Drawing.Point(27, 20);
            this.cmbRstraint.Name = "cmbRstraint";
            this.cmbRstraint.Size = new System.Drawing.Size(211, 20);
            this.cmbRstraint.TabIndex = 5;
            this.cmbRstraint.MouseHover += new System.EventHandler(this.cmbRstraint_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParameterOpen);
            this.groupBox1.Controls.Add(this.btnParameterSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtParameter);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "4.参数设置";
            // 
            // btnParameterOpen
            // 
            this.btnParameterOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnParameterOpen.Image")));
            this.btnParameterOpen.Location = new System.Drawing.Point(211, 142);
            this.btnParameterOpen.Name = "btnParameterOpen";
            this.btnParameterOpen.Size = new System.Drawing.Size(27, 27);
            this.btnParameterOpen.TabIndex = 8;
            this.btnParameterOpen.UseVisualStyleBackColor = true;
            this.btnParameterOpen.Click += new System.EventHandler(this.btnParameterOpen_Click);
            // 
            // btnParameterSave
            // 
            this.btnParameterSave.Image = ((System.Drawing.Image)(resources.GetObject("btnParameterSave.Image")));
            this.btnParameterSave.Location = new System.Drawing.Point(244, 142);
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
            this.txtParameter.Size = new System.Drawing.Size(262, 116);
            this.txtParameter.TabIndex = 6;
            this.txtParameter.Text = "5\n0 1 2 3 4 \n0.8 0.7 0.8 0.1 0\n3\n2019 2020\n0\n1";
            this.txtParameter.MouseHover += new System.EventHandler(this.txtParameter_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRstraint);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbRstraint);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3.限制区域";
            // 
            // btnRstraint
            // 
            this.btnRstraint.Image = ((System.Drawing.Image)(resources.GetObject("btnRstraint.Image")));
            this.btnRstraint.Location = new System.Drawing.Point(246, 15);
            this.btnRstraint.Name = "btnRstraint";
            this.btnRstraint.Size = new System.Drawing.Size(27, 27);
            this.btnRstraint.TabIndex = 8;
            this.btnRstraint.UseVisualStyleBackColor = true;
            this.btnRstraint.Click += new System.EventHandler(this.btnRstraint_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-143, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "参数设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBoundary);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbBoundary);
            this.groupBox3.Location = new System.Drawing.Point(12, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2.研究区域";
            // 
            // btnBoundary
            // 
            this.btnBoundary.Image = ((System.Drawing.Image)(resources.GetObject("btnBoundary.Image")));
            this.btnBoundary.Location = new System.Drawing.Point(245, 18);
            this.btnBoundary.Name = "btnBoundary";
            this.btnBoundary.Size = new System.Drawing.Size(27, 27);
            this.btnBoundary.TabIndex = 8;
            this.btnBoundary.UseVisualStyleBackColor = true;
            this.btnBoundary.Click += new System.EventHandler(this.btnBoundary_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-143, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "参数设置";
            // 
            // cmbBoundary
            // 
            this.cmbBoundary.FormattingEnabled = true;
            this.cmbBoundary.Location = new System.Drawing.Point(26, 23);
            this.cmbBoundary.Name = "cmbBoundary";
            this.cmbBoundary.Size = new System.Drawing.Size(211, 20);
            this.cmbBoundary.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.RegressionResult);
            this.groupBox4.Controls.Add(this.btnRemoveX);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnAddX);
            this.groupBox4.Controls.Add(this.btnAddY);
            this.groupBox4.Controls.Add(this.lsbLayerDriverFactor);
            this.groupBox4.Controls.Add(this.lsbLayerLandUse);
            this.groupBox4.Controls.Add(this.lsbLayerAll);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(304, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(525, 337);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "6.驱动因子";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "驱动因子";
            // 
            // RegressionResult
            // 
            this.RegressionResult.FormattingEnabled = true;
            this.RegressionResult.ItemHeight = 12;
            this.RegressionResult.Location = new System.Drawing.Point(326, 38);
            this.RegressionResult.Name = "RegressionResult";
            this.RegressionResult.Size = new System.Drawing.Size(190, 280);
            this.RegressionResult.TabIndex = 18;
            // 
            // btnRemoveX
            // 
            this.btnRemoveX.Location = new System.Drawing.Point(145, 198);
            this.btnRemoveX.Name = "btnRemoveX";
            this.btnRemoveX.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveX.TabIndex = 17;
            this.btnRemoveX.Text = "←";
            this.btnRemoveX.UseVisualStyleBackColor = true;
            this.btnRemoveX.Click += new System.EventHandler(this.btnRemoveX_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "土地利用变化驱动因子";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "土地利用类型数据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "空间数据列表";
            // 
            // btnAddX
            // 
            this.btnAddX.Location = new System.Drawing.Point(145, 169);
            this.btnAddX.Name = "btnAddX";
            this.btnAddX.Size = new System.Drawing.Size(25, 23);
            this.btnAddX.TabIndex = 12;
            this.btnAddX.Text = "→";
            this.btnAddX.UseVisualStyleBackColor = true;
            this.btnAddX.Click += new System.EventHandler(this.btnAddX_Click);
            // 
            // btnAddY
            // 
            this.btnAddY.Location = new System.Drawing.Point(145, 49);
            this.btnAddY.Name = "btnAddY";
            this.btnAddY.Size = new System.Drawing.Size(25, 23);
            this.btnAddY.TabIndex = 11;
            this.btnAddY.Text = "→";
            this.btnAddY.UseVisualStyleBackColor = true;
            this.btnAddY.Click += new System.EventHandler(this.btnAddY_Click);
            // 
            // lsbLayerDriverFactor
            // 
            this.lsbLayerDriverFactor.FormattingEnabled = true;
            this.lsbLayerDriverFactor.ItemHeight = 12;
            this.lsbLayerDriverFactor.Location = new System.Drawing.Point(180, 110);
            this.lsbLayerDriverFactor.Name = "lsbLayerDriverFactor";
            this.lsbLayerDriverFactor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbLayerDriverFactor.Size = new System.Drawing.Size(140, 208);
            this.lsbLayerDriverFactor.Sorted = true;
            this.lsbLayerDriverFactor.TabIndex = 8;
            // 
            // lsbLayerLandUse
            // 
            this.lsbLayerLandUse.FormattingEnabled = true;
            this.lsbLayerLandUse.ItemHeight = 12;
            this.lsbLayerLandUse.Location = new System.Drawing.Point(180, 38);
            this.lsbLayerLandUse.Name = "lsbLayerLandUse";
            this.lsbLayerLandUse.Size = new System.Drawing.Size(140, 40);
            this.lsbLayerLandUse.TabIndex = 9;
            // 
            // lsbLayerAll
            // 
            this.lsbLayerAll.FormattingEnabled = true;
            this.lsbLayerAll.ItemHeight = 12;
            this.lsbLayerAll.Location = new System.Drawing.Point(12, 38);
            this.lsbLayerAll.Name = "lsbLayerAll";
            this.lsbLayerAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbLayerAll.Size = new System.Drawing.Size(126, 280);
            this.lsbLayerAll.Sorted = true;
            this.lsbLayerAll.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-143, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "参数设置";
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(732, 355);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(90, 28);
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
            this.txtProjectPath.Text = "D:";
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
            // btnGenerateInputData
            // 
            this.btnGenerateInputData.Location = new System.Drawing.Point(633, 355);
            this.btnGenerateInputData.Name = "btnGenerateInputData";
            this.btnGenerateInputData.Size = new System.Drawing.Size(89, 28);
            this.btnGenerateInputData.TabIndex = 16;
            this.btnGenerateInputData.Text = "生成输入数据";
            this.btnGenerateInputData.UseVisualStyleBackColor = true;
            this.btnGenerateInputData.Click += new System.EventHandler(this.btnGenerateInputData_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtxtState);
            this.groupBox6.Location = new System.Drawing.Point(304, 407);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(524, 104);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "状态窗口";
            // 
            // rtxtState
            // 
            this.rtxtState.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rtxtState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtState.Location = new System.Drawing.Point(3, 17);
            this.rtxtState.Name = "rtxtState";
            this.rtxtState.ReadOnly = true;
            this.rtxtState.Size = new System.Drawing.Size(518, 84);
            this.rtxtState.TabIndex = 18;
            this.rtxtState.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnDemandOpen);
            this.groupBox7.Controls.Add(this.btnDemandSave);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtDemand);
            this.groupBox7.Location = new System.Drawing.Point(12, 363);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(286, 158);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "5.用地需求";
            // 
            // btnDemandOpen
            // 
            this.btnDemandOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnDemandOpen.Image")));
            this.btnDemandOpen.Location = new System.Drawing.Point(210, 121);
            this.btnDemandOpen.Name = "btnDemandOpen";
            this.btnDemandOpen.Size = new System.Drawing.Size(27, 27);
            this.btnDemandOpen.TabIndex = 8;
            this.btnDemandOpen.UseVisualStyleBackColor = true;
            this.btnDemandOpen.Click += new System.EventHandler(this.btnDemandOpen_Click);
            // 
            // btnDemandSave
            // 
            this.btnDemandSave.Image = ((System.Drawing.Image)(resources.GetObject("btnDemandSave.Image")));
            this.btnDemandSave.Location = new System.Drawing.Point(243, 121);
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
            this.txtDemand.Size = new System.Drawing.Size(262, 95);
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
            this.btn_copydata.Location = new System.Drawing.Point(633, 389);
            this.btn_copydata.Name = "btn_copydata";
            this.btn_copydata.Size = new System.Drawing.Size(89, 23);
            this.btn_copydata.TabIndex = 21;
            this.btn_copydata.Text = "情景参数提取 ";
            this.btn_copydata.UseVisualStyleBackColor = true;
            this.btn_copydata.Click += new System.EventHandler(this.btn_copydata_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbx_scene);
            this.groupBox8.Controls.Add(this.cbx_risk);
            this.groupBox8.Location = new System.Drawing.Point(311, 355);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(298, 46);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "情景选择";
            // 
            // btn_outTransfer
            // 
            this.btn_outTransfer.Location = new System.Drawing.Point(732, 389);
            this.btn_outTransfer.Name = "btn_outTransfer";
            this.btn_outTransfer.Size = new System.Drawing.Size(88, 23);
            this.btn_outTransfer.TabIndex = 22;
            this.btn_outTransfer.Text = "结果输出";
            this.btn_outTransfer.UseVisualStyleBackColor = true;
            this.btn_outTransfer.Click += new System.EventHandler(this.btn_outTransfer_Click);
            // 
            // frmDLSSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(834, 523);
            this.Controls.Add(this.btn_outTransfer);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btn_copydata);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnGenerateInputData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSimulation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.Name = "frmDLSSimulation";
            this.Text = "空间布局模拟";
            this.Load += new System.EventHandler(this.frmDLSParemeters_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRstraint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtParameter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBoundary;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddX;
        private System.Windows.Forms.Button btnAddY;
        private System.Windows.Forms.ListBox lsbLayerDriverFactor;
        private System.Windows.Forms.ListBox lsbLayerLandUse;
        private System.Windows.Forms.ListBox lsbLayerAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnParameterSave;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProjectPath;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Button btnParameterOpen;
        private System.Windows.Forms.Button btnRstraint;
        private System.Windows.Forms.Button btnBoundary;
        private System.Windows.Forms.Button btnRemoveX;
        private System.Windows.Forms.Button btnGenerateInputData;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtxtState;
        private System.Windows.Forms.ListBox RegressionResult;
        private System.Windows.Forms.Label label6;
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
    }
}