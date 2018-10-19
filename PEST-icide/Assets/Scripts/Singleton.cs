using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <T> specifies the class as generic, meaning it doesn't know the type until runtime
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

    private static T privateInstance;

    public static T publicInstance
    {
        get
        {
            // Check if privateInstance is null
            if(privateInstance == null)
            {
                // Try to find it in the scene
                privateInstance = GameObject.FindObjectOfType<T>();

                if(privateInstance == null)
                {
                    // If privateInstance returns null again, we have to create it
                    GameObject singleton = new GameObject(typeof(T).Name);
                    privateInstance = singleton.AddComponent<T>();
                }
            }

            return privateInstance;
        }
    }

    // This function ensures pesistance of the singleton between Scenes
    // Made as a virtual function so that classes that extend singleton can override this function
    public virtual void Awake()
    {
        if(privateInstance == null)
        {
            privateInstance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
