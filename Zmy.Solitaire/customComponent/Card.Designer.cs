namespace Zmy.Solitaire.customComponent
{
    partial class Card
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNumberLeft = new System.Windows.Forms.Label();
            this.labelNumberRight = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.panelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumberLeft
            // 
            this.labelNumberLeft.AutoSize = true;
            this.labelNumberLeft.Location = new System.Drawing.Point(29, 13);
            this.labelNumberLeft.Name = "labelNumberLeft";
            this.labelNumberLeft.Size = new System.Drawing.Size(15, 15);
            this.labelNumberLeft.TabIndex = 2;
            this.labelNumberLeft.Text = "A";
            this.labelNumberLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNumberRight
            // 
            this.labelNumberRight.AutoSize = true;
            this.labelNumberRight.Location = new System.Drawing.Point(73, 96);
            this.labelNumberRight.Name = "labelNumberRight";
            this.labelNumberRight.Size = new System.Drawing.Size(15, 15);
            this.labelNumberRight.TabIndex = 3;
            this.labelNumberRight.Text = "A";
            this.labelNumberRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelNumberLeft);
            this.panelTop.Controls.Add(this.pictureBoxLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(115, 45);
            this.panelTop.TabIndex = 4;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            // 
            // panelButtom
            // 
            this.panelButtom.Controls.Add(this.pictureBoxRight);
            this.panelButtom.Controls.Add(this.labelNumberRight);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtom.Location = new System.Drawing.Point(0, 45);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(115, 120);
            this.panelButtom.TabIndex = 5;
            this.panelButtom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtom_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(85, 90);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            // 
            // Card
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.background;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.panelTop);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(115, 165);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Card_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Card_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Card_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Card_MouseUp);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.panelButtom.ResumeLayout(false);
            this.panelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Label labelNumberLeft;
        private System.Windows.Forms.Label labelNumberRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelButtom;
    }
}
