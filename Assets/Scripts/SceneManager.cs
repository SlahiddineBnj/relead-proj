using System.Collections.Generic;
using AutoLayout3D;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // the speed at which the balls should be moving => defaulted to 17
    public float speed = 17f;
    // the interval of time between direction updates in the game => defaulted to 2.4 seconds between each update
    public float interval = 2.4f;
    // the parent of the balls objects in the scene
    [SerializeField] private Transform ballsContainer;
    // a reference for the ball prefab 
    [SerializeField] private Ball ballPrefab;  
    // the number of balls selected by the admin to be instantiated => defaulted to 4
    public int ballsNumber = 4; 
    // should contain all the instantiated ball objects
    private List<Ball> _ballsList = new List<Ball>();
    // should contain the correct ball instances selected by the admin
    public List<int> correctBallsIndexes;
    // should contain the player selected balls to be verified
    public List<int> playerSelectedBallsIndexes;
    // gives us a feedback whether the game state is 
    //todo - add odin here por favore
    public GameState state;
    // contains the success rate result of the scene 
    private float rate;
    [SerializeField] private PanelHandler _panelHandler; 
    
    
    
    private void Start()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        _generateBalls();
        state = GameState.NotStarted; 
    }
    
    
    // generate the balls with shuffeled indexes to confuse the player who try to memorize the places 
    public void _generateBalls()
    {
        var indexesList = new List<int>();
        for (var counter = 0; counter < ballsNumber; counter++)
        {
            indexesList.Add(counter+1);
        }
        Shuffle(indexesList);
        RemoveChildrenIfExists();
        _ballsList.Clear();
        for (var i = 0; i < ballsNumber; i++)
        {
            Ball ball = Instantiate(ballPrefab, ballsContainer); 
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
            Destroy(ballsContainer.GetChild(i).gameObject);
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
        rate = (float)correctAnswers/ (float)correctBallsIndexes.Count;
    }

    
    
}
