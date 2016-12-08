using UnityEngine;
using System.Collections.Generic;
using System;

/*
* This is only for humans. As humans can not destroy buildings the graph will have edges
*  with weight 1 between empty edges and no edges between empty cells and cells occupied by a building.
*
* Badies on the other hand will have edges between occupied and free cells those edges will have a higher
* cost as it will take more time to destroy the obstacles. So paths with no obstacles will be prefered but
* if not available the badie will go towards obstacle at which point interactions should be created so that
* that building looses health. Still thinking about that
*/

public class Graph {
	List<GameObject> nodes;
	HashSet<Edge> edges;
	public float squareRootOfHalf = Mathf.Sqrt(8.0f);
	int minx;
	int minz;
	int maxx;
	int	maxz;
	int sizex;
	int sizez;
	public float gridx = 2.0f;
	public float gridz = 2.0f;
	public int ncellsinrow;

	public Graph (int xmin,int xmax, int zmin, int zmax){
		nodes = new List<GameObject>();
		edges = new HashSet<Edge>();
		minx = xmin;
		minz = zmin;
		maxx = xmax;
		maxz = zmax;
		sizex = xmax-xmin;
		sizez = zmax-zmin;
		ncellsinrow = sizex/ (int) gridx;
		initialize();
	}
	public int getListSize(){
		return nodes.Count;
	}
	public float getDistance(int src, int dst){
		return Vector3.Distance(nodes[src-1].transform.position,nodes[dst-1].transform.position);
	}

	public HashSet<Edge> getEdges(int cellID){
		int ncellsinrow = sizex/(int) gridx;
		HashSet<Edge> subset = new HashSet<Edge>();
		int []offsets = new int[] {cellID + ncellsinrow -1, cellID + ncellsinrow +1, cellID - ncellsinrow -1, cellID - ncellsinrow +1 , cellID -1, cellID +1, cellID+ ncellsinrow, cellID-ncellsinrow};

		for (int i=0; i<offsets.Length; i++){
			if( i < 4){
				Edge e = new Edge(squareRootOfHalf,cellID,offsets[i]);
				if (edges.Contains(e)) subset.Add(e);
			}
			else if(i < 6){
				Edge e = new Edge(gridx,cellID,offsets[i]);
				if (edges.Contains(e)) subset.Add(e);
			}
			else{
				Edge e = new Edge(gridz,cellID,offsets[i]);
				if (edges.Contains(e)) subset.Add(e);
			}
		}
		
		return subset;
	}

	public void edgeRemove(int cellID){
		int ncellsinrow = sizex/(int) gridx;
		int []offsets = new int[] {cellID + ncellsinrow -1, cellID + ncellsinrow +1, cellID - ncellsinrow -1, cellID - ncellsinrow +1
								 , cellID -1, cellID +1
								 , cellID+ ncellsinrow, cellID-ncellsinrow};

		for (int i=0; i<offsets.Length; i++){
			if( i < 4){
				Edge e = new Edge(squareRootOfHalf,cellID,offsets[i]);
				edges.Remove(e);
			}
			else if(i < 6){
				Edge e = new Edge(gridx,cellID,offsets[i]);
				edges.Remove(e);
			}
			else{
				Edge e = new Edge(gridz,cellID,offsets[i]);
				edges.Remove(e);
			}
		}
	}

	public Vector3 getCellPosition(int cellID){
		return nodes[cellID].transform.position;
	} 

	public int getEdgesCount(){
		return edges.Count;
	}

	public void edgeAdd(int cellID){

		int ncellsinrow = sizex/(int) gridx;
		int []offsets = new int[] {cellID + ncellsinrow -1, cellID + ncellsinrow +1,cellID - ncellsinrow -1,cellID - ncellsinrow +1
							, cellID -1, cellID +1
							, cellID+ ncellsinrow, cellID-ncellsinrow};
		string cstat = "";
		bool not_last_row = cellID < nodes.Count - ncellsinrow;
		bool not_first_row = cellID >= ncellsinrow;
		bool not_firstinrow = cellID% ncellsinrow != 0;
		bool not_lastinrow = (cellID+1)%ncellsinrow != 0;
		//WEST
		if (not_firstinrow && checkCell(offsets[4]) == "empty") edges.Add(new Edge(gridx,cellID,offsets[4]));
		//NORTH WEST
		if (not_firstinrow && not_last_row && checkCell(offsets[0]) == "empty") edges.Add(new Edge(squareRootOfHalf,cellID,offsets[0]));
		//NORTH
		if (not_last_row && checkCell(offsets[6]) == "empty") edges.Add(new Edge(gridz,cellID,offsets[6]));
		//NORTH EAST
		if (not_lastinrow && not_last_row && checkCell(offsets[1]) == "empty") edges.Add(new Edge(squareRootOfHalf,cellID,offsets[1]));
		//EAST
		if (not_lastinrow && checkCell(offsets[5]) == "empty") edges.Add(new Edge(gridx,cellID,offsets[5]));
		//SOUTH EAST
		if (not_first_row && not_lastinrow && checkCell(offsets[3]) == "empty") edges.Add(new Edge(squareRootOfHalf,cellID,offsets[3]));
		//SOUTH
		if (not_first_row && checkCell(offsets[7]) == "empty") edges.Add(new Edge(squareRootOfHalf,cellID,offsets[7]));
		// SOUTH WEST
		if (not_first_row && not_firstinrow && checkCell(offsets[2]) == "empty") edges.Add(new Edge(squareRootOfHalf,cellID,offsets[2]));
	}

	public string checkCell (int cellID){
		if(cellID > 0 && cellID <nodes.Count){
			return ((Cell)nodes[cellID].GetComponent(typeof(Cell))).getStatus();
		}
		return "Invalid Cell";
	}

	private void initialize(){
		// initialize grid of triggers
		int i = 0;
		for(float z = minz; z <maxz ; z +=gridz){
			for(float x = minx; x < maxx; x += gridx){
				Vector3 position = new Vector3((float)(x+1.0f),0.05f,(float)(z+1.0f));
				GameObject pre = Resources.Load("Cell") as GameObject;
				GameObject c = GameObject.Instantiate(pre,position, Quaternion.identity) as GameObject;
				c.name = string.Format("cell{0}",i);
				c.SendMessage("setid",i);
				nodes.Add(c);
				i++;
			}
		}

		
		
		float id = 0.0f;
		int ncellsinrow = sizex/(int) gridx;
		string s = string.Format("i  = {0} nodes count ={2}  cellsperrow = {1}",i,ncellsinrow,nodes.Count);
		Debug.Log(s);
		List<float> edgesIds = new List<float>();

		for (int ii = 0; ii < i; ii++){
			int i_NW = ii + ncellsinrow -1;
			int i_N  = ii + ncellsinrow;
			int i_NE = ii + ncellsinrow +1;
			int i_E  = ii + 1;

			bool not_last_row = ii < nodes.Count - ncellsinrow;
			bool not_firstinrow = ii% ncellsinrow != 0;
			bool not_lastinrow = (ii+1)%ncellsinrow != 0;

			if (not_firstinrow && not_last_row){
				Edge e = new Edge(squareRootOfHalf,ii,i_NW);
				edges.Add(e);
			}
			if (not_last_row){
				Edge e = new Edge(gridz,ii,i_N);
				edges.Add(e);
			}

			if (not_lastinrow && not_last_row){
				Edge e = new Edge(squareRootOfHalf,ii,i_NE);
				edges.Add(e);
			}
			if(not_lastinrow){
				Edge e = new Edge(gridx,ii,i_E);
				edges.Add(e);;
			}	
		}
		Debug.Log("Edges Done");
		int ncellsCols = (sizez/(int) gridz) ;
		int supposedEdged = 3 * ( ncellsCols- 1) + 4 * (ncellsinrow -2)*(ncellsCols -1) + 2*(ncellsCols-1) +ncellsinrow-1;
		s = string.Format("Actual edges = {0} theoretical = {1}",edges.Count,supposedEdged);
		Debug.Log(s);
	}
}


public class Edge : IEquatable<Edge>{
	public float w;
	public int src;
	public int dst;

	public Edge (float w, int src, int dst ){
		this.w = w;
		this.src = src;
		this.dst = dst;
	}

	public override int GetHashCode()
    {
        return w.GetHashCode() ^ src.GetHashCode() ^ dst.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return Equals((Edge)obj);
    }

    public bool Equals(Edge e)
    {
        if(e.w == w){
			if (e.src == src && e.dst == dst) return true;
			if (e.src == dst && e.dst == src) return true;
		}
		return false;
    }
}
