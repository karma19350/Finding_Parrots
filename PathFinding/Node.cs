using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public class Node//定义节点类
    {
        public int Number { get; set; }
        public int Parent { get; set; }
        public Cor State { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public Node(int number, int parent, int x, int y, int g, int h)//构造函数
        {
            Number = number;
            Parent = parent;
            State = new Cor(x, y);
            G = g;
            H = h;
            F = G + H;
        }
        public Node(int number, int parent, Cor state, int g, int h)//构造函数
        {
            Number = number;
            Parent = parent;
            State = state;
            G = g;
            H = h;
            F = G + H;
        }
    }
    public class SearchResult//定义搜索结果类
    {
        public Cor[] Path { get; set; }
        public int PathCost { get; set; }
        public int PathLength { get; set; }
        public int OpenListSize { get; set; }
        public int ClosedListSize { get; set; }
        public int Operations { get; set; }
        public string MethodName { get; set; }
        public bool PathFound { get; set; }
        public bool PathNotFound { get; set; }

    }
}
