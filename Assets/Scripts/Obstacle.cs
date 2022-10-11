using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private static float _obstacleMoveSpeed = 5f;
    private SpriteRenderer _obstacleRenderer;
    [SerializeField] private Sprite[] _shipSprites;

    private Animator _cameraAnimator;

    private AudioManager _audioManager;
 
    private void Awake()
    {
        _cameraAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _obstacleRenderer = GetComponent<SpriteRenderer>();
        _obstacleRenderer.sprite = _shipSprites[Random.Range(0, _shipSprites.Length)];
    }

   
    // Update is called once per frame
    void Update()
    {
        // Obstacle movement
        transform.Translate(Vector2.down * _obstacleMoveSpeed * Time.deltaTime);

        // Destroys obstacle when it goes off screen
        if(transform.position.y <= -2)
        {
            Destroy(gameObject);
        }
    }


    // Collision against player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScreenShake();
            _audioManager.PlayDamageSound();
            collision.GetComponent<Player>().shipHealth--;
            Destroy(gameObject);
        }
    }


    // Shake screen
    private void ScreenShake()
    {
        if(UI.isScreenShakeEnabled == true)
        {
            _cameraAnimator.SetTrigger("Shake");
        }
    }
}
