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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelGap = new System.Windows.Forms.Panel();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelButtom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(482, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(72, 31);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(337, 38);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Congratulations!";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 100);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(50, 353);
            this.panelLeft.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(432, 100);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(50, 353);
            this.panelRight.TabIndex = 2;
            // 
            // panelGap
            // 
            this.panelGap.BackColor = System.Drawing.Color.Transparent;
            this.panelGap.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGap.Location = new System.Drawing.Point(50, 100);
            this.panelGap.Name = "panelGap";
            this.panelGap.Size = new System.Drawing.Size(382, 22);
            this.panelGap.TabIndex = 3;
            // 
            // panelButtom
            // 
            this.panelButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelButtom.Controls.Add(this.buttonExit);
            this.panelButtom.Controls.Add(this.buttonNewGame);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(50, 370);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(382, 83);
            this.panelButtom.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.winform_backgournd_lightblue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.labelDifficulty);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(50, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 248);
            this.panel1.TabIndex = 5;
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.AutoSize = true;
            this.labelDifficulty.Font = new System.Drawing.Font("幼圆", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDifficulty.Location = new System.Drawing.Point(17, 34);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.Size = new System.Drawing.Size(99, 28);
            this.labelDifficulty.TabIndex = 0;
            this.labelDifficulty.Text = "难度：";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("幼圆", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.Location = new System.Drawing.Point(17, 134);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(99, 28);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "时间：";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNewGame.Location = new System.Drawing.Point(67, 22);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(94, 49);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "新游戏";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Location = new System.Drawing.Point(236, 22);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 49);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // VictoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.winform_backgournd_lightblue;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.panelGap);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTitle);
            this.Name = "VictoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VictoryForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VictoryForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelButtom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelGap;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDifficulty;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonExit;
    }
}