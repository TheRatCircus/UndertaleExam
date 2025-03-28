using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigator : MonoBehaviour
{
    public Button[] buttons; 
    public GameObject[] objectsToEnable; 
    private int currentIndex = 0;
    private bool navigationEnabled = true;

    void Start()
    {
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            EventTrigger trigger = buttons[i].gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry hoverEntry = new EventTrigger.Entry();
            hoverEntry.eventID = EventTriggerType.PointerEnter;
            hoverEntry.callback.AddListener((eventData) => EnableObject(index));
            trigger.triggers.Add(hoverEntry);

            EventTrigger.Entry selectEntry = new EventTrigger.Entry();
            selectEntry.eventID = EventTriggerType.PointerClick;
            selectEntry.callback.AddListener((eventData) => DisableObject(index));
            trigger.triggers.Add(selectEntry);
        }
    }

    void Update()
    {
        if (!navigationEnabled) return;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            return; // Ignore Enter key input
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Navigate(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Navigate(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            PressButton();
        }
    }


    void Navigate(int direction)
    {
        currentIndex += direction;
        if (currentIndex >= buttons.Length) currentIndex = 0;
        if (currentIndex < 0) currentIndex = buttons.Length - 1;

        EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
    }

    void EnableObject(int index)
    {
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(i == index);
        }
    }

    void DisableObject(int index)
    {
        objectsToEnable[index].SetActive(false);
    }

    void PressButton()
    {
        buttons[currentIndex].onClick.Invoke();
        DisableObject(currentIndex);
        navigationEnabled = false; 
    }

    public void EnableNavigation()
    {
        navigationEnabled = true;
    }
}
