using System;

public static class InGameEventManager
{
    public static event Action OnActiveBuildableChanged;
    public static void RaiseActiveBuildableChange() => OnActiveBuildableChanged?.Invoke();

    public static event Action OnBarrackClicked;
    public static void RaiseOnBarrackClicked() => OnBarrackClicked?.Invoke();

    public static event Action OnPowerPlantClicked;
    public static void RaiseOnPowerPlantClicked() => OnPowerPlantClicked?.Invoke();

    public static event Action<BuildableItem> OnBuildableClicked;
    public static void RaiseOnBuildableClicked(BuildableItem item) => OnBuildableClicked?.Invoke(item);

}
