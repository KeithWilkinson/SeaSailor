using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _targetPos;
    [SerializeField] private float _increment;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;

    private int _playerScore = 0;

    public float shipHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateScore", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        // Player movement and input
        if(UI.hasGameBegan == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > _minWidth)
            {
                _targetPos = new Vector2(transform.position.x - _increment, transform.position.y);
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < _maxWidth)
            {
                _targetPos = new Vector2(transform.position.x + _increment, transform.position.y);
            }
        }
        
    }

    // Adds to player's score each second
    void UpdateScore()
    {
        if(UI.hasGameBegan == true)
        {
            _playerScore++;
        }
    }

    public int playerScore
    {
        get { return _playerScore; }
        set { _playerScore = value; }
    }
}
