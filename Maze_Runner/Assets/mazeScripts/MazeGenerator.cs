using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] float nodeSize;
    public NavMeshSurface surface;
    public GameObject enemy;
    public float spawnTime = 10;
    public List<GameObject> enemyList = new List<GameObject>();
    public int maxEnemy = 12;


    private void Start()
    {
        GenerateMaze(mazeSize);
        surface.BuildNavMesh();
        //spawn zombies
        StartCoroutine("spawning");
    }

    private void Update()
    {
        //set position of maze and navmesh surface
        gameObject.transform.position = new Vector3(21.9f, -1.2f, 22);
        surface.transform.position = new Vector3(21.9f, -2.7f, 22);
        
    }
    private void GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        //create nodes
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f))*nodeSize;// X is set to the input, y is 0, z is set to the y input on a 2d grid x,y == x,z
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

            }
        }

        //node state lists
        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> CompletedNodes = new List<MazeNode>();

        //choose start node
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        //currentPath[0].SetState(NodeState.Current);

        //check if nodes left
        while (CompletedNodes.Count < nodes.Count)
        {
            //check nodes next to current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                //check if node right is available
                if (!CompletedNodes.Contains(nodes[currentNodeIndex + size.y]) && !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                //check if node is left
                if (!CompletedNodes.Contains(nodes[currentNodeIndex - size.y]) && !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                //check node above current node
                if (!CompletedNodes.Contains(nodes[currentNodeIndex + 1]) && !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                //check node below current
                if (!CompletedNodes.Contains(nodes[currentNodeIndex - 1]) && !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }
            //chose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];
                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);//remove wall left of the chosen node
                        currentPath[currentPath.Count - 1].RemoveWall(0);//remove wall right of current node
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);//remove right of chosen
                        currentPath[currentPath.Count - 1].RemoveWall(1);//remove left of current
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);//remove bottom wall
                        currentPath[currentPath.Count - 1].RemoveWall(2);//remove up wall from current
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);//remove top from chosen
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
            }
            else
            {
                //backtrack to more possible nodes
                //adding current node to completed list
                CompletedNodes.Add(currentPath[currentPath.Count-1]);
                ///removing node from current path
                currentPath.RemoveAt(currentPath.Count-1);
            }
        }
    }

    IEnumerator spawning()
    {
            //wait time to spawn
            yield return new WaitForSeconds(spawnTime);
            //instantiate zombies at specific position add them to enemy list
            if (enemyList.Count < maxEnemy)
            {
                Vector3 pos = new Vector3(29.25f, -1, 29.42f);
                enemyList.Add(Instantiate(enemy, pos, Quaternion.identity));
            }
            if (enemyList.Count < maxEnemy)
            {
                Vector3 pos2 = new Vector3(2f, -1, 2f);
            enemyList.Add(Instantiate(enemy, pos2, Quaternion.identity));
        }
            if (enemyList.Count < maxEnemy)
            {
                Vector3 pos3 = new Vector3(47f, -1, -7f);
            enemyList.Add(Instantiate(enemy, pos3, Quaternion.identity));
        }
            if (enemyList.Count < maxEnemy)
            {
                Vector3 pos4 = new Vector3(-8f, -1, 48f);
            enemyList.Add(Instantiate(enemy, pos4, Quaternion.identity));
        }
            //call spawn again
            StartCoroutine("spawning");
        }
        

    public void enemydie()
    {
        if (enemyList.Count > 0)
        {
            //remove all missing gameObjects from the list of enemies
            enemyList.RemoveAll(enemy => enemy == null);
        }
    }
}
