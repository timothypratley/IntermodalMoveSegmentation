using Microsoft.VisualStudio.GraphModel;
using QuickGraph;
using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IntermodalMoveSegmentation
{
    public static class MyGraphSerializeHelper
    {
        public static MyGraph LoadDGML(string filename)
        {
            var g = Graph.Load(filename);

            //graph where the vertices and edges should be put in
            var pocGraph = new MyGraph();
            foreach (var n in g.Nodes)
            {
                // arghh dgml uses labels and ids
                pocGraph.AddVertex(new MyVertex(n.Label));
            }
            var indexed = pocGraph.Vertices.ToDictionary(v => v.ID);
            foreach (var e in g.Links)
            {
                pocGraph.AddEdge(
                    new MyEdge(
                        indexed[e.Source.Label],
                        indexed[e.Target.Label],
                        e.Label));
            }
            return pocGraph;
        }

        public static MyGraph LoadGraph(string filename)
        {
            //open the file of the graph
            var reader = XmlReader.Create(filename);

            //create the serializer
            var serializer = new GraphMLDeserializer<MyVertex, MyEdge, MyGraph>();

            //graph where the vertices and edges should be put in
            var pocGraph = new MyGraph();

            //deserialize the graph
            serializer.Deserialize(reader, pocGraph,
                                    id => new MyVertex(id),
                                    (source, target, abbreviation) => new MyEdge(source, target, abbreviation));

            return pocGraph;
        }

        public static MyGraph LoadBasic(string filename)
        {
            var g = new MyGraph();

            var csv = new CsvHelper.CsvReader(new StreamReader("IntermodalGraphBasic.csv"));
            while (csv.Read())
            {
                if (!csv.CurrentRecord.Any())
                {
                    continue;
                }

                var node = new MyVertex(csv.CurrentRecord.First());
                var adjacent = csv.CurrentRecord.Skip(1)
                    .Select(x => x == null ? x : x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x));
                foreach (var v in adjacent)
                {
                    var end = new MyVertex(v);
                    g.AddVerticesAndEdge(new MyEdge(node, end, null));
                }
            }

            return g;
        }
    }
}
