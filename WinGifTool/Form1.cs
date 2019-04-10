using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinGifTool
{
    public partial class Form1 : Form
    {
        #region 变量
        //AnimateImage image;
        int lastImageCount = 0;
        //List<Image> imageList = null;
        /// <summary>
        /// 程序是否关闭
        /// </summary>
        bool IsFormClose = false;
        /// <summary>
        /// 是否播放
        /// </summary>
        bool IsPlay = false;
        #endregion

        #region Form事件
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //image = new AnimateImage(Image.FromFile(@"C:/Documents and Settings/Administrator/My Documents/My Pictures/未命名.gif"));
            //image.OnFrameChanged += new EventHandler<EventArgs>(image_OnFrameChanged);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsFormClose = true;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GIF文件|*.gif|所有文件|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fName = ofd.FileName;
                txtFilePath.Text = fName;
            }
        }

        #region 缩放
        public void SuoFang(string path, int suoFangWidth, int suoFangHeight)
        {
            //原图路径
            //string imgPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\0.gif";
            string imgPath = path;
            //原图
            Image img = Image.FromFile(imgPath);
            //int suoFangWidth = img.Width / 3 * 2;
            //int suoFangHeight = img.Height / 3 * 2;
            //不够100*100的不缩放
            if (img.Width > 100 && img.Height > 100)
            {
                //新图第一帧
                Image new_img = new Bitmap(suoFangWidth, suoFangHeight);
                //新图其他帧
                Image new_imgs = new Bitmap(suoFangWidth, suoFangHeight);
                //新图第一帧GDI+绘图对象
                Graphics g_new_img = Graphics.FromImage(new_img);
                //新图其他帧GDI+绘图对象
                Graphics g_new_imgs = Graphics.FromImage(new_imgs);
                //配置新图第一帧GDI+绘图对象
                g_new_img.CompositingMode = CompositingMode.SourceCopy;
                g_new_img.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g_new_img.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g_new_img.SmoothingMode = SmoothingMode.HighQuality;
                g_new_img.Clear(Color.FromKnownColor(KnownColor.Transparent));
                //配置其他帧GDI+绘图对象
                g_new_imgs.CompositingMode = CompositingMode.SourceCopy;
                g_new_imgs.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g_new_imgs.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g_new_imgs.SmoothingMode = SmoothingMode.HighQuality;
                g_new_imgs.Clear(Color.FromKnownColor(KnownColor.Transparent));
                //遍历维数
                foreach (Guid gid in img.FrameDimensionsList)
                {
                    //因为是缩小GIF文件所以这里要设置为Time
                    //如果是TIFF这里要设置为PAGE
                    FrameDimension f = FrameDimension.Time;
                    //获取总帧数
                    int count = img.GetFrameCount(f);
                    //保存标示参数
                    System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                    //
                    EncoderParameters ep = null;
                    //图片编码、解码器
                    ImageCodecInfo ici = null;
                    //图片编码、解码器集合
                    ImageCodecInfo[] icis = ImageCodecInfo.GetImageDecoders();
                    //为 图片编码、解码器 对象 赋值
                    foreach (ImageCodecInfo ic in icis)
                    {
                        if (ic.FormatID == ImageFormat.Gif.Guid)
                        {
                            ici = ic;
                            break;
                        }
                    }
                    //每一帧
                    for (int c = 0; c < count; c++)
                    {
                        //选择由维度和索引指定的帧
                        img.SelectActiveFrame(f, c);
                        //第一帧
                        if (c == 0)
                        {
                            //将原图第一帧画给新图第一帧
                            g_new_img.DrawImage(img, new Rectangle(0, 0, suoFangWidth, suoFangHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                            //把振频和透明背景调色板等设置复制给新图第一帧
                            for (int i = 0; i < img.PropertyItems.Length; i++)
                            {
                                new_img.SetPropertyItem(img.PropertyItems[i]);
                            }
                            ep = new EncoderParameters(1);
                            //第一帧需要设置为MultiFrame
                            ep.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
                            //保存第一帧
                            new_img.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + Path.GetFileName(path).Replace(".", DateTime.Now.ToString("yyMMddHHmmssfff") + "."), ici, ep);
                        }
                        //其他帧
                        else
                        {
                            //把原图的其他帧画给新图的其他帧
                            g_new_imgs.DrawImage(img, new Rectangle(0, 0, suoFangWidth, suoFangHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                            //把振频和透明背景调色板等设置复制给新图第一帧
                            for (int i = 0; i < img.PropertyItems.Length; i++)
                            {
                                new_imgs.SetPropertyItem(img.PropertyItems[i]);
                            }
                            ep = new EncoderParameters(1);
                            //如果是GIF这里设置为FrameDimensionTime
                            //如果为TIFF则设置为FrameDimensionPage
                            ep.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);
                            //向新图添加一帧
                            new_img.SaveAdd(new_imgs, ep);
                        }
                    }
                    ep = new EncoderParameters(1);
                    //关闭多帧文件流
                    ep.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                    new_img.SaveAdd(ep);
                }
                //new_img.Save(path.Insert(path.LastIndexOf('.') - 1, DateTime.Now.ToString("yyyyMMddHHmmssfff")));
                MessageBox.Show("缩放完成！");
                //释放文件
                img.Dispose();
                new_img.Dispose();
                new_imgs.Dispose();
                g_new_img.Dispose();
                g_new_imgs.Dispose();
            }
        }
        /// <summary> 
        /// 设置GIF大小 
        /// </summary> 
        /// <param name="path">图片路径</param> 
        /// <param name="width">宽</param> 
        /// <param name="height">高</param> 
        private void setGifSize(string path, int width, int height)
        {
            Image gif = new Bitmap(width, height);
            Image frame = new Bitmap(width, height);
            Image res = Image.FromFile(path);
            Graphics g = Graphics.FromImage(gif);
            Rectangle rg = new Rectangle(0, 0, width, height);
            Graphics gFrame = Graphics.FromImage(frame);

            foreach (Guid gd in res.FrameDimensionsList)
            {
                FrameDimension fd = new FrameDimension(gd);

                //因为是缩小GIF文件所以这里要设置为Time，如果是TIFF这里要设置为PAGE，因为GIF以时间分割，TIFF为页分割 
                FrameDimension f = FrameDimension.Time;
                int count = res.GetFrameCount(fd);
                ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Gif);
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                EncoderParameters eps = null;

                for (int i = 0; i < count; i++)
                {
                    res.SelectActiveFrame(f, i);
                    if (0 == i)
                    {

                        g.DrawImage(res, rg);

                        eps = new EncoderParameters(1);

                        //第一帧需要设置为MultiFrame 

                        eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
                        bindProperty(res, gif);
                        gif.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + Path.GetFileName(path).Replace(".", DateTime.Now.ToString("yyMMddHHmmssfff") + "."), codecInfo, eps);
                    }
                    else
                    {

                        gFrame.DrawImage(res, rg);

                        eps = new EncoderParameters(1);

                        //如果是GIF这里设置为FrameDimensionTime，如果为TIFF则设置为FrameDimensionPage 

                        eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);

                        bindProperty(res, frame);
                        gif.SaveAdd(frame, eps);
                    }
                }

                eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                gif.SaveAdd(eps);
            }
            MessageBox.Show("缩放完成！");
        }

        /// <summary> 
        /// 将源图片文件里每一帧的属性设置到新的图片对象里 
        /// </summary> 
        /// <param name="a">源图片帧</param> 
        /// <param name="b">新的图片帧</param> 
        private void bindProperty(Image a, Image b)
        {
            //这个东西就是每一帧所拥有的属性，可以用GetPropertyItem方法取得这里用为完全复制原有属性所以直接赋值了 
            //顺便说一下这个属性里包含每帧间隔的秒数和透明背景调色板等设置，这里具体那个值对应那个属性大家自己在msdn搜索GetPropertyItem方法说明就有了 
            for (int i = 0; i < a.PropertyItems.Length; i++)
            {
                b.SetPropertyItem(a.PropertyItems[i]);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void btnType1_Click(object sender, EventArgs e)
        {
            UseTypeFunction(1);
        }

        private void btnType2_Click(object sender, EventArgs e)
        {
            UseTypeFunction(2);
        }
        #endregion

        public void UseTypeFunction(int type)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                //原图
                Image img = Image.FromFile(txtFilePath.Text);
                int biLi = 60;
                if (int.TryParse(txtBiLi.Text, out biLi))
                {
                    int suoFangWidth = img.Width * biLi / 100;
                    int suoFangHeight = img.Height * biLi / 100;
                    img.Dispose();
                    if (type == 1)
                    {
                        SuoFang(txtFilePath.Text, suoFangWidth, suoFangHeight);
                    }
                    else if (type == 2)
                    {
                        setGifSize(txtFilePath.Text, suoFangWidth, suoFangHeight);
                    }
                }
                else
                {
                    MessageBox.Show("比例转换失败！");
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnLoadImgInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                //原图
                Image res = Image.FromFile(txtFilePath.Text);
                int count = 0;
                foreach (Guid gd in res.FrameDimensionsList)
                {
                    FrameDimension fd = new FrameDimension(gd);
                    count += res.GetFrameCount(fd);
                }
                lastImageCount = count;
                lblPicInfo.Text = "图片信息：" + count + "帧";
                res.Dispose();
            }
        }

        private void btnShowZhen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                int indexImg = 0;
                if (int.TryParse(txtGifZhen.Text, out indexImg))
                {
                    Image img = GetImg(txtFilePath.Text, indexImg);
                    if (img != null)
                    {
                        pbShow.Image = null;
                        pbShow.Image = img;
                    }
                }
            }
        }
        /// <summary>
        /// 获取指定帧数的图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Image GetImg(string path, int index)
        {
            Image res = Image.FromFile(path);
            int width = res.Width;
            int height = res.Height;
            Image gif = new Bitmap(width, height);
            Image frame = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(gif);
            Rectangle rg = new Rectangle(0, 0, width, height);
            Graphics gFrame = Graphics.FromImage(frame);
            int forIndex = 0;
            foreach (Guid gd in res.FrameDimensionsList)
            {
                FrameDimension fd = new FrameDimension(gd);

                //因为是缩小GIF文件所以这里要设置为Time，如果是TIFF这里要设置为PAGE，因为GIF以时间分割，TIFF为页分割 
                FrameDimension f = FrameDimension.Time;
                int count = res.GetFrameCount(fd);
                //ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Gif);
                //System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                //EncoderParameters eps = null;

                for (int i = 0; i < count; i++)
                {
                    forIndex++;
                    res.SelectActiveFrame(f, i);
                    if (0 == i)
                    {
                        if (forIndex == index)
                        {
                            g.DrawImage(res, rg);
                            bindProperty(res, gif);
                            return gif;
                        }
                        //gif.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + Path.GetFileName(path).Replace(".", DateTime.Now.ToString("yyMMddHHmmssfff") + "."), codecInfo, eps);
                    }
                    else
                    {
                        if (forIndex == index)
                        {
                            gFrame.DrawImage(res, rg);
                            bindProperty(res, frame);
                            return frame;
                        }
                        //gif.SaveAdd(frame, eps);
                    }
                }

                //eps = new EncoderParameters(1);
                //eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                //gif.SaveAdd(eps);
            }
            //MessageBox.Show("缩放完成！");
            res.Dispose();
            return null;
        }

        #region 拖放文件
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //如果拖进来的是文件类型
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                //得到拖进来的路径,取第一个文件
                string path = paths[0];
                //Clipboard.SetText(path);
                txtFilePath.Text = path;
                string fileName = txtFilePath.Text.Substring(txtFilePath.Text.LastIndexOf('\\') + 1);
                //txtFilePath.Text = path.Substring(0, path.LastIndexOf('\\'));
                //if (txtFilePath.Text.EndsWith("\\")) { txtFilePath.Text = txtFilePath.Text.TrimEnd('\\'); }
                //if (txtFilePath.Text.EndsWith("\\Debug")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\debug")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\bin")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\Bin")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //路径字符串长度不为空
                if (path.Length > 1)
                {
                    //判断是文件夹吗
                    FileInfo fil = new FileInfo(path);
                    if (fil.Attributes == FileAttributes.Directory)//文件夹
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                    else//文件
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                }
                else
                {
                    //鼠标图标禁止
                    e.Effect = DragDropEffects.None;
                }
                btnLoadImgInfo_Click(null, null);
                IsPlay = false;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //如果拖进来的是文件类型
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                //得到拖进来的路径,取第一个文件
                string path = paths[0];
                //Clipboard.SetText(path);
                txtFilePath.Text = path;
                string fileName = txtFilePath.Text.Substring(txtFilePath.Text.LastIndexOf('\\') + 1);
                //txtFilePath.Text = path.Substring(0, path.LastIndexOf('\\'));
                //if (txtFilePath.Text.EndsWith("\\")) { txtFilePath.Text = txtFilePath.Text.TrimEnd('\\'); }
                //if (txtFilePath.Text.EndsWith("\\Debug")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\debug")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\bin")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //if (txtFilePath.Text.EndsWith("\\Bin")) { txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf('\\')); }
                //路径字符串长度不为空
                if (path.Length > 1)
                {
                    //判断是文件夹吗
                    FileInfo fil = new FileInfo(path);
                    if (fil.Attributes == FileAttributes.Directory)//文件夹
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                    else//文件
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                }
                else
                {
                    //鼠标图标禁止
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        #endregion

        #region 帧操作
        /// <summary>
        /// 下一帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                int indexImg = 0;
                if (int.TryParse(txtGifZhen.Text, out indexImg))
                {
                    txtGifZhen.Text = (indexImg + 1).ToString();
                    Image img = GetImg(txtFilePath.Text, indexImg + 1);
                    if (img != null)
                    {
                        pbShow.Image = null;
                        pbShow.Image = img;
                    }
                }
            }
        }
        /// <summary>
        /// 上一帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                int indexImg = 0;
                if (int.TryParse(txtGifZhen.Text, out indexImg))
                {
                    txtGifZhen.Text = (indexImg - 1).ToString();
                    Image img = GetImg(txtFilePath.Text, indexImg - 1);
                    if (img != null)
                    {
                        pbShow.Image = null;
                        pbShow.Image = img;
                    }
                }
            }
        }

        private void btnPrevX_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                int indexImg = 0;
                if (int.TryParse(txtGifZhen.Text, out indexImg))
                {
                    int indexX = 0;
                    if (int.TryParse(txtGifZhenX.Text, out indexX))
                    {
                        if (indexImg - indexX >= 0)
                        {
                            txtGifZhen.Text = (indexImg - indexX).ToString();
                            Image img = GetImg(txtFilePath.Text, indexImg);
                            if (img != null)
                            {
                                pbShow.Image = null;
                                pbShow.Image = img;
                            }
                        }
                    }
                }
            }
        }

        private void btnNextX_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                int indexImg = 0;
                if (int.TryParse(txtGifZhen.Text, out indexImg))
                {
                    int indexX = 0;
                    if (int.TryParse(txtGifZhenX.Text, out indexX))
                    {
                        if (indexImg + indexX < lastImageCount)
                        {
                            txtGifZhen.Text = (indexImg + indexX).ToString();
                            Image img = GetImg(txtFilePath.Text, indexImg);
                            if (img != null)
                            {
                                pbShow.Image = null;
                                pbShow.Image = img;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// GIF每帧之间的间隔数组
        /// </summary>
        int[] delays = null;
        /// <summary>
        /// GIF每帧之间的间隔数组索引
        /// </summary>
        int delaysIndex = 0;
        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "";
            if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            {
                delays = null;
                delaysIndex = 0;
                timer1NowI = 0;
                IsPlay = true;
                beginZhen = int.Parse(txtPlayBeginZhen.Text);//播放开始帧数
                beiSu = double.Parse(txtPlayBeiSu.Text);//播放倍速
                animatedGif = new Bitmap(txtFilePath.Text);
                g = this.pbShow.CreateGraphics();
                // A Gif image's frame delays are contained in a byte array
                // in the image's PropertyTagFrameDelay Property Item's
                // value property.
                // Retrieve the byte array...
                int PropertyTagFrameDelay = 0x5100;
                PropertyItem propItem = animatedGif.GetPropertyItem(PropertyTagFrameDelay);
                byte[] bytes = propItem.Value;
                // Get the frame count for the Gif...
                frameDimension = new FrameDimension(animatedGif.FrameDimensionsList[0]);
                int frameCount = animatedGif.GetFrameCount(FrameDimension.Time);
                // Create an array of integers to contain the delays,
                // in hundredths of a second, between each frame in the Gif image.
                delays = new int[frameCount + 1];
                int i = 0;
                for (i = 0; i <= frameCount - 1; i++)
                {
                    delays[i] = BitConverter.ToInt32(bytes, i * 4);
                }
                //g.Dispose();
                //animatedGif.Dispose();
                timer1.Interval = delays[delaysIndex];
                timer1.Enabled = true;
                delaysIndex++;

                // Play the Gif one time...
                //while (true && !IsFormClose && IsPlay)
                //{
                //    for (i = 0; i <= animatedGif.GetFrameCount(frameDimension) - 1; i++)
                //    {
                //        if (i >= beginZhen)
                //        {
                //            animatedGif.SelectActiveFrame(frameDimension, i);
                //            g.DrawImage(animatedGif, new Point(0, 0));
                //            Application.DoEvents();
                //            Thread.Sleep((int)(delays[i] * 10 * beiSu));
                //            if (IsFormClose || !IsPlay)
                //            {
                //                g.Dispose();
                //                animatedGif.Dispose();
                //                break;
                //            }
                //        }
                //    }
                //    break;
                //}
            }
        }
        void PlayGif()
        {
            //if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
            //{
            //    IsPlay = true;
            //    int beginZhen = int.Parse(txtPlayBeginZhen.Text);//播放开始帧数
            //    double beiSu = double.Parse(txtPlayBeiSu.Text);//播放倍速
            //    Bitmap animatedGif = new Bitmap(txtFilePath.Text);
            //    Graphics g = this.pbShow.CreateGraphics();
            //    // A Gif image's frame delays are contained in a byte array
            //    // in the image's PropertyTagFrameDelay Property Item's
            //    // value property.
            //    // Retrieve the byte array...
            //    int PropertyTagFrameDelay = 0x5100;
            //    PropertyItem propItem = animatedGif.GetPropertyItem(PropertyTagFrameDelay);
            //    byte[] bytes = propItem.Value;
            //    // Get the frame count for the Gif...
            //    FrameDimension frameDimension = new FrameDimension(animatedGif.FrameDimensionsList[0]);
            //    int frameCount = animatedGif.GetFrameCount(FrameDimension.Time);
            //    // Create an array of integers to contain the delays,
            //    // in hundredths of a second, between each frame in the Gif image.
            //    int[] delays = new int[frameCount + 1];
            //    int i = 0;
            //    for (i = 0; i <= frameCount - 1; i++)
            //    {
            //        delays[i] = BitConverter.ToInt32(bytes, i * 4);
            //    }

            //    // Play the Gif one time...
            //    while (true && !IsFormClose && IsPlay)
            //    {
            //        for (i = 0; i <= animatedGif.GetFrameCount(frameDimension) - 1; i++)
            //        {
            //            if (i >= beginZhen)
            //            {
            //                animatedGif.SelectActiveFrame(frameDimension, i);
            //                g.DrawImage(animatedGif, new Point(0, 0));
            //                Application.DoEvents();
            //                Thread.Sleep((int)(delays[i] * 10 * beiSu));
            //                if (IsFormClose || !IsPlay)
            //                {
            //                    g.Dispose();
            //                    animatedGif.Dispose();
            //                    break;
            //                }
            //            }
            //        }
            //        break;
            //    }
            //}
        }
        Bitmap animatedGif = null;
        Graphics g = null;
        FrameDimension frameDimension = null;
        /// <summary>
        /// timer1要播放的当前帧数
        /// </summary>
        int timer1NowI = 0;
        /// <summary>
        /// 播放开始帧数
        /// </summary>
        int beginZhen = 0;//播放开始帧数
        /// <summary>
        /// 播放倍速
        /// </summary>
        double beiSu = 0;//播放倍速
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (delaysIndex < delays.Length)
            {
                if (!string.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
                {
                    // Play the Gif one time...
                    if (true && !IsFormClose && IsPlay)
                    {
                        for (int i = timer1NowI; i <= animatedGif.GetFrameCount(frameDimension) - 1; i++)
                        {
                            lblProgress.Text = (i.ToString() + "帧 " + ((double)i / (double)lastImageCount).ToString("0.00") + "%");
                            timer1NowI++;
                            if (i >= beginZhen)
                            {
                                animatedGif.SelectActiveFrame(frameDimension, i);
                                g.DrawImage(animatedGif, new Point(0, 0));
                                Application.DoEvents();
                                //Thread.Sleep((int)(delays[i] * 10 * beiSu));
                                if (IsFormClose || !IsPlay)
                                {
                                    g.Dispose();
                                    animatedGif.Dispose();
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                timer1.Interval = (int)(delays[delaysIndex] * 10 * beiSu);
                timer1.Enabled = true;
                delaysIndex++;
            }
            else
            {
                timer1.Enabled = false;
                g.Dispose();
                animatedGif.Dispose();
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            IsPlay = false;
            timer1.Enabled = false;
            timer1NowI = 0;
        }
    }
    /// <summary>      
    /// 表示一类带动画功能的图像。      
    /// </summary>      
    public class AnimateImage
    {
        Image image;
        FrameDimension frameDimension;
        /// <summary>      
        /// 动画当前帧发生改变时触发。      
        /// </summary>      
        public event EventHandler<EventArgs> OnFrameChanged;

        /// <summary>      
        /// 实例化一个AnimateImage。      
        /// </summary>      
        /// <param name="img">动画图片。</param>      
        public AnimateImage(Image img)
        {
            image = img;
            lock (image)
            {
                mCanAnimate = ImageAnimator.CanAnimate(image);
                if (mCanAnimate)
                {
                    Guid[] guid = image.FrameDimensionsList;
                    mFrameCount = image.GetFrameCount(frameDimension);
                }
            }
        }

        bool mCanAnimate;
        int mFrameCount = 1, mCurrentFrame = 0;

        /// <summary>      
        /// 图片。      
        /// </summary>      
        public Image Image
        {
            get { return image; }
        }

        /// <summary>      
        /// 是否动画。      
        /// </summary>      
        public bool CanAnimate
        {
            get { return mCanAnimate; }
        }

        /// <summary>      
        /// 总帧数。      
        /// </summary>      
        public int FrameCount
        {
            get { return mFrameCount; }
        }

        /// <summary>      
        /// 播放的当前帧。      
        /// </summary>      
        public int CurrentFrame
        {
            get { return mCurrentFrame; }
        }
        /// <summary>      
        /// 播放这个动画。      
        /// </summary>      
        public void Play()
        {
            if (mCanAnimate)
            {
                lock (image)
                {
                    ImageAnimator.Animate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>      
        /// 停止播放。      
        /// </summary>      
        public void Stop()
        {
            if (mCanAnimate)
            {
                lock (image)
                {
                    ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>      
        /// 重置动画，使之停止在第0帧位置上。      
        /// </summary>      
        public void Reset()
        {
            if (mCanAnimate)
            {
                ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                lock (image)
                {
                    image.SelectActiveFrame(frameDimension, 0);
                    mCurrentFrame = 0;
                }
            }
        }

        private void FrameChanged(object sender, EventArgs e)
        {
            mCurrentFrame = mCurrentFrame + 1 >= mFrameCount ? 0 : mCurrentFrame + 1;
            lock (image)
            {
                image.SelectActiveFrame(frameDimension, mCurrentFrame);
            }
            if (OnFrameChanged != null)
            {
                OnFrameChanged(image, e);
            }
        }
    }
}
