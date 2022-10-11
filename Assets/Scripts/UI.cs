using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private Player _playerController;
    [SerializeField] private TMP_Text _highscoreText;
    [SerializeField] private int _highScore = 0;
    public static bool hasGameBegan = false;
    [SerializeField] private GameObject _gameMenu;

    [SerializeField] private TMP_Text _lifeText;
    [SerializeField] private GameObject _lifeicon;

    private AudioManager _audioManager;
    private bool _isGameOver = false;

    List<GameObject> Enemies = new List<GameObject>();

    public static bool isScreenShakeEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _playerController = GameObject.Find("Player").GetComponent<Player>();
        scoreText.enabled = false;
        _lifeicon.SetActive(false);
        _lifeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Enemies.Add(enemy);
        }
        // Game over 
        if(_playerController.shipHealth <= 0)
        {
            foreach (GameObject enemy in Enemies)
            {
                Destroy(enemy);
            }
            //_audioManager.PlayGameOverSound();
            _isGameOver = true;
            hasGameBegan = false;
            _gameMenu.SetActive(true);
            scoreText.enabled = false;
            _lifeicon.SetActive(false);
            _lifeText.enabled = false;
        }
        // Highscore
        if(_highScore < _playerController.playerScore)
        {
            _highScore = _playerController.playerScore;
            _highscoreText.text = _playerController.playerScore.ToString();
        }
        scoreText.text = _playerController.playerScore.ToString();
        _lifeText.text = _playerController.shipHealth.ToString();

    }
    public void StartButton()
    {
          hasGameBegan = true;
          _gameMenu.SetActive(false);
        scoreText.enabled = true;
        _lifeicon.SetActive(true);
        _lifeText.enabled = true;

        if (_isGameOver == true)
        {
            Reset();
        }
    }

    private void Reset()
    {
        hasGameBegan = true;
        _gameMenu.SetActive(false);
        _playerController.shipHealth = 3;
        _playerController.playerScore = 0;
        _isGameOver = false;
        scoreText.enabled = true;
        _lifeicon.SetActive(true);
        _lifeText.enabled = true;
    }


    // Toggle screen shake
    public void ShakeToggle(bool toggle)
    {
        isScreenShakeEnabled = toggle;
    }
}
