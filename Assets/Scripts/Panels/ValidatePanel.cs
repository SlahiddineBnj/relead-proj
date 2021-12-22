using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatePanel : MonoBehaviour,IPanelAnimation
{

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
