using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [System.Serializable]
    public class CharacterStatEvent : UnityEvent<CharacterStat> { }
}
