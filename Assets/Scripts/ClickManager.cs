using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [Header("Click Related Values")]
    [SerializeField] private int _clickValue;
    [SerializeField] private int _clickDamage;
    [SerializeField] public static float bankedClicks;

    [Header("Text Components")]
    [SerializeField] private Text _clickValueText;
    [SerializeField] private Text _bankedClicksText;

    private BossManager _bm;

    private void Start()
    {
        _bm = GetComponent<BossManager>();
    }

    private void Update()
    {
        UpdateBankedClickText();
    }

    public void ClickButton()
    {
        _clickDamage = Random.Range(1, 4);
        DisplayClickValue(_clickDamage);
        _bm.DamageBoss(_clickDamage);
        bankedClicks += _clickValue;
    }

    private void DisplayClickValue(int clickValue)
    {
        _clickValueText.text = clickValue.ToString();
    }

    private void UpdateBankedClickText()
    {
        _bankedClicksText.text = bankedClicks.ToString("0");
    }
}
