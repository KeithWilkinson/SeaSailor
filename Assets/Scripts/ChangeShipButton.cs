using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShipButton : MonoBehaviour
{
    [SerializeField] private Sprite _newShipSprite;
    private SpriteRenderer _playerRenderer;
    private SpriteRenderer _lifeRenderer;

    private bool _hasClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _lifeRenderer = GameObject.Find("LifeSprite").GetComponent<SpriteRenderer>();
    }

    // Change colour of ship
    public void ChangeColour()
    {
        _playerRenderer.sprite = _newShipSprite;
        _lifeRenderer.sprite = _newShipSprite;
        _hasClicked = true;
        if(_hasClicked == true)
        {
            _playerRenderer.sprite = _newShipSprite;
            _lifeRenderer.sprite = _newShipSprite;
            _hasClicked = false;
            _hasClicked = false;
        }
    }
}
