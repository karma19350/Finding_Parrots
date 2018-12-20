using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;

namespace PathFinding
{
        public enum Type//格点类型
        {
            Invalid = -1,
            Empty = 0,
            Barrier = 1,
            Start = 2,
            End = 3,
            Path = 4,
            Open = 5,
            Closed =6,
            Closed1 = 7,
            Closed2 = 8,
            //Open1 = 9,
           // Open2 = 10
    }
        public class Cor//坐标
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Cor(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        public class Cell//格点类
        {
            public Cor CellCor { get; set; }
            public Type CellType { get; set; }
            public int CellWeight { get; set; }
            public Cell(Cell c)
            {
                CellCor = new Cor(c.CellCor.X, c.CellCor.Y);
                CellType = c.CellType;
                CellWeight = c.CellWeight;
            }
            public Cell() { }
        }
        public class Laby//迷宫地图类
    {
        private readonly Cell[,] myLaby;//以二维数组储存迷宫
        public int Height, Width;//定义宽高
        Cor StartPoint, EndPoint;//起始点与终点

        public Laby(int width, int height)//构造函数
        {
            Width = width;
            Height = height;
            myLaby = new Cell[width, height];

            StartPoint = new Cor(0, 0);
            EndPoint = new Cor(Width - 1, Height - 1);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    myLaby[x, y] = new Cell
                    {
                        CellCor = new Cor(x, y),
                        CellType = Type.Empty,
                        CellWeight = 0
                    };
                }
            }
            SetStartEnd();
        }

        public Laby(Laby laby)//复制构造函数
        {
            this.Height = laby.Height;
            this.Width = laby.Width;

            myLaby = new Cell[Width, Height];
            for (int x = 0; x < laby.Width; x++)
                for (int y = 0; y < laby.Height; y++)
                    myLaby[x, y] = new Cell(laby.myLaby[x, y]);

            StartPoint = new Cor(laby.StartPoint.X, laby.StartPoint.Y);
            EndPoint = new Cor(laby.EndPoint.X, laby.EndPoint.Y);
        }

        private void SetStartEnd()//生成起点与终点
        {
            myLaby[StartPoint.X, StartPoint.Y] = new Cell
            {
                CellCor = new Cor(StartPoint.X, StartPoint.Y),
                CellType = Type.Start,
                CellWeight = 0
            };
            myLaby[EndPoint.X, EndPoint.Y] = new Cell
            {
                CellCor = new Cor(EndPoint.X, EndPoint.Y),
                CellType = Type.End,
                CellWeight = 0
            };
        }

        public void SetCell(int x, int y, Type type)//设置格点信息1
        {
            if (x > Width - 1 || x < 0 || y > Height - 1 || y < 0)
                myLaby[x, y] = new Cell
                {
                    CellCor = new Cor(-1, -1),
                    CellType = Type.Invalid,
                    CellWeight = 0
                };
            else
            {
                int tempCellWeight = myLaby[x, y].CellWeight;
                myLaby[x, y] = new Cell
                {
                    CellCor = new Cor(x, y),
                    CellType = type,
                    CellWeight = tempCellWeight
                };
            }
            SetStartEnd();
        }

        public void SetCell(Cor cor, Type type)//设置格点信息2
        {
            SetCell(cor.X, cor.Y, type);
        }

        public void SetCell(int x, int y, Cell cell)//设置格点信息3
        {
            myLaby[x, y] = new Cell
            {
                CellCor = new Cor(x, y),
                CellType = cell.CellType,
                CellWeight = cell.CellWeight
            };
            SetStartEnd();
        }

        public void SetCell(Cor cor, Cell cell)//设置格点信息4
        {
            SetCell(cor.X, cor.Y, cell);
        }

        public Cell GetCell(int x, int y)//获取格点信息1
        {
            if (x > Width - 1 || x < 0 || y > Height - 1 || y < 0)
                return new Cell
                { CellCor = new Cor(-1, -1),
                    CellType = Type.Invalid,
                    CellWeight = 0
                };
            return myLaby[x, y];
        }

        public Cell GetCell(Cor cor)//获取格点信息2
        {
            return GetCell(cor.X, cor.Y);
        }

        public Cell GetStart()//获取起点信息
        {
            return GetCell(StartPoint);
        }

        public Cell GetEnd()//获取终点信息
        {
            return GetCell(EndPoint);
        }

        public void SetStartPoint(Cor cor)//设置起点
        {
            Random rand = new Random();
            int weight = rand.Next(1, 4);
            //if (cor.Equals(EndPoint))
            //{
            //    Console.WriteLine("起止点不能重合");
            //    return;
            //}
            myLaby[StartPoint.X, StartPoint.Y] = new Cell
            {
                CellCor = new Cor(StartPoint.X, StartPoint.Y),
                CellType = Type.Empty,
                CellWeight = weight
            };
            StartPoint = new Cor(cor.X, cor.Y);
            myLaby[StartPoint.X, StartPoint.Y] = new Cell
            {
                CellCor = new Cor(StartPoint.X, StartPoint.Y),
                CellType = Type.Start,
                CellWeight = 0
            };
        }

        public void SetEndPoint(Cor cor)//设置起点
        {
            Random rand = new Random();
            int weight = rand.Next(1, 4);
            //if (cor.Equals(StartPoint))
            //    return;

            myLaby[EndPoint.X, EndPoint.Y] = new Cell
            {
                CellCor = new Cor(EndPoint.X, EndPoint.Y),
                CellType = Type.Empty,
                CellWeight = weight
            };
            EndPoint = new Cor(cor.X, cor.Y);
            myLaby[EndPoint.X, EndPoint.Y] = new Cell
            {
                CellCor = new Cor(EndPoint.X, EndPoint.Y),
                CellType = Type.End,
                CellWeight = 0
            };
        }

        public void SetRandom()//随机初始化权重与类型，约25%比例为障碍
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    myLaby[x, y].CellWeight = rand.Next(1, 4);
                    if (rand.Next(0, 4) >= 3)
                        myLaby[x, y].CellType = Type.Barrier;
                    else
                        myLaby[x, y].CellType = Type.Empty;
                }
            }
            SetStartEnd();
        }

        public int TypeCount(Type type)//统计类型数
        {
            int total = 0;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    if (myLaby[x, y].CellType == type)
                        total++;
                }
            return total;
        }
    }
}

