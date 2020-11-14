using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CharacterStat : ScriptableObject
{
    [Header("Name")]
    [SerializeField]
    private string lastName;
    public string LastName
    {
        get => this.lastName;
    }

    [SerializeField]
    private string firstName;
    public string FirstName
    {
        get => this.firstName;
    }

    [Header("Date")]
    [SerializeField]
    [Range(1920f, 2050f)]
    private int yearOfBirth;
    public string YearOfBirth
    {
        get => this.yearOfBirth.ToString();
    }

    [SerializeField]
    [Range(2018f, 2050f)]
    private int yearOfDeath;
    public string YearOfDeath
    {
        get => this.yearOfDeath.ToString();
    }

    [Header("Sprite")]
    [SerializeField]
    private Sprite characterSprite;
    public Sprite CharacterSprite
    {
        get => this.characterSprite;
    }

    [SerializeField]
    private Sprite profilePicture;
    public Sprite ProfilePicture
    {
        get => this.profilePicture;
    }

    [Header("Other")]
    [SerializeField]
    private string job;
    public string Job
    {
        get => this.job;
    }

    [SerializeField]
    [Multiline(10)]
    private string[] facts;
    public string[] Facts
    {
        get => this.facts;
    }

    [SerializeField]
    [Multiline(10)]
    private string circumstancesOfDeath;
    public string CircumstancesOfDeath
    {
        get => this.circumstancesOfDeath;
    }
}
