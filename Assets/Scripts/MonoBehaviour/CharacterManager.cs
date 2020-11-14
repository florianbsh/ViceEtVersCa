using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Level_SO level;

    public void NextCharacter()
    {
        GameObject character = Instantiate(this.level.CharacterPrefab, this.level.InitialPosition, Quaternion.identity);

        
    }
}
