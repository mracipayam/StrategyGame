using Assets._GameData.Scripts.GameInput;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [field: SerializeField]
    public BuildableItem ActiveBuildable { get; private set; }

    [SerializeField] private float _maxBuildingDistance = 3f;
    [SerializeField] private ConstructionLayer _constructionLayer;
    [SerializeField] private MouseUser _mouseUser;

    private void Update()
    {
        //if (!IsMouseWithinBuildableRange()) return;

        if (Input.GetMouseButtonDown(0) && ActiveBuildable != null && _constructionLayer != null)
        {
            _constructionLayer.Build(Camera.main.ScreenToWorldPoint(Input.mousePosition), ActiveBuildable);
        }

    }

    private bool IsMouseWithinBuildableRange()
    {
        return Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) <= _maxBuildingDistance;
    }
}
