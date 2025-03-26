using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UpDownNavigator : MonoBehaviour
{
    public Button[] buttons;
    private int currentIndex = 0;

    void Start()
    {
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SetUpEventTriggers();
    }

    private void SetUpEventTriggers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            EventTrigger trigger = buttons[i].gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry hoverEntry = new EventTrigger.Entry();
            hoverEntry.eventID = EventTriggerType.PointerEnter;
            trigger.triggers.Add(hoverEntry);

            EventTrigger.Entry selectEntry = new EventTrigger.Entry();
            selectEntry.eventID = EventTriggerType.PointerClick;
            trigger.triggers.Add(selectEntry);
        }
    }

    public void UpdateButtons(List<Button> newButtons)
    {
        buttons = newButtons.ToArray(); 
        SetUpEventTriggers(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Navigate(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
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

    void PressButton()
    {
        buttons[currentIndex].onClick.Invoke();
    }
}
