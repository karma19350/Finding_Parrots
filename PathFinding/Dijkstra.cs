using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    class Dijkstra
    {
        private readonly Laby Laby;
        private readonly List<Node> Closed;
        private readonly List<Node> Open;
        private readonly Cor StartPoint;
        private readonly Cor EndPoint;
        private List<Cor> Path;
        private int Number;
        private Node CurrentNode;
        private int Operations;

        
        bool IsFound = false;
        bool NotFound = false;

        public Dijkstra(Laby laby)
        {
            Laby = laby;
            Closed = new List<Node>();
            Open = new List<Node>();
            Open.Clear();
            StartPoint = Laby.GetStart().CellCor;
            EndPoint = Laby.GetEnd().CellCor;
            Path = new List<Cor>();
            Number = 1;
            Operations = 0; 
            Open.Add(new Node(Number, 0, StartPoint, 0, 0));
            Operations++;
            Number++;
            Closed.Clear();
            Path.Clear();
        }

        public SearchResult GetPath()
        {
            if (Open.Count > 0)
            {
                CurrentNode = Open.OrderBy(node => node.G).First();
                Open.Remove(CurrentNode);
                if (AlreadyVisted(CurrentNode.State)) return GetResult();
                Operations++;
                Closed.Add(CurrentNode);
                Laby.SetCell(CurrentNode.State, Type.Closed);

                if ((CurrentNode.State.X == EndPoint.X) && (CurrentNode.State.Y == EndPoint.Y))
                {
                    IsFound = true;
                    Node step = CurrentNode;
                    while (!step.State.Equals(StartPoint))
                    {
                        Path.Add(step.State);
                        foreach (var node in Closed)
                            if (node.Number == step.Parent)
                                step = node;
                    }
                    Path.Add(StartPoint);
                    Path.Reverse();
                    return GetResult();
                }

                List<Cor> neighbors = GetNeighbor(CurrentNode);//点的列表
                foreach (Cor neighbor in neighbors)
                {
                    if (AlreadyVisted(neighbor)) continue;
                    if (!Open.Exists(x => x.State.Equals(neighbor)))//Open表中添加新节点
                    {
                        Open.Add(new Node(Number++, CurrentNode.Number, neighbor, CurrentNode.G + Laby.GetCell(neighbor).CellWeight, 0));
                        Operations++;
                        Laby.SetCell(neighbor, Type.Open);
                    }
                    else//更新Open表中已有节点代价
                    {
                        Node n = Open.First(x => x.State.Equals(neighbor));
                        if (n.G > CurrentNode.G + Laby.GetCell(neighbor).CellWeight)
                        {
                            n.G = CurrentNode.G + Laby.GetCell(neighbor).CellWeight;
                            n.Parent = CurrentNode.Number;
                            Operations++;
                        }
                    }
                    Laby.SetCell(neighbor, Type.Open);
                }
            }
            else 
            {
                NotFound = true;
                IsFound = false;
                Console.WriteLine("所寻找路径不存在");
            }
            return GetResult();
        }

        private bool AlreadyVisted(Cor cor)//判断节点是否访问过，不能为closed,open表中的点或起点
        {
            if (Laby.GetCell(cor).CellType == Type.Closed)
                return true;
            else
                return false;
        }

        public SearchResult GetResult()
        {
            return new SearchResult
            {
                Path = Path?.ToArray(),//寻找不到路径时允许路径为空
                PathCost = GetPathCost(),
                PathLength = GetPathLength(),
                OpenListSize = Open.Count,
                ClosedListSize = Closed.Count,
                Operations = Operations,
                MethodName = "Dijkstra",
                PathFound = IsFound,
                PathNotFound = NotFound
            };
        }


        private List<Cor> GetNeighbor(Node current)
        {
            List<Cor> Neighbor = new List<Cor>();
            List<Cell> Temp = new List<Cell> {//右下左上循环
                Laby.GetCell(current.State.X + 1, current.State.Y),
                Laby.GetCell(current.State.X , current.State.Y + 1),
                Laby.GetCell(current.State.X - 1, current.State.Y),
                Laby.GetCell(current.State.X, current.State.Y - 1)
            };
            foreach (var cell in Temp)
            {
                if (cell.CellType == Type.Invalid || cell.CellType == Type.Barrier)
                    continue;
                Neighbor.Add(cell.CellCor);
            }
            return Neighbor;
        }

        private int GetPathCost()//计算路径代价
        {
            if (Path == null) return 0;
            int cost = 0;
            foreach (var step in Path)
                cost = cost + Laby.GetCell(step.X, step.Y).CellWeight;
            return cost;
        }
        private int GetPathLength()//计算路径长度
        {
            return Path.Count;
        }
    }
}
