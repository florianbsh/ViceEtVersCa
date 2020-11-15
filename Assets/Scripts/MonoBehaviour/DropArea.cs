using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))] 
public class DropArea : MonoBehaviour
{
    public Events.GameObjectEvent OnAddPurgatoty;
    public Events.GameObjectEvent OnRemovePurgatory;

    [SerializeField] private int lines;
    [SerializeField] private int columns;
    [SerializeField] private Vector2 elementSize;
    [SerializeField] private float padding;
    [SerializeField] private LayerMask characterLayers;
    [SerializeField] private LayerMask dropLayer;
    [SerializeField] private Zone zone;

    private int numElements = 0;
    private Vector3 topLeftCornerPosition;

    private CharacterController[] elements;

    private Collider2D areaCollider;

    private void Awake()
    {
        areaCollider = GetComponent<Collider2D>();
        areaCollider.isTrigger = true;
        topLeftCornerPosition = this.transform.position + new Vector3(-((columns - 1) / 2.0f) * elementSize.x, ((lines - 1) / 2.0f) * elementSize.y);
        elements = new CharacterController[lines * columns];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (numElements < lines * columns && collision.IsTouchingLayers(dropLayer))
        {
            CharacterController character = collision.GetComponent<CharacterController>();
            Vector3 newResetPosition = topLeftCornerPosition + new Vector3((numElements % columns) * elementSize.x, (numElements / columns) * (-elementSize.y));
            character.PendingDrop(zone, newResetPosition);
            character.ApplyResetPosition();
            elements[numElements] = character;
            ++numElements;

            if (this.zone == Zone.Purgatory)
            {
                this.OnAddPurgatoty.Invoke(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterController character;
        if (collision.gameObject.TryGetComponent(out character))
        {
            for (int i = 0; i < numElements; ++i)
            {
                if (elements[i] == character)
                {
                    RepositionElements(i);
                }
            }
        }

        if (this.zone == Zone.Purgatory)
        {
            this.OnRemovePurgatory.Invoke(collision.gameObject);
        }
    }

    private void RepositionElements(int removedElement)
    {
        for (int i = removedElement; i < numElements - 1; ++i)
        {
            elements[i] = elements[i + 1];
            elements[i].ResetPosition = topLeftCornerPosition + new Vector3((i % columns) * elementSize.x, (i / columns) * (-elementSize.y));
            elements[i].ApplyDrop();
        }

        elements[numElements - 1] = null;
        --numElements;
    }
}
