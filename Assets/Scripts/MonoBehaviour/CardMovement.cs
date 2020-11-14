using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardMovement : MonoBehaviour
{
    public UnityEvent CardEndMovingEvent = new UnityEvent();

    private RectTransform rectTransform;

    public Vector2 Position
    {
        get => rectTransform.localPosition;
        private set => rectTransform.localPosition = value;
    }

    private bool isMoving = false;

    private Vector2 targetPosition;

    private float speed;

    private float duration;

    private float time;

    private void Awake()
    {
        this.rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        Vector2 delta = this.targetPosition - this.Position;

        if (delta.x == 0 && delta.y == 0)
        {
            this.isMoving = false;
        }

        this.Position += delta * this.speed * Time.deltaTime;

        //(this.duration - this.time) / this.duration

        //this.time += Time.deltaTime;

        //if (this.time >= this.duration)
        //{
        //    this.isMoving = false;

        //    this.CardEndMovingEvent.Invoke();
        //}
    }

    public void OnCardMoveTo(Vector2 targetPosition, float speed)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;

        this.duration = Mathf.Abs(targetPosition.y - this.Position.y) / speed;

        this.time = 0f;
        this.isMoving = true;
    }
}
