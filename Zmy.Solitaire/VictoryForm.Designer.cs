﻿namespace Zmy.Solitaire
{
    partial class VictoryForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelMFill = new System.Windows.Forms.Panel();
            this.panelRFill = new System.Windows.Forms.Panel();
            this.panelLFill = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelRightFill = new System.Windows.Forms.Panel();
            this.panelLeftFill = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainButtom = new System.Windows.Forms.Panel();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.panelMainMiddle = new System.Windows.Forms.Panel();
            this.panelLeastTime = new System.Windows.Forms.Panel();
            this.labelWhatTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.panelTime = new System.Windows.Forms.Panel();
            this.labelWhatSwitchNumber = new System.Windows.Forms.Label();
            this.labelSwitchNumber = new System.Windows.Forms.Label();
            this.panelDifficulty = new System.Windows.Forms.Panel();
            this.labelWhatDifficulty = new System.Windows.Forms.Label();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.panelMainRFlii = new System.Windows.Forms.Panel();
            this.panelMainLFill = new System.Windows.Forms.Panel();
            this.panelMainTFill = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainButtom.SuspendLayout();
            this.panelMainMiddle.SuspendLayout();
            this.panelLeastTime.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelDifficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.panelMFill);
            this.panelTop.Controls.Add(this.panelRFill);
            this.panelTop.Controls.Add(this.panelLFill);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(356, 16);
            this.panelTop.TabIndex = 1;
            // 
            // panelMFill
            // 
            this.panelMFill.BackColor = System.Drawing.SystemColors.Control;
            this.panelMFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMFill.Location = new System.Drawing.Point(15, 0);
            this.panelMFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMFill.Name = "panelMFill";
            this.panelMFill.Size = new System.Drawing.Size(326, 16);
            this.panelMFill.TabIndex = 2;
            this.panelMFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMFill_Paint);
            // 
            // panelRFill
            // 
            this.panelRFill.BackColor = System.Drawing.Color.Red;
            this.panelRFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRFill.Location = new System.Drawing.Point(341, 0);
            this.panelRFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRFill.Name = "panelRFill";
            this.panelRFill.Size = new System.Drawing.Size(15, 16);
            this.panelRFill.TabIndex = 1;
            // 
            // panelLFill
            // 
            this.panelLFill.BackColor = System.Drawing.Color.Red;
            this.panelLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLFill.Location = new System.Drawing.Point(0, 0);
            this.panelLFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLFill.Name = "panelLFill";
            this.panelLFill.Size = new System.Drawing.Size(15, 16);
            this.panelLFill.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.panelTitle.Controls.Add(this.buttonExit);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelTitle.Location = new System.Drawing.Point(0, 16);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(356, 40);
            this.panelTitle.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(316, 7);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(24, 26);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "×";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonNewGame_MouseLeave);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(44, 13);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(152, 16);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Congratulations!";
            // 
            // panelRightFill
            // 
            this.panelRightFill.BackColor = System.Drawing.Color.Red;
            this.panelRightFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightFill.Location = new System.Drawing.Point(341, 56);
            this.panelRightFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRightFill.Name = "panelRightFill";
            this.panelRightFill.Size = new System.Drawing.Size(15, 297);
            this.panelRightFill.TabIndex = 5;
            this.panelRightFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRightFill_Paint);
            // 
            // panelLeftFill
            // 
            this.panelLeftFill.BackColor = System.Drawing.Color.Red;
            this.panelLeftFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFill.Location = new System.Drawing.Point(0, 56);
            this.panelLeftFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeftFill.Name = "panelLeftFill";
            this.panelLeftFill.Size = new System.Drawing.Size(15, 297);
            this.panelLeftFill.TabIndex = 4;
            this.panelLeftFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeftFill_Paint);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.panelMainButtom);
            this.panelMain.Controls.Add(this.panelMainMiddle);
            this.panelMain.Controls.Add(this.panelMainRFlii);
            this.panelMain.Controls.Add(this.panelMainLFill);
            this.panelMain.Controls.Add(this.panelMainTFill);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(15, 56);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(326, 297);
            this.panelMain.TabIndex = 6;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelMainButtom
            // 
            this.panelMainButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelMainButtom.Controls.Add(this.buttonNewGame);
            this.panelMainButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainButtom.Location = new System.Drawing.Point(38, 214);
            this.panelMainButtom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainButtom.Name = "panelMainButtom";
            this.panelMainButtom.Size = new System.Drawing.Size(250, 83);
            this.panelMainButtom.TabIndex = 4;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.buttonbg1;
            this.buttonNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewGame.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonNewGame.FlatAppearance.BorderSize = 0;
            this.buttonNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNewGame.ForeColor = System.Drawing.Color.White;
            this.buttonNewGame.Location = new System.Drawing.Point(64, 22);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(126, 40);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "新游戏";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            this.buttonNewGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseDown);
            this.buttonNewGame.MouseEnter += new System.EventHandler(this.buttonNewGame_MouseEnter);
            this.buttonNewGame.MouseLeave += new System.EventHandler(this.buttonNewGame_MouseLeave);
            this.buttonNewGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseUp);
            // 
            // panelMainMiddle
            // 
            this.panelMainMiddle.BackColor = System.Drawing.Color.Transparent;
            this.panelMainMiddle.BackgroundImage = global::Zmy.Solitaire.Properties.Resources._3_40_71background;
            this.panelMainMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMainMiddle.Controls.Add(this.panelLeastTime);
            this.panelMainMiddle.Controls.Add(this.panelTime);
            this.panelMainMiddle.Controls.Add(this.panelDifficulty);
            this.panelMainMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainMiddle.Location = new System.Drawing.Point(38, 20);
            this.panelMainMiddle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainMiddle.Name = "panelMainMiddle";
            this.panelMainMiddle.Size = new System.Drawing.Size(250, 194);
            this.panelMainMiddle.TabIndex = 3;
            // 
            // panelLeastTime
            // 
            this.panelLeastTime.Controls.Add(this.labelWhatTime);
            this.panelLeastTime.Controls.Add(this.labelTime);
            this.panelLeastTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeastTime.Location = new System.Drawing.Point(0, 130);
            this.panelLeastTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeastTime.Name = "panelLeastTime";
            this.panelLeastTime.Size = new System.Drawing.Size(250, 65);
            this.panelLeastTime.TabIndex = 4;
            // 
            // labelWhatTime
            // 
            this.labelWhatTime.AutoSize = true;
            this.labelWhatTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatTime.ForeColor = System.Drawing.Color.White;
            this.labelWhatTime.Location = new System.Drawing.Point(182, 20);
            this.labelWhatTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWhatTime.Name = "labelWhatTime";
            this.labelWhatTime.Size = new System.Drawing.Size(70, 22);
            this.labelWhatTime.TabIndex = 2;
            this.labelWhatTime.Text = "00:00";
            this.labelWhatTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(8, 21);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(56, 22);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "时间";
            // 
            // panelTime
            // 
            this.panelTime.Controls.Add(this.labelWhatSwitchNumber);
            this.panelTime.Controls.Add(this.labelSwitchNumber);
            this.panelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTime.Location = new System.Drawing.Point(0, 65);
            this.panelTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(250, 65);
            this.panelTime.TabIndex = 3;
            // 
            // labelWhatSwitchNumber
            // 
            this.labelWhatSwitchNumber.AutoSize = true;
            this.labelWhatSwitchNumber.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatSwitchNumber.ForeColor = System.Drawing.Color.White;
            this.labelWhatSwitchNumber.Location = new System.Drawing.Point(176, 20);
            this.labelWhatSwitchNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWhatSwitchNumber.Name = "labelWhatSwitchNumber";
            this.labelWhatSwitchNumber.Size = new System.Drawing.Size(79, 22);
            this.labelWhatSwitchNumber.TabIndex = 2;
            this.labelWhatSwitchNumber.Text = "翻一张";
            // 
            // labelSwitchNumber
            // 
            this.labelSwitchNumber.AutoSize = true;
            this.labelSwitchNumber.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSwitchNumber.ForeColor = System.Drawing.Color.White;
            this.labelSwitchNumber.Location = new System.Drawing.Point(8, 20);
            this.labelSwitchNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSwitchNumber.Name = "labelSwitchNumber";
            this.labelSwitchNumber.Size = new System.Drawing.Size(79, 22);
            this.labelSwitchNumber.TabIndex = 1;
            this.labelSwitchNumber.Text = "翻牌数";
            // 
            // panelDifficulty
            // 
            this.panelDifficulty.Controls.Add(this.labelWhatDifficulty);
            this.panelDifficulty.Controls.Add(this.labelDifficulty);
            this.panelDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDifficulty.Location = new System.Drawing.Point(0, 0);
            this.panelDifficulty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDifficulty.Name = "panelDifficulty";
            this.panelDifficulty.Size = new System.Drawing.Size(250, 65);
            this.panelDifficulty.TabIndex = 2;
            // 
            // labelWhatDifficulty
            // 
            this.labelWhatDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWhatDifficulty.AutoSize = true;
            this.labelWhatDifficulty.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatDifficulty.ForeColor = System.Drawing.Color.White;
            this.labelWhatDifficulty.Location = new System.Drawing.Point(193, 22);
            this.labelWhatDifficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWhatDifficulty.Name = "labelWhatDifficulty";
            this.labelWhatDifficulty.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.labelWhatDifficulty.Size = new System.Drawing.Size(57, 22);
            this.labelWhatDifficulty.TabIndex = 1;
            this.labelWhatDifficulty.Text = "随机";
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.AutoSize = true;
            this.labelDifficulty.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDifficulty.ForeColor = System.Drawing.Color.White;
            this.labelDifficulty.Location = new System.Drawing.Point(8, 22);
            this.labelDifficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.Size = new System.Drawing.Size(56, 22);
            this.labelDifficulty.TabIndex = 0;
            this.labelDifficulty.Text = "难度";
            // 
            // panelMainRFlii
            // 
            this.panelMainRFlii.BackColor = System.Drawing.Color.Transparent;
            this.panelMainRFlii.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMainRFlii.Location = new System.Drawing.Point(288, 20);
            this.panelMainRFlii.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainRFlii.Name = "panelMainRFlii";
            this.panelMainRFlii.Size = new System.Drawing.Size(38, 277);
            this.panelMainRFlii.TabIndex = 2;
            // 
            // panelMainLFill
            // 
            this.panelMainLFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMainLFill.Location = new System.Drawing.Point(0, 20);
            this.panelMainLFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainLFill.Name = "panelMainLFill";
            this.panelMainLFill.Size = new System.Drawing.Size(38, 277);
            this.panelMainLFill.TabIndex = 1;
            // 
            // panelMainTFill
            // 
            this.panelMainTFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainTFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainTFill.Location = new System.Drawing.Point(0, 0);
            this.panelMainTFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainTFill.Name = "panelMainTFill";
            this.panelMainTFill.Size = new System.Drawing.Size(326, 20);
            this.panelMainTFill.TabIndex = 0;
            // 
            // VictoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(356, 353);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRightFill);
            this.Controls.Add(this.panelLeftFill);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VictoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.VictoryForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMainButtom.ResumeLayout(false);
            this.panelMainMiddle.ResumeLayout(false);
            this.panelLeastTime.ResumeLayout(false);
            this.panelLeastTime.PerformLayout();
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelDifficulty.ResumeLayout(false);
            this.panelDifficulty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMFill;
        private System.Windows.Forms.Panel panelRFill;
        private System.Windows.Forms.Panel panelLFill;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelRightFill;
        private System.Windows.Forms.Panel panelLeftFill;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMainButtom;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Panel panelMainMiddle;
        private System.Windows.Forms.Panel panelMainRFlii;
        private System.Windows.Forms.Panel panelMainLFill;
        private System.Windows.Forms.Panel panelMainTFill;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.Panel panelDifficulty;
        private System.Windows.Forms.Panel panelLeastTime;
        private System.Windows.Forms.Label labelWhatTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelWhatSwitchNumber;
        private System.Windows.Forms.Label labelSwitchNumber;
        private System.Windows.Forms.Label labelWhatDifficulty;
        private System.Windows.Forms.Label labelDifficulty;
    }
}