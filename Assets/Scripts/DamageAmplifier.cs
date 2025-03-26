using UnityEngine;

public class DamageAmplifier : MonoBehaviour
{
    public Attack attackScript; 
    private float damageMultiplier = 1f;
    private string currentTag = ""; 
    private string previousTag = ""; 

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag != currentTag)
        {
            // Log the tag of the object the collider is touching
            Debug.Log("Entered collider with tag: " + collider.tag);

            // Update the damage multiplier based on the new tag
            switch (collider.tag)
            {
                case "Red": // Red tag (1x damage)
                    damageMultiplier = 1f;
                    break;
                case "Yellow": // Yellow tag (1.50x damage)
                    damageMultiplier = 1.50f;
                    break;
                case "Green": // Green tag (1.75x damage)
                    damageMultiplier = 1.75f;
                    break;
                case "Blue": // Blue tag (no damage)
                    damageMultiplier = 0f;
                    break;
                default:
                    damageMultiplier = 1f; // Default (if it's an unexpected tag, normal damage)
                    break;
            }

            currentTag = collider.tag;
            previousTag = currentTag; // Track the last active tag


            if (attackScript != null)
            {
                attackScript.SetDamageMultiplier(damageMultiplier);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == currentTag)
        {
            // Log the tag of the object the collider is exiting
            Debug.Log("Exited collider with tag: " + collider.tag);

            currentTag = ""; // Clear the current tag to reset
            damageMultiplier = 1f; // Reset the multiplier to default

            if (attackScript != null)
            {
                attackScript.SetDamageMultiplier(damageMultiplier);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        // Continuously update multiplier if needed while inside a trigger zone
        if (collider.tag != currentTag)
        {
            Debug.Log("Staying in collider with tag: " + collider.tag);

            switch (collider.tag)
            {
                case "Red": // Red tag (1.25x damage)
                    damageMultiplier = 1.25f;
                    break;
                case "Yellow": // Yellow tag (1.50x damage)
                    damageMultiplier = 1.50f;
                    break;
                case "Green": // Green tag (1.75x damage)
                    damageMultiplier = 1.75f;
                    break;
                case "Blue": // Blue tag (no damage)
                    damageMultiplier = 0f;
                    break;
                default:
                    damageMultiplier = 1f; // Default (if it's an unexpected tag, normal damage)
                    break;
            }

            currentTag = collider.tag;

            if (attackScript != null)
            {
                attackScript.SetDamageMultiplier(damageMultiplier);
            }
        }
    }
}
