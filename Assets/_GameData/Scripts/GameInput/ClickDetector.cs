using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("You touched " + gameObject.name);
    }
}
