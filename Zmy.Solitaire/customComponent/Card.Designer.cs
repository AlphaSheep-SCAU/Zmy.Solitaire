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
            this.labelNumberRight = new System.Windows.Forms.Label();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.labelNumberLeft = new System.Windows.Forms.Label();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.panelButtom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNumberRight
            // 
            this.labelNumberRight.AutoSize = true;
            this.labelNumberRight.Location = new System.Drawing.Point(74, 111);
            this.labelNumberRight.Name = "labelNumberRight";
            this.labelNumberRight.Size = new System.Drawing.Size(15, 15);
            this.labelNumberRight.TabIndex = 3;
            this.labelNumberRight.Text = "A";
            this.labelNumberRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(88, 105);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
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
            // panelButtom
            // 
            this.panelButtom.Controls.Add(this.pictureBoxRight);
            this.panelButtom.Controls.Add(this.labelNumberRight);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtom.Location = new System.Drawing.Point(0, 33);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(115, 132);
            this.panelButtom.TabIndex = 5;
            this.panelButtom.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelNumberLeft);
            this.panelTop.Controls.Add(this.pictureBoxLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(115, 33);
            this.panelTop.TabIndex = 4;
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
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Card";
            this.Size = new System.Drawing.Size(115, 165);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Card_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Card_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Card_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.panelButtom.ResumeLayout(false);
            this.panelButtom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNumberRight;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.Label labelNumberLeft;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Panel panelTop;
    }
}
