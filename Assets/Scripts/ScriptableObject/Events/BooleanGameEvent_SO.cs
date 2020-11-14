using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanGameEvent_SO : ScriptableObject
{
    private List<BooleanGameEventListener> listeners = new List<BooleanGameEventListener>();

    public void Raise(bool value)
    {
        for (int i = this.listeners.Count - 1; i >= 0; --i)
        {
            this.listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(BooleanGameEventListener listener)
    {
        this.listeners.Add(listener);
    }

    public void UnregisterListener(BooleanGameEventListener listener)
    {
        this.listeners.Remove(listener);
    }
}
