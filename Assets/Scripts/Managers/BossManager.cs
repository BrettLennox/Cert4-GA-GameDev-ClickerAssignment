using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Boss Data/Components")]
    [SerializeField] private int _bossReward;
    [SerializeField] private float _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private List<Sprite> _bossSprites;
    [SerializeField] private Image _bossImage;

    private void Start()
    {
        SelectRandomBossImage();
        _healthSlider.maxValue = _maxHealth;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        UpdateBossHealthSlider();
    }

    public void ClickDamageBoss(int damage)
    {
        //sets the value of currentHealth to be whatever is the larger number
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
    }

    public void BuildingDamageBoss(float damage)
    {
        //uses Mathf.Lerp to move the bosses currentHealth from its current amount to the amount it would be after damage over a set amount of time
        _currentHealth = Mathf.Lerp(_currentHealth, _currentHealth - damage, 1f * Time.deltaTime);
        //if the currentHealth value is or falls below 0
        if (_currentHealth <= 0)
        {
            //call these functions
            BossDeath();
            SelectRandomBossImage();
        }
    }

    private void BossDeath()
    {
        //increases banked clicks by the boss reward value
        ClickManager.bankedClicks += _bossReward;
        //increases the boss maxHealth and reward and sets its currentHealth back to maxHealth
        _maxHealth *= 2;
        _bossReward *= 2;
        _currentHealth = _maxHealth;
        //adjusts the healthSlider maxValue to match its new maxHealth
        _healthSlider.maxValue = _maxHealth;
    }

    private void UpdateBossHealthSlider()
    {
        //adjusts the healthSlider value to match bosses currentHealth
        _healthSlider.value = _currentHealth;
    }

    private void SelectRandomBossImage()
    {
        //chooses a number between 0 and the bossSprite count
        int randomNumber = Random.Range(0, _bossSprites.Count);
        //sets the bossImage sprite to be from the bossSprites list at the element matching randomNumber
        _bossImage.sprite = _bossSprites[randomNumber];
    }
}
