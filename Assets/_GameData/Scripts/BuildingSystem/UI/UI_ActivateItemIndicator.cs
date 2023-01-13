using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UI_ActivateItemIndicator : MonoBehaviour
{
    [SerializeField]
    private BuildingPlacer _buildingPlacer;
    private Image _icon;

    private void Awake()
    {
        _icon = GetComponent<Image>();
    }
    private void OnEnable()
    {
        InGameEventManager.OnActiveBuildableChanged += OnActiveBuildableChangedHandler;
    }
    private void OnDisable()
    {
        InGameEventManager.OnActiveBuildableChanged -= OnActiveBuildableChangedHandler;
    }
    private void Start()
    {
        OnActiveBuildableChangedHandler();
    }

    private void OnActiveBuildableChangedHandler()
    {
        if (_buildingPlacer.ActiveBuildable != null)
        {
            _icon.enabled = true;
            _icon.sprite = _buildingPlacer.ActiveBuildable.UiIcon;
        }
        else
        {
            _icon.enabled = false;
        }
    }
}
