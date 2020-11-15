using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public Events.CharacterStatEvent CharacterSelectedEvent;

    public Events.BooleanEvent CharacterDropped;

    public Events.IntEvent UpdateRedBarEvent;
    public Events.IntEvent UpdateBlueBarEvent;

    [SerializeField]
    private CharacterStat characterStat;
    public CharacterStat CharacterStat
    {
        get => characterStat;
    }

    [SerializeField]
    private CardPosition cardPosition;

    [SerializeField]
    private Level_SO level;

    [SerializeField]
    private Vector2 colliderSizeFullSize;

    [SerializeField]
    private Vector2 colliderSizeProfilePicture;

    public Vector3 DefaultPosition { get; set; }
    public Vector3 ResetPosition { get; set; }
    public Zone CurrentZone { get; set; } = Zone.Void;

    public bool HasBeenJudged { get; set; } = false;

    private BoxCollider2D elementCollider;
    private Rigidbody2D elementRigidBody;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        elementCollider = GetComponent<BoxCollider2D>();
        elementCollider.isTrigger = false;
        

        elementRigidBody = GetComponent<Rigidbody2D>();
        elementRigidBody.bodyType = RigidbodyType2D.Kinematic;

        this.characterStat = this.level.GetCurrentCharacterStatAndIncreament();

        ResetPosition = transform.localPosition;
        DefaultPosition = transform.localPosition;

        OnCharacterSelected();
    }

    public void OnCharacterSelected()
    {
        ChangeToFullCharacter();

        this.CharacterSelectedEvent.Invoke(this.characterStat);
    }

    private void OnMouseDown()
    {
        // DONE show text, maybe in another script
        if (Input.GetMouseButtonDown(1) && this.level.isBatchEnd() && this.cardPosition.CardStatus != CardStatus.Selected)
        {
            this.CharacterSelectedEvent.Invoke(this.characterStat);
        }
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && this.cardPosition.CardStatus != CardStatus.Selected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.localPosition.z);
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ApplyDrop();
        }
    }

    public void ApplyDrop()
    {
        if (!HasBeenJudged && this.CurrentZone != Zone.Void)
        {
            HasBeenJudged = true;
            this.CharacterDropped.Invoke(true);
        }
        else
        {
            this.CharacterDropped.Invoke(false);
        }
        ApplyResetPosition();
    }

    public void ApplyResetPosition()
    {
        transform.position = ResetPosition + Vector3.back;
    }

    public void ChangeToProfilePicture()
    {
        spriteRenderer.sprite = characterStat.ProfilePicture;
        elementCollider.size = colliderSizeProfilePicture;
    }

    public void ChangeToFullCharacter()
    {
        spriteRenderer.sprite = characterStat.CharacterSprite;
        elementCollider.size = colliderSizeFullSize;
    }

    public void PendingDrop(Zone zone, Vector3 newResetPosition)
    {
        ChangeToProfilePicture();
        CurrentZone = zone;
        ResetPosition = newResetPosition;
    }

    public void OnNextBatch()
    {
        if (this.CurrentZone != Zone.Purgatory)
        {
            if (this.CurrentZone == Zone.Heaven)
            {
                this.UpdateRedBarEvent.Invoke(this.characterStat.HeanvenImpact);
            }

            if (this.CurrentZone == Zone.Hell)
            {
                this.UpdateBlueBarEvent.Invoke(this.characterStat.HellImpact);
            }

            Destroy(this.gameObject);
        }
    }
}
