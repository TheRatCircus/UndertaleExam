using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemObject> objectList;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private UpDownNavigator upDownNavigator;

    private void Start()
    {
        if (upDownNavigator == null)
        {
            Debug.LogWarning("UpDownNavigator not assigned!");
            return;
        }

        SpawnObjects();
    }

    private void SpawnObjects()
    {
        if (prefabToSpawn == null || objectList == null || objectList.Count == 0)
        {
            Debug.LogWarning("Missing references or empty list!");
            return;
        }

        List<Button> spawnedButtons = new List<Button>();

        for (int i = 0; i < objectList.Count; i++)
        {
            GameObject newObject = Instantiate(prefabToSpawn, transform);
            newObject.name = objectList[i].Name;

            Text textComponent = newObject.GetComponentInChildren<Text>();
            if (textComponent != null)
            {
                textComponent.text = $"{objectList[i].Name}";
            }

            Button button = newObject.GetComponent<Button>();
            if (button != null)
            {
                ItemButton itemButton = newObject.GetComponent<ItemButton>();
                if (itemButton != null)
                {
                    itemButton.itemObject = objectList[i];  
                }

                spawnedButtons.Add(button);
            }
        }

        upDownNavigator.UpdateButtons(spawnedButtons);
    }
}
