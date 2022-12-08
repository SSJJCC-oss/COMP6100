using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Grid grid;
    //private List<PathNode> openList;
    //private List<PathNode> closedList;

    public Pathfinding(int width, int height)
    {
        grid = new Grid(width, height, 0.5f);
    }

    //private List<PathNode> FindPath(int startx, int startz, int endx, int endy)
    //{
        //PathNode startNode = grid.GetXZ(startx, startz);
       // openList = new List<PathNode>();
       // closedList = new List<PathNode>();
   // }
}
