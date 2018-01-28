using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionScript : MonoBehaviour {

    public Text score;


    // Use this for initialization
    void Start () {

        score = GameObject.Find("Score").GetComponent<Text>();

        //score.text = "SCORE: " + (SCORE);

  

    }

    // Update is called once per frame
    void Update () {



    }
    //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {
        GameObject explosion = Instantiate(Resources.Load("ExplosionMobile", typeof(GameObject))) as GameObject;
        Debug.Log(explosion.GetComponent<AudioSource>());

        explosion.GetComponent<AudioSource>().Play();

        explosion.transform.position = transform.position;
        Destroy(col.gameObject);
        Destroy(explosion, 2);

        WebCamScript.SCORE += 10;

        score.text = "SCORE: " + WebCamScript.SCORE;
        Debug.Log("SCORE: " + WebCamScript.SCORE);

        Debug.Log("Player "+ GameObject.FindGameObjectsWithTag("Player").Length);






        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {

            Debug.Log("WON");

            GameObject enemy = Instantiate(Resources.Load("Enemy1", typeof(GameObject))) as GameObject;
            GameObject enemy1 = Instantiate(Resources.Load("Enemy2", typeof(GameObject))) as GameObject;
            GameObject enemy2 = Instantiate(Resources.Load("Enemy3", typeof(GameObject))) as GameObject;
            GameObject enemy3 = Instantiate(Resources.Load("Enemy4", typeof(GameObject))) as GameObject;
            GameObject drone = Instantiate(Resources.Load("Drone", typeof(GameObject))) as GameObject;
            GameObject drone1 = Instantiate(Resources.Load("Drone (1)", typeof(GameObject))) as GameObject;

        }

        Destroy(gameObject);


    }
}
