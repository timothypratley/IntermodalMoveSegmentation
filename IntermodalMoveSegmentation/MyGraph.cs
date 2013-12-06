using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermodalMoveSegmentation
{
    public class MyGraph : BidirectionalGraph<MyVertex, MyEdge>
    {
        public MyGraph() { }
        public MyGraph(bool allowParallelEdges) : base(allowParallelEdges) { }
        public MyGraph(bool allowParallelEdges, int vertexCapacity) : base(allowParallelEdges, vertexCapacity) { }
    }
}
