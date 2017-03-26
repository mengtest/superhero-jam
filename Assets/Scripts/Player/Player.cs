using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public LayerMask layerMask;

    public LaneManager laneManager;
    public int currentLaneIndex;

    public Vector3 jumpPos;

    public bool jump;
    public bool isGrounded;

    public GameObject shadow;
    private Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
        MoveToLane(laneManager.lanes[currentLaneIndex]);
    }

    void FixedUpdate()
    {
        if (jump)
        {
            transform.position += jumpPos;
            isGrounded = jump = false;
            animator.SetBool("isJumping", true);
        }

    }

    ///////////Actions

    public void MoveUp()
    {
        /*if (isGrounded)
        {*/
            if (currentLaneIndex > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, layerMask);
                if (hit.collider == null){
                    currentLaneIndex--;
                    MoveToLane(laneManager.lanes[currentLaneIndex]);
                }
            }
        //}//endif
    }

    public void MoveDown()
    {
        /*if (isGrounded)
        {*/
            if (currentLaneIndex < laneManager.lanes.Length - 1)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layerMask);
                if (hit.collider == null){
                    currentLaneIndex++;
                    MoveToLane(laneManager.lanes[currentLaneIndex]);
                }
            }
        //}//endif
    }

    public void Jump(){
    }

    private void MoveToLane (Lane lane){
        transform.SetParent (lane.transform);
        this.Setup(lane);
    }

///////////Setups

    private void Setup(Lane lane)
    {
        //if lane == top then use a custom pos //imsorry
        
        if (isGrounded) {
            transform.localPosition = new Vector3(transform.localPosition.x, 0, lane.transform.position.z - 0.1f);
        }

        else {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, lane.transform.position.z - 0.1f);
        }

        SetLayer(lane);
    }

    private void SetLayer(Lane lane){
        gameObject.layer = lane.layerIndex;
        shadow.layer     = lane.layerIndex;
    }

///////////Collisions

    void OnCollisionStay2D()
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }
}
