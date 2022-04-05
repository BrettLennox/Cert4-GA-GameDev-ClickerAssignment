using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [Header("Click Related Values")]
    [SerializeField] public int clickValue;
    [SerializeField] public int clickDamage;
    [SerializeField] public int clickDamageMultiplier = 1;
    [SerializeField] public static float bankedClicks;
    [SerializeField] public static bool shouldCrit;

    [Header("Text Components")]
    [SerializeField] private Text _bankedClicksText;

    [SerializeField] private RectTransform _damageNumberBounds;
    [SerializeField] private GameObject _damageNumberPrefab;

    private BossManager _bossManager;

    private void Start()
    {
        _bossManager = GetComponent<BossManager>();
    }

    private void Update()
    {
        UpdateBankedClickText();
    }

    public void ClickButton()
    {
        //sets clickDamage to a random
        clickDamage = Random.Range(1, 4);
        //multiplies clickDamage by clickDamageMultiplier
        clickDamage *= clickDamageMultiplier;
        //calls ClickDamageBoss from bossManager script
        _bossManager.ClickDamageBoss(clickDamage);
        //calls the InstantiateDamageNumbers method
        InstantiateDamageNumbers();
        //increase bankedClicks by clickValue
        bankedClicks += clickValue;
    }

    private void InstantiateDamageNumbers()
    {
        //sets the spawn position for the damageNumbers within the bounds of the damageNumberBounds gameobject
        Vector3 spawnPosition = GetBottomleftCorner(_damageNumberBounds) - new Vector3(Random.Range(0, _damageNumberBounds.rect.x), Random.Range(0, _damageNumberBounds.rect.y), 0);
        //instantiate dmgText and adjust its text to display clickDamage
        GameObject dmgText = Instantiate(_damageNumberPrefab, spawnPosition, Quaternion.identity, _damageNumberBounds);
        dmgText.GetComponent<Text>().text = clickDamage.ToString();
    }

    //this function creates a Vector3 list that stores the values of the corners fed in and then returns the positions of the first element in the list
    private Vector3 GetBottomleftCorner(RectTransform rt)
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        return v[0];
    }

    private void UpdateBankedClickText()
    {
        //sets the bankedClicksText text to be the value of bankedClicks
        _bankedClicksText.text = bankedClicks.ToString("0");
    }
}
