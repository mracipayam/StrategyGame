using UnityEngine;
using UnityEngine.UI;

public class InfoController : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    private void OnEnable()
    {
        InGameEventManager.OnBuildableClicked += OnBuildableClickedHandler;

    }
    private void OnDisable()
    {
        InGameEventManager.OnBuildableClicked -= OnBuildableClickedHandler;

    }

    private void OnBuildableClickedHandler(BuildableItem item)
    {
        Debug.Log("Clicked item name is : " + item.Name);
        image.sprite = item.UiIcon;
        nameText.text = item.Name;
    }

}
