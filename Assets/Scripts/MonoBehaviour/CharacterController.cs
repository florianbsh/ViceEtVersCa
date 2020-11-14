using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterController : MonoBehaviour
{
    public CharacterStatEvent CharacterInitializeEvent;

    private SpriteRenderer spriteRenderer;

    private bool isSpriteActive = false;

    [SerializeField]
    private CharacterStat characterStat;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ToggleCharacterSprite();
    }

    public void ToggleCharacterSprite()
    {
        this.isSpriteActive = !this.isSpriteActive;
        this.spriteRenderer.sprite = this.isSpriteActive ? this.characterStat.CharacterSprite : null;

        this.CharacterInitializeEvent.Invoke(this.characterStat);
    }
}
