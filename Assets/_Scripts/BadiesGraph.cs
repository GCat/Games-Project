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
    Dictionary<int, HashSet<Edge>> cell_to_edges = new Dictionary<int, HashSet<Edge>>();           // a map from cell id to all connected edges for optimisation
    public BadiesGraph(int xmin, int xmax, int zmin, int zmax, List<GameObject> nodes, HashSet<Edge> edges)
    {
        this.nodes = nodes;
        this.edges = new List<Edge>(edges);
        constructMap();
        minx = xmin;
        minz = zmin;
        maxx = xmax;
        maxz = zmax;
        sizex = xmax - xmin;
        sizez = zmax - zmin;
        ncellsinrow = sizex / (int)gridx;
    }

    private void constructMap()
    {
        foreach (Edge e in edges)
        {
            if (cell_to_edges.ContainsKey(e.src))
            {
                cell_to_edges[e.src].Add(e);
            }
            if (cell_to_edges.ContainsKey(e.dst))
            {
                cell_to_edges[e.dst].Add(e);
            }
        }
    }

    public void edgeChangeWeight(int cellID, float weight) {
        if (!cell_to_edges.ContainsKey(cellID))
        {
            return;
        }

        foreach (Edge e in cell_to_edges[cellID])
        {
            e.updateWeight(weight);
        }
    }

    public void resetWeights(int cellID)
    {

    }
    public HashSet<Edge> getEdges(int cellID)
    {
        return new HashSet<Edge>(cell_to_edges[cellID]);
    }



}
