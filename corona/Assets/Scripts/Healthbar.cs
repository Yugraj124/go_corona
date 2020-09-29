using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    Slider slider;
    public Gradient gradient;
    public Image fill;
    public float max = 0f;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = max;
        slider.value = 0;

        fill.color = gradient.Evaluate(0f);
    }


    public void SetValue(float val)
    {
        slider.value = val;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
