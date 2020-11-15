using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardMovement : MonoBehaviour
{
    public UnityEvent CardEndMovingEvent = new UnityEvent();

    [SerializeField]
    private CardPosition cardPosition;

    private CardStatus cardStatus;

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

        if (Mathf.Abs(delta.x) <= 5f && Mathf.Abs(delta.y) <= 5f)
        {
            this.isMoving = false;
            this.cardPosition.CardStatus = this.cardStatus;
            this.CardEndMovingEvent.Invoke();
        }

        this.Position += delta * this.speed * Time.deltaTime;
    }

    public void OnCardMoveTo(Vector2 targetPosition, float speed, CardStatus cardStatus)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;
        this.cardStatus = cardStatus;

        this.isMoving = true;
    }
}
