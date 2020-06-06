using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class World
{
    public Tilemap map;
    public GameObject player;

    public int width { get => map.size.x; }
    public int height { get => map.size.y; }


    public World(Tilemap map)
    {
        this.map = map;
        map.CompressBounds();
        
    }

}