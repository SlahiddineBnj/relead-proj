using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    [SerializeField] private AdminPanel adminPanel;
    [SerializeField] private SelectPanel selectPanel;
    [SerializeField] private GameStopPanel gameStopPanel; 
    [SerializeField] private ValidatePanel validatePanel; 
    [SerializeField] private ResultPanel resultPanel;
    [SerializeField] private SceneManager _sceneManager;

    
    public void Select()
    {
        selectPanel.Show();
        adminPanel.Hide();
    }

    public void Play()
    {
        if (_sceneManager.correctBallsIndexes.Count == 0)
        {
            // trigger an exception or show a popup to signal the admin to select balls 
            Debug.Log("Please Select some balls !");
        }
        else
        {
            selectPanel.Hide();
            _sceneManager.Run();
            gameStopPanel.Show();
        }
    }

    public void Stop()
    {
        _sceneManager.Stop();
        gameStopPanel.Hide();
        validatePanel.Show();
    }

    public void Validate()
    {
        var rate = _sceneManager.Check();
        resultPanel.AssignValue(rate);
        resultPanel.Show();
    }

    public void Replay()
    {
        _sceneManager.Reset();
        resultPanel.Hide();
        validatePanel.Hide();
        adminPanel.Show();
    }
    
    
    
}
