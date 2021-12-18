using System;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMesh text;
    [SerializeField] private ForceGenerator _forceGenerator; 
    private bool _iSelected ;
    
    public void Initialize(int id,float speed,float interval)
    {
        text.text = id.ToString();
        _forceGenerator.Initialize(speed,interval);
    }
    
    private void Select(){}
    private void UnSelect(){}
    private void HandleClick(){}

    public void ShowId()
    {
        text.gameObject.SetActive(true);
    }


    public void Execute()
    {
        _forceGenerator.Execute(); }

    public void Stop()
    {
        _forceGenerator.Stop();
    }
    
}
