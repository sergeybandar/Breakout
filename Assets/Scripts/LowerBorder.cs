using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBorder : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (ball.IsRun)
            {
                _audioSource.Play();
            }
        }
    }
}
