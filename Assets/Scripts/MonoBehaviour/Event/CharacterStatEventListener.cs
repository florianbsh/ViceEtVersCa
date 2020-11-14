using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatEventListener : MonoBehaviour
{
    public CharacterStatEvent_SO Event;
    public Events.CharacterStatEvent Response;

    private void OnEnable()
    {
        this.Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.Event.UnregisterListener(this);
    }

    public void OnEventRaised(CharacterStat characterStat)
    {
        this.Response.Invoke(characterStat);
    }

}
