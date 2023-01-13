using Assets._GameData.Scripts.GameInput;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [field: SerializeField]
    public BuildableItem ActiveBuildable { get; private set; }

    [SerializeField] private float _maxBuildingDistance = 3f;
    [SerializeField] private ConstructionLayer _constructionLayer;
    [SerializeField] private PreviewLayer _previewLayer;
    [SerializeField] private MouseUser _mouseUser;
    [SerializeField] private Camera cam;
    private Vector2 mousePos;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (!IsMouseWithinBuildableRange() || ActiveBuildable == null)
        {
            _previewLayer.ClearPreview();
            return;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        _previewLayer.ShowPreview(ActiveBuildable, mousePos, _constructionLayer.IsEmpty(mousePos));
        if (Input.GetMouseButtonDown(0) && ActiveBuildable != null && _constructionLayer != null && _constructionLayer.IsEmpty(mousePos))
        {
            _constructionLayer.Build(mousePos, ActiveBuildable);
        }

    }

    private bool IsMouseWithinBuildableRange()
    {
        return Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) <= _maxBuildingDistance;
    }

    public void SetActiveBuildable(BuildableItem item)
    {
        ActiveBuildable = item;
    }
}
