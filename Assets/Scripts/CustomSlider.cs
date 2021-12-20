using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro ; 
public class CustomSlider : MonoBehaviour
{
    [SerializeField] private SliderType type ;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private Slider slider;
    [SerializeField] private float initialValue;
    [SerializeField] private bool isFloat;
   

    private void Awake()
    {
        if(!isFloat) text.text = ((int)initialValue).ToString();
        else text.text = ((float)initialValue).ToString();
    }

    public void UpdateComponent()
    {
        // Update text value
        if(!isFloat) text.text = ((int)slider.value).ToString();
        else text.text = ((float)slider.value).ToString("F1");
        // regenerate the balls 
        switch (type)
        {
            case SliderType.BallsNumber:
                sceneManager.ballsNumber = (int)slider.value; 
                sceneManager._generateBalls();
                break;
            case SliderType.Speed:
                sceneManager.speed = slider.value;
                break;
            case SliderType.Interval:
                sceneManager.interval = slider.value;
                break;
        }
        
    }
}
