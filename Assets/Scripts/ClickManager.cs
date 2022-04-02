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
    [SerializeField] public static bool shouldCrit;

    [Header("Text Components")]
    [SerializeField] private Text _bankedClicksText;

    [SerializeField] private RectTransform _damageNumberBounds;
    [SerializeField] private GameObject _damageNumberPrefab;

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
        if (shouldCrit)
        {
            //int critRoll = Random
        }
        _bm.DamageBoss(_clickDamage);
        InstantiateDamageNumbers();
        bankedClicks += _clickValue;
    }

    private void InstantiateDamageNumbers()
    {
        Vector3 spawnPosition = GetBottomleftCorner(_damageNumberBounds) - new Vector3(Random.Range(0, _damageNumberBounds.rect.x), Random.Range(0, _damageNumberBounds.rect.y), 0);
        GameObject dmgText = Instantiate(_damageNumberPrefab, spawnPosition, Quaternion.identity, _damageNumberBounds);
        dmgText.GetComponent<Text>().text = _clickDamage.ToString();
    }

    private Vector3 GetBottomleftCorner(RectTransform rt)
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        return v[0];
    }

    private void UpdateBankedClickText()
    {
        _bankedClicksText.text = bankedClicks.ToString("0");
    }
}
