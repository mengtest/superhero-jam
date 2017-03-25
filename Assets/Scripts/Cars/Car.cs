using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	public float startPos = -3; //TODO: fix the startpos to one relative to worldpoint

	//do I want acceleration?
	//make a static moving function and just add a feature if needed

	void Update(){
		Move ();
	}

	public void MoveToLane(Lane lane){
		transform.SetParent (lane.transform);
		this.Setup(lane);
	}

	public void MoveToPool(CarPool pool){
		transform.SetParent (pool.transform);
	}
		

	public void SetActive(bool value){
		gameObject.SetActive(value);
	}

	private void Setup(Lane lane){
		transform.localPosition = new Vector3(startPos, 0, 0);
	}

	private void Move(){
		transform.position += new Vector3(1, 0.0f, 0.0f) * speed * Time.deltaTime;
	}

	//oncolliderenter
}
