using UnityEngine;
using UnityEngine.UI;

public class InfoController : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Image productImage;
    [SerializeField] private Text productNameText;
    [SerializeField] private Button produceButton;
    private Transform GameObjTransform;
    private void OnEnable()
    {
        InGameEventManager.OnBuildableClicked += OnBuildableClickedHandler;

    }
    private void OnDisable()
    {
        InGameEventManager.OnBuildableClicked -= OnBuildableClickedHandler;

    }

    private void OnBuildableClickedHandler(BuildableItem item, Transform objTransform)
    {
        image.sprite = item.UiIcon;
        nameText.text = item.Name;
        GameObjTransform = objTransform;
        if (item.Product != null)
        {
            productImage.enabled = true;
            productNameText.enabled = true;
            productImage.sprite = item.ProductIcon;
            productNameText.text = item.ProductName;
            produceButton.enabled = true;
        }
        else
        {
            productImage.enabled = false;
            productNameText.enabled = false;
            produceButton.enabled = false;
        }
    }

    public void ProduceButton()
    {
        FactoryManager.Instance.barrackFactory.Produce(GameObjTransform);
    }

}
