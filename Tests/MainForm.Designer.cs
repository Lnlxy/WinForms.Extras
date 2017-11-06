namespace Tests
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudB = new System.Windows.Forms.NumericUpDown();
            this.nudG = new System.Windows.Forms.NumericUpDown();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnAddR = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMenuText = new System.Windows.Forms.TextBox();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.btnAddB = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAddG = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblB);
            this.groupBox1.Controls.Add(this.lblG);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudB);
            this.groupBox1.Controls.Add(this.nudG);
            this.groupBox1.Controls.Add(this.nudR);
            this.groupBox1.Controls.Add(this.lblColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Bidnings";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(10, 88);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 12);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "lblTotal";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blue";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Green";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(336, 66);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(47, 12);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "{value}";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(180, 66);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(47, 12);
            this.lblG.TabIndex = 3;
            this.lblG.Text = "{value}";
            this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(37, 66);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(47, 12);
            this.lblR.TabIndex = 3;
            this.lblR.Text = "{value}";
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Red";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudB
            // 
            this.nudB.Location = new System.Drawing.Point(338, 42);
            this.nudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(76, 21);
            this.nudB.TabIndex = 1;
            // 
            // nudG
            // 
            this.nudG.Location = new System.Drawing.Point(182, 42);
            this.nudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudG.Name = "nudG";
            this.nudG.Size = new System.Drawing.Size(76, 21);
            this.nudG.TabIndex = 1;
            // 
            // nudR
            // 
            this.nudR.Location = new System.Drawing.Point(39, 42);
            this.nudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(76, 21);
            this.nudR.TabIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblColor.Location = new System.Drawing.Point(3, 17);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(415, 22);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "Color";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // btnAddR
            // 
            this.btnAddR.Location = new System.Drawing.Point(12, 20);
            this.btnAddR.Name = "btnAddR";
            this.btnAddR.Size = new System.Drawing.Size(75, 23);
            this.btnAddR.TabIndex = 1;
            this.btnAddR.Text = "Add Red";
            this.btnAddR.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMenuText);
            this.groupBox2.Controls.Add(this.txtAppName);
            this.groupBox2.Controls.Add(this.btnAddB);
            this.groupBox2.Controls.Add(this.btnAll);
            this.groupBox2.Controls.Add(this.btnAddG);
            this.groupBox2.Controls.Add(this.btnAddR);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 218);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command Bindings";
            // 
            // txtMenuText
            // 
            this.txtMenuText.Location = new System.Drawing.Point(103, 165);
            this.txtMenuText.Name = "txtMenuText";
            this.txtMenuText.Size = new System.Drawing.Size(172, 21);
            this.txtMenuText.TabIndex = 2;
            this.txtMenuText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(103, 109);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(172, 21);
            this.txtAppName.TabIndex = 2;
            // 
            // btnAddB
            // 
            this.btnAddB.Location = new System.Drawing.Point(305, 20);
            this.btnAddB.Name = "btnAddB";
            this.btnAddB.Size = new System.Drawing.Size(75, 23);
            this.btnAddB.TabIndex = 1;
            this.btnAddB.Text = "Add Blue";
            this.btnAddB.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(143, 80);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Add All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnAddG
            // 
            this.btnAddG.Location = new System.Drawing.Point(143, 20);
            this.btnAddG.Name = "btnAddG";
            this.btnAddG.Size = new System.Drawing.Size(75, 23);
            this.btnAddG.TabIndex = 1;
            this.btnAddG.Text = "Add Green";
            this.btnAddG.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(5, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.item1ToolStripMenuItem.Text = "item1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "WinForm.Extras Tests";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudB;
        private System.Windows.Forms.NumericUpDown nudG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAddR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Button btnAddB;
        private System.Windows.Forms.Button btnAddG;
        private System.Windows.Forms.TextBox txtMenuText;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
    }
}

