using UnityEngine;

public class SwitchBack : MonoBehaviour
{
    public Animator animator;  // Animator to trigger the animation
    public GameObject objectToDisable;  // Object to disable after the animation is triggered
    public ButtonNavigator buttonNavigator;

    void Update()
    {
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAnimationAndDisableObject();  // Call the method when space is pressed
        }
    }

    public void StartAnimationAndDisableObject()
    {
        TriggerAnimationAndDisable();
    }

    private void TriggerAnimationAndDisable()
    {
        if (animator != null && objectToDisable != null && buttonNavigator != null)
        {
            animator.SetTrigger("TextOut");
            objectToDisable.SetActive(false);
            buttonNavigator.EnableNavigation();
            Debug.Log("Animation triggered and object disabled.");
        }
        else
        {
            Debug.LogWarning("Missing references! Ensure all fields are properly assigned.");
        }
    }
}
