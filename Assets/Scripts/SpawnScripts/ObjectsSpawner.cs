using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private Transform[] _points;

    private void Start()
    {
        InitializeSpawnPoints();
        CreateObject();
    }

    private void InitializeSpawnPoints()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _points[i] = transform.GetChild(i);
    }

    private void CreateObject()
    {
        foreach (var point in _points)
            Instantiate(_prefab, point);
    }
}
