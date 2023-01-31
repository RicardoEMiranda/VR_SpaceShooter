using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] public float minRotSpeed;
    [SerializeField] public float maxRotSpeed;
    [SerializeField] private float rotSpeed;
    private Vector3 rotAxis;
    private float speed;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    // Start is called before the first frame update
    void Start()  {
        speed = Random.Range(minSpeed, maxSpeed);
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);
        rotSpeed = Random.Range(0, 300);
        transform.Rotate(new Vector3(xAngle, yAngle,zAngle));
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
        rotAxis = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    // Update is called once per frame
    void Update()  {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        transform.Rotate(rotAxis * Time.deltaTime * rotSpeed);
 
    }

    
}
