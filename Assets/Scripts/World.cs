using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class World
{
    private Tilemap _map;
    private Player _player;

    public Player player
    {
        get { return _player;  }
        set { _player = value;  }
    }

    public int width { get => _map.size.x; }
    public int height { get => _map.size.y; }


    public World(Tilemap map)
    {
        this._map = map;
        map.CompressBounds();

        
    }
    
}