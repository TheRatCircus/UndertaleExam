using UnityEngine;

public class MenuStart : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableObject", 4f);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
