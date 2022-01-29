using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using Sounds;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    [Header("音量を設定するスライダー")]
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _seSlider;

    void Start()
    {

    }

    public void SetBGM(float Volume)
    {
        SoundManager.Instance.BGMVolume = Volume;
        //_audioMixer.SetFloat("BGMVolume", Volume);
    }
    public void SetSE(float Volume)
    {
        SoundManager.Instance.SEVolume = Volume;
        Debug.Log(SoundManager.Instance.SEVolume);
        //_audioMixer.SetFloat("SEVolume", Volume);
    }

}
