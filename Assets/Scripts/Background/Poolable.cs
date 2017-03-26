using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour {

    public delegate void Del(Poolable obj);
    public Del LeaveScreenAction;
    public Del HalfScreenAction;

    private CameraChecker checker;
    private bool isHalfway;

    public bool rightMode;

    void Awake() {
        checker = new CameraChecker(Camera.main);
    }

    void Update() {
        
        if (rightMode) {
            RightModeChecks();
        }
        else
        {
            LeftModeChecks();
        }

    }

    void RightModeChecks()
    {
        if (!isHalfway)
        {
            if (checker.IsHalfwayRight(gameObject))
            {
                isHalfway = true;
                HalfScreenAction(this);
            }
        }

        if (checker.IsOutOfBoundsRight(gameObject))
        {
            LeaveScreenAction(this);
        }
    }

    void LeftModeChecks()
    {
        if (!isHalfway)
        {
            if (checker.IsHalfwayLeft(gameObject))
            {
                isHalfway = true;
                HalfScreenAction(this);
            }
        }

        if (checker.IsOutOfBoundsLeft(gameObject))
        {
            LeaveScreenAction(this);
        }
    }


    public void MoveToPosition(ParallaxScroller pos) { //movetoposition
        transform.SetParent(pos.transform);
        this.Setup(pos);
    }

    public void MoveToPool<T>(T pool) where T : MonoBehaviour { //gdi make an inheritance thing
        transform.SetParent(pool.transform);
        gameObject.SetActive(false);
    }

    public void SetActive(bool value){
        gameObject.SetActive(value);
    }

    private void Setup(ParallaxScroller pos){
        transform.localPosition = new Vector3(pos.startPosX, 0, 0);
        isHalfway = false;
    }
}
