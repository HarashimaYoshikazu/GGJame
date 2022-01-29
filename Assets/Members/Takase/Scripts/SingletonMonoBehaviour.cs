using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance = null;

    public static T I => Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<T>();
            OnAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 継承先で初期化処理が必要な場合、ここに記述
    /// </summary>
    protected virtual void OnAwake()
    {
    }

    private void OnDestroy()
    {
        Dispose();
    }

    private void OnApplicationQuit()
    {
        Dispose();
    }

    private void Dispose()
    {
        Instance = null;
        OnDispose();
    }

    protected virtual void OnDispose()
    {

    }
}
