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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rotateLabel = new Zmy.Solitaire.RotateLabel();
            this.panelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).BeginInit();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumberLeft
            // 
            this.labelNumberLeft.AutoSize = true;
            this.labelNumberLeft.BackColor = System.Drawing.Color.Transparent;
            this.labelNumberLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNumberLeft.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNumberLeft.Location = new System.Drawing.Point(0, 0);
            this.labelNumberLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberLeft.Name = "labelNumberLeft";
            this.labelNumberLeft.Size = new System.Drawing.Size(15, 15);
            this.labelNumberLeft.TabIndex = 2;
            this.labelNumberLeft.Text = "A";
            this.labelNumberLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelButtom
            // 
            this.panelButtom.Controls.Add(this.pictureBox2);
            this.panelButtom.Controls.Add(this.pictureBoxRight);
            this.panelButtom.Controls.Add(this.rotateLabel);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtom.Location = new System.Drawing.Point(83, 0);
            this.panelButtom.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(15, 140);
            this.panelButtom.TabIndex = 5;
            this.panelButtom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtom_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxRight.Location = new System.Drawing.Point(0, 109);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(15, 16);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRight.TabIndex = 5;
            this.pictureBoxRight.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.pictureBoxLeft);
            this.panelTop.Controls.Add(this.labelNumberLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(15, 140);
            this.panelTop.TabIndex = 4;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 15);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(15, 16);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeft.TabIndex = 3;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxMiddle
            // 
            this.pictureBoxMiddle.BackColor = System.Drawing.Color.White;
            this.pictureBoxMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMiddle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMiddle.Name = "pictureBoxMiddle";
            this.pictureBoxMiddle.Size = new System.Drawing.Size(68, 140);
            this.pictureBoxMiddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMiddle.TabIndex = 0;
            this.pictureBoxMiddle.TabStop = false;
            this.pictureBoxMiddle.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMiddle_Paint);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.pictureBoxMiddle);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(15, 0);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(68, 140);
            this.panelMiddle.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 109);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 109);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // rotateLabel
            // 
            this.rotateLabel.BackColor = System.Drawing.Color.Transparent;
            this.rotateLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rotateLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rotateLabel.Location = new System.Drawing.Point(0, 125);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.RText = " A";
            this.rotateLabel.Size = new System.Drawing.Size(15, 15);
            this.rotateLabel.TabIndex = 4;
            // 
            // Card
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Zmy.Solitaire.Properties.Resources.cardbackground1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(98, 140);
            this.Load += new System.EventHandler(this.Card_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.panelButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
