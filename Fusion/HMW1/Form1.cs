using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace HMW1
{
    public partial class Form1 : Form
    {
        int picHeight1, picHeight2, picWidth1, picWidth2;
        Bitmap OriginalPic1, OriginalPic2, NewPic,ResPic;
        double[,] Pic1Cor = new double[68, 2];
        double[,] Pic1CorNew = new double[68, 2];
        int[,] Pic1CorNewInt = new int[68, 2];
        double[,] Pic2Cor = new double[68, 2];
        int[,] Pic2CorNew = new int[68, 2];
        public Form1()
        {
            InitializeComponent();
            OriginalPic1 = new Bitmap("../Input/6.jpg");
            OriginalPic2= new Bitmap("../Input/8.jpg");
            this.Picture1.Image = new Bitmap(OriginalPic1, 250, 250);
            this.Picture2.Image = new Bitmap(OriginalPic2, 250, 250);
            NewPic = new Bitmap("../Input/8.jpg");
            ResPic = new Bitmap("../Input/8.jpg");
            picHeight1 = OriginalPic1.Height;
            picHeight2 = OriginalPic2.Height;
            picWidth1 = OriginalPic1.Width;
            picWidth2 = OriginalPic2.Width;
            
            Console.WriteLine(picWidth1 + " "+ picHeight1);
            Console.WriteLine(picWidth2 + " " + picHeight2);
            try//读取人脸关键点坐标
            { 
                using (StreamReader sr = new StreamReader("../Input/6.txt")) // 读取第一张图片的特征点坐标
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace('\n', ' ');
                        string[] temp = line.Split(' ');
                        double x = Convert.ToDouble(temp[0]);
                        double y = Convert.ToDouble(temp[1]);
                        Pic1Cor[i, 0] = x;
                        Pic1Cor[i, 1] = y;
                        //Console.WriteLine("第{0}个点 x:{1} y:{2}", i, Pic1Cor[i, 0], Pic1Cor[i, 1]);
                        i++;
                    }
                    //Console.WriteLine(i);
                }
                using (StreamReader sr = new StreamReader("../Input/8.txt")) // 读取图片2的特征点坐标
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace('\n', ' ');
                        string[] temp = line.Split(' ');
                        double x = Convert.ToDouble(temp[0]);
                        double y = Convert.ToDouble(temp[1]);
                        Pic2Cor[i, 0] = x;
                        Pic2Cor[i, 1] = y;
                        //Console.WriteLine("第{0}个点 x:{1} y:{2}", i, Pic2Cor[i, 0], Pic2Cor[i, 1]);
                        i++;
                    }
                    //Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:"); // 向用户显示出错消息
                Console.WriteLine(e.Message);
            }

            //MatchPositive();
            //Matrix M = TPSparamPositive();
            //TPSchangePositive(M);//可以运行的TPS正变换
            //Matrix M = TPSparamNegative();
            //TPSchangeNegative(M);//可以运行的TPS未配准的反变换
            // MatchNegative();//可以运行的反配准的B样条SPlineChange()
            //SPlinechange();//配准方法不同的B样条
            //SPlinechange1();//另一种效果不好的B样条
            this.Picture3.Image = new Bitmap(NewPic, 250, 250);

        }

        private Color Bilinear(double x, double y)//双线性插值
        {
            if (x < 0 || y < 0 || x >= picWidth2 - 1 || y >= picHeight2 - 1)
                return Color.FromArgb(0, 0, 0);//越界返回黑色

            double R, G, B;
            int x1 = (int)Math.Floor(x);
            int y1 = (int)Math.Floor(y);
            double u = x - x1;
            double v = y - y1;

            Matrix M1= new Matrix(1,2);
            M1[0, 0] = 1 - u; M1[0, 1] = u;

            Matrix M3 = new Matrix(2, 1);
            M3[0, 0] = 1 - v;
            M3[1, 0] = v;

            Matrix M2 = new Matrix(2, 2);//利用矩阵求出插值后像素点的R,G,B
            M2[0, 0] = OriginalPic2.GetPixel(x1, y1).R;      M2[0, 1] = OriginalPic2.GetPixel(x1, y1+1).R;
            M2[1, 0] = OriginalPic2.GetPixel(x1 + 1, y1).R;  M2[1, 1] = OriginalPic2.GetPixel(x1 + 1, y1+1).R;
            R = ((M1 * M2) * M3)[0,0];

            M2[0, 0] = OriginalPic2.GetPixel(x1, y1).G;      M2[0, 1] = OriginalPic2.GetPixel(x1, y1 + 1).G;
            M2[1, 0] = OriginalPic2.GetPixel(x1 + 1, y1).G;  M2[1, 1] = OriginalPic2.GetPixel(x1 + 1, y1 + 1).G;
            G = ((M1 * M2) * M3)[0, 0];

            M2[0, 0] = OriginalPic2.GetPixel(x1, y1).B;      M2[0, 1] = OriginalPic2.GetPixel(x1, y1 + 1).B;
            M2[1, 0] = OriginalPic2.GetPixel(x1 + 1, y1).B;  M2[1, 1] = OriginalPic2.GetPixel(x1 + 1, y1 + 1).B;
            B = ((M1 * M2) * M3)[0, 0];

            return Color.FromArgb((int)R,(int)G,(int)B);
        }

        private Color Nearest(double x, double y)//最近邻插值
        {
            if (x < 0 || y < 0 || x >= picWidth2 - 1 || y >= picHeight2 - 1)
                return Color.FromArgb(0, 0, 0);//越界返回黑色

            int x1 = (int)Math.Floor(x);
            int y1 = (int)Math.Floor(y);
            double u = x - x1;
            double v = y - y1;
            if (u >= 0.5) x1 = x1 + 1;
            if (v >= 0.5) y1 = y1 + 1;

            return OriginalPic2.GetPixel(x1,y1);
        }

        private double S(double x)//双三次插值函数S(x)
        {
            double S;
            double x1 = Math.Abs(x);
            if (x1 <= 1)
                S = 1 - 2 * Math.Pow(x1, 2) + Math.Pow(x1, 3);
            else if (x1 < 2)
                S = 4 - 8 * x1 + 5 * Math.Pow(x1, 2) - Math.Pow(x1, 3);
            else  S = 0;

            return S;
        }

        private Color Bicubic(double x, double y)//双三次插值
        {
            if (x < 1 || y < 1 || x >= picWidth2 - 2 || y >= picHeight2 - 2)
                return Color.FromArgb(0, 0, 0);//越界返回黑色

            double R, G, B;
            int x1 = (int)Math.Floor(x);
            int y1 = (int)Math.Floor(y);
            double u = x - x1;
            double v = y - y1;

            Matrix M1 = new Matrix(1, 4);
            M1[0, 0] = S(1 + u); M1[0, 1] = S(u); M1[0, 2] = S(u - 1); M1[0, 3] = S(u - 2);

            Matrix M3 = new Matrix(1, 4);
            M3[0, 0] = S(1 + v); M3[0, 1] = S(v); M3[0, 2] = S(v - 1); M3[0, 3] = S(v - 2);

            Matrix M2_R = new Matrix(4, 4);
            Matrix M2_G = new Matrix(4, 4);
            Matrix M2_B = new Matrix(4, 4);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    M2_R[i, j] = OriginalPic2.GetPixel(x1 - 1 + i, y1 - 1 + j).R;
                    M2_G[i, j] = OriginalPic2.GetPixel(x1 - 1 + i, y1 - 1 + j).G;
                    M2_B[i, j] = OriginalPic2.GetPixel(x1 - 1 + i, y1 - 1 + j).B;
                }

            R = (M1 * M2_R * (M3.Transpose()))[0, 0];
            G = (M1 * M2_G * (M3.Transpose()))[0, 0];
            B = (M1 * M2_B * (M3.Transpose()))[0, 0];

            if (R < 0) R = 0;
            else if (R > 255) R = 255;

            if (G < 0) G = 0;
            else if (G > 255) G = 255;

            if (B < 0) B = 0;
            else if (B > 255) B = 255;

            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        private Matrix TPSparamPositive()//求解TPS正变换参数矩阵
        {
            Matrix L = new Matrix(71, 71);
            Matrix Y = new Matrix(71, 2);

            for (int i = 0; i < 68; i++)
            {
                L[i, 68] = 1;//构造矩阵L
                L[i, 69] = Pic2Cor[i, 0];
                L[i, 70] = Pic2Cor[i, 1];
                L[68, i] = 1;
                L[69, i] = Pic2Cor[i, 0];
                L[70, i] = Pic2Cor[i, 1];
                L[i, i] = 0;

                //Y[i, 0] = Pic1Cor[i, 0];//构造矩阵Y
                //Y[i, 1] = Pic1Cor[i, 1];
                Y[i, 0] = Pic1CorNew[i, 0];//构造矩阵Y
                Y[i, 1] = Pic1CorNew[i, 1];

            }

            for (int i = 68; i < 71; i++)
                for(int j = 68; j < 71; j++)
            {
                L[i,j] = 0;
            }

            double distance;
            for (int i = 0; i < 68; i++)
                for (int j = i+1; j < 68; j++)
                {
                    distance = Math.Pow(Pic2Cor[i, 0]- Pic2Cor[j, 0], 2) + Math.Pow(Pic2Cor[i, 1]-Pic2Cor[j, 1], 2);
                    L[i, j] = distance * Math.Log(distance);
                    L[j, i] = L[i, j];
                }

            for (int i = 68; i < 71; i++)
                for (int j = 0; j < 2; j++)
                {
                    Y[i, j] = 0;
                }

            Matrix A = L.Inverse() * Y;
            return A;
        }

        private void TPSchangePositive(Matrix A)//TPS正变换变形
        {
            Matrix T = new Matrix(1, 71);
            Matrix F = new Matrix(1, 2);
            double distance;
            for (int i = 0; i < picWidth2; i++)
                for (int j = 0; j < picHeight2; j++)
                {
                    for (int k = 0; k < 68; k++)//对图像1里的每个点构造矩形求取f(x,y)映射到2图中
                    {
                        distance = Math.Pow(i - Pic2Cor[k, 0], 2) + Math.Pow(j - Pic2Cor[k, 1], 2);
                        if (distance == 0) T[0, k] = 0;
                        else
                            T[0, k] = distance * Math.Log(distance);
                    }
                    T[0, 68] = 1;
                    T[0, 69] = i;
                    T[0, 70] = j;
                    F = T * A;
                    if (F[0, 0] < 0 || F[0, 1] < 0 || F[0, 0] >= picWidth2 || F[0, 1] >= picHeight2)
                        continue;
                    else
                        NewPic.SetPixel((int)F[0, 0], (int)F[0, 1], OriginalPic2.GetPixel(i, j));
                }
                }

        private Matrix TPSparamNegative()//求解TPS反变换参数矩阵
        {
            Matrix L = new Matrix(71, 71);
            Matrix Y = new Matrix(71, 2);

            for (int i = 0; i < 68; i++)
            {
                L[i, 68] = 1;//构造矩阵L
                L[i, 69] = Pic1Cor[i, 0];
                L[i, 70] = Pic1Cor[i, 1];
                L[68, i] = 1;
                L[69, i] = Pic1Cor[i, 0];
                L[70, i] = Pic1Cor[i, 1];
                L[i, i] = 0;

                Y[i, 0] = Pic2Cor[i, 0];//构造矩阵Y
                Y[i, 1] = Pic2Cor[i, 1];

            }

            for (int i = 68; i < 71; i++)
                for (int j = 68; j < 71; j++)
                {
                    L[i, j] = 0;
                }

            double distance;
            for (int i = 0; i < 68; i++)
                for (int j = i + 1; j < 68; j++)
                {
                    distance = Math.Pow(Pic1Cor[i, 0] - Pic1Cor[j, 0], 2) + Math.Pow(Pic1Cor[i, 1] - Pic1Cor[j, 1], 2);
                    L[i, j] = distance * Math.Log(distance);
                    L[j, i] = L[i, j];
                }

            for (int i = 68; i < 71; i++)
                for (int j = 0; j < 2; j++)
                {
                    Y[i, j] = 0;
                }

            Matrix A = L.Inverse() * Y;
            return A;
        }
      
        private void TPSchangeNegative(Matrix A)//TPS反变换变形
        {
            Matrix T = new Matrix(1, 71);
            Matrix F = new Matrix(1, 2);
            double distance;
            for (int i = 0; i < picWidth2; i++)
                for (int j = 0; j < picHeight2; j++)
                {
                    for (int k = 0; k < 68; k++)//对新图像里的每个点构造矩形求取f(x,y)映射到2图中
                    {
                        distance = Math.Pow(i - Pic1Cor[k, 0], 2) + Math.Pow(j - Pic1Cor[k, 1], 2);
                        if (distance == 0) T[0, k] = 0;
                        else
                            T[0, k] = distance * Math.Log(distance);
                    }
                    T[0, 68] = 1;
                    T[0, 69] = i;
                    T[0, 70] = j;
                    F = T * A;
                    if ((int)F[0, 0] < 0 || (int)F[0, 1] < 0 || (int)F[0, 0] >= picWidth2 || (int)F[0, 1] >= picHeight2)
                        NewPic.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        NewPic.SetPixel(i, j, OriginalPic2.GetPixel((int)F[0, 0], (int)F[0, 1]));
                }
        }

        private Matrix TPSparamNegativeMatch()//求解TPS反变换参数矩阵(配准后)
        {
            Matrix L = new Matrix(71, 71);
            Matrix Y = new Matrix(71, 2);

            for (int i = 0; i < 68; i++)
            {
                L[i, 68] = 1;//构造矩阵L
                L[i, 69] = Pic1CorNew[i, 0];
                L[i, 70] = Pic1CorNew[i, 1];
                L[68, i] = 1;
                L[69, i] = Pic1CorNew[i, 0];
                L[70, i] = Pic1CorNew[i, 1];
                L[i, i] = 0;

                Y[i, 0] = Pic2Cor[i, 0];//构造矩阵Y
                Y[i, 1] = Pic2Cor[i, 1];

            }

            for (int i = 68; i < 71; i++)
                for (int j = 68; j < 71; j++)
                {
                    L[i, j] = 0;
                }

            double distance;
            for (int i = 0; i < 68; i++)
                for (int j = i + 1; j < 68; j++)
                {
                    distance = Math.Pow(Pic1CorNew[i, 0] - Pic1CorNew[j, 0], 2) + Math.Pow(Pic1CorNew[i, 1] - Pic1CorNew[j, 1], 2);
                    L[i, j] = distance * Math.Log(distance);
                    L[j, i] = L[i, j];
                }

            for (int i = 68; i < 71; i++)
                for (int j = 0; j < 2; j++)
                {
                    Y[i, j] = 0;
                }

            Matrix A = L.Inverse() * Y;
            return A;
        }

        private void TPSchangeNegativeMatch(Matrix A)//TPS逆变换变形(配准后)
        {
            Matrix T = new Matrix(1, 71);
            Matrix F = new Matrix(1, 2);
            double distance;

            progressBar1.Maximum = picWidth2;//进度条显示
            progressBar1.Visible = true;


            for (int i = 0; i < picWidth2; i++)
            {
                progressBar1.Value = i;
                progressBar1.PerformStep();
                Application.DoEvents();

                for (int j = 0; j < picHeight2; j++)
                {
                    for (int k = 0; k < 68; k++)//对新图像里的每个点构造矩形求取f(x,y)映射到2图中
                    {
                        distance = Math.Pow(i - Pic1CorNew[k, 0], 2) + Math.Pow(j - Pic1CorNew[k, 1], 2);
                        if (distance == 0) T[0, k] = 0;
                        else
                            T[0, k] = distance * Math.Log(distance);
                    }
                    T[0, 68] = 1;
                    T[0, 69] = i;
                    T[0, 70] = j;
                    F = T * A;

                    if (nearest.Checked)
                    {
                        NewPic.SetPixel(i, j, Nearest(F[0, 0], F[0, 1]));
                    }
                    else if (bilinear.Checked)
                    {
                        NewPic.SetPixel(i, j, Bilinear(F[0, 0], F[0, 1]));
                    }
                    else if (bicubic.Checked)
                    {
                        NewPic.SetPixel(i, j, Bicubic(F[0, 0], F[0, 1]));
                    } 
                    }
            }
        }

        private void MatchPositive()//人脸配准,把提供特征点的脸（小孩）与需要变形的脸（特朗普）进行对齐
        {
            double u0 = Pic1Cor[30, 0], v0 = Pic1Cor[30, 1];
            double x0 = Pic2Cor[30, 0], y0 = Pic2Cor[30, 1];
            double Tx = x0-u0;
            double Ty = y0-v0;

            double u1 = Pic1Cor[0, 0], u2 = Pic1Cor[16, 0];
            double x1 = Pic2Cor[0, 0], x2 = Pic2Cor[16, 0];
            double k = (x2 - x1) / (u2 - u1);

            double temp1, temp2;
            
            for (int i = 0; i < 68; i++)//求图片1配准后的坐标
            {
                temp1 = u0 + k * (Pic1Cor[i, 0] - u0);
                temp2 = v0 + k * (Pic1Cor[i, 1] - v0);
                Pic1CorNew[i, 0] = temp1 + Tx;
                Pic1CorNew[i, 1] = temp2 + Ty;
                //Console.WriteLine("配准前第{0}个点 x:{1} y:{2}", i, Pic1Cor[i, 0], Pic1Cor[i, 1]);
                //Console.WriteLine("配准后第{0}个点 x:{1} y:{2}", i, Pic1CorNew[i, 0], Pic1CorNew[i, 1]);
            }

            //for (int i = 0; i < picWidth1; i++)//测试配准效果
            //    for (int j = 0; j < picHeight1; j++)
            //    {
            //        temp1 = u0 + k * (i - u0);
            //        temp2 = v0 + k * (j - v0);
            //        temp1 = temp1 + Tx;
            //        temp2 = temp2 + Ty;

            //        if ((int)temp1 < 0 || (int)temp2 < 0 || (int)temp1 >= picWidth1 || (int)temp2 >= picHeight1)
            //            continue;
            //        else
            //            NewPic.SetPixel((int)temp1, (int)temp2, OriginalPic1.GetPixel(i, j));
            //    }
        }

        private void MatchPositiveInt()//人脸配准,把提供特征点的脸（小孩）与需要变形的脸（特朗普）进行对齐,整数用于B样条变换
        {
            double u0 = Pic1Cor[30, 0], v0 = Pic1Cor[30, 1];
            double x0 = Pic2Cor[30, 0], y0 = Pic2Cor[30, 1];
            double Tx = x0 - u0;
            double Ty = y0 - v0;

            double u1 = Pic1Cor[0, 0], u2 = Pic1Cor[16, 0];
            double x1 = Pic2Cor[0, 0], x2 = Pic2Cor[16, 0];
            double k = (x2 - x1) / (u2 - u1);

            double temp1, temp2;
            double u, v;

            for (int i = 0; i < 68; i++)//求图片1配准后的坐标
            {
                temp1 = u0 + k * (Pic1Cor[i, 0] - u0);
                temp2 = v0 + k * (Pic1Cor[i, 1] - v0);
                temp1 = temp1 + Tx;
                temp2 = temp2 + Ty;

                Pic1CorNewInt[i, 0] = (int)Math.Floor(temp1);
                Pic1CorNewInt[i, 1] = (int)Math.Floor(temp2);
                u = temp1 - Pic1CorNewInt[i, 0];//0.5的配准变换误差
                v = temp2 - Pic1CorNewInt[i, 1];
                if (u >= 0.5) Pic1CorNewInt[i, 0] = Pic1CorNewInt[i, 0] + 1;
                if (v >= 0.5) Pic1CorNewInt[i, 1] = Pic1CorNewInt[i, 1] + 1;
            }
        }

        private double[] MatchNegative()//人脸配准,把需要变形的脸（特朗普）与提供特征点的脸（小孩）进行对齐
        {
            double u0 = Pic2Cor[30, 0], v0 = Pic2Cor[30, 1];
            double x0 = Pic1Cor[30, 0], y0 = Pic1Cor[30, 1];
            double Tx = x0 - u0;
            double Ty = y0 - v0;

            double u1 = Pic2Cor[0, 0], u2 = Pic2Cor[16, 0];
            double x1 = Pic1Cor[0, 0], x2 = Pic1Cor[16, 0];
            double k = (x2 - x1) / (u2 - u1);

            double temp1, temp2;
            double u, v;
            double[] Param = new double[5];
            Param[0] = u0;
            Param[1] = v0;
            Param[2] = Tx;
            Param[3] = Ty;
            Param[4] = k;

            for (int i = 0; i < 68; i++)//求图片1配准后的坐标
            {
                temp1 = u0 + k * (Pic2Cor[i, 0] - u0);
                temp2 = v0 + k * (Pic2Cor[i, 1] - v0);
                temp1 = temp1 + Tx;
                temp2 = temp2 + Ty;

                Pic2CorNew[i, 0] = (int)Math.Floor(temp1);
                Pic2CorNew[i, 1] = (int)Math.Floor(temp2);
                u = temp1 - Pic2CorNew[i, 0];
                v = temp2 - Pic2CorNew[i, 1];
                if (u >= 0.5) Pic2CorNew[i, 0] = Pic2CorNew[i, 0] + 1;
                if (v >= 0.5) Pic2CorNew[i, 1] = Pic2CorNew[i, 1] + 1;
            }
            return Param;
        }

        private double[] MatchNegativeInv(double x, double y, double[] Param) //人脸配准的逆变换,把配准的逆变换的规则应用于所有待逆映射再插值的点
        {
            double[] OriginalCor = new double[2];
            OriginalCor[0] = Param[0] + (x - Param[0] - Param[2]) / Param[4];
            OriginalCor[1] = Param[1] + (y - Param[1] - Param[3]) / Param[4];
            return (OriginalCor);
        }

        private double G(int i, double t)//三次B样条变形函数G(x)
        {
            double G = 0;
            if (i == 0)
                G = (-Math.Pow(t, 3) + 3 * Math.Pow(t, 2) - 3 * t + 1 ) / 6.0;
            else if (i == 1)
                G = (3 * Math.Pow(t, 3) - 6 * Math.Pow(t, 2) + 4) / 6.0;
            else if (i == 2)
                G = (-3 * Math.Pow(t, 3) + 3 * Math.Pow(t, 2) + 3 * t + 1) / 6.0;
            else if (i == 3)
                G = Math.Pow(t, 3) / 6.0;
            return G;
        }

        private void SPlinechange()//将特朗普的脸与小孩对齐后进行的B样条变换
        {
            int max = 0;
            for (int I = 0; I < 68; I++)
            {
                int AbsX = (int)Math.Abs(Pic1Cor[I, 0] - Pic2CorNew[I, 0]);
                int AbsY = (int)Math.Abs(Pic1Cor[I, 1] - Pic2CorNew[I, 1]);
                if (AbsX > max)
                    max = AbsX;
                if (AbsY > max)
                    max = AbsY;
                Console.WriteLine("AbsX:{0} AbsY:{1}", AbsX, AbsY);
            }
            Console.WriteLine("max:{0}", max);
            int Nx = max, Ny = max;
            for (int I = 0; I < 68; I++) {
                int IndexX = (int)(Pic1Cor[I, 0] / Nx);//确定按控制点分片后新点所处的Tiles坐标[IndexX,IndexY]
                int IndexY = (int)(Pic1Cor[I, 1] / Ny);
     
                double dx = Pic1Cor[I, 0] - Pic2CorNew[I, 0];//目标点-初始点即为位移
                double dy = Pic1Cor[I, 1] - Pic2CorNew[I, 1];
                //Console.WriteLine("X方向位移dx:{0} Y方向位移dy:{1}", dx, dy);

                if (dx > 3 * Nx) dx = 3 * Nx;
                if (dy > 3 * Ny) dy = 3 * Ny;

                double Tx =0, Ty =0;//目标点
                int dx0 = (int)Pic1Cor[I, 0] - IndexX * Nx;//定义两个校正量,把位移到达的点当做控制点
                int dy0 = (int)Pic1Cor[I, 1] - IndexY * Ny;//注意，由于引入配准的话实际会引入误差，因为要求坐标为整数点
                //Console.WriteLine("dx0:{0} dy0:{1}", dx0, dy0);

                double[] Param = MatchNegative();

                for (int x1 = -2 * Nx; x1 < 2 * Nx; x1++)
                for (int y1 = -2 * Ny; y1 < 2 * Ny; y1++)//开始遍历4*Nx，4*Ny之间的所有受该控制点平移影响的点（x,y）
                    {
                    int x = (int)Pic1Cor[I, 0] + x1;
                    int y = (int)Pic1Cor[I, 1] + y1;
                    //Console.WriteLine("此时将平移到的点的坐标 X:{0} Y:{1}", x, y);
                      

                    int i = (int)((x - dx0) / Nx) - 1;//将默认从（0,0）开始的控制点方格平移为从（2,3）开始
                    int j = (int)((y - dy0) / Ny) - 1;//计算该受影响的点落在了被控制点分割出的哪个tile内
                    //Console.WriteLine("目标点所属tiles下标[{0},{1}]", i, j);

                    double u = (double)(x - dx0) / Nx - (int)((x - dx0) / Nx);//计算该受影响的点在所处tile内的offset
                    double v = (double)(y - dy0) / Ny - (int)((y - dy0) / Ny);
                    //Console.WriteLine("所属tiles下标[{0},{1}]", i, j);

                    for (int l = 0; l <= 3; l++)
                        for (int m = 0; m <= 3; m++)
                            if ((l + i) == IndexX && (j + m) == IndexY)//对所有遍历的点而言，只有一个控制点的位移不为0需要计算
                            {
                                double weight = G(l, u) * G(m, v);//想要优化可以存一张表
                                Tx = x - weight * dx;
                                Ty = y - weight * dy;
                            }
                        double[] OriginalCor = MatchNegativeInv(Tx, Ty, Param);

                        if (x < 0 || y < 0 || x >= picWidth2 - 1 || y >= picHeight2 - 1)
                            continue;

                        else if (OriginalCor[0] < 0 || OriginalCor[1] < 0 || OriginalCor[0] >= picWidth2 - 1 || OriginalCor[1] >= picHeight2 - 1)
                            NewPic.SetPixel(x, y ,Color.FromArgb(0, 0, 0));//越界返回黑色

                        else NewPic.SetPixel(x, y, Nearest(OriginalCor[0], OriginalCor[1]));
                }
            } 
        }

        private void SPlinechange1()//将小孩的脸与特朗普对齐后进行的B样条反变换(对控制点采用最近邻思想，认为某一点发生的位移是离它最近的控制点的位移)
        {
            int Nx = 45, Ny = 45;
            int max = 0;
            for (int I = 0; I < 68; I++)
            {
                int AbsX = (int)Math.Abs(Pic1CorNewInt[I, 0] - Pic2Cor[I, 0]);
                int AbsY = (int)Math.Abs(Pic1CorNewInt[I, 1] - Pic2Cor[I, 1]);
                if (AbsX > max)
                    max = AbsX;
                if (AbsY > max)
                    max = AbsY;
                //Console.WriteLine("AbsX:{0} AbsY:{1}", AbsX, AbsY);
            }
            Console.WriteLine("max:{0}", max);//取平移的最大值作为控制点间距
            if (max <= 45)
            {
                Nx = max;
                Ny = max;
            }
            progressBar1.Maximum = 67;
            progressBar1.Visible = true;

            for (int I = 0; I < 68; I++)
            {
                progressBar1.Value = I;
                progressBar1.PerformStep();
                Application.DoEvents();

                int IndexX = (int)(Pic1CorNewInt[I, 0] / Nx);//确定按控制点分片后新特征点所处的Tiles坐标[IndexX,IndexY]
                int IndexY = (int)(Pic1CorNewInt[I, 1] / Ny);

                double dx = Pic1CorNewInt[I, 0] - Pic2Cor[I, 0];//目标控制点-初始控制点即为位移
                double dy = Pic1CorNewInt[I, 1] - Pic2Cor[I, 1];

                if (Pic1CorNewInt[I, 0] - IndexX * Nx > 0.5 * Nx)//对控制点形成的大格点采用最近邻思想，认为某一点发生的位移是离它最近的控制点的位移
                {
                    Pic1CorNewInt[I, 0] = (IndexX + 1) * Nx;
                    IndexX = IndexX + 1;
                }
                else Pic1CorNewInt[I, 0] = IndexX * Nx;
                if (Pic1CorNewInt[I, 1] - IndexY * Ny > 0.5 * Ny)
                {
                    Pic1CorNewInt[I, 1] = (IndexY + 1) * Ny;
                    IndexY = IndexY + 1;
                }
                else Pic1CorNewInt[I, 1] = IndexY * Ny;

                double Tx = 0, Ty = 0;//此后循环时的目标点
               
                for (int x1 = -2 * Nx; x1 < 2 * Nx; x1++)
                    for (int y1 = -2 * Ny; y1 < 2 * Ny; y1++)//开始遍历4*Nx，4*Ny之间的所有受该控制点平移影响的点（x,y）
                    {
                        int x = (int)Pic1CorNewInt[I, 0] + x1;
                        int y = (int)Pic1CorNewInt[I, 1] + y1;

                        int i = (int)(x / Nx) - 1;
                        int j = (int)(y / Ny) - 1;//计算该受影响的点落在了被控制点分割出的哪个tile内

                        double u = (double)(x / Nx) - (int)(x / Nx);//计算该受影响的点在所处tile内的offset
                        double v = (double)(y / Ny) - (int)(y / Ny);

                        for (int l = 0; l <= 3; l++)
                            for (int m = 0; m <= 3; m++)
                                if ((l + i) == IndexX && (j + m) == IndexY)//对所有遍历的点而言，只有一个控制点的位移不为0需要计算
                                {
                                    double weight = G(l, u) * G(m, v);//想要优化可以存一张表
                                    Tx = x - weight * dx;
                                    Ty = y - weight * dy;
                                }

                        if (x < 0 || y < 0 || x >= picWidth2 - 1 || y >= picHeight2 - 1)//目标点超出范围了继续下一次循环
                            continue;

                        else if (Tx < 0 || Ty < 0 || Tx >= picWidth2 - 1 || Ty >= picHeight2 - 1)
                            NewPic.SetPixel(x, y, Color.FromArgb(0, 0, 0));//越界返回黑色

                        else
                        {
                            if (nearest.Checked)
                            {
                                NewPic.SetPixel(x, y, Nearest(Tx, Ty));
                            }
                            else if (bilinear.Checked)
                            {
                                NewPic.SetPixel(x, y, Bilinear(Tx, Ty));
                            }
                            else if (bicubic.Checked)
                            {
                                NewPic.SetPixel(x, y, Bicubic(Tx, Ty));
                            }
                        }
                    }
            }
        }

        private void SPlinechange2()//将小孩的脸与特朗普对齐后进行的B样条反变换(最终采用)
        {
            int Nx = 45, Ny = 45;
            int max = 0;
            for (int I = 0; I < 68; I++)
            {
                int AbsX = (int)Math.Abs(Pic1CorNewInt[I, 0] - Pic2Cor[I, 0]);
                int AbsY = (int)Math.Abs(Pic1CorNewInt[I, 1] - Pic2Cor[I, 1]);
                if (AbsX > max)
                    max = AbsX;
                if (AbsY > max)
                    max = AbsY;
                //Console.WriteLine("AbsX:{0} AbsY:{1}", AbsX, AbsY);
            }
            Console.WriteLine("max:{0}", max);
            if (max <= 45)
            {
                Nx = max;
                Ny = max;
            }
            progressBar1.Maximum = 67;
            progressBar1.Visible = true;

            for (int I = 0; I < 68; I++)
            {
                progressBar1.Value = I;
                progressBar1.PerformStep();
                Application.DoEvents();

                int IndexX = (int)(Pic1CorNewInt[I, 0] / Nx);//确定按控制点分片后新特征点所处的Tiles坐标[IndexX,IndexY]
                int IndexY = (int)(Pic1CorNewInt[I, 1] / Ny);

                double dx = Pic1CorNewInt[I, 0] - Pic2Cor[I, 0];//目标控制点-初始控制点即为位移
                double dy = Pic1CorNewInt[I, 1] - Pic2Cor[I, 1];

                double Tx = 0, Ty = 0;//此后循环时的目标点
                int dx0 = (int)Pic1CorNewInt[I, 0] - IndexX * Nx;//定义两个校正量,把位移到达的点当做控制点
                int dy0 = (int)Pic1CorNewInt[I, 1] - IndexY * Ny;//注意，此时由于引入配准实际会引入误差，因为要求整数点

                for (int x1 = -2 * Nx; x1 < 2 * Nx; x1++)
                    for (int y1 = -2 * Ny; y1 < 2 * Ny; y1++)//开始遍历4*Nx，4*Ny之间的所有受该控制点平移影响的点（x,y）
                    {
                        int x = (int)Pic1CorNewInt[I, 0] + x1;
                        int y = (int)Pic1CorNewInt[I, 1] + y1;

                        int i = (int)((x - dx0) / Nx) - 1;//将默认从（0,0）开始的控制点方格平移为从（2,3）开始
                        int j = (int)((y - dy0) / Ny) - 1;//计算该受影响的点落在了被控制点分割出的哪个tile内

                        double u = (double)(x - dx0) / Nx - (int)((x - dx0) / Nx);//计算该受影响的点在所处tile内的offset
                        double v = (double)(y - dy0) / Ny - (int)((y - dy0) / Ny);

                        for (int l = 0; l <= 3; l++)
                            for (int m = 0; m <= 3; m++)
                                if ((l + i) == IndexX && (j + m) == IndexY)//对所有遍历的点而言，只有一个控制点的位移不为0，需要计算
                                {
                                    double weight = G(l, u) * G(m, v);//想要优化可以存一张表
                                    Tx = x - weight * dx;
                                    Ty = y - weight * dy;
                                }

                        if (x < 0 || y < 0 || x >= picWidth2 - 1 || y >= picHeight2 - 1)//目标点超出范围了继续下一次循环
                            continue;

                        else if (Tx < 0 || Ty < 0 || Tx >= picWidth2 - 1 || Ty >= picHeight2 - 1)
                            NewPic.SetPixel(x, y, Color.FromArgb(0, 0, 0));//越界返回黑色

                        else
                        {
                            if (nearest.Checked)
                            {
                                NewPic.SetPixel(x, y, Nearest(Tx, Ty));
                            }
                            else if (bilinear.Checked)
                            {
                                NewPic.SetPixel(x, y, Bilinear(Tx, Ty));
                            }
                            else if (bicubic.Checked)
                            {
                                NewPic.SetPixel(x, y, Bicubic(Tx, Ty));
                            }
                        }
                    }
            }
        }

        public class Matrix//利用二维数组构造矩阵类
        {
            public double[,] my_data;
            public Matrix(int row, int col)//构造矩阵
            {
                my_data = new double[row, col];
            }

            public Matrix(Matrix m)//复制构造函数
            {
                int row = m.Row;
                int col = m.Col;
                my_data = new double[row, col];
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                        my_data[i, j] = m[i, j];
            }

            public void show()//打印显示矩阵用于调试
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                        Console.Write("{0} ", my_data[i, j]);
                    Console.Write("\r\n");
                }
            }

            public void SetValue(double d)//设置元素值
            {
                for (int i = 0; i < my_data.GetLength(0); i++)
                    for (int j = 0; j < my_data.GetLength(1); j++)
                        my_data[i, j] = d;
            }
            
            public int Row// 获取行数
            {
                get
                {
                    return my_data.GetLength(0);
                }
            }
           
            public int Col //获取列数
            {
                get
                {
                    return my_data.GetLength(1);
                }
            }

            public double this[int row, int col]//存取数据成员
            {
                get
                {
                    return my_data[row, col];
                }
                set
                {
                    my_data[row, col] = value;
                }
            }

            public Matrix Transpose()//转置
            {
                Matrix  T = new Matrix(my_data.GetLength(1), my_data.GetLength(0));
                for (int i = 0; i < my_data.GetLength(0); i++)
                    for (int j = 0; j < my_data.GetLength(1); j++)
                    {
                        T[j, i] = my_data[i, j];
                    }
                return T;
            }

            public static Matrix operator +(Matrix L, Matrix R)//矩阵加
            {
                if ((L.Row != R.Row)|| (L.Col != R.Col)) 
                {
                    System.Exception e = new Exception("矩阵不可相加");
                    throw e;
                }
                int row = L.Row;
                int col = L.Col;
                Matrix ret = new Matrix(row, col);
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                    {
                        double d = L[i, j] + R[i, j];
                        ret[i, j] = d;
                    }
                return ret;
            }
           
            public static Matrix operator *(Matrix L, Matrix R) //矩阵乘
            {
                if (L.Col != R.Row)
                {
                    System.Exception e = new Exception("矩阵不可相乘");
                    throw e;
                }
                Matrix ret = new Matrix(L.Row, R.Col);
                double temp;
                for (int i = 0; i < L.Row; i++)
                {
                    for (int j = 0; j < R.Col; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < L.Col; k++)
                        {
                            temp += L[i, k] * R[k, j];
                        }
                        ret[i, j] = temp;
                    }
                }
                return ret;
            }

            public Matrix Exchange(int i, int j) //矩阵行交换
            {
                double temp;
                for (int k = 0; k < Col; k++)
                {
                    temp = my_data[i, k];
                    my_data[i, k] = my_data[j, k];
                    my_data[j, k] = temp;
                }
                return this;
            }

            Matrix Multiple(int i, double a)//矩阵第i行倍乘a
            {
                for (int j = 0; j < Col; j++)
                {
                    my_data[i, j] *= a;
                }
                return this;
            }

            Matrix MultipleAdd(int i, int j, double a) //矩阵第j行倍乘a加到第i行
            {
                for (int k = 0; k < Col; k++)
                {
                    my_data[i, k] += my_data[j, k] * a;
                }
                return this;
            }

            int Max(int row) //找子矩阵列主元素
            {
                int max = row;
                for (int i = row + 1; i < Row; i++)
                {
                    if (my_data[i, row] > my_data[max, row])
                        max = i;
                }
                return max;
            }

            public Matrix Inverse()//矩阵求逆
            {
                if (Row!= Col)    
                {
                    System.Exception e = new Exception("矩阵不为方阵，不可求逆");
                    throw e;
                }
                Matrix Temp = new Matrix(this);
                Matrix Inv = new Matrix(Row, Col); 
                Inv.SetValue(0);
                for (int i = 0; i < Row; i++)
                {
                    Inv[i, i] = 1;
                }

                int maxIndex;
                double a;

                for (int i = 0; i < Row; i++)//变为上三角矩阵
                {
                    maxIndex = Temp.Max(i);

                    if (Temp.my_data[maxIndex, i] == 0)
                    {
                        System.Exception e = new Exception("矩阵的行列式为0,不可求逆");
                        throw e;
                    }

                    if (maxIndex != i)//将列主元素移至子矩阵的第一行
                    {
                        Temp.Exchange(i, maxIndex);
                        Inv.Exchange(i, maxIndex);
                    }

                    Inv.Multiple(i, 1 / Temp[i, i]);
                    Temp.Multiple(i, 1 / Temp[i, i]);

                    for (int j = i + 1; j < Row; j++)//对子矩阵的第一列进行消元
                    {
                        a = -Temp[j, i] / Temp[i, i];
                        Temp.MultipleAdd(j, i, a);
                        Inv.MultipleAdd(j, i, a);
                    }
                }

                for (int i = Row - 1; i > 0; i--)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        a = -Temp[j, i] / Temp[i, i];
                        Temp.MultipleAdd(j, i, a);
                        Inv.MultipleAdd(j, i, a);
                    }
                }
                return Inv;
            }
        }

        private void SelectButton1_Click(object sender, EventArgs e)//更换图片1
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "Image Files(*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|Text Files(*.txt)|*.txt";
            if (Dialog1.ShowDialog() == DialogResult.OK)
            {
                OriginalPic1 = new Bitmap(Dialog1.FileName);
                picHeight1 = OriginalPic1.Height;
                picWidth1 = OriginalPic1.Width;
                string FullName1 = Dialog1.FileName;
                string[] temp = FullName1.Split('.');
                string TextName = temp[0]+ ".txt";

                try//读取人脸关键点坐标
                {
                    using (StreamReader sr = new StreamReader(TextName)) // 读取图片1的特征点坐标
                    {
                        string line;
                        int i = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Replace('\n', ' ');
                            string[] temp1 = line.Split(' ');
                            double x = Convert.ToDouble(temp1[0]);
                            double y = Convert.ToDouble(temp1[1]);
                            Pic1Cor[i, 0] = x;
                            Pic1Cor[i, 1] = y;
                            //Console.WriteLine("第{0}个点 x:{1} y:{2}", i, Pic1Cor[i, 0], Pic1Cor[i, 1]);
                            i++;
                        }
                        Console.WriteLine(i);
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("该图片还未进行人脸检测,\n请先运行人脸检测程序对该图片进行处理!");// 向用户显示出错消息
                    return;
                }
                this.Picture1.Image = new Bitmap(OriginalPic1, 250, 250);
            }
        }
        private void SelectButton2_Click(object sender, EventArgs e)//更换图片2
        {
            OpenFileDialog Dialog2 = new OpenFileDialog();
            Dialog2.Filter = "Image Files(*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|Text Files(*.txt)|*.txt";
            if (Dialog2.ShowDialog() == DialogResult.OK)
            {
                OriginalPic2 = new Bitmap(Dialog2.FileName);
                picHeight2 = OriginalPic2.Height;
                picWidth2 = OriginalPic2.Width;

                string FullName2 = Dialog2.FileName;
                string[] temp = FullName2.Split('.');
                string TextName = temp[0] + ".txt";

                try//读取人脸关键点坐标
                {
                    using (StreamReader sr = new StreamReader(TextName)) // 读取图片1的特征点坐标
                    {
                        string line;
                        int i = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Replace('\n', ' ');
                            string[] temp1 = line.Split(' ');
                            double x = Convert.ToDouble(temp1[0]);
                            double y = Convert.ToDouble(temp1[1]);
                            Pic2Cor[i, 0] = x;
                            Pic2Cor[i, 1] = y;
                            //Console.WriteLine("第{0}个点 x:{1} y:{2}", i, Pic1Cor[i, 0], Pic1Cor[i, 1]);
                            i++;
                        }
                        Console.WriteLine(i);
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("该图片还未进行人脸检测,\n请先运行人脸检测程序对该图片进行处理");// 向用户显示出错消息
                    return;
                }
                this.Picture2.Image = new Bitmap(OriginalPic2, 250, 250);
            }
        }
        private void Picture1_Click(object sender, EventArgs e)//查看图片1原图
        {
            ShowForm Pic1 = new ShowForm(new Bitmap(OriginalPic1));
            Pic1.ShowDialog();
        }
        private void Picture2_Click(object sender, EventArgs e)//查看图片2原图
        {
            ShowForm Pic2 = new ShowForm(new Bitmap(OriginalPic2));
            Pic2.ShowDialog();
        }
        private void Picture3_Click(object sender, EventArgs e)//查看新生成图片原图
        {
            ShowForm Pic3 = new ShowForm(new Bitmap(NewPic));
            Pic3.ShowDialog();
        }
        private void Process_Click(object sender, EventArgs e)//开始变换
        {
            ResPic = new Bitmap(OriginalPic2);
            if (!BSpline.Checked && !TPS.Checked)
            {
                MessageBox.Show("您还没有选择变形方式");
                return;
            }
            if (!nearest.Checked && !bilinear.Checked&&!bicubic.Checked)
            {
                MessageBox.Show("您还没有选择插值方式");
                return;
            }
            if(TPS.Checked)
            {
                NewPic = new Bitmap(OriginalPic2);
                this.Picture3.Image = new Bitmap(NewPic, 250, 250);
                Console.WriteLine("开始TPS变形");
                MatchPositive();
                Matrix M = TPSparamNegativeMatch();
                var dateTime1 = DateTime.Now;
                TPSchangeNegativeMatch(M);
                var dateTime2 = DateTime.Now;
                Console.WriteLine("Time consuming:{0}",dateTime2-dateTime1);
                this.Picture3.Image = new Bitmap(NewPic, 250, 250);
                return;
            }
            if (BSpline.Checked)
            {
                NewPic = new Bitmap(OriginalPic2);
                this.Picture3.Image = new Bitmap(NewPic, 250, 250);
                Console.WriteLine("开始B样条变形");
                MatchPositiveInt();
                var dateTime1 = DateTime.Now;
                SPlinechange2();
                var dateTime2 = DateTime.Now;
                Console.WriteLine("Time consuming:{0}", dateTime2 - dateTime1);
                this.Picture3.Image = new Bitmap(NewPic, 250, 250);
                return;
            }
        }
        private void Retract_Click(object sender, EventArgs e)//还原图片
        {
            //NewPic = new Bitmap(HMW1.Properties.Resources._9);
            this.Picture3.Image = new Bitmap(ResPic, 250, 250);
        }
        private void Save_Click(object sender, EventArgs e)//保存图片
        {
            try
            {
                Bitmap SavePic = new Bitmap(NewPic);
                SaveFileDialog Dialog4 = new SaveFileDialog();
                Dialog4.Title = "Save";
                Dialog4.Filter = "jpg files(*.jpg)|*.jpg";
                if (Dialog4.ShowDialog() == DialogResult.OK)
                {
                    string FullName = Dialog4.FileName;
                    SavePic.Save(FullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("图片仍在变形中，请稍等.");
                return;
            }
        }
    }
}
