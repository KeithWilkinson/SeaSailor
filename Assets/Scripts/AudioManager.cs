using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _damageAudioSource;
    [SerializeField] private AudioSource _gameOverAudioSource;

    public void PlayDamageSound()
    {
        _damageAudioSource.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOverAudioSource.Play();
    }
}
