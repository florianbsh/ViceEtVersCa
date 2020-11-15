using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEventListener : MonoBehaviour
{
    public GameObjectEvent_SO Event;
    public Events.GameObjectEvent Response;

    private void OnEnable()
    {
        this.Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject value)
    {
        this.Response.Invoke(value);
    }
}
