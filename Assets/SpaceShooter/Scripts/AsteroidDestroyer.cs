using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidDestroyer : MonoBehaviour {

    [SerializeField] public GameObject asteroidExplosion;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupCanvas;
    public int points;

    private void Awake() {
        if(FindObjectOfType<GameController>() != null) {
            gameController = FindObjectOfType<GameController>();
        }
        popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

    }

    private void Update() {
        if(GameController.currentGameState == GameController.GameState.GameOver) {
            Destroy(gameObject);
        }
    }

    public void DestroyAsteroid() {
        //Debug.Log("DestroyAsteroid");
        Instantiate(asteroidExplosion, this.gameObject.transform.position, this.gameObject.transform.rotation);

        float distance = Vector3.Distance(transform.position, Vector3.zero);
        points = (int)distance;
        gameController.UpdateScore(points);
        
        //Instantiate popup canvas
        GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);
        popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = points.ToString();

        float xScale = transform.localScale.x * distance / 5;
        float yScale = transform.localScale.y * distance / 5;
        float zScale = transform.localScale.z * distance / 5;

        asteroidPopup.transform.localScale = new Vector3(xScale, yScale, zScale);

        Destroy(this.gameObject);
    }


}
