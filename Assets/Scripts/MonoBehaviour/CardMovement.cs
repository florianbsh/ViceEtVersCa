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

        if (Mathf.Abs(delta.x) <= 10f && Mathf.Abs(delta.y) <= 10f)
        {
            this.isMoving = false;
        }

        this.Position += delta * this.speed * Time.deltaTime;
    }

    public void OnCardMoveTo(Vector2 targetPosition, float speed)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;

        this.isMoving = true;
    }
}
