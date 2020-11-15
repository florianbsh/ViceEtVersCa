using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardPosition : ScriptableObject
{
    [SerializeField]
    private CardStatus cardStatus;
    public CardStatus CardStatus
    {
        get => this.cardStatus;
        set => this.cardStatus = value;
    }

    [Header("Positions")]
    [SerializeField]
    private Vector2 selectedPosition;
    public Vector2 SelectedPosition
    {
        get => this.selectedPosition;
    }

    [SerializeField]
    private Vector2 deseselctedPosition;
    public Vector2 DeselectedPosition
    {
        get => this.deseselctedPosition;
    }

    [SerializeField]
    private Vector2 hidePosition;
    public Vector2 HidePosition
    {
        get => this.hidePosition;
    }

    [Header("Speed")]
    [SerializeField]
    private float toSelectedPositionSpeed;
    public float ToSelectedPositionSpeed
    {
        get => this.toSelectedPositionSpeed;
    }

    [SerializeField]
    private float toDeselectedPositionSpeed;
    public float ToDeselectedPositionSpeed
    {
        get => this.toDeselectedPositionSpeed;
    }

    [SerializeField]
    private float toHidePositionSpeed;
    public float ToHidePositionSpeed
    {
        get => this.toHidePositionSpeed;
    }
}
