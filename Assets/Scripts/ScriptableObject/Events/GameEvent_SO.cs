using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/SimpleEvent")]
public class GameEvent_SO : ScriptableObject
{
    protected List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = this.listeners.Count - 1; i >= 0; --i)
        {
            this.listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        this.listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        this.listeners.Remove(listener);
    }
}
