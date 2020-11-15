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
    private int nbCharacterByBatch;
    public int NbCharacterByBatch
    {
        get => this.nbCharacterByBatch;
    }

    [SerializeField]
    [Range(1f, 4f)]
    private int nbCharacterInPurgatory;
    public int NbCharacterInPurgatory
    {
        get => this.nbCharacterInPurgatory;
    }

    [SerializeField]
    private CharacterStat[] characterStats;
    public CharacterStat[] CharacterStats
    {
        get => this.characterStats;
    }

    [SerializeField]
    private Vector2 initialPosition;
    public Vector2 InitialPosition
    {
        get => this.initialPosition;
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

    public CharacterStat GetCurrentCharacterStatAndIncreament()
    {
        CharacterStat characterStat = this.characterStats[this.runtimeCharacterIndex];
        ++this.runtimeCharacterIndex;
        return characterStat;
    }

    public CharacterStat GetNextCharacterStat()
    {
        ++this.runtimeCharacterIndex;

        if (this.runtimeCharacterIndex >= 20)
        {
            Debug.LogWarning("[Level_SO] index out of range");
            return null;
        }

        return this.characterStats[this.runtimeCharacterIndex];
    }

    public bool isBatchEnd()
    {
        Debug.Log(runtimeCharacterIndex);
        return this.runtimeCharacterIndex % this.nbCharacterByBatch == 0;
    }

    public bool isNextCharacterBatchEnd()
    {
        if (this.runtimeCharacterIndex == 0)
        {
            return false;
        }
        return (this.runtimeCharacterIndex - 1) % this.nbCharacterByBatch == 0;
    }
}
