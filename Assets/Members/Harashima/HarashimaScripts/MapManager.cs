using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���݂̓�Փx��State
/// </summary>
public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

/// <summary>
/// �}�b�v�𐶐��Ǘ�����N���X
/// </summary>
public class MapManager : MonoBehaviour
{
    [Header("��������}�b�v�̃v���n�u")]
    [SerializeField, Tooltip("�C�[�W�[")]
    GameObject[] _easyMapPrefubs;
    [SerializeField, Tooltip("�m�[�}��")]
    GameObject[] _normalMapPrefubs;
    [SerializeField, Tooltip("�n�[�h")]
    GameObject[] _hardMapPrefubs;

    [Header("�������")]
    [SerializeField, Tooltip("���񐶐��������Փx��ύX���邩")]
    int _changeTimes = 3;
    /// <summary>�����̃J�E���g</summary>
    int _instansCount;

    [SerializeField, Tooltip("�����̃C���^�[�o��")]
    float _interval;
    /// <summary>�����𔻒肷��^�C�}�[</summary>
    float _timer;

    /// <summary>���݂̃}�b�v�������Ă��郊�X�g</summary>
    List<GameObject> _currentMaps  = new List<GameObject>() ;

    [Header("�����|�W�V����")]
    [SerializeField, Tooltip("�����̐����|�W�V����")]
    Transform _initialTransform;
    [SerializeField,Tooltip("2��ڈȍ~�̐����|�W�V����")]
    Transform _instanceTransform;

    /// <summary>�ꎞ�I�ɗv�f���ɉ������l��ۑ����Ă��������_���ϐ�</summary>
    int _random;
    /// <summary>���݂̓�Փx</summary>
    Difficulty _currentDifficulty;

    void Start()
    {
        //�ŏ��̓�Փx��Easy�ŏ�����
        _currentDifficulty = Difficulty.Easy;
        //�ŏ��̂ݏ����ʒu�ɐ���
        _random = Random.Range(0,_easyMapPrefubs.Length);
        _currentMaps.Add(Instantiate(_easyMapPrefubs[_random], _initialTransform.position,Quaternion.identity));
    }

    void Update()
    {
        if (_normalMapPrefubs != null)
        {
            InstansMap(_currentDifficulty);
        }       
    }

    /// <summary>
    /// ��Փx�ɉ����Đ�������Map��ύX����֐�
    /// </summary>
    /// <param name="difficulty">���݂̓�Փx</param>
    void InstansMap(Difficulty difficulty)
    {
        _timer += Time.deltaTime;
        if (_interval< _timer)
        {
            switch (difficulty)
            {
                //�����_���ȃ}�b�v�v���n�u�𐶐�,List�Ɋi�[
                case Difficulty.Easy:
                    _random = Random.Range(0, _easyMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_easyMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
                    break;

                case Difficulty.Normal:
                    _random = Random.Range(0, _normalMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_normalMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
                    break;

                case Difficulty.Hard:
                    _random = Random.Range(0, _hardMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_hardMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
                    break;
            }
            //�^�C�}�[��0��
            _timer = 0;
            //����������J�E���g�𑝂₷
            _instansCount++;
            //��Փx�̔���
            ChangeDifficulty();
        }
    }

    /// <summary>
    /// ���Ԃɉ����ē�Փx��ύX����֐�
    /// </summary>
    void ChangeDifficulty()
    {
        //�����񐔂��K��񐔂𒴂������Փx���グ��
        if (_currentDifficulty == Difficulty.Easy)
        {
            return;
        }
        else if (_changeTimes*2 <= _instansCount && _hardMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Hard;
        }
        else if(_normalMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Normal;
        }
    }
}
