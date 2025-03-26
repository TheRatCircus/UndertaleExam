using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject objectToControl;
    public ItemObject itemObject;
    private HealthSystem playerHealth;
    private Button button;
    private SwitchObject switchObject; 

    void Start()
    {
        playerHealth = FindObjectOfType<HealthSystem>();
        if (playerHealth == null)
        {
            Debug.LogWarning("HealthSystem not found in the scene.");
        }

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        switchObject = FindObjectOfType<SwitchObject>();
        if (switchObject == null)
        {
            Debug.LogWarning("SwitchObject not found in the scene.");
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (objectToControl != null)
        {
            objectToControl.SetActive(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (objectToControl != null)
        {
            objectToControl.SetActive(false);
        }
    }

    private void OnButtonClick()
    {
        if (itemObject != null && playerHealth != null)
        {
            playerHealth.Heal((int)itemObject.HealAmmount);
        }

        GameObject itemUi = GameObject.FindGameObjectWithTag("ItemUi");
        if (itemUi != null)
        {
            itemUi.SetActive(false);  
        }

        if (switchObject != null)
        {
            switchObject.StartAnimationWithDelay(); 
        }
    }
}
