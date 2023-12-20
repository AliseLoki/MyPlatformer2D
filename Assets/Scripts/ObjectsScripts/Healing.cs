using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int _healingPower;

    public int HealingPower => _healingPower;
}
