using System.Collections.Generic;
using AutoLayout3D;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // the speed at which the balls should be moving => defaulted to 17
    public float speed ;
    // the interval of time between direction updates in the game => defaulted to 2.4 seconds between each update
    public float interval ;
    // the parent of the balls objects in the scene
    [SerializeField] private Transform ballsContainer;
    // a reference for the ball prefab 
    [SerializeField] private Ball ballPrefab;  
    // should contain all the instantiated ball objects
    private List<Ball> _ballsList = new List<Ball>();
    // should contain the correct ball instances selected by the admin
    public List<int> correctBallsIndexes = new List<int>();
    // should contain the player selected balls to be verified
    public List<int> playerSelectedBallsIndexes = new List<int>();
    // gives us a feedback whether the game state is 
    public GameState state;
    // we should grab the number of balls to be generated value for the reset 
    [SerializeField] private Slider numberSlider; 
    [SerializeField] private PanelHandler _panelHandler;
    public LayoutGroup3D _layoutGroup3D; 
    
    
    
    private void Start()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        //_generateBalls();
        state = GameState.NotStarted; 
    }
    
    
    // generate the balls with shuffled indexes to confuse the player who try to memorize the places 
    public void _generateBalls(int nb)
    {
        RemoveChildrenIfExists();
        var indexesList = new List<int>();
        for (var counter = 0; counter < nb; counter++)
        {
            indexesList.Add(counter+1);
        }
        Shuffle(indexesList);
        _ballsList.Clear();
        for (var i = 0; i < nb; i++)
        {
            var ball = Instantiate(ballPrefab, ballsContainer); 
            ball.Initialize(indexesList[i],speed,interval);
            _ballsList.Add(ball);
        }
    }
    
    private static void Shuffle(List<int> l) {
        for (var i = 0; i < l.Count; i++) {
            var rnd = Random.Range(0, l.Count);
            var temp = l[rnd];
            l[rnd] = l[i];
            l[i] = temp;
        }
    }

    

    // remove ball container children when the scene reloads => would probably be used in a reset function
    private void RemoveChildrenIfExists()
    {
        var children = ballsContainer.childCount;
        for (var i = children - 1; i >= 0; i--)
        {
            DestroyImmediate(ballsContainer.GetChild(i).gameObject);;
        }
    }


    // set all balls in motion
    public void Run()
    {
        ballsContainer.GetComponent<GridLayoutGroup3D>().enabled = false;
        for (var i = 0; i < _ballsList.Count; i++)
        {
            _ballsList[i].UnSelect();
            _ballsList[i].Execute();
        }
        state = GameState.Running; 
    }

    // stop the balls to check 
    public void Stop()
    {
        for (var i = 0; i < _ballsList.Count; i++)
        {
            _ballsList[i].Stop();
            _ballsList[i].ShowId(); 
        }
        state = GameState.Stopped;
    }


    public void Check()
    {
        var correctAnswers = 0;
        for (var i = 0; i < correctBallsIndexes.Count; i++)
        {
            if (playerSelectedBallsIndexes.Contains(correctBallsIndexes[i])) correctAnswers++; 
        }
        var rate = ( (float)correctAnswers/ (float)correctBallsIndexes.Count ) * 100;
        _panelHandler.AssignRateValue(rate);
    }


    public void Reset()
    {
        correctBallsIndexes.Clear();
        playerSelectedBallsIndexes.Clear();
        state = GameState.NotStarted;
        _generateBalls((int)numberSlider.value);
        _layoutGroup3D.UpdateLayout();
        _panelHandler.ShowAdminPanel();
        
    }
    
    
}
