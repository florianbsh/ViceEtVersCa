﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragSystem : MonoBehaviour
{
    [SerializeField] private LayerMask droppingArea;

    private bool isMoving;

    private float startPosX;
    private float startPosY;

    public Vector3 DefaultPosition { get; set; }
    public Vector3 ResetPosition { get; set; }

    private Collider2D elementCollider;
    private Rigidbody2D elementRigidBody;

    private void Start()
    {
        elementCollider = GetComponent<Collider2D>();
        elementCollider.isTrigger = false;

        elementRigidBody = GetComponent<Rigidbody2D>();
        elementRigidBody.bodyType = RigidbodyType2D.Kinematic;

        ResetPosition = transform.localPosition;
        DefaultPosition = transform.localPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clic");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isMoving = true;
        }  
    }

    private void OnMouseUp()
    {
        isMoving = false;
        ApplyResetPosition();
    }

    public void ApplyResetPosition()
    {
        transform.position = ResetPosition + Vector3.back;
    }
}