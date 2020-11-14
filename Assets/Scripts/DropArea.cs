using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    [SerializeField] private int lines;
    [SerializeField] private int columns;
    [SerializeField] private Vector2 elementSize;
    [SerializeField] private float padding;
    [SerializeField] private LayerMask characterLayers;
    [SerializeField] private LayerMask dropLayer;

    private int numElements = 0;
    private Vector3 topLeftCornerPosition;

    private DraggableComponent[] elements;

    private Collider2D areaCollider;

    private void Awake()
    {
        areaCollider = GetComponent<Collider2D>();
        topLeftCornerPosition = this.transform.position + new Vector3(-((columns - 1) / 2.0f) * elementSize.x, ((lines - 1) / 2.0f) * elementSize.y);
        elements = new DraggableComponent[lines * columns];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (numElements < lines * columns && collision.IsTouchingLayers(dropLayer))
        {
            DraggableComponent draggableComponent = collision.GetComponent<DraggableComponent>();
            
            Debug.Log("Element: " + numElements + " " + (numElements % columns) * elementSize.x + " " + (numElements / columns) * (-elementSize.y));
            draggableComponent.ResetPosition = topLeftCornerPosition + new Vector3((numElements % columns) * elementSize.x, (numElements / columns) * (-elementSize.y));
            elements[numElements] = draggableComponent;
            ++numElements;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DraggableComponent draggableComponent;
        if (collision.gameObject.TryGetComponent(out draggableComponent))
        {
            Debug.Log("out");

            for (int i = 0; i < numElements; ++i)
            {
                if (elements[i] == draggableComponent)
                {
                    RepositionElements(i);
                }
            }

            draggableComponent.ResetPosition = draggableComponent.DefaultPosition;
        }
    }

    private void RepositionElements(int removedElement)
    {
        for (int i = removedElement; i < numElements - 1; ++i)
        {
            elements[i] = elements[i + 1];
            elements[i].ResetPosition = topLeftCornerPosition + new Vector3((i % columns) * elementSize.x, (i / columns) * (-elementSize.y));
            elements[i].ApplyResetPosition();
        }

        elements[numElements - 1] = null;
        --numElements;
    }
}
