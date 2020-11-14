using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Level_SO level;

    private CharacterStat currentCharacterStat;

    private void Start()
    {
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
}
