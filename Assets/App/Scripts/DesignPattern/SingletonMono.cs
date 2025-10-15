using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T singleton;

    public static bool IsInstanceValid() { return singleton != null; }

    void Reset()
    {
        gameObject.name = typeof(T).Name;
    }

    public static T instance
    {
        get
        {
            if (SingletonMono<T>.singleton == null)
            {
                SingletonMono<T>.singleton = (T)FindObjectOfType(typeof(T));
                if (SingletonMono<T>.singleton == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "[@" + typeof(T).Name + "]";
                    SingletonMono<T>.singleton = obj.AddComponent<T>();
                }
            }

            return SingletonMono<T>.singleton;
        }
    }

    public static T I
    {
        get { return instance; }
    }
}
