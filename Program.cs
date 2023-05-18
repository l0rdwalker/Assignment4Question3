using System;

class Program
{
    static void Main(string[] args)
    {
        graph myGraph = new graph();
        myGraph.addNode("A", new shape(5, 10, 0, 0));
        myGraph.addNode("B", new shape(6, 8, 15, 0));
        myGraph.addNode("C", new shape(7, 12, 0, 15));
        myGraph.addNode("D", new shape(4, 6, 15, 15));
        myGraph.addNode("E", new shape(8, 7, 30, 0));
        myGraph.addNode("F", new shape(3, 5, 45, 0));
        myGraph.addNode("G", new shape(6, 9, 30, 15));
        myGraph.addNode("H", new shape(5, 7, 45, 15));
        myGraph.addNode("I", new shape(4, 10, 60, 0));
        myGraph.addNode("J", new shape(7, 8, 60, 15));

        myGraph.Dikstras("A","J");
    }


}
