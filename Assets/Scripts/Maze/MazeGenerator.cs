using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10, height = 10;
    public GameObject wallPrefab, floorPrefab, playerPrefab, goalPrefab;

    private int[,] maze;
    private Vector2Int startPos;
    private Vector2Int goalPos;

    void Start()
    {
        GenerateMaze();
        SpawnMaze();
        SpawnPlayerAndGoal();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        Vector2Int current = new Vector2Int(1, 1);
        maze[current.x, current.y] = 1;
        stack.Push(current);

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        while (stack.Count > 0)
        {
            current = stack.Peek();
            List<Vector2Int> availableDirs = new List<Vector2Int>();

            foreach (var dir in directions)
            {
                Vector2Int next = current + dir * 2;
                if (next.x > 0 && next.x < width - 1 && next.y > 0 && next.y < height - 1 && maze[next.x, next.y] == 0)
                {
                    availableDirs.Add(dir);
                }
            }

            if (availableDirs.Count > 0)
            {
                Vector2Int chosenDir = availableDirs[Random.Range(0, availableDirs.Count)];
                Vector2Int next = current + chosenDir * 2;
                maze[next.x, next.y] = 1;
                maze[current.x + chosenDir.x, current.y + chosenDir.y] = 1;
                stack.Push(next);
            }
            else
            {
                stack.Pop();
            }
        }

        startPos = new Vector2Int(1, 1);
        goalPos = new Vector2Int(width - 3, height - 3);
    }

    void SpawnMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x, y, 0);
                if (maze[x, y] == 0)
                    Instantiate(wallPrefab, pos, Quaternion.identity);
                else
                    Instantiate(floorPrefab, pos, Quaternion.identity);
            }
        }
    }

    void SpawnPlayerAndGoal()
    {
        Instantiate(playerPrefab, new Vector3(startPos.x, startPos.y, 0), Quaternion.identity);
        Instantiate(goalPrefab, new Vector3(goalPos.x, goalPos.y, 0), Quaternion.identity);
    }
}
