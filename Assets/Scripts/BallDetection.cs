using System;
using UnityEngine;

public class BallDetection : MonoBehaviour
{
    [SerializeField] private SceneManager _sceneManager; 
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit, 100f)) return;
        if (!hit.transform.CompareTag("Ball")) return;
        Ball ball = hit.transform.GetComponent<Ball>();
        var ballId = ball.id; 
        if (_sceneManager.state == GameState.Running) return;
        switch (_sceneManager.state)
        {
            case GameState.NotStarted :
                // admin would choose the correct balls to add or pop it out 
                if (!_sceneManager.correctBallsIndexes.Contains(ballId)) _sceneManager.correctBallsIndexes.Add(ballId);
                else
                    _sceneManager.correctBallsIndexes.Remove(ballId); 
                ball.HandleClick();
                break; 
            case GameState.Stopped :
                // player selection would be registered or removed 
                if (!_sceneManager.playerSelectedBallsIndexes.Contains(ballId)
                    &&
                    _sceneManager.playerSelectedBallsIndexes.Count < _sceneManager.correctBallsIndexes.Count)
                {
                    _sceneManager.playerSelectedBallsIndexes.Add(ballId);
                    ball.HandleClick();
                }
                else if (_sceneManager.playerSelectedBallsIndexes.Contains(ballId))
                {
                    _sceneManager.playerSelectedBallsIndexes.Remove(ballId);
                    ball.HandleClick();
                }
                    
                
                break; 
        }
        
    }
}
