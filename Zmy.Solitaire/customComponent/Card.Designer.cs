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
            this.panelButtom = new System.Windows.Forms.Panel();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxMiddle = new System.Windows.Forms.PictureBox();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.rotateLabel = new Zmy.Solitaire.RotateLabel();
            this.panelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).BeginInit();
            this.panelMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNumberLeft
            // 
            this.labelNumberLeft.AutoSize = true;
            this.labelNumberLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNumberLeft.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNumberLeft.Location = new System.Drawing.Point(0, 0);
            this.labelNumberLeft.Name = "labelNumberLeft";
            this.labelNumberLeft.Size = new System.Drawing.Size(20, 19);
            this.labelNumberLeft.TabIndex = 2;
            this.labelNumberLeft.Text = "A";
            this.labelNumberLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelButtom
            // 
            this.panelButtom.Controls.Add(this.pictureBoxRight);
            this.panelButtom.Controls.Add(this.rotateLabel);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtom.Location = new System.Drawing.Point(106, 0);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(24, 175);
            this.panelButtom.TabIndex = 5;
            this.panelButtom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(2, 132);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRight.TabIndex = 5;
            this.pictureBoxRight.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBoxLeft);
            this.panelTop.Controls.Add(this.labelNumberLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(24, 175);
            this.panelTop.TabIndex = 4;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(2, 19);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeft.TabIndex = 3;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxMiddle
            // 
            this.pictureBoxMiddle.BackColor = System.Drawing.Color.White;
            this.pictureBoxMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMiddle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMiddle.Name = "pictureBoxMiddle";
            this.pictureBoxMiddle.Size = new System.Drawing.Size(82, 175);
            this.pictureBoxMiddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMiddle.TabIndex = 0;
            this.pictureBoxMiddle.TabStop = false;
            this.pictureBoxMiddle.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMiddle_Paint);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.pictureBoxMiddle);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(24, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(82, 175);
            this.panelMiddle.TabIndex = 6;
            this.panelMiddle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // rotateLabel
            // 
            this.rotateLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rotateLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rotateLabel.Location = new System.Drawing.Point(0, 156);
            this.rotateLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.RText = " A";
            this.rotateLabel.Size = new System.Drawing.Size(24, 19);
            this.rotateLabel.TabIndex = 4;
            // 
            // Card
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.cardbackground1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Card";
            this.Size = new System.Drawing.Size(130, 175);
            this.Load += new System.EventHandler(this.Card_Load);
            this.panelButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNumberLeft;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxMiddle;
        private System.Windows.Forms.Panel panelMiddle;
        private RotateLabel rotateLabel;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
    }
}
