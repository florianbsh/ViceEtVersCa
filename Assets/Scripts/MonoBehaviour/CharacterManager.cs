using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Level_SO level;

    private CharacterStat currentCharacterStat;

    private GameObject[] charactersInPurgatory;

    private int purgatoryIndex = 0;

    public UnityEvent onLastCharacterDropped;

    private void Start()
    {
        this.charactersInPurgatory = new GameObject[this.level.NbCharacterInPurgatory];

        NextCharacter();
    }

    public void OnDropped(bool isFirstTime)
    {
        if (isFirstTime && !this.level.isBatchEnd())
        {
            NextCharacter();
        }
        else if (isFirstTime && this.level.isBatchEnd())
        {
            onLastCharacterDropped.Invoke();
        }
    }

    public void NextCharacter()
    {
        if (NextCharacterInPurgatory())
        {
            return;
        }

        this.currentCharacterStat = this.level.GetCurrentCharacterStat();

        GameObject character = Instantiate(this.level.CharacterPrefab, this.level.InitialPosition, Quaternion.identity);
    }

    public bool NextCharacterInPurgatory()
    {
        if (this.purgatoryIndex >= this.level.NbCharacterInPurgatory)
        {
            return false;
        }

        GameObject character = null;

        for (int i = this.purgatoryIndex; i < this.charactersInPurgatory.Length; ++i)
        {
            if (this.charactersInPurgatory[i] != null)
            {
                character = this.charactersInPurgatory[this.purgatoryIndex];
                break;
            }
            ++this.purgatoryIndex;
        }

        if (character == null)
        {
            return false;
        }

        CharacterController characterController = character.GetComponent<CharacterController>();

        this.currentCharacterStat = characterController.CharacterStat;

        characterController.HasBeenJudged = false;

        character.transform.position = this.level.InitialPosition;

        characterController.OnCharacterSelected();

        this.charactersInPurgatory[this.purgatoryIndex] = null;

        ++this.purgatoryIndex;

        return true;
    }

    public void OnNextBatch()
    {
        this.purgatoryIndex = 0;
        NextCharacter();
    }

    public void OnAddCharacterInPurgatory(GameObject character)
    {
        for (int i = 0; i < this.charactersInPurgatory.Length; ++i)
        {
            if (this.charactersInPurgatory[i] == null)
            {
                this.charactersInPurgatory[i] = character;
                return;
            }
        }
    }

    public void OnRemoveCharacterInPurgatory(GameObject character)
    {
        for (int i = 0; i < this.charactersInPurgatory.Length; ++i)
        {
            if (this.charactersInPurgatory[i] == character)
            {
                this.charactersInPurgatory[i] = null;
                return;
            }
        }
    }
}
