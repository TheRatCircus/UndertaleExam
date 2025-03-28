using UnityEngine;

public class DisableOnX : MonoBehaviour
{
    public GameObject objectToDisable;
    public ButtonNavigator buttonNavigator;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            buttonNavigator.EnableNavigation();

        }
    }
}
