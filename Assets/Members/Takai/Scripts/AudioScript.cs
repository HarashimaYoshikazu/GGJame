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

    float _saveBGMVolume;
    float _saveSEVolume;

    bool _bgmCheck = true;
    bool _seCheck = true;
    void Start()
    {

    }

    public void SetBGM(float Volume)
    {
        _saveBGMVolume = Volume;
        if (!_bgmCheck)
            return;

        SoundManager.Instance.BGMVolume = Volume;
        //_audioMixer.SetFloat("BGMVolume", Volume);
    }
    public void SetSE(float Volume)
    {
        _saveSEVolume = Volume;
        if (!_seCheck)
            return;
        SoundManager.Instance.SEVolume = Volume;
        Debug.Log(SoundManager.Instance.SEVolume);
        //_audioMixer.SetFloat("SEVolume", Volume);
    }

    public void MuteBGM()
    {
        if (_bgmCheck)
        {
            _bgmCheck = false;
            _saveBGMVolume = SoundManager.Instance.BGMVolume;
            SoundManager.Instance.BGMVolume = 0;
        }
        else
        {
            _bgmCheck = true;
            SoundManager.Instance.BGMVolume = _saveBGMVolume;
        }
    }

    public void MuteSE()
    {
        if (_seCheck)
        {
            _seCheck = false;
            _saveSEVolume = SoundManager.Instance.SEVolume;
            SoundManager.Instance.SEVolume = 0;
        }
        else
        {
            _seCheck = true;
            SoundManager.Instance.SEVolume = _saveSEVolume;
        }
    }
}
