using Assets._GameData.Scripts.BuildingSystem.Models;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionLayer : TilemapLayer
{

    private Dictionary<Vector3Int, Buildable> _buildables = new Dictionary<Vector3Int, Buildable>();

    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        GameObject itemObject = null;
        var coords = _tilemap.WorldToCell(worldCoords);

        if (item.Tile != null)
        {
            _tilemap.SetTile(coords, item.Tile);
        }
        if (item.GameObject != null)
        {
            itemObject = Instantiate(item.GameObject, _tilemap.CellToWorld(coords) + _tilemap.cellSize / 2, Quaternion.identity);
        }
        var buildable = new Buildable(item, coords, _tilemap, itemObject);
        _buildables.Add(coords, buildable);
    }

    public bool IsEmpty(Vector3 worldCoords)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        return !_buildables.ContainsKey(coords);
    }

}
