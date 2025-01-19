using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>: MonoBehaviour where T : MonoBehaviour
{
    private static T instance_;
    public static T instance
    {
        get
        {
            if(instance_ == null)
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<T>();
                gameObject.name = typeof(T).ToString();
                instance_ = gameObject.GetComponent<T>();
            }    
            return instance_;
        }
    }

    private void Awake()
    {
        instance_ = gameObject.GetComponent<T>();
        OnAwake();
    }
    public virtual void OnAwake()
    {

    }
    private void Reset()
    {
        gameObject.name = typeof(T).ToString();
    }
}
