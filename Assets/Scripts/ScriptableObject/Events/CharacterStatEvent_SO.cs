using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatEvent_SO : ScriptableObject
{
    private List<CharacterStatEventListener> listeners = new List<CharacterStatEventListener>();

    public void Raise(CharacterStat characterStat)
    {
        for (int i = this.listeners.Count - 1; i >= 0; --i)
        {
            this.listeners[i].OnEventRaised(characterStat);
        }
    }

    public void RegisterListener(CharacterStatEventListener listener)
    {
        this.listeners.Add(listener);
    }

    public void UnregisterListener(CharacterStatEventListener listener)
    {
        this.listeners.Remove(listener);
    }
}
