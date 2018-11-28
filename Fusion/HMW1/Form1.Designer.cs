namespace HMW1
{
    partial class Form1
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
            this.Picture1 = new System.Windows.Forms.PictureBox();
            this.Picture2 = new System.Windows.Forms.PictureBox();
            this.Picture3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectButton1 = new System.Windows.Forms.Button();
            this.SelectButton2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bicubic = new System.Windows.Forms.RadioButton();
            this.bilinear = new System.Windows.Forms.RadioButton();
            this.nearest = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TPS = new System.Windows.Forms.RadioButton();
            this.BSpline = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Save = new System.Windows.Forms.Button();
            this.Process = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.Retract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Picture1
            // 
            this.Picture1.Location = new System.Drawing.Point(45, 30);
            this.Picture1.Name = "Picture1";
            this.Picture1.Size = new System.Drawing.Size(300, 300);
            this.Picture1.TabIndex = 0;
            this.Picture1.TabStop = false;
            this.Picture1.Click += new System.EventHandler(this.Picture1_Click);
            // 
            // Picture2
            // 
            this.Picture2.Location = new System.Drawing.Point(429, 30);
            this.Picture2.Name = "Picture2";
            this.Picture2.Size = new System.Drawing.Size(300, 300);
            this.Picture2.TabIndex = 1;
            this.Picture2.TabStop = false;
            this.Picture2.Click += new System.EventHandler(this.Picture2_Click);
            // 
            // Picture3
            // 
            this.Picture3.Location = new System.Drawing.Point(820, 30);
            this.Picture3.Name = "Picture3";
            this.Picture3.Size = new System.Drawing.Size(300, 300);
            this.Picture3.TabIndex = 2;
            this.Picture3.TabStop = false;
            this.Picture3.Click += new System.EventHandler(this.Picture3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(752, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "——>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(374, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "+";
            // 
            // SelectButton1
            // 
            this.SelectButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectButton1.Location = new System.Drawing.Point(45, 326);
            this.SelectButton1.Name = "SelectButton1";
            this.SelectButton1.Size = new System.Drawing.Size(300, 51);
            this.SelectButton1.TabIndex = 5;
            this.SelectButton1.Text = "选择图片";
            this.SelectButton1.UseVisualStyleBackColor = false;
            this.SelectButton1.Click += new System.EventHandler(this.SelectButton1_Click);
            // 
            // SelectButton2
            // 
            this.SelectButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectButton2.Location = new System.Drawing.Point(429, 326);
            this.SelectButton2.Name = "SelectButton2";
            this.SelectButton2.Size = new System.Drawing.Size(300, 51);
            this.SelectButton2.TabIndex = 6;
            this.SelectButton2.Text = "选择图片";
            this.SelectButton2.UseVisualStyleBackColor = false;
            this.SelectButton2.Click += new System.EventHandler(this.SelectButton2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bicubic);
            this.groupBox2.Controls.Add(this.bilinear);
            this.groupBox2.Controls.Add(this.nearest);
            this.groupBox2.Location = new System.Drawing.Point(394, 415);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 158);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "插值方式";
            // 
            // bicubic
            // 
            this.bicubic.AutoSize = true;
            this.bicubic.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bicubic.Location = new System.Drawing.Point(44, 112);
            this.bicubic.Name = "bicubic";
            this.bicubic.Size = new System.Drawing.Size(105, 24);
            this.bicubic.TabIndex = 2;
            this.bicubic.TabStop = true;
            this.bicubic.Text = "双三次插值";
            this.bicubic.UseVisualStyleBackColor = true;
            // 
            // bilinear
            // 
            this.bilinear.AutoSize = true;
            this.bilinear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bilinear.Location = new System.Drawing.Point(44, 72);
            this.bilinear.Name = "bilinear";
            this.bilinear.Size = new System.Drawing.Size(105, 24);
            this.bilinear.TabIndex = 1;
            this.bilinear.TabStop = true;
            this.bilinear.Text = "双线性插值";
            this.bilinear.UseVisualStyleBackColor = true;
            // 
            // nearest
            // 
            this.nearest.AutoSize = true;
            this.nearest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nearest.Location = new System.Drawing.Point(44, 30);
            this.nearest.Name = "nearest";
            this.nearest.Size = new System.Drawing.Size(105, 24);
            this.nearest.TabIndex = 0;
            this.nearest.TabStop = true;
            this.nearest.Text = "最近邻插值";
            this.nearest.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TPS);
            this.groupBox1.Controls.Add(this.BSpline);
            this.groupBox1.Location = new System.Drawing.Point(45, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 159);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "变形方式";
            // 
            // TPS
            // 
            this.TPS.AutoSize = true;
            this.TPS.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TPS.Location = new System.Drawing.Point(21, 99);
            this.TPS.Name = "TPS";
            this.TPS.Size = new System.Drawing.Size(87, 24);
            this.TPS.TabIndex = 2;
            this.TPS.TabStop = true;
            this.TPS.Text = "TPS变形";
            this.TPS.UseVisualStyleBackColor = true;
            // 
            // BSpline
            // 
            this.BSpline.AutoSize = true;
            this.BSpline.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BSpline.Location = new System.Drawing.Point(21, 46);
            this.BSpline.Name = "BSpline";
            this.BSpline.Size = new System.Drawing.Size(99, 24);
            this.BSpline.TabIndex = 0;
            this.BSpline.TabStop = true;
            this.BSpline.Text = "B样条变形";
            this.BSpline.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Save);
            this.groupBox3.Controls.Add(this.Retract);
            this.groupBox3.Controls.Add(this.Process);
            this.groupBox3.Location = new System.Drawing.Point(749, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 158);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Save.Location = new System.Drawing.Point(240, 24);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(124, 112);
            this.Save.TabIndex = 1;
            this.Save.Text = "保存图片";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Process
            // 
            this.Process.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Process.Location = new System.Drawing.Point(20, 24);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(199, 56);
            this.Process.TabIndex = 0;
            this.Process.Text = "开始变换";
            this.Process.UseVisualStyleBackColor = false;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Location = new System.Drawing.Point(820, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 41);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "变换进度";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 18);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 15);
            this.progressBar1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(760, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "(变换完成后点击图片均可查看原图哦！快来试试吧~)";
            // 
            // Retract
            // 
            this.Retract.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Retract.Location = new System.Drawing.Point(20, 86);
            this.Retract.Name = "Retract";
            this.Retract.Size = new System.Drawing.Size(199, 56);
            this.Retract.TabIndex = 2;
            this.Retract.Text = "还原图片";
            this.Retract.UseVisualStyleBackColor = false;
            this.Retract.Click += new System.EventHandler(this.Retract_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 598);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SelectButton2);
            this.Controls.Add(this.SelectButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Picture3);
            this.Controls.Add(this.Picture2);
            this.Controls.Add(this.Picture1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "人脸易容术";
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture1;
        private System.Windows.Forms.PictureBox Picture2;
        private System.Windows.Forms.PictureBox Picture3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectButton1;
        private System.Windows.Forms.Button SelectButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton bicubic;
        private System.Windows.Forms.RadioButton bilinear;
        private System.Windows.Forms.RadioButton nearest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TPS;
        private System.Windows.Forms.RadioButton BSpline;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Retract;
        private System.Windows.Forms.Label label3;
    }
}

