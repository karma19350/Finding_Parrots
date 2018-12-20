using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace PathFinding
{
    class BiBreadthFirst
    {
        private readonly Laby Laby;
        private readonly List<Node> Closed1;
        private readonly List<Node> Closed2;
        private readonly Cor StartPoint;
        private readonly Cor EndPoint;
        private List<Cor> Path;
        //private List<Cor> HalfPath;
        private int Number;
        private Node CurrentNode;
        private int Operations;

        private ConcurrentQueue<Node> NodeQueue1;//队列数据结构
        private ConcurrentQueue<Node> NodeQueue2;//队列数据结构
        bool IsFound = false;
        bool NotFound = false;

        public BiBreadthFirst(Laby laby)
        {
            Laby = laby;
            Closed1 = new List<Node>();
            Closed2 = new List<Node>();
            StartPoint = Laby.GetStart().CellCor;
            EndPoint = Laby.GetEnd().CellCor;
            Path = new List<Cor>();
            //HalfPath = new List<Cor>();
            Path.Clear();
            //HalfPath.Clear();
            Number = 1;
            Operations = 0;
            NodeQueue1 = new ConcurrentQueue<Node>();
            NodeQueue1.Enqueue(new Node(Number, 0, StartPoint, 0, 0));
            Number++;
            Operations++;
            NodeQueue2 = new ConcurrentQueue<Node>();
            NodeQueue2.Enqueue(new Node(Number, 0, EndPoint, 0, 0));
            Number++;
            Operations++;
            Closed1.Clear();
            Closed2.Clear();
        }

        public SearchResult GetPath()
        {
            if (NodeQueue1.Count > 0)
            {
                NodeQueue1.TryDequeue(out CurrentNode);
                if (AlreadyVisted1(CurrentNode.State)) return GetResult();
                Closed1.Add(CurrentNode);
                Operations++;

                if (Laby.GetCell(CurrentNode.State).CellType == Type.Closed2|| Laby.GetCell(CurrentNode.State).CellType == Type.End)
                {
                    IsFound = true;
                    Console.WriteLine("Find!1");
                    Node step = CurrentNode;
                    Console.WriteLine("CurrentNode.X:{0},CurrentNode.Y:{1}", CurrentNode.State.X, CurrentNode.State.Y);
                    while ((step.State.X!=StartPoint.X)||(step.State.Y != StartPoint.Y))
                    {
                        Path.Add(step.State);
                        foreach (var node in Closed1)
                            if (node.Number == step.Parent)
                                step = node;
                    }
                    Path.Add(StartPoint);
                    Path.Reverse();
                    Console.WriteLine("Path Length:{0}", Path.Count);
                    step = CurrentNode;
                    foreach (var node in Closed2)//在close2中找到相同状态的节点
                        if ((node.State.X == step.State.X)&& (node.State.Y == step.State.Y))
                            step = node;
                    Console.WriteLine("CurrentNode.X:{0},CurrentNode.Y:{1}", step.State.X, step.State.Y);
                    while ((step.State.X != EndPoint.X) || (step.State.Y != EndPoint.Y))
                    { 
                        foreach (var node in Closed2)
                            if (node.Number == step.Parent)
                                step = node;
                        Path.Add(step.State);//防止交叉点重复计数
                    }
                    //Path.Add(EndPoint);
                    Console.WriteLine("Path Length:{0}", Path.Count);
                    return GetResult();
                }
                Laby.SetCell(CurrentNode.State, Type.Closed1);
                List<Cor> neighbors = GetNeighbor(CurrentNode);//点的列表
                foreach (Cor neighbor in neighbors)
                {
                    if (AlreadyVisted1(neighbor)||AlreadyVisted2(neighbor)) continue;
                    Node NeighborNode = new Node(Number++, CurrentNode.Number, neighbor, 0, 0);
                    NodeQueue1.Enqueue(NeighborNode);
                    Operations++;
                    Laby.SetCell(neighbor, Type.Open);
                }
            }

            if (NodeQueue2.Count > 0)
            {
                NodeQueue2.TryDequeue(out CurrentNode);
                if (AlreadyVisted2(CurrentNode.State)) return GetResult();
                Closed2.Add(CurrentNode);
                Operations++;

                if (Laby.GetCell(CurrentNode.State).CellType == Type.Closed1|| Laby.GetCell(CurrentNode.State).CellType == Type.Start)
                {
                    IsFound = true;
                    Console.WriteLine("Find!2");
                    Node step = CurrentNode;
                    foreach (var node in Closed1)//在close1中找到相同状态的节点
                        if ((node.State.X == step.State.X) && (node.State.Y == step.State.Y))
                            step = node;
                    Console.WriteLine("CurrentNode.X:{0},CurrentNode.Y:{1}", CurrentNode.State.X, CurrentNode.State.Y);
                    while (!step.State.Equals(StartPoint))
                    {
                        foreach (var node in Closed1)
                            if (node.Number == step.Parent)
                                step = node;
                        Path.Add(step.State);
                    }
                    //Path.Add(StartPoint);
                    Path.Reverse();
                    Console.WriteLine("Path Length:{0}", Path.Count);
                    step = CurrentNode;
                    Console.WriteLine("CurrentNode.X:{0},CurrentNode.Y:{1}", CurrentNode.State.X, CurrentNode.State.Y);
                    while (!step.State.Equals(EndPoint))
                    {
                        Path.Add(step.State);
                        foreach (var node in Closed2)
                            if (node.Number == step.Parent)
                                step = node;
                    }
                    Path.Add(EndPoint);
                    Console.WriteLine("Path Length:{0}", Path.Count);
                    return GetResult();
                }
                Laby.SetCell(CurrentNode.State, Type.Closed2);
                List<Cor> neighbors = GetNeighbor(CurrentNode);//点的列表
                foreach (Cor neighbor in neighbors)
                {
                    if (AlreadyVisted2(neighbor)|| AlreadyVisted1(neighbor)) continue;
                    Node NeighborNode = new Node(Number++, CurrentNode.Number, neighbor, 0, 0);
                    NodeQueue2.Enqueue(NeighborNode);
                    Operations++;
                    Laby.SetCell(neighbor, Type.Open);
                }
            }
            if((NodeQueue2.Count == 0) && (NodeQueue1.Count == 0))
            {
                Console.WriteLine("NodeQueue2.Count:{0}", NodeQueue2.Count);
                Console.WriteLine("所寻找路径不存在");
                NotFound = true;
                IsFound = false;
            }
            return GetResult();
        }

        private bool AlreadyVisted1(Cor cor)
        {
            if (Laby.GetCell(cor).CellType == Type.Closed1) 
                return true;
            else
                return false;
        }

        private bool AlreadyVisted2(Cor cor)
        {
            if (Laby.GetCell(cor).CellType == Type.Closed2) 
                return true;
            else
                return false;
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
        public SearchResult GetResult()
        {
            return new SearchResult
            {
                Path = Path?.ToArray(),//寻找不到路径时允许路径为空
                PathCost = GetPathCost(),
                PathLength = GetPathLength(),
                OpenListSize = NodeQueue1.Count + NodeQueue2.Count,
                ClosedListSize = Closed1.Count+Closed2.Count,
                Operations = Operations,
                MethodName = "BiBreadth First",
                PathFound = IsFound,
                PathNotFound = NotFound
            };
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
