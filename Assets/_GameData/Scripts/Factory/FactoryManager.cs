using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager Instance;
    [field: SerializeField] public FactoryBase barrackFactory;

    private void Awake()
    {
        Instance = this;
    }



}
