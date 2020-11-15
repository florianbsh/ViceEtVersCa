using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [System.Serializable]
    public class CharacterStatEvent : UnityEvent<CharacterStat> { }

    [System.Serializable]
    public class BooleanEvent : UnityEvent<bool> { }

    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    [System.Serializable]
    public class GameObjectEvent : UnityEvent<GameObject> { }
}
