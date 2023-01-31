using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour {


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Asteroid") {
            //Debug.Log("Destroy");

            other.GetComponent<Animator>().SetTrigger("FadeOut");
            Destroy(other.gameObject, 3f);
        }
    }
}
