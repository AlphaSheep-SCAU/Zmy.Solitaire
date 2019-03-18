namespace Zmy.Solitaire
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
            this.panelTime = new System.Windows.Forms.Panel();
            this.panelDifficulty = new System.Windows.Forms.Panel();
            this.panelMainRFlii = new System.Windows.Forms.Panel();
            this.panelMainLFill = new System.Windows.Forms.Panel();
            this.panelMainTFill = new System.Windows.Forms.Panel();
            this.panelLeastTime = new System.Windows.Forms.Panel();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelLeastTime = new System.Windows.Forms.Label();
            this.labelWhatDifficulty = new System.Windows.Forms.Label();
            this.labelWhatTime = new System.Windows.Forms.Label();
            this.labelWhatLeastTime = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainButtom.SuspendLayout();
            this.panelMainMiddle.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelDifficulty.SuspendLayout();
            this.panelLeastTime.SuspendLayout();
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
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(475, 20);
            this.panelTop.TabIndex = 1;
            // 
            // panelMFill
            // 
            this.panelMFill.BackColor = System.Drawing.SystemColors.Control;
            this.panelMFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMFill.Location = new System.Drawing.Point(20, 0);
            this.panelMFill.Name = "panelMFill";
            this.panelMFill.Size = new System.Drawing.Size(435, 20);
            this.panelMFill.TabIndex = 2;
            this.panelMFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMFill_Paint);
            // 
            // panelRFill
            // 
            this.panelRFill.BackColor = System.Drawing.Color.Red;
            this.panelRFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRFill.Location = new System.Drawing.Point(455, 0);
            this.panelRFill.Name = "panelRFill";
            this.panelRFill.Size = new System.Drawing.Size(20, 20);
            this.panelRFill.TabIndex = 1;
            // 
            // panelLFill
            // 
            this.panelLFill.BackColor = System.Drawing.Color.Red;
            this.panelLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLFill.Location = new System.Drawing.Point(0, 0);
            this.panelLFill.Name = "panelLFill";
            this.panelLFill.Size = new System.Drawing.Size(20, 20);
            this.panelLFill.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.panelTitle.Controls.Add(this.buttonExit);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelTitle.Location = new System.Drawing.Point(0, 20);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(475, 51);
            this.panelTitle.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(422, 9);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(32, 32);
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
            this.labelTitle.Location = new System.Drawing.Point(58, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(185, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Congratulations!";
            // 
            // panelRightFill
            // 
            this.panelRightFill.BackColor = System.Drawing.Color.Red;
            this.panelRightFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightFill.Location = new System.Drawing.Point(455, 71);
            this.panelRightFill.Name = "panelRightFill";
            this.panelRightFill.Size = new System.Drawing.Size(20, 370);
            this.panelRightFill.TabIndex = 5;
            this.panelRightFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRightFill_Paint);
            // 
            // panelLeftFill
            // 
            this.panelLeftFill.BackColor = System.Drawing.Color.Red;
            this.panelLeftFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFill.Location = new System.Drawing.Point(0, 71);
            this.panelLeftFill.Name = "panelLeftFill";
            this.panelLeftFill.Size = new System.Drawing.Size(20, 370);
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
            this.panelMain.Location = new System.Drawing.Point(20, 71);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(435, 370);
            this.panelMain.TabIndex = 6;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelMainButtom
            // 
            this.panelMainButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelMainButtom.Controls.Add(this.buttonNewGame);
            this.panelMainButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainButtom.Location = new System.Drawing.Point(50, 268);
            this.panelMainButtom.Name = "panelMainButtom";
            this.panelMainButtom.Size = new System.Drawing.Size(335, 102);
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
            this.buttonNewGame.Location = new System.Drawing.Point(86, 28);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(168, 50);
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
            this.panelMainMiddle.Location = new System.Drawing.Point(50, 25);
            this.panelMainMiddle.Name = "panelMainMiddle";
            this.panelMainMiddle.Size = new System.Drawing.Size(335, 243);
            this.panelMainMiddle.TabIndex = 3;
            // 
            // panelTime
            // 
            this.panelTime.Controls.Add(this.labelWhatTime);
            this.panelTime.Controls.Add(this.labelTime);
            this.panelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTime.Location = new System.Drawing.Point(0, 81);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(335, 81);
            this.panelTime.TabIndex = 3;
            // 
            // panelDifficulty
            // 
            this.panelDifficulty.Controls.Add(this.labelWhatDifficulty);
            this.panelDifficulty.Controls.Add(this.labelDifficulty);
            this.panelDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDifficulty.Location = new System.Drawing.Point(0, 0);
            this.panelDifficulty.Name = "panelDifficulty";
            this.panelDifficulty.Size = new System.Drawing.Size(335, 81);
            this.panelDifficulty.TabIndex = 2;
            // 
            // panelMainRFlii
            // 
            this.panelMainRFlii.BackColor = System.Drawing.Color.Transparent;
            this.panelMainRFlii.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMainRFlii.Location = new System.Drawing.Point(385, 25);
            this.panelMainRFlii.Name = "panelMainRFlii";
            this.panelMainRFlii.Size = new System.Drawing.Size(50, 345);
            this.panelMainRFlii.TabIndex = 2;
            // 
            // panelMainLFill
            // 
            this.panelMainLFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMainLFill.Location = new System.Drawing.Point(0, 25);
            this.panelMainLFill.Name = "panelMainLFill";
            this.panelMainLFill.Size = new System.Drawing.Size(50, 345);
            this.panelMainLFill.TabIndex = 1;
            // 
            // panelMainTFill
            // 
            this.panelMainTFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainTFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainTFill.Location = new System.Drawing.Point(0, 0);
            this.panelMainTFill.Name = "panelMainTFill";
            this.panelMainTFill.Size = new System.Drawing.Size(435, 25);
            this.panelMainTFill.TabIndex = 0;
            // 
            // panelLeastTime
            // 
            this.panelLeastTime.Controls.Add(this.labelWhatLeastTime);
            this.panelLeastTime.Controls.Add(this.labelLeastTime);
            this.panelLeastTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeastTime.Location = new System.Drawing.Point(0, 162);
            this.panelLeastTime.Name = "panelLeastTime";
            this.panelLeastTime.Size = new System.Drawing.Size(335, 81);
            this.panelLeastTime.TabIndex = 4;
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.AutoSize = true;
            this.labelDifficulty.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDifficulty.ForeColor = System.Drawing.Color.White;
            this.labelDifficulty.Location = new System.Drawing.Point(11, 27);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.Size = new System.Drawing.Size(70, 28);
            this.labelDifficulty.TabIndex = 0;
            this.labelDifficulty.Text = "难度";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(11, 25);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(70, 28);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "时间";
            // 
            // labelLeastTime
            // 
            this.labelLeastTime.AutoSize = true;
            this.labelLeastTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLeastTime.ForeColor = System.Drawing.Color.White;
            this.labelLeastTime.Location = new System.Drawing.Point(11, 26);
            this.labelLeastTime.Name = "labelLeastTime";
            this.labelLeastTime.Size = new System.Drawing.Size(128, 28);
            this.labelLeastTime.TabIndex = 1;
            this.labelLeastTime.Text = "最短时间";
            // 
            // labelWhatDifficulty
            // 
            this.labelWhatDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWhatDifficulty.AutoSize = true;
            this.labelWhatDifficulty.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatDifficulty.ForeColor = System.Drawing.Color.White;
            this.labelWhatDifficulty.Location = new System.Drawing.Point(258, 27);
            this.labelWhatDifficulty.Name = "labelWhatDifficulty";
            this.labelWhatDifficulty.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.labelWhatDifficulty.Size = new System.Drawing.Size(71, 28);
            this.labelWhatDifficulty.TabIndex = 1;
            this.labelWhatDifficulty.Text = "随机";
            // 
            // labelWhatTime
            // 
            this.labelWhatTime.AutoSize = true;
            this.labelWhatTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatTime.ForeColor = System.Drawing.Color.White;
            this.labelWhatTime.Location = new System.Drawing.Point(242, 25);
            this.labelWhatTime.Name = "labelWhatTime";
            this.labelWhatTime.Size = new System.Drawing.Size(87, 28);
            this.labelWhatTime.TabIndex = 2;
            this.labelWhatTime.Text = "00:00";
            // 
            // labelWhatLeastTime
            // 
            this.labelWhatLeastTime.AutoSize = true;
            this.labelWhatLeastTime.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatLeastTime.ForeColor = System.Drawing.Color.White;
            this.labelWhatLeastTime.Location = new System.Drawing.Point(242, 25);
            this.labelWhatLeastTime.Name = "labelWhatLeastTime";
            this.labelWhatLeastTime.Size = new System.Drawing.Size(87, 28);
            this.labelWhatLeastTime.TabIndex = 2;
            this.labelWhatLeastTime.Text = "00:00";
            this.labelWhatLeastTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VictoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(475, 441);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRightFill);
            this.Controls.Add(this.panelLeftFill);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelDifficulty.ResumeLayout(false);
            this.panelDifficulty.PerformLayout();
            this.panelLeastTime.ResumeLayout(false);
            this.panelLeastTime.PerformLayout();
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
        private System.Windows.Forms.Label labelWhatLeastTime;
        private System.Windows.Forms.Label labelLeastTime;
        private System.Windows.Forms.Label labelWhatTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelWhatDifficulty;
        private System.Windows.Forms.Label labelDifficulty;
    }
}