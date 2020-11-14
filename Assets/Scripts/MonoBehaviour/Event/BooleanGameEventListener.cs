using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanGameEventListener : MonoBehaviour
{
    public BooleanGameEvent_SO Event;
    public Events.BooleanEvent Response;

    private void OnEnable()
    {
        this.Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.Event.UnregisterListener(this);
    }

    public void OnEventRaised(bool value)
    {
        this.Response.Invoke(value);
    }
}
