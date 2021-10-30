using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxCharge(float Charge)
    {
        slider.maxValue = Charge;
    }
    public void SetJumpCharge(float Charge)
    {
        slider.value = Charge;
    }
}
