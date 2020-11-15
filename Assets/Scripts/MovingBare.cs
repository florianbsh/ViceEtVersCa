using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingBare : MonoBehaviour
{
    [SerializeField]  private int cibleValue ; //should be pass at nomrla field afeter test 
    [SerializeField]  private int maxvalue;
    [SerializeField] private float movingSpeed = 1 ;
    private float curentvalue; 
    private Image bar;

    void Start()
    {
        bar = GetComponent<Image>();
        curentvalue = 0;
    }

    private void FixedUpdate()
     //to remove 
    {
        if (curentvalue != cibleValue)
        {
            curentvalue = Mathf.Lerp(curentvalue, cibleValue, Time.time * movingSpeed);
        }
        
        UpdateBareState();
    }

    // Make the bare avancement decrease 
    public void ReduceBare(int value)
    {
        this.cibleValue -= value;
       // UpdateBareState();
    }
    // Make the bare avancement incereace 
    public void ImproveBare(int value)
    {
        this.cibleValue += value;

        if (this.cibleValue >= maxvalue)
        {
            SceneManager.LoadScene("DefeatScene", LoadSceneMode.Single);
        }
        //UpdateBareState();
    }

    //acutualise l'etas de la bar 
    private void UpdateBareState()
    {
        curentvalue = Mathf.Clamp(curentvalue, 0, maxvalue);
        float amount = (float)curentvalue / maxvalue;
        bar.fillAmount = amount;
    }
}
