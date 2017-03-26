using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

	public CarPool carPool;
	public LaneManager laneManager;

	public float currentTime;

    public bool isSpawning;

    void Awake() {
        StartSpawning();

        GameManager.StartGame += StartSpawning;
        GameManager.EndGame += StopSpawning;
    }

    void OnDestroy()
    {
        GameManager.StartGame -= StartSpawning;
        GameManager.EndGame -= StopSpawning;
    }

	void Update(){
		//TODO: make something that randomizes spawn time and spawn amount
        if (isSpawning){
            currentTime += Time.deltaTime;

            if (currentTime >= 1)
            {
                Spawn();
                currentTime = 0;
            }
        }
	}

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    void Spawn(){
		SpawnTo (ChooseLane());
	}
		
	/**
	 Randomizes Lane to spawn at
	 **/
	private Lane ChooseLane(){
		int laneIndex;
		//TODO
			//while lane.transform.childCount < lane.maxAmountOfCars 
				laneIndex = Random.Range (0,laneManager.lanes.Length);
				//Debug.Log (laneManager.lanes[laneIndex]);

		return laneManager.lanes[laneIndex];
	}

	/**
	 Randomizes what Car to spawn at the specified Lane
	 Doesn't spawn if Lane is null (it's prettier this way)
	 **/
	private void SpawnTo(Lane lane){
		if (lane != null) {
				int tempIndex = Random.Range (0, 100);
				//Debug.Log (tempIndex);

						if (tempIndex <= 70 /*&& 													//spawns small car
							carPool.smallCarPool.deployed < carPool.smallCarPool.pool.Count*/) { 	//if deployed < list size
							TakeCarFromPool(carPool.smallCarPool).MoveToLane(lane);
						}

						if (tempIndex > 70 /*&&												//spawns big car
							/*carPool.bigCarPool.deployed < carPool.bigCarPool.pool.Count*/){ 	//if deployed < list size
							TakeCarFromPool(carPool.bigCarPool).MoveToLane(lane);
						}
		}
	}

	/**
	 Randomly takes an inactive car from the pool
	 **/
	private Car TakeCarFromPool(Pool<Car> carPool){ //make this prettier
		int i = 0;

				while ( carPool.pool [i].gameObject.activeInHierarchy /*&&
                        carPool.deployed < carPool.pool.Count*/)
                {

					i = Random.Range (0, carPool.pool.Count);
				}

		carPool.pool [i].gameObject.SetActive (true);
		//carPool.deployed++;

		return carPool.pool[i];
	}

}
