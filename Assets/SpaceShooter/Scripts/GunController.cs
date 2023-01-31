using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField] public GameObject laser;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Animator triggerAnimator;
    [SerializeField] private Transform rayCastOrigin_TopLeft;
    [SerializeField] private Transform rayCastOrigin_TopRight;
    [SerializeField] private Transform rayCastOrigin_BottomLeft;
    [SerializeField] private Transform rayCastOrigin_BottomRight;
    [SerializeField] private Transform reticleOrigin;
    private RaycastHit hitInformation;
    private LineRenderer reticle;
    [SerializeField] public float reticleWidth = .01f;
    [SerializeField] public float reticleLength = 2500f;
    private Pose gunPose;

    private void Awake() {
        gunPose.position = transform.position;
        gunPose.rotation = transform.rotation;
    }

    private void Start() {
        reticle = GetComponent<LineRenderer>();
        reticle.startColor = Color.red;
        reticle.endColor = Color.red;

        reticle.SetPosition(0, reticleOrigin.position);
        reticle.SetPosition(1, reticleOrigin.position + reticleOrigin.forward * reticleLength);
    }

    private void Update() {
        //Debug.Log(rayCastOrigin.transform.position);
        Debug.DrawRay(rayCastOrigin_TopLeft.position, rayCastOrigin_TopLeft.forward, Color.red);
        Debug.DrawRay(rayCastOrigin_TopRight.position, rayCastOrigin_TopRight.forward, Color.red);
        Debug.DrawRay(rayCastOrigin_BottomLeft.position, rayCastOrigin_BottomLeft.forward, Color.red);
        Debug.DrawRay(rayCastOrigin_BottomRight.position, rayCastOrigin_BottomRight.forward, Color.red);

        reticle.SetPosition(0, reticleOrigin.position);
        reticle.SetPosition(1, reticleOrigin.position + reticleOrigin.forward * reticleLength);
        reticle.startWidth = .01f;
        reticle.endWidth = .01f;
    }

    public void OnLetGoOfGun() {
        transform.position = gunPose.position;
        transform.rotation = gunPose.rotation;
    }

    public void OnTriggerPulled() {
        //Debug.Log("Fire");
        triggerAnimator.SetTrigger("Fire");
        
        audioSource.Play();

        if(Physics.Raycast(rayCastOrigin_TopLeft.position, rayCastOrigin_TopLeft.forward, out hitInformation, Mathf.Infinity)) {
            //NOTE: Be sure to use rayCastOrigin.forward for the direction. Previously used the 
            //Vector3.forward and this was likely using a different origin that was preventing the detection of the object tag
            //Debug.Log(hitInformation.transform.tag);
            if(hitInformation.transform.GetComponent<AsteroidDestroyer>() != null) {
                hitInformation.transform.GetComponent<AsteroidDestroyer>().DestroyAsteroid();
            } else if(hitInformation.transform.GetComponent<IRaycastInterface>() != null) {
                hitInformation.transform.GetComponent<IRaycastInterface>().HitByRaycast();
            }
            reticle.SetPosition(1, hitInformation.point);

        } 
        
        if (Physics.Raycast(rayCastOrigin_TopRight.position, rayCastOrigin_TopRight.forward, out hitInformation, Mathf.Infinity)) {
            //NOTE: Be sure to use rayCastOrigin.forward for the direction. Previously used the 
            //Vector3.forward and this was likely using a different origin that was preventing the detection of the object tag
            //Debug.Log(hitInformation.transform.tag);
            if (hitInformation.transform.GetComponent<AsteroidDestroyer>() != null) {
                hitInformation.transform.GetComponent<AsteroidDestroyer>().DestroyAsteroid();
            }
            reticle.SetPosition(1, hitInformation.point);

        } 
        
        if (Physics.Raycast(rayCastOrigin_BottomRight.position, rayCastOrigin_BottomRight.forward, out hitInformation, Mathf.Infinity)) {
            //NOTE: Be sure to use rayCastOrigin.forward for the direction. Previously used the 
            //Vector3.forward and this was likely using a different origin that was preventing the detection of the object tag
            //Debug.Log(hitInformation.transform.tag);
            if (hitInformation.transform.GetComponent<AsteroidDestroyer>() != null) {
                hitInformation.transform.GetComponent<AsteroidDestroyer>().DestroyAsteroid();
            }
            reticle.SetPosition(1, hitInformation.point);

        } 
        
        if (Physics.Raycast(rayCastOrigin_BottomLeft.position, rayCastOrigin_BottomLeft.forward, out hitInformation, Mathf.Infinity)) {
            //NOTE: Be sure to use rayCastOrigin.forward for the direction. Previously used the 
            //Vector3.forward and this was likely using a different origin that was preventing the detection of the object tag
            //Debug.Log(hitInformation.transform.tag);
            if (hitInformation.transform.GetComponent<AsteroidDestroyer>() != null) {
                hitInformation.transform.GetComponent<AsteroidDestroyer>().DestroyAsteroid();
            }
            reticle.SetPosition(1, hitInformation.point);

        }

    }

}
