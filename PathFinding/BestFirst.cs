﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    class BestFirst
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

        public BestFirst(Laby laby)
        {
            Laby = laby;
            Closed = new List<Node>();
            Open = new List<Node>();
            StartPoint = Laby.GetStart().CellCor;
            EndPoint = Laby.GetEnd().CellCor;
            Path = new List<Cor>();
            Number = 1;
            Operations = 0;
            Open.Add(new Node(Number, 0, StartPoint, 0, GetManhatten(StartPoint,EndPoint)));
            Operations++;
            Number++;
            Closed.Clear();
            Path.Clear();
        }

        public SearchResult GetPath()
        {
            if (Open.Count > 0)
            {
                CurrentNode = Open.OrderBy(node => node.F).First();
                Open.Remove(CurrentNode);
                if (AlreadyVisted(CurrentNode.State)) return GetResult();
                Operations++;
                Closed.Add(CurrentNode);
                Laby.SetCell(CurrentNode.State, Type.Closed);

                if ((CurrentNode.State.X == EndPoint.X) && (CurrentNode.State.Y == EndPoint.Y))
                {
                    Console.WriteLine("Find!");
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
                    Node NeighborNode = new Node(Number++, CurrentNode.Number, neighbor, 0, GetManhatten(neighbor, EndPoint));
                    Open.Add(NeighborNode);
                    Operations++;
                    Laby.SetCell(neighbor, Type.Open);
                }
            }
                else 
                {
                    Console.WriteLine(Open.Count);
                    Console.WriteLine("所寻找路径不存在");
                    NotFound = true;
                    IsFound = false;
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
                MethodName = "Best First",
                PathFound = IsFound,
                PathNotFound = NotFound
            };
        }
    


    private List<Cor> GetNeighbor(Node current)
    {
        List<Cor> Neighbor = new List<Cor>();
        List<Cell> Temp = new List<Cell> {//左下右上循环
                Laby.GetCell(current.State.X - 1, current.State.Y),
                Laby.GetCell(current.State.X , current.State.Y + 1),
                Laby.GetCell(current.State.X + 1, current.State.Y),
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

    private int GetManhatten(Cor StartCor, Cor EndCor)
    {
        return Math.Abs(StartCor.X - EndCor.X) + Math.Abs(StartCor.Y - EndCor.Y);
    }

}
}
