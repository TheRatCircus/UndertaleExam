using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemObject", menuName = "ItemObjects/HealtItem")]
public class ItemObject : ScriptableObject
{
    public string Name;

    public float HealAmmount;
}
