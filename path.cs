using System;


public class path {
    private node destination; 
    private int pathCost; 
    public path(node newKey, int pathCost) {
        this.destination = newKey;
        this.pathCost = pathCost;
    }

    public int getPathCost() {
        return this.pathCost;
    }

    public void setPathCost(int cost) {
        this.pathCost = cost; 
    }

    public node getDestination() {
        return this.destination;
    }
}