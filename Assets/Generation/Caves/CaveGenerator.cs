using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    private int _width;
    private int _height;

    [SerializeField] [Range(0.0f, 1.0f)] private float _chanceToStartAlive = 0.45f;
    [SerializeField] private int _birthLimit = 4;
    [SerializeField] private int _deathLimit = 3;
    [SerializeField] private int _numberOfSteps = 2;

    public bool[,] Generate(int width, int height)
    {
        _width = width;
        _height = height;
        bool[,] cellmap = new bool[_width, _height];

        cellmap = InitialiseMap(cellmap);
        for (int i = 0; i < _numberOfSteps; i++)
        {
            cellmap = SimulateStep(cellmap);
        }

        return cellmap;
    }

    private bool[,] InitialiseMap(bool[,] map)
    {

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                float r = (Random.Range(0, 1000));

                if (r * 0.001f < _chanceToStartAlive)
                {
                    map[x, y] = true;
                }
            }
        }
        return map;
    }

    private bool[,] SimulateStep(bool[,] oldMap)
    {
        bool[,] newMap = new bool[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                int aliveNeighbours = CountAliveNeighbours(oldMap, x, y);
                if (oldMap[x, y])
                {
                    if (aliveNeighbours < _deathLimit)
                    {
                        newMap[x, y] = false;
                    }
                    else
                    {
                        newMap[x, y] = true;
                    }
                }
                else
                {
                    if (aliveNeighbours > _birthLimit)
                    {
                        newMap[x, y] = true;
                    }
                    else
                    {
                        newMap[x, y] = false;
                    }
                }
            }
        }
        return newMap;
    }
    private int CountAliveNeighbours(bool[,] map, int x, int y)
    {
        int count = 0;

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int neighbourX = x + i;
                int neighbourY = y + j;
                if (!(i == 0 && j == 0))
                {
                    if (neighbourX < 0 || neighbourY < 0 || neighbourX >= _width || neighbourY >= _height)
                    {
                        count = count + 1;
                    }
                    else if (map[neighbourX, neighbourY])
                    {
                        count = count + 1;
                    }
                }

            }
        }
        return count;
    }
}
