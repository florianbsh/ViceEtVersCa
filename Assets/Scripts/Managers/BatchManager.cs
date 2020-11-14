using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    private static BatchManager instance;

    public static BatchManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BatchManager();
            }

            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
