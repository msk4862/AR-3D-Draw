using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    void Start()
    {

        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * 3.7f * Time.deltaTime);
        
    }

    IEnumerator Move()
    {


        while (true)
        {
            yield return new WaitForSeconds(7f);

            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}
