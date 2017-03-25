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

}
