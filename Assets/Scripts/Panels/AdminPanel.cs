using UnityEngine;

public class AdminPanel : MonoBehaviour,IPanelAnimation
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
