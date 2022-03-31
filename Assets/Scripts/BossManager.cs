using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Boss Data/Components")]
    [SerializeField] private int _bossReward;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private List<Sprite> _bossSprites;
    [SerializeField] private Image _bossImage;

    private void Start()
    {
        _healthSlider.maxValue = _maxHealth;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        UpdateBossHealthSlider();
    }

    public void DamageBoss(int damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        if (_currentHealth <= 0)
        {
            BossDeath();
            RespawnRandomBoss();
        }
    }

    private void BossDeath()
    {
        ClickManager.bankedClicks += _bossReward;
    }

    private void UpdateBossHealthSlider()
    {
        _healthSlider.value = _currentHealth;
    }

    private void RespawnRandomBoss()
    {
        SelectRandomBossImage();
        _currentHealth = _maxHealth;
    }

    private void SelectRandomBossImage()
    {
        int randomNumber = Random.Range(0, _bossSprites.Count);
        _bossImage.sprite = _bossSprites[randomNumber];
    }
}
