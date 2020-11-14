using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingBare : MonoBehaviour
{
    [SerializeField]  private int value ; //should be pass at nomrla field afeter test 
    [SerializeField]  private int maxvalue;
    private Image bar;

    void Start()
    {
        bar = GetComponent<Image>();
    }

    private void Update()
    {
        UpdateBareState();
    }

    // Make the bare avancement decrease 
    public void ReduceBare(int value)
    {
        this.value -= value;
        UpdateBareState();
    }
    // Make the bare avancement incereace 
    public void ImproveBare(int value)
    {
        this.value += value;
        UpdateBareState();
    }

    //acutualise l'etas de la bar 
    private void UpdateBareState()
    {
        value = Mathf.Clamp(value, 0, maxvalue);

        float amount = (float)value / maxvalue;
        Debug.Log(amount);
        bar.fillAmount = amount;
    }
}
