using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Level_SO level;

    private CharacterStat currentCharacterStat;

    private GameObject[] characterInPurgatory;

    private void Start()
    {
        this.characterInPurgatory = new GameObject[this.level.NbCharacterInPurgatory];

        NextCharacter();
    }

    public void OnDropped(bool isFirstTime)
    {
        if (isFirstTime && !this.level.isBatchEnd())
        {
            NextCharacter();
        }
    }

    public void NextCharacter()
    {
        this.currentCharacterStat = this.level.GetCurrentCharacterStat();

        GameObject character = Instantiate(this.level.CharacterPrefab, this.level.InitialPosition, Quaternion.identity);
    }

    public void OnNextBatch()
    {

    }

    public void OnCharacterInPurgatory()
    {

    }
}
