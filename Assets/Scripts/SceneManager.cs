using System;
using System.Collections;
using System.Collections.Generic;
using AutoLayout3D;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private float speed = 17f;
    [SerializeField] private float interval = 2.4f;
    [SerializeField] private Transform ballsContainer;
    [SerializeField] private Ball ballPrefab;  
    [SerializeField] private int ballsNumber = 4; 
    [SerializeField] private List<Ball> _ballsList ;
    [SerializeField] private List<Ball> _correctBalls;

    private void Start()
    {
        loadScene();
    }

    private void loadScene()
    {
        _generateBalls();
    }
    
    
    private void _generateBalls()
    {
        var id = 1;
        RemoveChildrenIfExists();
        _ballsList.Clear();
        for (var i = 0; i < ballsNumber; i++)
        {
            Ball ball = Instantiate(ballPrefab, ballsContainer); 
            ball.Initialize(id,speed,interval);
            _ballsList.Add(ball);
            id++; 


        }
    }

    private void RemoveChildrenIfExists()
    {
        for (var i = 0; i < ballsContainer.childCount; i++)
        {
            DestroyImmediate(ballsContainer.GetChild(i).gameObject);
        }
    }


    // set all balls in motion
    public void Run()
    {
        //todo -  unselect all balls first 

        ballsContainer.GetComponent<GridLayoutGroup3D>().enabled = false; 
        for(var i = 0; i < _ballsList.Count; i++)
        {
            _ballsList[i].Execute();
        }
    }

    // stop the balls to assess
    public void Stop()
    {
        for (var i = 0; i < _ballsList.Count; i++)
        {
            _ballsList[i].Stop();
            _ballsList[i].ShowId(); 
        }
    } 
    
}
