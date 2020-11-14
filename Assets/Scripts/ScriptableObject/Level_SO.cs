using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level_SO : ScriptableObject
{
    [SerializeField]
    private GameObject characterPrefab;
    public GameObject CharacterPrefab
    {
        get => this.characterPrefab;
    }

    [SerializeField]
    private CharacterStat[] characterStats;
    public CharacterStat[] CharacterStats
    {
        get => this.characterStats;
    }

    [SerializeField]
    [Range(0f, 19f)]
    private int characterIndex;

    private int runtimeCharacterIndex;

    private void OnValidate()
    {
        this.runtimeCharacterIndex = this.characterIndex;
    }

    public CharacterStat GetCurrentCharacterStat()
    {
        return this.characterStats[this.runtimeCharacterIndex];
    }
}
