using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{

    [SerializeField] private Sprite fullCharacter;
    [SerializeField] private Sprite icon;

    public Vector3 DefaultPosition { get; set; }
    public Vector3 ResetPosition { get; set; }
    public Zone CurrentZone { get; set; } = Zone.Void;

    private bool hasBeenJudged = false;

    private Collider2D elementCollider;
    private Rigidbody2D elementRigidBody;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        elementCollider = GetComponent<Collider2D>();
        elementCollider.isTrigger = false;

        elementRigidBody = GetComponent<Rigidbody2D>();
        elementRigidBody.bodyType = RigidbodyType2D.Kinematic;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fullCharacter;

        ResetPosition = transform.localPosition;
        DefaultPosition = transform.localPosition;
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
        ApplyResetPosition();
    }

    public void ApplyResetPosition()
    {
        transform.position = ResetPosition + Vector3.back;
    }

    public void ChangeToIcon()
    {
        spriteRenderer.sprite = icon;
    }

    public void ChangeToFullCharacter()
    {
        spriteRenderer.sprite = fullCharacter;
    }

    public void Dropped(Zone zone, Vector3 newResetPosition)
    {
        if (!hasBeenJudged)
        {
            hasBeenJudged = true;
            spriteRenderer.sprite = icon;
        }
        CurrentZone = zone;
        ResetPosition = newResetPosition;
    }
}
