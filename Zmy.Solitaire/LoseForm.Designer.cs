namespace Zmy.Solitaire
{
    partial class LoseForm
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
            this.panelLeftFill = new System.Windows.Forms.Panel();
            this.panelRightFill = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainButtom = new System.Windows.Forms.Panel();
            this.buttonRestartGame = new System.Windows.Forms.Button();
            this.panelMainMiddle = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.panelTime = new System.Windows.Forms.Panel();
            this.labelWhatSwitchNumber = new System.Windows.Forms.Label();
            this.labelSwitchNumber = new System.Windows.Forms.Label();
            this.panelDifficulty = new System.Windows.Forms.Panel();
            this.labelWhatDifficulty = new System.Windows.Forms.Label();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.panelMainRFlii = new System.Windows.Forms.Panel();
            this.panelMainLFill = new System.Windows.Forms.Panel();
            this.panelMainTFill = new System.Windows.Forms.Panel();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.labelTip1 = new System.Windows.Forms.Label();
            this.labelTip2 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainButtom.SuspendLayout();
            this.panelMainMiddle.SuspendLayout();
            this.panelTip.SuspendLayout();
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
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(355, 16);
            this.panelTop.TabIndex = 2;
            // 
            // panelMFill
            // 
            this.panelMFill.BackColor = System.Drawing.SystemColors.Control;
            this.panelMFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMFill.Location = new System.Drawing.Point(15, 0);
            this.panelMFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelMFill.Name = "panelMFill";
            this.panelMFill.Size = new System.Drawing.Size(325, 16);
            this.panelMFill.TabIndex = 2;
            this.panelMFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMFill_Paint);
            // 
            // panelRFill
            // 
            this.panelRFill.BackColor = System.Drawing.Color.Red;
            this.panelRFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRFill.Location = new System.Drawing.Point(340, 0);
            this.panelRFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelRFill.Name = "panelRFill";
            this.panelRFill.Size = new System.Drawing.Size(15, 16);
            this.panelRFill.TabIndex = 1;
            // 
            // panelLFill
            // 
            this.panelLFill.BackColor = System.Drawing.Color.Red;
            this.panelLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLFill.Location = new System.Drawing.Point(0, 0);
            this.panelLFill.Margin = new System.Windows.Forms.Padding(2);
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
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(355, 40);
            this.panelTitle.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(316, 7);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(24, 26);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "×";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(44, 13);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(89, 16);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "You Lose!";
            // 
            // panelLeftFill
            // 
            this.panelLeftFill.BackColor = System.Drawing.Color.Red;
            this.panelLeftFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFill.Location = new System.Drawing.Point(0, 56);
            this.panelLeftFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeftFill.Name = "panelLeftFill";
            this.panelLeftFill.Size = new System.Drawing.Size(15, 299);
            this.panelLeftFill.TabIndex = 5;
            this.panelLeftFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeftFill_Paint);
            // 
            // panelRightFill
            // 
            this.panelRightFill.BackColor = System.Drawing.Color.Red;
            this.panelRightFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightFill.Location = new System.Drawing.Point(340, 56);
            this.panelRightFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightFill.Name = "panelRightFill";
            this.panelRightFill.Size = new System.Drawing.Size(15, 299);
            this.panelRightFill.TabIndex = 6;
            this.panelRightFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRightFill_Paint);
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
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(325, 299);
            this.panelMain.TabIndex = 7;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelMainButtom
            // 
            this.panelMainButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelMainButtom.Controls.Add(this.buttonUndo);
            this.panelMainButtom.Controls.Add(this.buttonRestartGame);
            this.panelMainButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainButtom.Location = new System.Drawing.Point(38, 214);
            this.panelMainButtom.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainButtom.Name = "panelMainButtom";
            this.panelMainButtom.Size = new System.Drawing.Size(249, 85);
            this.panelMainButtom.TabIndex = 4;
            // 
            // buttonRestartGame
            // 
            this.buttonRestartGame.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.buttonbg1;
            this.buttonRestartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRestartGame.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonRestartGame.FlatAppearance.BorderSize = 0;
            this.buttonRestartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonRestartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonRestartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestartGame.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRestartGame.ForeColor = System.Drawing.Color.White;
            this.buttonRestartGame.Location = new System.Drawing.Point(4, 24);
            this.buttonRestartGame.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRestartGame.Name = "buttonRestartGame";
            this.buttonRestartGame.Size = new System.Drawing.Size(98, 40);
            this.buttonRestartGame.TabIndex = 0;
            this.buttonRestartGame.Text = "重新开始";
            this.buttonRestartGame.UseVisualStyleBackColor = true;
            this.buttonRestartGame.Click += new System.EventHandler(this.buttonRestartGame_Click);
            this.buttonRestartGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseDown);
            this.buttonRestartGame.MouseEnter += new System.EventHandler(this.buttonNewGame_MouseEnter);
            this.buttonRestartGame.MouseLeave += new System.EventHandler(this.buttonNewGame_MouseLeave);
            this.buttonRestartGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseUp);
            // 
            // panelMainMiddle
            // 
            this.panelMainMiddle.BackColor = System.Drawing.Color.Transparent;
            this.panelMainMiddle.BackgroundImage = global::Zmy.Solitaire.Properties.Resources._3_40_71background;
            this.panelMainMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMainMiddle.Controls.Add(this.panelTip);
            this.panelMainMiddle.Controls.Add(this.panelTime);
            this.panelMainMiddle.Controls.Add(this.panelDifficulty);
            this.panelMainMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainMiddle.Location = new System.Drawing.Point(38, 20);
            this.panelMainMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainMiddle.Name = "panelMainMiddle";
            this.panelMainMiddle.Size = new System.Drawing.Size(249, 194);
            this.panelMainMiddle.TabIndex = 3;
            // 
            // panelTip
            // 
            this.panelTip.Controls.Add(this.labelTip2);
            this.panelTip.Controls.Add(this.labelTip1);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTip.Location = new System.Drawing.Point(0, 130);
            this.panelTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(249, 65);
            this.panelTip.TabIndex = 4;
            // 
            // panelTime
            // 
            this.panelTime.Controls.Add(this.labelWhatSwitchNumber);
            this.panelTime.Controls.Add(this.labelSwitchNumber);
            this.panelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTime.Location = new System.Drawing.Point(0, 65);
            this.panelTime.Margin = new System.Windows.Forms.Padding(2);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(249, 65);
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
            this.panelDifficulty.Margin = new System.Windows.Forms.Padding(2);
            this.panelDifficulty.Name = "panelDifficulty";
            this.panelDifficulty.Size = new System.Drawing.Size(249, 65);
            this.panelDifficulty.TabIndex = 2;
            // 
            // labelWhatDifficulty
            // 
            this.labelWhatDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWhatDifficulty.AutoSize = true;
            this.labelWhatDifficulty.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWhatDifficulty.ForeColor = System.Drawing.Color.White;
            this.labelWhatDifficulty.Location = new System.Drawing.Point(192, 22);
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
            this.panelMainRFlii.Location = new System.Drawing.Point(287, 20);
            this.panelMainRFlii.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainRFlii.Name = "panelMainRFlii";
            this.panelMainRFlii.Size = new System.Drawing.Size(38, 279);
            this.panelMainRFlii.TabIndex = 2;
            // 
            // panelMainLFill
            // 
            this.panelMainLFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainLFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMainLFill.Location = new System.Drawing.Point(0, 20);
            this.panelMainLFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainLFill.Name = "panelMainLFill";
            this.panelMainLFill.Size = new System.Drawing.Size(38, 279);
            this.panelMainLFill.TabIndex = 1;
            // 
            // panelMainTFill
            // 
            this.panelMainTFill.BackColor = System.Drawing.Color.Transparent;
            this.panelMainTFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainTFill.Location = new System.Drawing.Point(0, 0);
            this.panelMainTFill.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainTFill.Name = "panelMainTFill";
            this.panelMainTFill.Size = new System.Drawing.Size(325, 20);
            this.panelMainTFill.TabIndex = 0;
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.buttonbg1;
            this.buttonUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUndo.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonUndo.FlatAppearance.BorderSize = 0;
            this.buttonUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUndo.ForeColor = System.Drawing.Color.White;
            this.buttonUndo.Location = new System.Drawing.Point(147, 24);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(98, 40);
            this.buttonUndo.TabIndex = 1;
            this.buttonUndo.Text = "撤销";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            this.buttonUndo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseDown);
            this.buttonUndo.MouseEnter += new System.EventHandler(this.buttonNewGame_MouseEnter);
            this.buttonUndo.MouseLeave += new System.EventHandler(this.buttonNewGame_MouseLeave);
            this.buttonUndo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseUp);
            // 
            // labelTip1
            // 
            this.labelTip1.AutoSize = true;
            this.labelTip1.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip1.ForeColor = System.Drawing.Color.White;
            this.labelTip1.Location = new System.Drawing.Point(85, 7);
            this.labelTip1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTip1.Name = "labelTip1";
            this.labelTip1.Size = new System.Drawing.Size(79, 22);
            this.labelTip1.TabIndex = 1;
            this.labelTip1.Text = "你输了";
            // 
            // labelTip2
            // 
            this.labelTip2.AutoSize = true;
            this.labelTip2.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip2.ForeColor = System.Drawing.Color.White;
            this.labelTip2.Location = new System.Drawing.Point(19, 38);
            this.labelTip2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTip2.Name = "labelTip2";
            this.labelTip2.Size = new System.Drawing.Size(194, 22);
            this.labelTip2.TabIndex = 2;
            this.labelTip2.Text = "请重新开始或撤销";
            this.labelTip2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 355);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRightFill);
            this.Controls.Add(this.panelLeftFill);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.LoseForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMainButtom.ResumeLayout(false);
            this.panelMainMiddle.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.panelTip.PerformLayout();
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
        private System.Windows.Forms.Panel panelLeftFill;
        private System.Windows.Forms.Panel panelRightFill;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMainButtom;
        private System.Windows.Forms.Button buttonRestartGame;
        private System.Windows.Forms.Panel panelMainMiddle;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.Label labelWhatSwitchNumber;
        private System.Windows.Forms.Label labelSwitchNumber;
        private System.Windows.Forms.Panel panelDifficulty;
        private System.Windows.Forms.Label labelWhatDifficulty;
        private System.Windows.Forms.Label labelDifficulty;
        private System.Windows.Forms.Panel panelMainRFlii;
        private System.Windows.Forms.Panel panelMainLFill;
        private System.Windows.Forms.Panel panelMainTFill;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Label labelTip2;
        private System.Windows.Forms.Label labelTip1;
    }
}