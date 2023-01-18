using UnityEngine;

public abstract class BuildableGameObject : MonoBehaviour
{
    [field: SerializeField] public BuildableItem buildableItem;

    private void OnMouseDown()
    {
        InGameEventManager.RaiseOnBuildableClicked(buildableItem);
    }
}
