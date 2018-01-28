using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class WebCamScript : MonoBehaviour {

    //public RawImage cam;
    public GameObject webCameraPlane;
    //public Button fireButton;
    

    WebCamTexture webCameraTexture;
    //public AudioSource blast;


    private float time = 4; //Seconds to read the text

    public static int SCORE = 0;




    // Use this for initialization
    void Start () {

        ////Turn off Vuforia
        VuforiaBehaviour.Instance.enabled = false;
        VuforiaRuntime.Instance.Deinit();



       
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);


        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
           cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;


        

            
                webCameraTexture = new WebCamTexture(Screen.width, Screen.height);

         webCameraTexture.filterMode = FilterMode.Point;

        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();

        //cam.texture = webCameraTexture;
        //webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;


        //Destroy(InfoButton.gameObject, time);
        //Destroy(Info.gameObject, time);
        //Destroy(image, time);


    }



    private void OnOkayDown()
    {
        //Destroy(image);
        //Destroy(Info.gameObject);
    }

    private void OnButtonDown()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rb.AddForce(Camera.main.transform.forward * 5000f);
        Destroy(bullet, 3F);

        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update () {

        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;

        if(Input.GetButton("Fire1"))
        {
            GameObject paint = Instantiate(Resources.Load("1", typeof(GameObject))) as GameObject;
            Rigidbody rb = paint.GetComponent<Rigidbody>();
            paint.transform.rotation = Camera.main.transform.rotation;
            paint.transform.position = Camera.main.transform.position;
            rb.AddForce(Camera.main.transform.forward * 100f);
            //Destroy(bullet, 3F);
        }
        
    }
}
