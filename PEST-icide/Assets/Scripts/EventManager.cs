using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {
    // Dictionary for keeping track of events
    private Dictionary<string, UnityEvent> eventDictionary;

    public static EventManager instance = null;

    // Awake() runs before any Start() calls 
    // Enforces the singleton pattern
    private void Awake()
    {
        // Check if instance exists
        if (instance == null)
        {
            // If not, set the game manager to this
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Ensures that this persists between scenes
        DontDestroyOnLoad(gameObject);

        // Initializes the event dictionary
        InitializeDictionary();
    }

    // Initializing the event dictionary
    void InitializeDictionary()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        // Creating an empty UnityEvent
        UnityEvent currentEvent = null;

        // Attempting to get the key and its associated value as specified in the function call
        if (instance.eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.AddListener(listener);
        }

        // In case the above statement is not true, we will create a new UnityEvent, add a listener to it and add it to the event dictionary
        else
        {
            currentEvent = new UnityEvent();
            currentEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, currentEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        // Checking to see if the eventmanager exists so that we don't get any errors
        if (instance == null)
            return;

        // Creating empty UnityEvent like in StartListening
        UnityEvent currentEvent = null;

        if(instance.eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.RemoveListener(listener);
        }

    }

    public static void TriggerEvent(string eventName)
    {
        // Creating empty UnityEvent
        UnityEvent currentEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.Invoke();
        }
    }

}
