using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private List<Sprite> _buildingSprites;
    private Image _buildingImage;

    private void Start()
    {
        _buildingImage = GetComponent<Image>();

        ChooseRandomSprite();
    }

    private void ChooseRandomSprite()
    {
        int randomNumber = Random.Range(0, _buildingSprites.Count);
        _buildingImage.sprite = _buildingSprites[randomNumber];
    }
}
