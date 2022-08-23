using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CaveGenerator))]
public class CaveGeneration : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Tile _floor;
    [SerializeField] private Tile _wall;

    private Tilemap _tilemap;
    private bool[,] _cellmap;
    private CaveGenerator _generator;

    void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _generator = GetComponent<CaveGenerator>();
        _cellmap = _generator.Generate(_width, _height);
        Draw();
    }

	private void Draw()
	{
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_cellmap[x, y])
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), _wall);
                }
                else
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), _floor);
                }
            }
        }
    }

}
