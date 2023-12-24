using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Gradient Gradient;

    public Slider slider;
    public Image fill;


    public void SetMaxHealth (int Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;

        fill.color = Gradient.Evaluate(1f);
    }
    public void SetHealth(int Hp)
    {
        slider.value = Hp;

        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}
