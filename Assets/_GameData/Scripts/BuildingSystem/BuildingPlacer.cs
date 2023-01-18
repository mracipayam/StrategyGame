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
        if (!IsMouseWithinBuildableRange() || _constructionLayer == null)
        {
            _previewLayer.ClearPreview();
            return;
        }
        if (ActiveBuildable == null) return;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            _constructionLayer.Destroy(mousePos);
        }

        var isSpaceEmpty = _constructionLayer.IsEmpty(mousePos,
                ActiveBuildable.UseCustomCollisionSpace ?
                ActiveBuildable.CollisionSpace :
                default);

        _previewLayer.ShowPreview(ActiveBuildable, mousePos, isSpaceEmpty);

        if (Input.GetMouseButtonDown(0) && isSpaceEmpty)
        {
            _constructionLayer.Build(mousePos, ActiveBuildable);
            ActiveBuildable = null;
        }
    }

    private bool IsMouseWithinBuildableRange()
    {
        return Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) <= _maxBuildingDistance;
    }

    public void SetActiveBuildable(BuildableItem item)
    {
        ActiveBuildable = item;
        InGameEventManager.RaiseActiveBuildableChange();
    }
}
