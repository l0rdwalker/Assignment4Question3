using System;

public class node {
    private List<path> adjacencyList = new List<path>();
    private string id;
    private shape savedShape = null;
    private int cost = int.MaxValue;
    private node parent = null; 
    private int arrival = 0;
    
    public node(string id, shape Shape) {
        this.id = id;
        this.savedShape = Shape;
    }

    public node() {
        this.id = "null";
    }

    public shape getShape() {
        return this.savedShape;
    }

    public void setNodeCost(int cost) {
        this.cost = cost; 
    }

    public int getNodeCost() {
        return this.cost;
    }

    public node getPathParent() {
        return this.parent;
    }

    public void setPathParent(node parent) {
        this.parent = parent;
    }

    public string getId() {
        return this.id;
    }

    public List<path> getAdjacent() {
        return this.adjacencyList;
    }

    public void addAdjacenct(node Node,int cost, bool origin = true) {
        if (origin) {
            this.adjacencyList.Add(new path(Node,cost));
        } else {
            this.adjacencyList.Add(new path(Node,cost));
        }
    
        if (origin) {
            Node.addAdjacenct(this,cost,false);
        }
    }
}