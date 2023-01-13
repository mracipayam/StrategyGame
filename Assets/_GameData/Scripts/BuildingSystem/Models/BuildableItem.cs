using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Building/New Buildable Item", fileName = "New Buildable Item")]
public class BuildableItem : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public TileBase Tile { get; private set; }
    [field: SerializeField]
    public Vector3 TileOffset { get; private set; }
    [field: SerializeField]
    public Sprite PreviewSprite { get; private set; }

}
