using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BaseEnemyObject", menuName = "EnemyObjects/BaseEnemy")]
public class EnemyObjectt : ScriptableObject
{
    public string Name;

    public float Hp;

    [SerializeField]
    private List<GameObject> attackPrefabs = new List<GameObject>();

    public List<GameObject> AttackPrefabs => attackPrefabs;
}
