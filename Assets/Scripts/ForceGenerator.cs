using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ForceGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 currentAppliedForce;
    [SerializeField] private ConstantForce _constantForce;
    [SerializeField] private Rigidbody _rigidbody; 
    [SerializeField] private float _speed ;
    [SerializeField] private float _interval ; 
    
    // initialization of the component
    public void Initialize(float speed, float interval)
    {
        _speed = speed; 
        _interval = interval; 
    }

    // well this function will simply trigger the movement of the balls 
    public void Execute()
    {
        StopAllCoroutines();
        StartCoroutine(randomizeForce()); 
    }

    // this function will make the ball cease its movement
    public void Stop()
    {
        // we add some constraints on the rigidbody so the ball stops its movement in the XYZ Axis +  rotation
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll; 
    }
    
    // generates a random force and applies it to the ball 
    void _generateForce(float speed)
    {
        // get 3 instances of the random value 
        var xComponent = Random.Range(-speed,speed);
        var yComponent = Random.Range(-speed,speed);
        var zComponent = Random.Range(-speed,speed);
        currentAppliedForce = new Vector3(xComponent, yComponent, zComponent);
        // randomize the force
        _constantForce.relativeForce = currentAppliedForce; 
    }
    
    // apply it every {{interval value}} to actually make the ball move in different directions
    IEnumerator randomizeForce()
    {
        while (true)
        {
            _generateForce(_speed);
             yield return new WaitForSecondsRealtime(_interval);
        }
    }

    
}



