using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Block.onBreakeBloack += BreakBlockAudio;

    }
    private void BreakBlockAudio()
    {
        _audioSource.Play();
    }
    
}
