using UnityEngine;
using UnityEngine.UI;

public class PlayerK : MonoBehaviour
{
    public Slider healthSlider;


    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
    }
    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }
}