using UnityEngine;
using System.Collections;

public class TouchPainting : MonoBehaviour
{
    float distance = 3.3f;

    public GameObject brush;
   Vector3 brushPos;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;

       // brush.transform.position = objPosition;

        Vector3 StickBottomSpot = objPosition + (new Vector3(0, -1, 0) * transform.localScale.y);

        //brushPos = Camera.main.ScreenToWorldPoint(StickBottomSpot);

        brush.transform.position = StickBottomSpot;
    }
}