using System.Collections.Generic;
using UnityEngine;

public class BuildingSelector : MonoBehaviour
{
    [SerializeField]
    private List<BuildableItem> _buildables;
    [SerializeField]
    private BuildingPlacer _buildingPlacer;

    private int _activeBuildableIndex;

    private void NextItem()
    {
        _activeBuildableIndex = (_activeBuildableIndex + 1) % _buildables.Count;
        _buildingPlacer.SetActiveBuildable(_buildables[_activeBuildableIndex]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextItem();
        }
    }
}
