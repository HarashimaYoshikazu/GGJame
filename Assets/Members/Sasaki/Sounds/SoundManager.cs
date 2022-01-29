using System.Collections.Generic;
using UnityEngine;
using Pools;

namespace Sounds
{
    public enum SoundGroupID
    {
        BGM,
        SE,

        None,
    }

    public class SoundManager : MonoBehaviour
    {
        // どこからでも呼び出せるように
        private static SoundManager _instance = null;
        public static SoundManager Instance => _instance;

        [Range(0, 1)] public float MasterVolume;
        [Range(0, 1)] public float BGMVolume;
        [Range(0, 1)] public float SEVolume;
        [SerializeField] SoundEffect _soundEffect;
        [SerializeField] int _poolCount;
        [SerializeField] List<SoundGroup> _soundGroups;

        float _saveMasterVolume;

        [System.Serializable]
        class SoundGroup
        {
            public SoundDataBase SoundDataBase;
            public SoundGroupID SoundGroupID;
        }

        ObjectPool<SoundEffect> _soundPool;
        List<SoundEffect> _loopSounds = new List<SoundEffect>();
        
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _saveMasterVolume = MasterVolume;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
            _soundPool = new ObjectPool<SoundEffect>(_soundEffect, _poolCount, transform);
        }

        /// <summary>
        /// 鳴らす音源をRequesut. 名前で検索
        /// </summary>
        /// <param name="name">Soundの名前</param>
        /// <param name="groupID">GrounpID</param>
        static public void Request(string name, SoundGroupID groupID)
        {
            SoundGroup group = Instance._soundGroups.Find(s => s.SoundGroupID == groupID);
            if (group == null) Debug.Log("Missing. Nothing SoundData");

            SoundData data = group.SoundDataBase.Datas.Find(s => s.Name == name);
            if (data == null) Debug.Log("Missing. Don't MatchName");

            SoundEffect effect = Instance._soundPool
                    .UseRequest().GetComponent<SoundEffect>();

            effect.SetEffectData(data);
            if (data.Loop) Instance._loopSounds.Add(effect);
        }

        /// <summary>
        /// 鳴らす音源をRequesut. IDで検索
        /// </summary>
        /// <param name="id">SoundのID</param>
        /// <param name="groupID">GrounpID</param>
        static public void Request(int id, SoundGroupID groupID)
        {
            SoundGroup group = Instance._soundGroups.Find(s => s.SoundGroupID == groupID);
            if (group == null) Debug.Log("Missing. Nothing SoundData");

            SoundData data = group.SoundDataBase.Datas.Find(s => s.ID == id);
            if (data == null) Debug.Log("Missing. Don't MatchID");

            SoundEffect effect = Instance._soundPool
                    .UseRequest().GetComponent<SoundEffect>();

            effect.SetEffectData(data);
            if (data.Loop) Instance._loopSounds.Add(effect);
        }

        /// <summary>
        /// 現在流れているLoop音源の削除. Nameで検索
        /// </summary>
        /// <param name="name">削除するSoundName</param>
        static public void DeleteLoopSounds(string name)
        {
            if (Instance._loopSounds.Count <= 0) Debug.Log("Nothing DeleteData");

            SoundEffect effect = Instance._loopSounds.Find(s => s.Name == name);
            effect.Action.Invoke();
        }

        /// <summary>
        /// 現在流れているLoop音源の削除. IDで検索
        /// </summary>
        /// <param name="id">削除するSoundID</param>
        static public void DeleteLoopSounds(int id)
        {
            if (Instance._loopSounds.Count <= 0) Debug.Log("Nothing DeleteData");

            SoundEffect effect = Instance._loopSounds.Find(s => s.ID == id);
            effect.Action.Invoke();
        }

        static public void Mute(bool check)
        {
            if (!check) Instance.MasterVolume = 0;
            else Instance.MasterVolume = Instance._saveMasterVolume;
        }
    }
}
