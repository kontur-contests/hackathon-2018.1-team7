namespace DevUiWinForms
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUnitHorse = new System.Windows.Forms.RadioButton();
            this.radioButtonUnitArcher = new System.Windows.Forms.RadioButton();
            this.radioButtonUnitSwords = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this._radioTeamA = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonGameSpeedX4 = new System.Windows.Forms.RadioButton();
            this.radioButtonGameSpeedX2 = new System.Windows.Forms.RadioButton();
            this.radioButtonGameSpeedNormal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonGenerateWorld = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWorldY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWorldX = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxSquareAmount = new System.Windows.Forms.TextBox();
            this.radioButtonSquare = new System.Windows.Forms.RadioButton();
            this.radioButtonOneUnit = new System.Windows.Forms.RadioButton();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.48485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.51515F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.73431F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.26568F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 724);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(979, 585);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(988, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(123, 585);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUnitHorse);
            this.groupBox1.Controls.Add(this.radioButtonUnitArcher);
            this.groupBox1.Controls.Add(this.radioButtonUnitSwords);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UnitType";
            // 
            // radioButtonUnitHorse
            // 
            this.radioButtonUnitHorse.AutoSize = true;
            this.radioButtonUnitHorse.Location = new System.Drawing.Point(6, 42);
            this.radioButtonUnitHorse.Name = "radioButtonUnitHorse";
            this.radioButtonUnitHorse.Size = new System.Drawing.Size(71, 17);
            this.radioButtonUnitHorse.TabIndex = 1;
            this.radioButtonUnitHorse.TabStop = true;
            this.radioButtonUnitHorse.Text = "horseman";
            this.radioButtonUnitHorse.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnitArcher
            // 
            this.radioButtonUnitArcher.AutoSize = true;
            this.radioButtonUnitArcher.Location = new System.Drawing.Point(6, 65);
            this.radioButtonUnitArcher.Name = "radioButtonUnitArcher";
            this.radioButtonUnitArcher.Size = new System.Drawing.Size(55, 17);
            this.radioButtonUnitArcher.TabIndex = 2;
            this.radioButtonUnitArcher.TabStop = true;
            this.radioButtonUnitArcher.Text = "archer";
            this.radioButtonUnitArcher.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnitSwords
            // 
            this.radioButtonUnitSwords.AutoSize = true;
            this.radioButtonUnitSwords.Checked = true;
            this.radioButtonUnitSwords.Location = new System.Drawing.Point(6, 19);
            this.radioButtonUnitSwords.Name = "radioButtonUnitSwords";
            this.radioButtonUnitSwords.Size = new System.Drawing.Size(78, 17);
            this.radioButtonUnitSwords.TabIndex = 0;
            this.radioButtonUnitSwords.TabStop = true;
            this.radioButtonUnitSwords.Text = "swordsman";
            this.radioButtonUnitSwords.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this._radioTeamA);
            this.groupBox2.Location = new System.Drawing.Point(3, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 43);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Text = "TeamB";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // _radioTeamA
            // 
            this._radioTeamA.AutoSize = true;
            this._radioTeamA.Checked = true;
            this._radioTeamA.Location = new System.Drawing.Point(7, 20);
            this._radioTeamA.Name = "_radioTeamA";
            this._radioTeamA.Size = new System.Drawing.Size(59, 17);
            this._radioTeamA.TabIndex = 0;
            this._radioTeamA.TabStop = true;
            this._radioTeamA.Text = "TeamA";
            this._radioTeamA.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonGameSpeedX4);
            this.groupBox3.Controls.Add(this.radioButtonGameSpeedX2);
            this.groupBox3.Controls.Add(this.radioButtonGameSpeedNormal);
            this.groupBox3.Location = new System.Drawing.Point(3, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(104, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GameSpeed";
            // 
            // radioButtonGameSpeedX4
            // 
            this.radioButtonGameSpeedX4.AutoSize = true;
            this.radioButtonGameSpeedX4.Location = new System.Drawing.Point(7, 67);
            this.radioButtonGameSpeedX4.Name = "radioButtonGameSpeedX4";
            this.radioButtonGameSpeedX4.Size = new System.Drawing.Size(36, 17);
            this.radioButtonGameSpeedX4.TabIndex = 2;
            this.radioButtonGameSpeedX4.Text = "x4";
            this.radioButtonGameSpeedX4.UseVisualStyleBackColor = true;
            this.radioButtonGameSpeedX4.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButtonGameSpeedX2
            // 
            this.radioButtonGameSpeedX2.AutoSize = true;
            this.radioButtonGameSpeedX2.Location = new System.Drawing.Point(7, 44);
            this.radioButtonGameSpeedX2.Name = "radioButtonGameSpeedX2";
            this.radioButtonGameSpeedX2.Size = new System.Drawing.Size(36, 17);
            this.radioButtonGameSpeedX2.TabIndex = 1;
            this.radioButtonGameSpeedX2.Text = "x2";
            this.radioButtonGameSpeedX2.UseVisualStyleBackColor = true;
            this.radioButtonGameSpeedX2.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButtonGameSpeedNormal
            // 
            this.radioButtonGameSpeedNormal.AutoSize = true;
            this.radioButtonGameSpeedNormal.Checked = true;
            this.radioButtonGameSpeedNormal.Location = new System.Drawing.Point(7, 20);
            this.radioButtonGameSpeedNormal.Name = "radioButtonGameSpeedNormal";
            this.radioButtonGameSpeedNormal.Size = new System.Drawing.Size(58, 17);
            this.radioButtonGameSpeedNormal.TabIndex = 0;
            this.radioButtonGameSpeedNormal.TabStop = true;
            this.radioButtonGameSpeedNormal.Text = "Normal";
            this.radioButtonGameSpeedNormal.UseVisualStyleBackColor = true;
            this.radioButtonGameSpeedNormal.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxPreset);
            this.groupBox4.Controls.Add(this.buttonGenerateWorld);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxWorldY);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxWorldX);
            this.groupBox4.Location = new System.Drawing.Point(3, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(104, 130);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // buttonGenerateWorld
            // 
            this.buttonGenerateWorld.Location = new System.Drawing.Point(29, 101);
            this.buttonGenerateWorld.Name = "buttonGenerateWorld";
            this.buttonGenerateWorld.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateWorld.TabIndex = 4;
            this.buttonGenerateWorld.Text = "New wold";
            this.buttonGenerateWorld.UseVisualStyleBackColor = true;
            this.buttonGenerateWorld.Click += new System.EventHandler(this.buttonGenerateWorld_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // textBoxWorldY
            // 
            this.textBoxWorldY.Location = new System.Drawing.Point(38, 49);
            this.textBoxWorldY.Name = "textBoxWorldY";
            this.textBoxWorldY.Size = new System.Drawing.Size(66, 20);
            this.textBoxWorldY.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // textBoxWorldX
            // 
            this.textBoxWorldX.Location = new System.Drawing.Point(38, 23);
            this.textBoxWorldX.Name = "textBoxWorldX";
            this.textBoxWorldX.Size = new System.Drawing.Size(66, 20);
            this.textBoxWorldX.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxSquareAmount);
            this.groupBox5.Controls.Add(this.radioButtonSquare);
            this.groupBox5.Controls.Add(this.radioButtonOneUnit);
            this.groupBox5.Location = new System.Drawing.Point(3, 436);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // textBoxSquareAmount
            // 
            this.textBoxSquareAmount.Location = new System.Drawing.Point(2, 67);
            this.textBoxSquareAmount.Name = "textBoxSquareAmount";
            this.textBoxSquareAmount.Size = new System.Drawing.Size(82, 20);
            this.textBoxSquareAmount.TabIndex = 2;
            this.textBoxSquareAmount.Text = "50";
            // 
            // radioButtonSquare
            // 
            this.radioButtonSquare.AutoSize = true;
            this.radioButtonSquare.Location = new System.Drawing.Point(6, 44);
            this.radioButtonSquare.Name = "radioButtonSquare";
            this.radioButtonSquare.Size = new System.Drawing.Size(57, 17);
            this.radioButtonSquare.TabIndex = 1;
            this.radioButtonSquare.TabStop = true;
            this.radioButtonSquare.Text = "square";
            this.radioButtonSquare.UseVisualStyleBackColor = true;
            // 
            // radioButtonOneUnit
            // 
            this.radioButtonOneUnit.AutoSize = true;
            this.radioButtonOneUnit.Checked = true;
            this.radioButtonOneUnit.Location = new System.Drawing.Point(6, 20);
            this.radioButtonOneUnit.Name = "radioButtonOneUnit";
            this.radioButtonOneUnit.Size = new System.Drawing.Size(63, 17);
            this.radioButtonOneUnit.TabIndex = 0;
            this.radioButtonOneUnit.TabStop = true;
            this.radioButtonOneUnit.Text = "one unit";
            this.radioButtonOneUnit.UseVisualStyleBackColor = true;
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Items.AddRange(new object[] {
            "1"});
            this.comboBoxPreset.Location = new System.Drawing.Point(7, 75);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(97, 21);
            this.comboBoxPreset.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 724);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUnitSwords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton _radioTeamA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonGameSpeedX4;
        private System.Windows.Forms.RadioButton radioButtonGameSpeedX2;
        private System.Windows.Forms.RadioButton radioButtonGameSpeedNormal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonGenerateWorld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWorldY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWorldX;
        private System.Windows.Forms.RadioButton radioButtonUnitHorse;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonSquare;
        private System.Windows.Forms.RadioButton radioButtonOneUnit;
        private System.Windows.Forms.TextBox textBoxSquareAmount;
        private System.Windows.Forms.RadioButton radioButtonUnitArcher;
        private System.Windows.Forms.ComboBox comboBoxPreset;
    }
}

