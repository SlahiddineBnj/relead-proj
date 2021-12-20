using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    [SerializeField] private Transform adminPanel;
    [SerializeField] private Transform selectPanel;
    [SerializeField] private Transform gameStopPanel; 
    [SerializeField] private Transform validatePanel; 
    [SerializeField] private Transform resultPanel;
    [SerializeField] private SceneManager _sceneManager; 


    //todo - animate all of these
    public void CloseAdminPanel()
    {
        
        adminPanel.gameObject.SetActive(false);
    }

    public void ShowSelectPanel()
    {
        selectPanel.gameObject.SetActive(true);
    }

    private void CloseSelectPanel()
    {
        selectPanel.gameObject.SetActive(false);
        _sceneManager.Run();
    }

    public void ShowGameStopPanel()
    {
        CloseSelectPanel();
        gameStopPanel.gameObject.SetActive(true);
    }

    private void CloseGameStopPanel()
    {
        gameStopPanel.gameObject.SetActive(false);
        _sceneManager.Stop();
    }

    public void ShowValidatePanel()
    {
        CloseGameStopPanel();
        validatePanel.gameObject.SetActive(true);
    }

    private void CloseValidatePanel()
    {
        validatePanel.gameObject.SetActive(false);
    }

    public void ShowResultPanel()
    {
        CloseValidatePanel();
        resultPanel.gameObject.SetActive(true);
    }

    public void CloseResultPanel()
    {
        resultPanel.gameObject.SetActive(false);
    }
}
