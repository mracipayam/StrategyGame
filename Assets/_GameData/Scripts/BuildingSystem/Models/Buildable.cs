using Assets._GameData.Scripts.Extensions;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets._GameData.Scripts.BuildingSystem.Models
{
    [Serializable]
    public class Buildable
    {
        [field: SerializeField]
        public Tilemap ParentTilemap { get; private set; }
        [field: SerializeField]
        public BuildableItem BuildableType { get; private set; }
        [field: SerializeField]
        public GameObject GameObject { get; private set; }
        [field: SerializeField]
        public Vector3Int Coordinates { get; private set; }

        public Buildable(BuildableItem type, Vector3Int coordinates, Tilemap tilemap, GameObject gameObject = null)
        {
            ParentTilemap = tilemap;
            BuildableType = type;
            GameObject = gameObject;
            Coordinates = coordinates;
        }

        public void Destroy()
        {
            if (GameObject != null)
            {
                UnityEngine.Object.Destroy(GameObject);
            }
            ParentTilemap.SetTile(Coordinates, null);
        }

        public void IterateCollisionSpace(RectIntExtensions.RectAction action)
        {
            BuildableType.CollisionSpace.Iterate(Coordinates, action);
        }
        public bool IterateCollisionSpace(RectIntExtensions.RectActionBool action)
        {
            return BuildableType.CollisionSpace.Iterate(Coordinates, action);
        }
    }
}