using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermodalMoveSegmentation
{
    public class MyEdge : Edge<MyVertex>
    {
        public string Abbreviation { get; private set; }
        public MyEdge(MyVertex source, MyVertex target, string abbreviation)
            : base(source, target)
        {
            Abbreviation = abbreviation;
        }
    }
}
