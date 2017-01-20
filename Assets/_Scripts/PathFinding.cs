using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PathFinding : MonoBehaviour {
	
	Graph world;
	public bool done;
	// Use this for initialization
	void Start () {
		done = false;
		world = new Graph(-50,50,-100,100);
		done = true;
	}

	public int getMaxCell(){
		return world.getListSize();
	}

	public Vector3 getCellPosition (int cellId){
		return world.getCellPosition(cellId);
	}

	public string checkCell(int cellId){
		return world.checkCell(cellId);
	}
	void buildingAdded(int id){
		
		world.edgeRemove(id);
	}
	void buildingRemoved(int id){
		world.edgeAdd(id);
	}

	public HashSet<Edge> getEdgesFrom (int e){
		return world.getEdges (e);
	}
	
	public List<int> Astar(int src, int dst){
		//Debug.Log("Start Pathfinding");
		//Debug.Log(world.getEdgesCount());

		List<Node> open = new List<Node>();
		List<Node> closed= new List<Node>();

		Node n = new Node(null,src,0.0f,costEstimate(src,dst));
		open.Add(n);

		while (open.Count > 0){
			open.Sort((x, y) => x.f.CompareTo(y.f));
			Node q = open[0];
			open.Remove(q);
			closed.Add(q);
			if(q.id == dst){
				return reconstructpath(q);
			}
			HashSet<Edge> edgesFromQ = world.getEdges(q.id);

			foreach (Edge e in edgesFromQ){
				int neighId = (e.src == q.id)? e.dst : e.src;
				List<Node> temp = closed.Where(node => node.id == neighId).ToList();
				if (temp.Count > 0) continue;

				float tempgscore = q.g + costEstimate(q.id,neighId);
				temp = open.Where(node => node.id == neighId).ToList();
				if(temp.Count == 0){
					Node neigh = new Node(q,neighId,tempgscore,costEstimate(neighId,dst));
					open.Add(neigh);
				}
				else if( tempgscore >= temp[0].g) continue;

			}
		}
		return new List<int>();
	}

	private float costEstimate(int src, int dst){
		float displacementX = (Math.Abs(src-dst) % world.ncellsinrow) *world.gridx;
		float displacementY =  (Math.Abs(src-dst)/ world.ncellsinrow) * world.gridz;
		float distance = (float)Math.Sqrt( displacementX*displacementX +displacementY*displacementY);
		return distance;
	}

	private List<int> reconstructpath (Node q){
		//Debug.Log(q.id);
		List<int> waypoints = new List<int>();
		Node n = q;
		while (n.parent != null){
			waypoints.Add(n.id);
			n = n.parent;
		}
		waypoints.Add(n.id);
		waypoints.Reverse();
		return waypoints;
	
	}
}

public class Node {
	public Node parent;
	public int id;
	public float f,g,h;
	public Node(Node parent, int id, float g ,float h){
		this.parent = parent;
		this.id = id;
		this.g = g;
		this.h = h;
		f = g +h;
	}
	public Node(Node parent,float g ,float h){
		this.parent = parent;
		this.g = g;
		this.h = h;
		f = g +h;
	}
}

