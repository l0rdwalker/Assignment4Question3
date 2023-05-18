using System;

public class graph {
    private Dictionary<string, node> visited = new Dictionary<string, node>();
    private Dictionary<string, node> unvisited = new Dictionary<string, node>();
    private Dictionary<string, node> quickFix = new Dictionary<string, node>();
    private int size = 0;
    private int discovery = 0;
    private Dictionary<string, node> tempDist = new Dictionary<string, node>();
    public node addNode(string id, shape Shape = null) {
        node newNode = new node(id, Shape);
        unvisited.Add(id,newNode);
        this.size++;
        return newNode;
    }

    public void joinNode(string id1, string id2, int cost) {
        node Node1 = getNode(id1);
        node Node2 = getNode(id2);

        Node1.addAdjacenct(Node2,cost);
    }

    private node getNode(string id) {
        if (unvisited.ContainsKey(id)) {
            return unvisited[id];
        } else {
            return this.addNode(id);
        }
    }

    public node Get(string id) {
        if (unvisited.ContainsKey(id)) {
            return unvisited[id];
        } else {
            return null;
        }
    }

    public List<node> Dikstras(string sourse, string dest){ 
        buildAdajcentNodes();

        node startNode = getNode(sourse);
        startNode.setNodeCost(0);
        node endNode = iterateGraph(startNode,dest);

        List<node> shortestPath = new List<node>(0);

        while (endNode != startNode) {
            shortestPath.Insert(0,endNode);
            endNode = endNode.getPathParent();
        }
        shortestPath.Insert(0,startNode);

        return shortestPath;
    }

    public node iterateGraph(node current, string dest){
        if (current.getId() == dest) {
            return current;
        }

        List<path> adajacentList = current.getAdjacent();

        for (int index = 0; index < adajacentList.Count(); index++) {
            path route = adajacentList[index];
            node destination = route.getDestination();

            int newCost = route.getPathCost() + current.getNodeCost();
            if (newCost < destination.getNodeCost()) {
                destination.setNodeCost(newCost);
                destination.setPathParent(current);
            }
        }

        visited.Add(current.getId(),current);
        unvisited.Remove(current.getId()); 

        return iterateGraph(dummyQueue(),dest);
    }

    public node dummyQueue() { //So. I didn't actually implement a priority queue. Implementing my past queue would have been annoying. So, lets just pretend this runs in log time :]
        node nullNode = new node();
        foreach (KeyValuePair<string, node> pair in unvisited)
        {
            if (pair.Value.getNodeCost() <= nullNode.getNodeCost()) {
                nullNode = pair.Value;
            }
        }

        return nullNode;
    }

    public void buildAdajcentNodes() {

        foreach (KeyValuePair<string, node> current in unvisited)
        {
            shape currentShape = current.Value.getShape();
            foreach (KeyValuePair<string, node> subject in unvisited)
            {
                shape subjectShape = subject.Value.getShape();
                if ((currentShape.isSame(subjectShape) == false) & (currentShape.OverlapsWith(subjectShape))) {
                    this.joinNode(current.Value.getId(),subject.Value.getId(),(int)(currentShape.CalculateArea() + subjectShape.CalculateArea()));
                }
            }
        }

    }
}