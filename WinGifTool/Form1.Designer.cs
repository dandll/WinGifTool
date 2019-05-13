namespace WinGifTool
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
            this.components = new System.ComponentModel.Container();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnType1 = new System.Windows.Forms.Button();
            this.btnType2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtBiLi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.btnShowZhen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGifZhen = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPicInfo = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLoadImgInfo = new System.Windows.Forms.Button();
            this.txtGifZhenX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNextX = new System.Windows.Forms.Button();
            this.btnPrevX = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtPlayBeginZhen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlayBeiSu = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblProgress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDaoFang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(197, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "宽高等比缩放";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 14);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(179, 21);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnType1
            // 
            this.btnType1.Location = new System.Drawing.Point(12, 107);
            this.btnType1.Name = "btnType1";
            this.btnType1.Size = new System.Drawing.Size(75, 23);
            this.btnType1.TabIndex = 3;
            this.btnType1.Text = "压缩模式一";
            this.btnType1.UseVisualStyleBackColor = true;
            this.btnType1.Click += new System.EventHandler(this.btnType1_Click);
            // 
            // btnType2
            // 
            this.btnType2.Location = new System.Drawing.Point(116, 107);
            this.btnType2.Name = "btnType2";
            this.btnType2.Size = new System.Drawing.Size(75, 23);
            this.btnType2.TabIndex = 4;
            this.btnType2.Text = "压缩模式二";
            this.btnType2.UseVisualStyleBackColor = true;
            this.btnType2.Click += new System.EventHandler(this.btnType2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtBiLi
            // 
            this.txtBiLi.Location = new System.Drawing.Point(116, 58);
            this.txtBiLi.Name = "txtBiLi";
            this.txtBiLi.Size = new System.Drawing.Size(36, 21);
            this.txtBiLi.TabIndex = 6;
            this.txtBiLi.Text = "60";
            this.txtBiLi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBiLi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "%";
            // 
            // pbShow
            // 
            this.pbShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbShow.Location = new System.Drawing.Point(349, 14);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(364, 325);
            this.pbShow.TabIndex = 8;
            this.pbShow.TabStop = false;
            // 
            // btnShowZhen
            // 
            this.btnShowZhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowZhen.Location = new System.Drawing.Point(551, 387);
            this.btnShowZhen.Name = "btnShowZhen";
            this.btnShowZhen.Size = new System.Drawing.Size(50, 23);
            this.btnShowZhen.TabIndex = 9;
            this.btnShowZhen.Text = "预览";
            this.btnShowZhen.UseVisualStyleBackColor = true;
            this.btnShowZhen.Click += new System.EventHandler(this.btnShowZhen_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "预览帧数";
            // 
            // txtGifZhen
            // 
            this.txtGifZhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGifZhen.Location = new System.Drawing.Point(451, 389);
            this.txtGifZhen.Name = "txtGifZhen";
            this.txtGifZhen.Size = new System.Drawing.Size(92, 21);
            this.txtGifZhen.TabIndex = 11;
            this.txtGifZhen.Text = "0";
            this.txtGifZhen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(607, 387);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 23);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "上一帧";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(663, 387);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "下一帧";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPicInfo
            // 
            this.lblPicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPicInfo.AutoSize = true;
            this.lblPicInfo.Location = new System.Drawing.Point(396, 363);
            this.lblPicInfo.Name = "lblPicInfo";
            this.lblPicInfo.Size = new System.Drawing.Size(65, 12);
            this.lblPicInfo.TabIndex = 14;
            this.lblPicInfo.Text = "图片信息：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "预览";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnLoadImgInfo
            // 
            this.btnLoadImgInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadImgInfo.Location = new System.Drawing.Point(638, 358);
            this.btnLoadImgInfo.Name = "btnLoadImgInfo";
            this.btnLoadImgInfo.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImgInfo.TabIndex = 16;
            this.btnLoadImgInfo.Text = "加载信息";
            this.btnLoadImgInfo.UseVisualStyleBackColor = true;
            this.btnLoadImgInfo.Click += new System.EventHandler(this.btnLoadImgInfo_Click);
            // 
            // txtGifZhenX
            // 
            this.txtGifZhenX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGifZhenX.Location = new System.Drawing.Point(451, 416);
            this.txtGifZhenX.Name = "txtGifZhenX";
            this.txtGifZhenX.Size = new System.Drawing.Size(92, 21);
            this.txtGifZhenX.TabIndex = 18;
            this.txtGifZhenX.Text = "5";
            this.txtGifZhenX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "X帧数";
            // 
            // btnNextX
            // 
            this.btnNextX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextX.Location = new System.Drawing.Point(607, 414);
            this.btnNextX.Name = "btnNextX";
            this.btnNextX.Size = new System.Drawing.Size(50, 23);
            this.btnNextX.TabIndex = 20;
            this.btnNextX.Text = "下X帧";
            this.btnNextX.UseVisualStyleBackColor = true;
            this.btnNextX.Click += new System.EventHandler(this.btnNextX_Click);
            // 
            // btnPrevX
            // 
            this.btnPrevX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevX.Location = new System.Drawing.Point(551, 414);
            this.btnPrevX.Name = "btnPrevX";
            this.btnPrevX.Size = new System.Drawing.Size(50, 23);
            this.btnPrevX.TabIndex = 19;
            this.btnPrevX.Text = "上X帧";
            this.btnPrevX.UseVisualStyleBackColor = true;
            this.btnPrevX.Click += new System.EventHandler(this.btnPrevX_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Location = new System.Drawing.Point(607, 443);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(50, 23);
            this.btnPlay.TabIndex = 21;
            this.btnPlay.Text = "播放";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtPlayBeginZhen
            // 
            this.txtPlayBeginZhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayBeginZhen.Location = new System.Drawing.Point(451, 445);
            this.txtPlayBeginZhen.Name = "txtPlayBeginZhen";
            this.txtPlayBeginZhen.Size = new System.Drawing.Size(45, 21);
            this.txtPlayBeginZhen.TabIndex = 23;
            this.txtPlayBeginZhen.Text = "0";
            this.txtPlayBeginZhen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "开始帧数";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(663, 443);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "倍速";
            // 
            // txtPlayBeiSu
            // 
            this.txtPlayBeiSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayBeiSu.Location = new System.Drawing.Point(551, 445);
            this.txtPlayBeiSu.Name = "txtPlayBeiSu";
            this.txtPlayBeiSu.Size = new System.Drawing.Size(50, 21);
            this.txtPlayBeiSu.TabIndex = 26;
            this.txtPlayBeiSu.Text = "1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(549, 363);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(71, 12);
            this.lblProgress.TabIndex = 27;
            this.lblProgress.Text = "lblProgress";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 96);
            this.label7.TabIndex = 28;
            this.label7.Text = "压缩\r\n\r\n1：拖动图片至窗体或点击选择文件\r\n\r\n2：填写压缩比例\r\n\r\n3：选择压缩模式，成功后会在桌面新建压缩后的图片文件\r\n\r\n";
            // 
            // btnDaoFang
            // 
            this.btnDaoFang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDaoFang.Location = new System.Drawing.Point(664, 414);
            this.btnDaoFang.Name = "btnDaoFang";
            this.btnDaoFang.Size = new System.Drawing.Size(50, 23);
            this.btnDaoFang.TabIndex = 29;
            this.btnDaoFang.Text = "倒放";
            this.btnDaoFang.UseVisualStyleBackColor = true;
            this.btnDaoFang.Click += new System.EventHandler(this.btnDaoFang_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 476);
            this.Controls.Add(this.btnDaoFang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.txtPlayBeiSu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtPlayBeginZhen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnNextX);
            this.Controls.Add(this.btnPrevX);
            this.Controls.Add(this.txtGifZhenX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoadImgInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblPicInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.txtGifZhen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowZhen);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBiLi);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnType2);
            this.Controls.Add(this.btnType1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "Form1";
            this.Text = "GIFTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnType1;
        private System.Windows.Forms.Button btnType2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtBiLi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.Button btnShowZhen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGifZhen;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPicInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLoadImgInfo;
        private System.Windows.Forms.TextBox txtGifZhenX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNextX;
        private System.Windows.Forms.Button btnPrevX;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtPlayBeginZhen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlayBeiSu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDaoFang;
    }
}

