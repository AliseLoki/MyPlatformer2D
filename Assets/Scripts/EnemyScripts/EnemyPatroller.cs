using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private PlayerDetector _playerDetector;
   
    private int _currentIndex;
    private Coroutine _patrol;

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += OnPlayerDetected;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= OnPlayerDetected;
    }

    public void Initialize(List<Transform>points)
    {
       _targets = points;
        StartPatrol();
    }

    private void OnPlayerDetected(bool detected)
    {
        if (detected)
        {
            StopPatrol();
        }
        else
        {
            StartPatrol();
        }
    }

    private void ChangeWayPoint()
    {
        var rotationAngle = 180;

        if(_currentIndex == 0)
        {
            Rotate(0);
            _currentIndex = 1;
        }
        else
        {
            Rotate(rotationAngle);
            _currentIndex = 0;
        }
    }

    private void Rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0, angle,0);
    }

    private void StartPatrol()
    {
        _patrol = StartCoroutine(Patrolling());
    }

    private void StopPatrol()
    {
        if(_patrol != null)
        {
            StopCoroutine(_patrol);
        }
    }

    private IEnumerator Patrolling()
    {
        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targets[_currentIndex].position,
                _speed * Time.deltaTime);
            yield return null;

            if(transform.position == _targets[_currentIndex].position)
            {
                ChangeWayPoint();
            }
        }
    }
}
