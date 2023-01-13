using Assets._GameData.Scripts.BuildingSystem.Models;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionLayer : TilemapLayer
{

    private Dictionary<Vector3Int, Buildable> _buildables = new Dictionary<Vector3Int, Buildable>();

    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        var buildable = new Buildable(item, coords, _tilemap);
        if (item.Tile != null)
        {
            _tilemap.SetTile(coords, item.Tile);
        }
        _buildables.Add(coords, buildable);
    }

    public bool IsEmpty(Vector3 worldCoords)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        return !_buildables.ContainsKey(coords);
    }

}
