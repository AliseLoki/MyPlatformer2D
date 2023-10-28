using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPatroller _enemy;
    [SerializeField] private List<Transform> _wayPoints; 

    private void Awake()
    {
        EnemyPatroller enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.Initialize(_wayPoints);
    }
}
