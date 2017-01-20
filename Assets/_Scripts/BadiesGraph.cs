using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BadiesGraph{

    List<GameObject> nodes;
    List<Edge> edges;
    public float squareRootOfHalf = Mathf.Sqrt(8.0f);
    int minx;
    int minz;
    int maxx;
    int maxz;
    int sizex;
    int sizez;
    public float gridx = 2.0f;
    public float gridz = 2.0f;
    public int ncellsinrow;

    public BadiesGraph(int xmin, int xmax, int zmin, int zmax, List<GameObject> nodes, HashSet<Edge> edges)
    {
        this.nodes = nodes;
        this.edges = new List<Edge>(edges);
        minx = xmin;
        minz = zmin;
        maxx = xmax;
        maxz = zmax;
        sizex = xmax - xmin;
        sizez = zmax - zmin;
        ncellsinrow = sizex / (int)gridx;
    }

    public void edgeChangeWeight(int cellID, float weight) {
        foreach (Edge e in edges.FindAll(x => (x.src == cellID) || (x.dst == cellID)))
        {
            e.updateWeight(weight);
        }
    }

    public void resetWeights(int cellID)
    {

    }
    public HashSet<Edge> getEdges(int cellID)
    {
        return new HashSet<Edge>(edges.FindAll(x => (x.src == cellID) || (x.dst == cellID)));
    }



}
