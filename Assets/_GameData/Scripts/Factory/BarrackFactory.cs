using UnityEngine;
using UnityEngine.Tilemaps;

public class BarrackFactory : FactoryBase
{
    [field: SerializeField] public MoveOnTilemap productChief { get; private set; }
    [field: SerializeField] public Tilemap tilemap;
    [SerializeField] private Vector3 offset;
    public override void Produce(Transform spawnTransform)
    {
        var producedItem = Instantiate(productChief, spawnTransform.position + offset, Quaternion.identity);
        producedItem.tilemap = tilemap;
    }
}
