using Assets._GameData.Scripts.BuildingSystem.Models;
using Assets._GameData.Scripts.Extensions;
using System.Collections.Generic;
using UnityEngine;


public class ConstructionLayer : TilemapLayer
{

    private Dictionary<Vector3Int, Buildable> _buildables = new Dictionary<Vector3Int, Buildable>();

    [SerializeField]
    private CollisionLayer _collisionLayer;


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
            itemObject = Instantiate(item.GameObject, _tilemap.CellToWorld(coords) + _tilemap.cellSize / 2 + item.TileOffset, Quaternion.identity);
        }
        var buildable = new Buildable(item, coords, _tilemap, itemObject);
        if (item.UseCustomCollisionSpace)
        {
            _collisionLayer.SetCollisions(buildable, true);
            RegisterBuildableCollisionSpace(buildable);
        }
        else
        {
            _buildables.Add(coords, buildable);
        }
    }
    public void Destroy(Vector3 worldCoords)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        if (!_buildables.ContainsKey(coords)) { return; }
        var buildable = _buildables[coords];
        if (buildable.BuildableType.UseCustomCollisionSpace)
        {
            _collisionLayer.SetCollisions(buildable, false);
            UnRegisterBuildableCollisionSpace(buildable);   
        }
        _buildables.Remove(coords);
        buildable.Destroy();
    }

    public bool IsEmpty(Vector3 worldCoords, RectInt collisionSpace = default)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        if (!collisionSpace.Equals(default))
        {
            return !IsRectOccupied(coords, collisionSpace);
        }
        return !_buildables.ContainsKey(coords) && _tilemap.GetTile(coords) == null;
    }

    private void RegisterBuildableCollisionSpace(Buildable buildable)
    {
        buildable.IterateCollisionSpace(tileCoords => _buildables.Add(tileCoords, buildable));
    }
    private void UnRegisterBuildableCollisionSpace(Buildable buildable)
    {
        buildable.IterateCollisionSpace(tileCoords =>
        {
            _buildables.Remove(tileCoords);
        });
    }
    private bool IsRectOccupied(Vector3Int coords, RectInt rect)
    {
        return rect.Iterate(coords, tileCoords => _buildables.ContainsKey(tileCoords));
    }

}
