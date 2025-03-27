using UnityEngine;

public class AttackDuration : MonoBehaviour
{
    public float duration = 4.2f;
    private SwitchBack switchBack;  // Reference to the SwitchBack script

    void Start()
    {
        // Find the SwitchBack script in the scene (if it's attached to an object)
        switchBack = FindObjectOfType<SwitchBack>();

        // Debug message to confirm if the SwitchBack script was found
        if (switchBack != null)
        {
            Debug.Log("Found SwitchBack script in the scene.");
        }
        else
        {
            Debug.LogWarning("SwitchBack script not found in the scene!");
        }
    }

    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0f)
        {
            if (switchBack != null)
            {
                // Destroy all children of the current object
                DestroyAllChildren();

                // Call the StartAnimationAndDisableObject before destroying the object
                switchBack.StartAnimationAndDisableObject();
            }
            else
            {
                Debug.LogWarning("SwitchBack script not found, skipping animation.");
            }

            // Destroy the object itself after triggering the animation
            Destroy(gameObject);
        }
    }

    private void DestroyAllChildren()
    {
        // Loop through all child objects and destroy them
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Debug message confirming all children were destroyed
        Debug.Log("Destroyed all children of: " + gameObject.name);
    }
}
