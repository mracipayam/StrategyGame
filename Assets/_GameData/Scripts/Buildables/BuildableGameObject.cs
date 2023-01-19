using UnityEngine;

public abstract class BuildableGameObject : MonoBehaviour
{
    [field: SerializeField] public BuildableItem buildableItem;
    [field: SerializeField] public Transform ObjectTransform;

    private void Awake()
    {
        ObjectTransform = transform;
    }

    private void OnMouseDown()
    {
        InGameEventManager.RaiseOnBuildableClicked(buildableItem,ObjectTransform);
    }
}
