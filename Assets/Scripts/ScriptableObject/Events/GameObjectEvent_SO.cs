using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameObjectEvent")]
public class GameObjectEvent_SO : ScriptableObject
{
    private List<GameObjectEventListener> listeners = new List<GameObjectEventListener>();

    public void Raise(GameObject value)
    {
        for (int i = this.listeners.Count - 1; i >= 0; --i)
        {
            this.listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameObjectEventListener listener)
    {
        this.listeners.Add(listener);
    }

    public void UnregisterListener(GameObjectEventListener listener)
    {
        this.listeners.Remove(listener);
    }
}
