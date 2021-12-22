using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour,IPanelAnimation
{

    [SerializeField] private TextMeshProUGUI text;
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void AssignValue(float value)
    {
        text.text = value.ToString("F1")+" %"; 
    }

}
