using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

   public void SliderDeger(int maxDeger, int gecDeger)
    {
        int sliderDeger = maxDeger - gecDeger;
        slider.maxValue = maxDeger;
        slider.value = sliderDeger;
    }
}
