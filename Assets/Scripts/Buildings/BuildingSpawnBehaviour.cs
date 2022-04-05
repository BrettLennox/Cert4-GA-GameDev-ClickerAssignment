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
        //sets the sprite
        ChooseRandomSprite();
    }

    private void ChooseRandomSprite()
    {
        //choose a random number between 0 and the length of the buildingSprites list
        int randomNumber = Random.Range(0, _buildingSprites.Count);
        //set the sprite to the buildsprites sprite at the randomNumber element
        _buildingImage.sprite = _buildingSprites[randomNumber];
    }
}
