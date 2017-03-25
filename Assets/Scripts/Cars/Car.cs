using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	public float startPos = -3; //TODO: fix the startpos to one relative to worldpoint

    public delegate void Del(Car car);
    public Del LeaveScreenAction;

    private CameraChecker checker;

    //do I want acceleration?
    //make a static moving function and just add a feature if needed

    void Awake() {
        checker = new CameraChecker(Camera.main);
    }

	void Update() {
		Move ();
 
        if (checker.IsOutOfBounds(gameObject)){
            LeaveScreenAction(this);
        }
	}

    //oncolliderenter


    public void MoveToLane(Lane lane){
		transform.SetParent (lane.transform);
		this.Setup(lane);
	}
    
	public void MoveToPool(CarPool pool){
		transform.SetParent (pool.transform);
        gameObject.SetActive(false);
	}	

	public void SetActive(bool value){
		gameObject.SetActive(value);
	}

	private void Setup(Lane lane){
		transform.localPosition = new Vector3(startPos, 0, 0);
        gameObject.layer = lane.layerIndex;
    }

	private void Move(){
		transform.position += new Vector3(1, 0.0f, 0.0f) * speed * Time.deltaTime;
	}

}
