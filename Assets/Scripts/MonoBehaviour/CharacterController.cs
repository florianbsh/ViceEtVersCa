using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public Events.CharacterStatEvent CharacterInitializeEvent;

    public Events.BooleanEvent CharacterDropped;

    [SerializeField]
    private CharacterStat characterStat;

    [SerializeField]
    private Level_SO level;

    [SerializeField]
    private Vector2 colliderSizeFullSize;

    [SerializeField]
    private Vector2 colliderSizeProfilePicture;

    public Vector3 DefaultPosition { get; set; }
    public Vector3 ResetPosition { get; set; }
    public Zone CurrentZone { get; set; } = Zone.Void;

    private bool hasBeenJudged = false;

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

        ToggleCharacterSprite();
    }

    public void ToggleCharacterSprite()
    {
        ChangeToFullCharacter();

        this.CharacterInitializeEvent.Invoke(this.characterStat);
    }

    private void OnMouseDown()
    {
        // TODO show text, maybe in another script
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.localPosition.z);
    }

    private void OnMouseUp()
    {
        ApplyDrop();
    }

    public void ApplyDrop()
    {
        if (!hasBeenJudged)
        {
            hasBeenJudged = true;
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

    }
}
