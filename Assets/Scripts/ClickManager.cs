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
    [SerializeField] private int _bossReward;
    [SerializeField] private float _bossCurrentHealth;
    [SerializeField] private float _bossMaxHealth;
    [SerializeField] private Slider _bossHealthSlider;
    [SerializeField] private List<Sprite> _bossSprites;
    [SerializeField] private Image _bossImage;

    [Header("Buildings Data/Components")]
    [SerializeField] private int _buildingCost;
    [SerializeField] private int _buildingCount;
    [SerializeField] private float _buildingDamage = 1f;
    [SerializeField] private GameObject _buildingPrefab;
    [SerializeField] private GameObject _buildingParent;

    [SerializeField] private float timer;

    private void Start()
    {
        _bossHealthSlider.maxValue = _bossMaxHealth;
        _bossCurrentHealth = _bossMaxHealth;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateBankedClickText();
        UpdateBossHealthSlider();
        BuildingsDamageBoss();
    }

    public void ClickButton()
    {
        _clickDamage = Random.Range(1, 4);
        DisplayClickValue(_clickDamage);
        DamageBoss(_clickDamage);
        _bankedClicks += _clickValue;
    }

    public void PurchaseBuildingButton()
    {
        if(_bankedClicks >= _buildingCost)
        {
            _bankedClicks -= _buildingCost;
            _buildingCount++;
            Instantiate(_buildingPrefab, _buildingParent.transform);
        }
        else
        {
            Debug.Log("INSUFFICIENT FUNDS");
        }
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
            BossDeath();
            RespawnRandomBoss();
        }
    }

    private void UpdateBossHealthSlider()
    {
        _bossHealthSlider.value = _bossCurrentHealth;
    }

    private void BossDeath()
    {
        _bankedClicks += _bossReward;
    }

    private void RespawnRandomBoss()
    {
        SelectRandomBossImage();
        _bossCurrentHealth = _bossMaxHealth;
    }

    private void SelectRandomBossImage()
    {
        int randomNumber = Random.Range(0, _bossSprites.Count);
        _bossImage.sprite = _bossSprites[randomNumber];
    }

    private void BuildingsDamageBoss()
    {
        if (timer >= 1 && _buildingCount >= 1)
        {
            DamageBoss(_buildingCount * (int)_buildingDamage);
            _bankedClicks += _clickValue * _buildingCount;
            timer = 0f;
        }
    }
}
