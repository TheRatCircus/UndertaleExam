using UnityEngine;

public class MenuStart : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableObject", 2f);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
