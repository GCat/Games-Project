using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;


/* Human AI  Explanation
 * 
 * Phase 1
 * Once spawn wander around finding a random position using calculatenewtarget()
 * once found target find fastest path using A*
 * Reapeat until battle phase.
 * 
 * If the human grabbed stop moving
 * If dragged outside the plane DIE
 * 
 * Phase 2
 * Have three type of humans
 * ---Attackers:
 * (Maybe sincronized as badies are way stronger)
 * Search for nearest badie and attack
 * 
 * For sincronisation give each human a rank  make humans comunicate with each other with target
 * If target match both attack
 * If target does not match go for target of human with highest rank
 * 
 * --- Campers:
 * Stay near watch towers and engage nearby enemies
 * 
 * --- Defenders:
 * Defend temple
 *  
 */ 
public class PathFinding : MonoBehaviour
{

    Graph world;
    BadiesGraph bWorld;

    public bool done;
    // Use this for initialization
    void Start()
    {
        done = false;
        world = new Graph(-50, 50, -100, 100);
        bWorld = new BadiesGraph(-50, 50, -100, 100, world.nodes, world.edges);
        done = true;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.KeypadEnter)|| Input.GetKey("enter")){
            GameObject[] badies = GameObject.FindGameObjectsWithTag("Badies");
            foreach (GameObject b in badies)
            {
                b.SendMessage("changeMoving", true);
            }
            GameObject[] humans = GameObject.FindGameObjectsWithTag("Human");
            foreach (GameObject h in humans)
            {
                h.SendMessage("changeMode", true);
            }

        }
    }
    public int getMaxCell()
    {
        return world.getListSize();
    }

    public Vector3 getCellPosition(int cellId)
    {
        return world.getCellPosition(cellId);
    }

    public string checkCell(int cellId)
    {   
        if (world == null) return "ERROR";
        return world.checkCell(cellId);
    }
    public void buildingAdded(int id)
    {

        world.edgeRemove(id);
        bWorld.edgeChangeWeight(id, 50.0f);
    }
    public void buildingRemoved(int id)
    {
        world.edgeAdd(id);
    }

    public HashSet<Edge> getEdgesFrom(int e)
    {
        return world.getEdges(e);
    }

    public List<int> Astar(int src, int dst)
    {
        //Debug.Log("Start Pathfinding");
        //Debug.Log(world.getEdgesCount());

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();

        Node n = new Node(null, src, 0.0f, costEstimate(src, dst));
        open.Add(n);

        while (open.Count > 0)
        {
            open.Sort((x, y) => x.f.CompareTo(y.f));
            Node q = open[0];
            open.Remove(q);
            closed.Add(q);
            if (q.id == dst)
            {
                return reconstructpath(q);
            }
            HashSet<Edge> edgesFromQ = world.getEdges(q.id);

            foreach (Edge e in edgesFromQ)
            {
                int neighId = (e.src == q.id) ? e.dst : e.src;
                List<Node> temp = closed.Where(node => node.id == neighId).ToList();
                if (temp.Count > 0) continue;

                float tempgscore = q.g + costEstimate(q.id, neighId);
                temp = open.Where(node => node.id == neighId).ToList();
                if (temp.Count == 0)
                {
                    Node neigh = new Node(q, neighId, tempgscore, costEstimate(neighId, dst));
                    open.Add(neigh);
                }
                else if (tempgscore >= temp[0].g) continue;

            }
        }
        return new List<int>();
    }

    public List<int> AstarB(int src, int dst)
    {
        //Debug.Log("Start Pathfinding");
        //Debug.Log(world.getEdgesCount());

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();

        Node n = new Node(null, src, 0.0f, costEstimate(src, dst));
        open.Add(n);

        while (open.Count > 0)
        {
            open.Sort((x, y) => x.f.CompareTo(y.f));
            Node q = open[0];
            open.Remove(q);
            closed.Add(q);
            if (q.id == dst)
            {
                return reconstructpath(q);
            }
            HashSet<Edge> edgesFromQ = bWorld.getEdges(q.id);

            foreach (Edge e in edgesFromQ)
            {
                int neighId = (e.src == q.id) ? e.dst : e.src;
                List<Node> temp = closed.Where(node => node.id == neighId).ToList();
                if (temp.Count > 0) continue;

                float tempgscore = q.g + e.w;
                temp = open.Where(node => node.id == neighId).ToList();
                if (temp.Count == 0)
                {
                    Node neigh = new Node(q, neighId, tempgscore, costEstimate(neighId, dst));
                    open.Add(neigh);
                }
                else if (tempgscore >= temp[0].g) continue;

            }
        }
        return new List<int>();
    }

    private float costEstimate(int src, int dst)
    {
        float displacementX = (Math.Abs(src % world.ncellsinrow - dst % world.ncellsinrow)) * world.gridx;
        float displacementY = (float)(Math.Abs((dst- dst % world.ncellsinrow) -src -src % world.ncellsinrow) *(world.gridz/world.ncellsinrow));
        float distance = (float)Math.Sqrt(displacementX * displacementX + displacementY * displacementY);
        return distance;
    }

    private List<int> reconstructpath(Node q)
    {
        //Debug.Log(q.id);
        List<int> waypoints = new List<int>();
        Node n = q;
        while (n.parent != null)
        {
            waypoints.Add(n.id);
            n = n.parent;
        }
        waypoints.Add(n.id);
        waypoints.Reverse();
        return waypoints;

    }
}

public class Node
{
    public Node parent;
    public int id;
    public float f, g, h;
    public Node(Node parent, int id, float g, float h)
    {
        this.parent = parent;
        this.id = id;
        this.g = g;
        this.h = h;
        f = g + h;
    }
    public Node(Node parent, float g, float h)
    {
        this.parent = parent;
        this.g = g;
        this.h = h;
        f = g + h;
    }
}
