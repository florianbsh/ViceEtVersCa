using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntGameEventListener : MonoBehaviour
{
    public IntGameEvent_SO Event;
    public Events.IntEvent Response;

    private void OnEnable()
    {
        this.Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.Event.UnregisterListener(this);
    }

    public void OnEventRaised(int value)
    {
        this.Response.Invoke(value);
    }
}
