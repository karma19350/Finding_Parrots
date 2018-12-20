using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;

namespace PathFinding
{
    public partial class Form1 : MaterialForm
    {
        private Draw myDraw;
        const int tableHeight = 30;
        private bool [] IsChosen;
        private BreadthFirst breadthSearch;
        private DepthFirst depthSearch;
        private BestFirst bestSearch;
        private Dijkstra dijkstraSearch;
        private AStar astarSearch;
        private BiBreadthFirst bibreadthSearch;
        private SearchResult CurrentStatus;

        private Label[,] ShowList;
       
        int MethodNum = 0;
        int CurrentLine = 0;
        int CurrentMethod = 0;

        int minPathLength,minPathCost;
        string minLengthName="", minCostName="";

        Laby CurrentLaby;

        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;//设置主题颜色
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey300, Accent.DeepOrange100, TextShade.WHITE);

            refreshTimer.Enabled = false;
            myDraw = new Draw(labyPicture);
            myDraw.DrawLaby();

            CurrentLaby = new Laby(myDraw.Laby);
            MethodNum = 0;
            CurrentMethod = 0;
            CurrentLine = 0;

            materialTab.SelectedTab = setPage;//将游戏设置设为起始页
            initLabels();
            initTable();
            IsChosen = new bool[6]{false, false, false, false, false, false };//初始时默认所有方法均未选定
        }

        private void initLabels()//生成所有标签
        {
            ShowList = new Label[7, 5];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    ShowList[i, j] = new Label();
                    ShowList[i, j].Text = "";
                    ShowList[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    ShowList[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    ShowList[i, j].Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    ShowList[i, j].Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }
            //labelcost.Text = "";
            labelcost.Visible = false;
        }
        private void initTable()//生成表格
        {
            {
                showTable.Controls.Clear();
                showTable.RowCount = 1;
                showTable.ColumnCount = 5;
                showTable.Height = showTable.RowCount * tableHeight;

                int j = 0;
                TableLayoutColumnStyleCollection styles = this.showTable.ColumnStyles;//设置表格宽高
                foreach (ColumnStyle style in styles)
                {
                    if (j == 0)
                    {
                        style.SizeType = SizeType.Percent;
                        style.Width = 30;
                    }
                    else if (j == 4)
                    {
                        style.SizeType = SizeType.Percent;
                        style.Width = 25;
                    }
                    else
                    {
                        style.SizeType = SizeType.Percent;
                        style.Width = 15;
                    }
                    j++;
                }
                for (int i = 0; i < showTable.RowCount; i++)
                {
                    showTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, tableHeight));
                }
                showTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                showTable.BackColor = Color.SeaShell;
                ShowList[0, 0].Text = "搜索算法";
                showTable.Controls.Add(ShowList[0, 0], 0, 0);

                ShowList[0, 1].Text = "Open表";
                showTable.Controls.Add(ShowList[0, 1], 1, 0);

                ShowList[0, 2].Text = "Close表";
                showTable.Controls.Add(ShowList[0, 2], 2, 0);

                ShowList[0, 3].Text = "操作数";
                showTable.Controls.Add(ShowList[0, 3], 3, 0);

                ShowList[0, 4].Text = "路径长度/代价";
                showTable.Controls.Add(ShowList[0, 4], 4, 0);
            }
        }

        private void labyPicture_Click(object sender, EventArgs e)//设置起止点与障碍
        {
            if (materialTab.SelectedTab == showPage)
                return;
            MouseEventArgs mouseLoc = (MouseEventArgs)e;

            int cellWidth = labyPicture.Width / CurrentLaby.Width;
            int cellHeight = labyPicture.Height / CurrentLaby.Height;
            int sideNum, cellLength, StartX, StartY;

            if (CurrentLaby.Width > CurrentLaby.Height)
            {
                sideNum = CurrentLaby.Width;//以长宽中分段较多的作为依据,保证显示格点为方形
                cellLength = cellWidth;
                StartX = 0;
                StartY = (labyPicture.Height - cellLength * CurrentLaby.Height) / 2 - 1;
            }
            else
            {
                sideNum = CurrentLaby.Height;//以长宽中分段较多的作为依据
                cellLength = cellHeight;
                StartY = 0;
                StartX = (labyPicture.Width - cellLength * CurrentLaby.Width) / 2 - 1;
            }
            int x = (mouseLoc.X - StartX) / cellLength;
            int y = (mouseLoc.Y - StartY) / cellLength;
            if (mouseLoc.X < StartX || mouseLoc.Y < StartY || x >= CurrentLaby.Width || y >= CurrentLaby.Height)
                return;
            else
            {
                if (setBarrierButton.Checked)
                {
                    Cell TempCell = CurrentLaby.GetCell(x, y);
                    if (TempCell.CellType == Type.Empty)
                    {
                        CurrentLaby.SetCell(x, y, Type.Barrier);
                        myDraw.Change(CurrentLaby);
                        myDraw.DrawLaby();
                    }
                    else if (TempCell.CellType == Type.Barrier)
                    {
                        CurrentLaby.SetCell(x, y, Type.Empty);
                        Random rand = new Random();
                        int weight = rand.Next(1, 4);

                        Cell cell = new Cell
                        {
                            CellCor = new Cor(x, y),
                            CellType = Type.Empty,
                            CellWeight = weight
                        };
                        CurrentLaby.SetCell(x, y, cell);
                        myDraw.Change(CurrentLaby);
                        myDraw.DrawLaby();
                    }
                    else return;//不能把起止点改为障碍
                }
                if (setStartButton.Checked)
                {
                    Cell TempCell = CurrentLaby.GetCell(x, y);
                    if (TempCell.CellType == Type.End)//不能把起止点设为重合
                        return;
                    CurrentLaby.SetStartPoint(new Cor(x, y));
                    myDraw.Change(CurrentLaby);
                    myDraw.DrawLaby();
                }
                if (setEndButton.Checked)
                {
                    Cell TempCell = CurrentLaby.GetCell(x, y);
                    if (TempCell.CellType == Type.Start)
                        return;
                    CurrentLaby.SetEndPoint(new Cor(x, y));
                    myDraw.Change(CurrentLaby);
                    myDraw.DrawLaby();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)//更改迷宫尺寸
        {
            int width = 0, height = 0;
            try
            {
                width = Convert.ToInt32(widthText.Text);
                height = Convert.ToInt32(heightText.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入大小介于5~20之间的数字.");
                return;
            }
            if (width < 5 || height < 5 || width > 20 || height > 20)
            {
                MessageBox.Show("建议设置迷宫宽、高均介于5~20之间.", "请重设");
                return;
            }
            if (width != CurrentLaby.Width || height != CurrentLaby.Height)
            {
                var r = MessageBox.Show("确认更改迷宫尺寸？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Cancel)
                    return;
                CurrentLaby = new Laby(width, height);
                CurrentLaby.SetRandom();
                myDraw.Change(CurrentLaby);
                myDraw.DrawLaby();
            }
            else return;
        }

        private void ResetButton_Click(object sender, EventArgs e)//还原地图显示
        {
            myDraw.Change(CurrentLaby);
            myDraw.DrawLaby();
        }

        private void generateButton_Click(object sender, EventArgs e)//随机生成地图
        {
            CurrentLaby.SetRandom();
            myDraw.Change(CurrentLaby);
            myDraw.DrawLaby();
        }

        private void startButton_Click_1(object sender, EventArgs e)//开始搜索
        {
            myDraw.Change(CurrentLaby);
            myDraw.DrawLaby();
            MethodNum = 0;
            IsChosen = new bool[6] { false, false, false, false, false, false };

            if (breadthBox.Checked)//使用宽度优先搜索
            {
                breadthSearch = new BreadthFirst(myDraw.Laby);
                MethodNum++;
                IsChosen[0] = true;
            }

            if (depthBox.Checked)//使用深度优先搜索
            {
                depthSearch = new DepthFirst(myDraw.Laby);
                MethodNum++;
                IsChosen[1] = true;
            }
            if (bestBox.Checked)//使用最佳优先搜索
            {
                bestSearch = new BestFirst(myDraw.Laby);
                MethodNum++;
                IsChosen[2] = true;
            }

            if (dijkstraBox.Checked)//使用一致代价搜索
            {
                dijkstraSearch = new Dijkstra(myDraw.Laby);
                MethodNum++;
                IsChosen[3] = true;
            }

            if (AstarBox.Checked)//使用A*搜索
            {
                astarSearch = new AStar(myDraw.Laby);
                MethodNum++;
                IsChosen[4] = true;
            }

            if (bibreadthBox.Checked)//使用双向宽度优先搜索
            {
                bibreadthSearch = new BiBreadthFirst(myDraw.Laby);
                MethodNum++;
                IsChosen[5] = true;
            }

            if (MethodNum == 0)
            {
                MessageBox.Show("请选择搜索算法以开始游戏!","未选择");
                return;
            }
            labyPicture.Enabled = false;
            generateButton.Enabled = false;
            startButton.Enabled = false;
            SaveButton.Enabled = false;
            materialTab.SelectedTab = showPage;
            materialTabSelector.Enabled = false;

            minPathLength = int.MaxValue;
            minPathCost = int.MaxValue;
            
            initLabels();
            initTable();
            CurrentLine = 0;
            CurrentMethod = 0;
            addLine();
            refreshTimer.Enabled = true;
            labelcost.Visible = false;
            ResetButton.Enabled = false;
        }

        private void ShowResult(SearchResult result)
        {
            ShowList[CurrentLine, 0].Text = result.MethodName;//搜索算法名称
            ShowList[CurrentLine, 1].Text = result.OpenListSize.ToString();//open表节点个数
            ShowList[CurrentLine, 2].Text = result.ClosedListSize.ToString();//close表节点个数     
            ShowList[CurrentLine, 3].Text = result.Operations.ToString();//操作数
            if (result.PathNotFound)
                ShowList[CurrentLine, 4].Text = "Do Not Exist.";
            else
                ShowList[CurrentLine, 4].Text = result.PathLength.ToString() + "/" + result.PathCost.ToString();//路径长度/代价
        }

        private void UpdateMinimum(SearchResult result)//更新最短路径与最小代价
        {
            int PathCost =result.PathCost;
            int PathLength = result.PathLength;
            if (result.PathNotFound)
            {
                labelcost.Text = "";
                labelcost.Text = "最小路径长度：Infinity\n";
                labelcost.Text = labelcost.Text + "最小路径代价：Infinity\n";
                minPathCost = int.MaxValue;
                minPathLength = int.MaxValue;
                return;
            }
            if (PathCost < minPathCost)
            {
                minPathCost = PathCost;
                minCostName = result.MethodName;
            }
            else if (PathCost == minPathCost)
            {
                minCostName = minCostName + "，" + result.MethodName;
            }
            if (PathLength < minPathLength)
            {
                minPathLength = PathLength;
                minLengthName = result.MethodName ;
            }
            else if (PathLength == minPathLength)
            {
                minLengthName = minLengthName + "，" + result.MethodName;
            }
            labelcost.Text = "";
            labelcost.Text = "最小路径长度：" + minPathLength.ToString() + " " + minLengthName + "\n";
            labelcost.Text = labelcost.Text + "最小路径代价：" + minPathCost.ToString() + " " + minCostName + "\n";
        }

        private void materialTabSelector_Click(object sender, EventArgs e)
        {
            if (materialTab.SelectedTab == showPage)
            {
                myDraw.Change(CurrentLaby);
                myDraw.DrawLaby();
            }
        }

        private void addLine()
        {
            showTable.RowCount++;
            showTable.Height = showTable.RowCount * tableHeight;
            showTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, tableHeight));
            showTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            CurrentLine = showTable.RowCount - 1;
            this.Invoke(new EventHandler(delegate
            {
                showTable.Controls.Add(ShowList[CurrentLine, 0], 0, CurrentLine);//将要添加的控件置于指定单元格
                for (int j = 1; j < 5; j++)
                    showTable.Controls.Add(ShowList[CurrentLine, j], j, CurrentLine);
            }
            ));
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;//间隔10后时钟触发停下，处理状况
            labelcost.Visible = false;
            if (MethodNum > 0)
            {
                while (IsChosen[CurrentMethod] == false) //对应初始情况，找到勾选的第一个算法
                    CurrentMethod++;
                switch (CurrentMethod)
                {
                    case 0: CurrentStatus = breadthSearch.GetPath(); break;
                    case 1: CurrentStatus = depthSearch.GetPath(); break;
                    case 2: CurrentStatus = bestSearch.GetPath(); break;
                    case 3: CurrentStatus = dijkstraSearch.GetPath(); break;
                    case 4: CurrentStatus = astarSearch.GetPath(); break;
                    case 5: CurrentStatus = bibreadthSearch.GetPath(); break;
                    default: Console.WriteLine("按算法搜索时出现错误"); break;
                }
                ShowResult(CurrentStatus); 

                if (CurrentStatus.PathFound)//一种搜索算法搜索结束,找到路径
                {
                    for (int i = 1; i < CurrentStatus.Path.Length - 1; i++)//不改变起终点
                    {
                        Cor step = CurrentStatus.Path[i];
                        myDraw.Laby.SetCell(step, Type.Path);
                        myDraw.DrawLaby();
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(20);
                    }
                    MethodNum--;
                    
                    UpdateMinimum(CurrentStatus);
                    Console.WriteLine("MiniCost:{0},MiniLength:{1}", minPathCost, minPathLength);

                    System.Threading.Thread.Sleep(1200);
                    CurrentMethod++;
                    if (MethodNum > 0)
                    {
                        addLine();
                        myDraw.Change(CurrentLaby);
                    }
                        myDraw.DrawLaby();
                }
                else if (CurrentStatus.PathNotFound)
                {
                    MethodNum--;
                    UpdateMinimum(CurrentStatus);
                    ShowResult(CurrentStatus);
                    System.Threading.Thread.Sleep(1200);
                    CurrentMethod++;
                    if (MethodNum > 0)
                    {
                        addLine();
                        myDraw.Change(CurrentLaby);
                    }
                        myDraw.DrawLaby();
                }
                else//还在搜索过程中
                {
                    System.Threading.Thread.Sleep(15);
                    myDraw.DrawLaby();
                }
                refreshTimer.Enabled = true;
            }
            else//对应初始情况与所有算法都搜索结束
            {
                refreshTimer.Enabled = false;
                labelcost.Visible = true;
                labyPicture.Enabled = true;
                generateButton.Enabled = true;
                startButton.Enabled = true;
                SaveButton.Enabled = true;
                labelcost.Visible = true;
                materialTabSelector.Enabled = true;
                ResetButton.Enabled = true;
                minPathLength = int.MaxValue;
                minPathCost = int.MaxValue;
            }
        }

    
    }
}
