using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;
    private void Awake()
    {
        instance = this;
    }

    public event Action OnBarrackBuildButton;
    public void RaiseBarrackBuildButton() => OnBarrackBuildButton?.Invoke();

    public event Action OnPowerPlantBuildButton;
    public void RaiseOnPowerPlantBuildButton() => OnPowerPlantBuildButton?.Invoke();


}
