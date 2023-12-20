using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    private TMP_Text _score;

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.GoldChanged += ShowGold;
    }

    private void OnDisable()
    {
        _player.GoldChanged -= ShowGold;
    }

    private void ShowGold(int gold)
    {
        _score.text = gold.ToString();
    }
}
