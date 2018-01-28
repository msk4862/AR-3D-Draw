using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class painting : MonoBehaviour
{

    //GameObject bluepaint;
    GameObject paint;
    public GameObject brush;

    public ParticleSystem flare;

    public GameObject stick;

    public Sprite blueBrush;
    public Sprite greenBrush;
    public Sprite redBrush;
    //public Button paintButton; 


    Material BLUE, GREEN, RED;
    Material selected;


    SpriteRenderer brushRenderer;

    GameObject[] PaintList;
    long paintCount = -1; 



    bool clicked = false;

    private void Start()
    {

        BLUE = Resources.Load("blueMat", typeof(Material)) as Material;
        GREEN = Resources.Load("greenMat", typeof(Material)) as Material;
        RED = Resources.Load("redMat", typeof(Material)) as Material;

        selected = BLUE;

        Input.backButtonLeavesApp = true;

        


        brushRenderer = GetComponent<SpriteRenderer>();

        //stick.GetComponent<Renderer>().material = BLUE;

        paint = Resources.Load("bluePaint", typeof(GameObject)) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {


        stick.GetComponent<Renderer>().material = selected;

        if (Application.platform == RuntimePlatform.Android)
        {
            Vector2 touch = Input.GetTouch(0).position;

           if (touch.y < 670)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                    clicked = true;

                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    clicked = false;
            }
                

        }

        else
        {
            
            Debug.Log("X: " + Input.mousePosition.x + " Y:" + Input.mousePosition.y);

            if (Input.GetKey(KeyCode.A) && Input.mousePosition != null)
            {
                Debug.Log("Pressed");

                GameObject p = Instantiate(paint, brush.transform.position, brush.transform.rotation);
                p.gameObject.tag = "Player";

            }
        }



        if (clicked)
        {
            Debug.Log("Pressed");

            GameObject p = Instantiate(paint, brush.transform.position, brush.transform.rotation);
            p.gameObject.tag = "Player";
        }


    }

    public void blueButton()
    {
        paint = Resources.Load("bluePaint", typeof(GameObject)) as GameObject;

        brushRenderer.sprite = blueBrush;

        selected = BLUE;

        
        //var main = flare.main;
        flare.startColor = Color.blue;
    }

    public void greenButton()
    {
        paint = Resources.Load("greenPaint", typeof(GameObject)) as GameObject;

        brushRenderer.sprite = greenBrush;

        selected = GREEN;


        //var main = flare.main;
        flare.startColor = Color.green;


    }

    public void redButton()
    {
        paint = Resources.Load("redPaint", typeof(GameObject)) as GameObject;

        brushRenderer.sprite = redBrush;

        selected = RED;

        var main = flare.main;
        main.startColor = Color.red;


    }


    public void erase()
    {
        var p = GameObject.FindGameObjectsWithTag("Player");

        foreach(var clone in p)
        {
            Destroy(clone);
        }


    }





}
