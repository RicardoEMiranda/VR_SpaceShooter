using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    [SerializeField] public float speed;
    private float timer;
    private float laserLifeSpan;
    

    // Start is called before the first frame update
    void Start()  {
        speed = 20f;
        timer = 0;
        laserLifeSpan = 8f;
    }

    // Update is called once per frame
    void Update()  {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        if(timer > laserLifeSpan) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Asteroid") {
            //Debug.Log("Boom!");
        }
    }
}
