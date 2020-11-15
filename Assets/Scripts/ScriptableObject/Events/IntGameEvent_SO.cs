using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/IntEvent")]
public class IntGameEvent_SO : ScriptableObject
{
    private List<IntGameEventListener> listeners = new List<IntGameEventListener>();

    public void Raise(int value)
    {
        for (int i = this.listeners.Count - 1; i >= 0; --i)
        {
            this.listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(IntGameEventListener listener)
    {
        this.listeners.Add(listener);
    }

    public void UnregisterListener(IntGameEventListener listener)
    {
        this.listeners.Remove(listener);
    }
}
