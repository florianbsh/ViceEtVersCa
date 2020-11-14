using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestCardMove : MonoBehaviour
{
    public UnityEvent CardSelectEvent = new UnityEvent();

    public UnityEvent CardDeselectEvent = new UnityEvent();

    public UnityEvent CardHideEvent = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.CardSelectEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.CardDeselectEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.CardHideEvent.Invoke();
        }
    }
}
