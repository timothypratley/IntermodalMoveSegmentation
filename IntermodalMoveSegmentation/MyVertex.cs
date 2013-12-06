using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermodalMoveSegmentation
{
    public class MyVertex
    {
        public string ID { get; private set; }
        public MyVertex(string id)
        {
            ID = id;
        }
        public override string ToString()
        {
            return ID;
        }
        public string CodeString()
        {
            return ToString().Replace(" ", "").Replace(",", "").Replace("RMG", "Rmg").Replace("UTR", "Utr");
        }
    }
}
