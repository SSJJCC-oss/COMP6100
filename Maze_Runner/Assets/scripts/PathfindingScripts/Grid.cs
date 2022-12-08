using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int z = 0; z < gridArray.GetLength(1); z++)
            {
                Debug.DrawLine(GetMapPoint(x, z), GetMapPoint(x, z+1), Color.white, 100f);
                Debug.DrawLine(GetMapPoint(x, z), GetMapPoint(x+1, z), Color.white, 100f);
            }
            Debug.DrawLine(GetMapPoint(0, height), GetMapPoint(width, height), Color.white, 100f);
            Debug.DrawLine(GetMapPoint(width, 0), GetMapPoint(width, height), Color.white, 100f);
        }
    }

    private Vector3 GetMapPoint(int x, int z)
    {
        return new Vector3(x,0, z) * cellSize;
    }

    private void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt(worldPos.x / cellSize);
        z = Mathf.FloorToInt(worldPos.y / cellSize);
    }

    public void setValue(int x, int z, int value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
        }
    }

    public void SetValue(Vector3 worldPos, int value)
    {
        int x, z;
        GetXZ(worldPos, out x, out z);
        setValue(x, z, value);
    }

    public int GetValue(int x, int z)
    {
        if(x >= 0 && z >= 0 && x < width && z <= height)
        {
            return gridArray[x, z];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPos)
    {
        int x, z;
        GetXZ(worldPos, out x, out z);
        return GetValue(x, z);
    }
}
