using UnityEngine;

public class AttackDuration : MonoBehaviour
{
    public float duration = 4.2f;
    private SwitchBack switchBack; 

    void Start()
    {
        switchBack = FindObjectOfType<SwitchBack>();

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
                DestroyAllChildren();

                switchBack.StartAnimationAndDisableObject();
            }
            else
            {
                Debug.LogWarning("SwitchBack script not found, skipping animation.");
            }

            Destroy(gameObject);
        }
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Destroyed all children of: " + gameObject.name);
    }
}
