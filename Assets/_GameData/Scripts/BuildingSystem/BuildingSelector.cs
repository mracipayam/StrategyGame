using System.Collections.Generic;
using UnityEngine;

public class BuildingSelector : MonoBehaviour
{
    [SerializeField]
    private List<BuildableItem> _buildables;
    [SerializeField]
    private BuildingPlacer _buildingPlacer;

    //private int _activeBuildableIndex;

    private void OnEnable()
    {
        GameEventManager.instance.OnBarrackBuildButton += BarrackBuildButtonHandler;
        GameEventManager.instance.OnPowerPlantBuildButton += PowerPlantButtonHandler;
    }
    private void OnDisable()
    {
        GameEventManager.instance.OnBarrackBuildButton -= BarrackBuildButtonHandler;
        GameEventManager.instance.OnPowerPlantBuildButton -= PowerPlantButtonHandler;

    }

    private void PowerPlantButtonHandler()
    {
        _buildingPlacer.SetActiveBuildable(_buildables[1]);
    }

    private void BarrackBuildButtonHandler()
    {
        _buildingPlacer.SetActiveBuildable(_buildables[0]);
    }

    //private void NextItem()
    //{
    //    _activeBuildableIndex = (_activeBuildableIndex + 1) % _buildables.Count;
    //    _buildingPlacer.SetActiveBuildable(_buildables[_activeBuildableIndex]);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.N))
    //    {
    //        NextItem();
    //    }
    //}
}
