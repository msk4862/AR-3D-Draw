using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePaintMarkLess : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
