using UnityEngine;
using Sounds;

public class SoundSetter : MonoBehaviour
{
    [SerializeField] string _bgmName;

    void Start()
    {
        if (_bgmName == "") return;
        SoundManager.Request(_bgmName, SoundGroupID.BGM);
    }

    public void OnClick(string seName)
    {
        SoundManager.Request(seName, SoundGroupID.SE);
    }

    public void OnClick(int seID)
    {
        SoundManager.Request(seID, SoundGroupID.SE);
    }
}
