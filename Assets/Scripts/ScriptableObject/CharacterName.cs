using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CharacterName : ScriptableObject
{
    [SerializeField]
    private string characterName;
    public string GetName
    {
        get => this.characterName;
    }
}
