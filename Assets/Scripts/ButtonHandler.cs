using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Level_SO level;

    [SerializeField]
    private Button validationButton;

    public UnityEvent onNextBatch;

    private void Awake()
    {
        Debug.Log("disabled");
        validationButton.gameObject.SetActive(false);
    }

    public void OnDropped(bool isFirstTime)
    {
        if (this.level.isBatchEnd())
        {
            validationButton.gameObject.SetActive(true);
        }
    }

    public void ValidateBatch()
    {
        onNextBatch.Invoke();
        validationButton.gameObject.SetActive(false);
    }
}
