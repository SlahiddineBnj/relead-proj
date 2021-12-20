using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    // the id of the ball object
    public int id; 
    // the text displayed on top of the ball , ie 1, 2
    [SerializeField] public TextMesh text;
    // a component to generate a random set of forces to hit the ball , making it move  
    [FormerlySerializedAs("_forceGenerator")] [SerializeField] private ForceGenerator forceGenerator;
    // an overlay sphere to give a feedback when the ball is selected 
    [SerializeField] private Transform overlaySphere;
    [SerializeField] private bool _iSelected ;
    
    // Ball initialization
    public void Initialize(int id,float speed,float interval)
    {
        this.id = id; 
        text.text = id.ToString();
        forceGenerator.Initialize(speed,interval);
    }

    // Ball Selected state
    private void Select()
    {
        overlaySphere.gameObject.SetActive(true);
        _iSelected = true; 
    }

    // Ball Unselected State
    public void UnSelect()
    {
        overlaySphere.gameObject.SetActive(false);
        _iSelected = false; 
    }

    // this function would handle the state switch of the buttons
    public void HandleClick()
    {
        switch (_iSelected)
        {
            case true :
                UnSelect();
                break; 
            case false :
                Select();
                break;
        }
    }

    // displays the text mesh on top of the ball object
    public void ShowId()
    {
        text.gameObject.SetActive(true);
    }


    //Executes the random force generator on the ball object => making it move in different directions
    public void Execute()
    {
        forceGenerator.Execute(); }

    public void Stop()
    {
        forceGenerator.Stop();
    }
    
}
