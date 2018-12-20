using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PathFinding
{
    class Draw
    {
        private readonly PictureBox myPic;
        public Laby Laby { get; set; }

        private int widthNum= 8;
        private int heightNum = 8;
        private int sideNum=0;

        private int cellWidth;
        private int cellHeight;
        private int cellLength;

        private int StartX;
        private int StartY;

        public Draw(PictureBox pictureBox)
        {
            myPic = pictureBox;
            Laby = new Laby(widthNum, heightNum);
            Laby.SetRandom();
        }
        public void DrawLaby()
        {
            cellWidth = myPic.Width / widthNum;
            cellHeight = myPic.Height / heightNum;
            if (widthNum > heightNum)
                {
                sideNum =  widthNum ;//以长宽中分段较多的作为依据,保证显示格点为方形
                cellLength = cellWidth;
                StartX = 0;
                StartY = (myPic.Height - cellLength * heightNum) / 2 - 1;
            }
           else
            {
                sideNum = heightNum;//以长宽中分段较多的作为依据
                cellLength = cellHeight;
                StartY = 0;
                StartX = (myPic.Width - cellLength * widthNum) / 2 - 1;
            }


            var image = new Bitmap(myPic.Width, myPic.Height);

            using (var g = Graphics.FromImage(image))
            {
                var background = new Rectangle(0, 0, image.Width, image.Height);
                g.FillRectangle(new SolidBrush(Color.SeaShell), background);

                for (int x = 0; x < widthNum; x++)
                {
                    for (int y = 0; y < heightNum; y++)
                    {
                        var cell = Laby.GetCell(x, y);
                        switch (cell.CellType)
                        {
                            case Type.Empty:
                                switch (cell.CellWeight)
                                {
                                    case 1: g.FillRectangle(Brushes.MistyRose, GetRectangle(x, y)); break;
                                    case 2: g.FillRectangle(Brushes.Pink, GetRectangle(x, y)); break;
                                    case 3: g.FillRectangle(Brushes.Lavender, GetRectangle(x, y)); break;
                                    //case 1: g.FillRectangle(Brushes.LavenderBlush, GetRectangle(x, y)); break;
                                    //case 2: g.FillRectangle(Brushes.MistyRose, GetRectangle(x, y)); break;
                                    //case 3: g.FillRectangle(Brushes.Pink, GetRectangle(x, y)); break;
                                    default: g.FillRectangle(Brushes.SeaShell, GetRectangle(x, y)); break;//权重为0颜色与背景一致
                                }
                                break;
                            case Type.Barrier:
                                g.FillRectangle(Brushes.DarkGray, GetRectangle(x, y));
                                break;
                            case Type.Path:
                                g.FillRectangle(Brushes.PaleVioletRed, GetRectangle(x, y));
                                break;
                            case Type.Open:
                            //case Type.Open1:
                            //case Type.Open2:
                                g.FillRectangle(Brushes.LightBlue, GetRectangle(x, y));
                                break;
                            case Type.Closed:
                            case Type.Closed1:
                            case Type.Closed2:
                                g.FillRectangle(Brushes.LightCyan, GetRectangle(x, y));
                                break;
                            case Type.Start:
                                g.DrawImage(Properties.Resources._1, GetRectangle(x, y));
                                break;
                            case Type.End:
                                g.DrawImage(Properties.Resources._2, GetRectangle(x, y));
                                break;
                            default:
                               // g.FillRectangle(Brushes.LightCyan, GetRectangle(x, y));
                                break;
                        }
                    }
                }
                myPic.Image = image;
            }
        }
        private Rectangle GetRectangle(int x, int y)
        {
            return new Rectangle(StartX + x * cellLength , StartY + y * cellLength, cellLength, cellLength);
        }
        private PointF GetPoint(int x, int y)
        {
            return new PointF(StartX + x * cellLength, StartY + y * cellLength);
        }
        public void Change(Laby laby)
        {

            if (laby.Width == widthNum && laby.Height == heightNum)
            {
                Laby.SetStartPoint(laby.GetStart().CellCor);
                Laby.SetEndPoint(laby.GetEnd().CellCor);
                for (int x = 0; x < laby.Width; x++)
                    for (int y = 0; y < laby.Height; y++)
                        Laby.SetCell(x, y, laby.GetCell(x, y));
            }
            else
            {
                widthNum = laby.Width;
                heightNum = laby.Height;
                Laby = new Laby(laby);

                Laby = new Laby(widthNum, heightNum);
                Laby.SetStartPoint(laby.GetStart().CellCor);
                Laby.SetEndPoint(laby.GetEnd().CellCor);
                for (int x = 0; x < laby.Width; x++)
                    for (int y = 0; y < laby.Height; y++)
                        Laby.SetCell(x, y, laby.GetCell(x, y));
            }

        }

    }
}
