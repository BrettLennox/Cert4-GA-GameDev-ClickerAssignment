using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [Header("Click Related Values")]
    [SerializeField] private int _clickValue;
    [SerializeField] private int _clickDamage;
    [SerializeField] private float _bankedClicks;

    [Header("Text Components")]
    [SerializeField] private Text _clickValueText;
    [SerializeField] private Text _bankedClicksText;

    [Header("Boss Data/Components")]
    [SerializeField] private float _bossCurrentHealth;
    [SerializeField] private float _bossMaxHealth;
    [SerializeField] private Slider _bossHealthSlider;

    private void Start()
    {
        _bossHealthSlider.maxValue = _bossMaxHealth;
        _bossCurrentHealth = _bossMaxHealth;
    }

    private void Update()
    {
        UpdateBankedClickText();
        UpdateBossHealthSlider();
    }

    public void ClickButton()
    {
        _clickDamage = Random.Range(1, 4);
        DisplayClickValue(_clickDamage);
        DamageBoss(_clickDamage);
        _bankedClicks += _clickValue;
    }

    private void DisplayClickValue(int clickValue)
    {
        _clickValueText.text = clickValue.ToString();
    }

    private void UpdateBankedClickText()
    {
        _bankedClicksText.text = _bankedClicks.ToString("0");
    }

    private void DamageBoss(int damage)
    {
        _bossCurrentHealth = Mathf.Max(_bossCurrentHealth - damage, 0);
        if(_bossCurrentHealth <= 0)
        {
            Debug.Log("BOSS DIED");
        }
    }

    private void UpdateBossHealthSlider()
    {
        _bossHealthSlider.value = _bossCurrentHealth;
    }
}
