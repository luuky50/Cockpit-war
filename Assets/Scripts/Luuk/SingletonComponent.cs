using UnityEngine;

public abstract class SingletonComponent<T> : MonoBehaviour where T : SingletonComponent<T>
{
    private static T _instance = null;

    /// <summary>Get the instance of this class.</summary>
    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    /// <remarks>
    ///     Protected because this shouldn't be used outside its class hierarchy.
    ///     Virtual so we can put the singleton instance logic here which will be used when this class is extended.
    /// </remarks>
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = (T)this;
        }
    }
}
