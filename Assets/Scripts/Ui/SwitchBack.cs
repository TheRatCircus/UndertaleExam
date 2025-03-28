using UnityEngine;
using System.Collections;


public class SwitchBack : MonoBehaviour
{
    public Animator animator;
    public GameObject objectToDisable;
    public ButtonNavigator buttonNavigator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAnimationAndDisableObject();
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
            StartCoroutine(EnableNavigationAfterDelay(1f));
            Debug.Log("Animation triggered and object disabled.");
        }
        else
        {
            Debug.LogWarning("Missing references! Ensure all fields are properly assigned.");
        }
    }

    // Coroutine to enable navigation after a delay
    private IEnumerator EnableNavigationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        buttonNavigator.EnableNavigation(); 
        Debug.Log("Navigation enabled after delay.");
    }
}
