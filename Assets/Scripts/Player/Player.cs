using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public LaneManager laneManager;
    public int currentLaneIndex;

    public float jumpHeight;
    public float jumpTime;

    public bool isJumping;

    void Awake(){
        MoveToLane(laneManager.lanes[currentLaneIndex]);
    }

    public void MoveUp()
    {
        if (!isJumping)
        {
            if (currentLaneIndex > 0)
            {
                currentLaneIndex--;
                MoveToLane(laneManager.lanes[currentLaneIndex]);
            }
        }//endif
    }

    public void MoveDown()
    {
        if (!isJumping)
        {
            if (currentLaneIndex < laneManager.lanes.Length - 1)
            {
                currentLaneIndex++;
                MoveToLane(laneManager.lanes[currentLaneIndex]);
            }
        }//endif
    }

    public void Jump()
    {
    }

    private void MoveToLane (Lane lane){
        transform.SetParent (lane.transform);
        this.Setup(lane);
    }

    private void Setup(Lane lane)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
    }
}
