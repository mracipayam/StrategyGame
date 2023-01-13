using System;

public static class InGameEventManager
{
    public static event Action OnActiveBuildableChanged;
    public static void RaiseActiveBuildableChange() => OnActiveBuildableChanged?.Invoke();
}
