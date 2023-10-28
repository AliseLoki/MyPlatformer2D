using System.Collections;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private PlayerDetector _detector;

    private Player _player;
    private Coroutine _following;

    private void OnEnable()
    {
        _detector.PlayerDetected += OnPlayerDetected;
        _detector.PlayerFound += SetPlayer;
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= OnPlayerDetected;
        _detector.PlayerFound -= SetPlayer;
    }

    private void SetPlayer(Player player)
    {
        _player = player;
    }

    private void OnPlayerDetected(bool detected)
    {
        if (detected)
        {
            StartFollow();
        }
        else
        {
            StopFollow();
        }
    }

    private void StartFollow()
    {
        _following = StartCoroutine(Following());
    }

    private void StopFollow()
    {
        if (_following != null)
            StopCoroutine(_following);
    }

    private IEnumerator Following()
    {
        while (enabled)
        {
            if (_player != null)
            {
                float targetPositionX = _player.transform.position.x;
                Vector3 followedTargetPosition = new Vector3(targetPositionX, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, followedTargetPosition,
                    _followSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
