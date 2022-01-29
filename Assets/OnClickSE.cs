using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSE : MonoBehaviour
{
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
