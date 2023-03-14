using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image imgFiller;

    public void SetValue(float value)
    {
        this.imgFiller.fillAmount = value;
    }
}
