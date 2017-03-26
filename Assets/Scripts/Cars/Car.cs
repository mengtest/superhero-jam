using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	public float startPos = -3; //TODO: fix the startpos to one relative to worldpoint

    public delegate void Del(Car car);
    public Del LeaveScreenAction;

    private CameraChecker checker;

    private bool isPlaying = true;

    //do I want acceleration?
    //make a static moving function and just add a feature if needed

    void Awake() {
        checker = new CameraChecker(Camera.main);

        GameManager.EndGame += StopPlaying;
        gameObject.SetActive(false);
    }

    void OnDestroy() {
        GameManager.EndGame -= StopPlaying;
    }

    void StartPlaying(){
        isPlaying = true;
    }

    void StopPlaying(){
        isPlaying = false;
    }

    void Update() {
        if (isPlaying) {
		    Move ();
        }

        if (checker.IsOutOfBounds(gameObject)){
            LeaveScreenAction(this);
        }
	}

    //oncolliderenter


    public void MoveToLane(Lane lane, float speed){
		transform.SetParent (lane.transform);
        this.speed = speed;
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
        transform.localPosition = new Vector3(startPos, 0, lane.transform.position.z + 0.1f);
        gameObject.layer = lane.layerIndex;
        transform.GetChild(0).gameObject.layer = lane.layerIndex;
    }

	private void Move(){
		transform.position += new Vector3(1, 0.0f, 0.0f) * speed * Time.deltaTime;
	}

}
