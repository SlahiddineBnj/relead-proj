using System;
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
    private ResultPanel resultPanelScript;

    private void Awake()
    {
        resultPanelScript = resultPanel.GetComponent<ResultPanel>(); 
    }


    public void ShowAdminPanel()
    {
        CloseResultPanel();
        CloseValidatePanel();
        ShowSelectPanel();
        adminPanel.gameObject.SetActive(true);
    }
    public void CloseAdminPanel()
    {
        
        adminPanel.gameObject.SetActive(false);
    }

    private void ShowSelectPanel()
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
        if (_sceneManager.correctBallsIndexes.Count == 0) return;
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
        _sceneManager.Check();
        resultPanel.gameObject.SetActive(true);
    }

    private void CloseResultPanel()
    {
        resultPanel.gameObject.SetActive(false);
    }

    public void AssignRateValue(float value)
    {
        resultPanelScript.rateText.text = value.ToString("F1")+"  %"; 
    }
}
