using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance = null;

    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = (T)(this);
        DontDestroyOnLoad(gameObject);
    }
}
