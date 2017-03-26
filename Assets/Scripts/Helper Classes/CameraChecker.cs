using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker {

    public Camera cam;

    public CameraChecker(Camera cam)
    {
        this.cam = cam;
    }

    public bool IsOutOfBounds(GameObject obj){

        Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);

        if (screenPoint.x < 1.25f){  //if object is in of camera
            return false;
        }

        return true;

    }

    public bool IsOutOfBoundsLeft(GameObject obj)
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);

        if (screenPoint.x > -0.51f) {  //if object is in of camera
            return false;
        }

        return true;

    }

    public bool IsOutOfBoundsRight(GameObject obj)
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);

        if (screenPoint.x < 1.51f)
        {  //if object is in of camera
            return false;
        }

        return true;

    }

    public bool IsHalfwayLeft(GameObject obj)
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);

        if (screenPoint.x < 0.5f)
        {  //if object is in of camera
            return true;
        }

        return false;


    }
    public bool IsHalfwayRight(GameObject obj)
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);

        if (screenPoint.x > 0.5f)
        {  //if object is in of camera
            return true;
        }

        return false;

    }

}
