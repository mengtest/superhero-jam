using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPool : MonoBehaviour {

	public List<GameObject> bigCars;
	public List<GameObject> smallCars;

	public Pool<Car> bigCarPool;
	public Pool<Car> smallCarPool;

	void Awake(){
		bigCarPool = new Pool<Car>(2);
		smallCarPool = new Pool<Car>(2);

		Spawner<Car> (bigCars, bigCarPool.pool, bigCarPool.count);
		Spawner<Car> (smallCars, smallCarPool.pool, smallCarPool.count);

        foreach (Car car in bigCarPool.pool){
            car.LeaveScreenAction += ReturnToPool;
        }

        foreach (Car car in smallCarPool.pool){
            car.LeaveScreenAction += ReturnToPool;
        }
    }

	void Spawner<T>(List<GameObject> objectList, List<T> poolList, int count) where T: UnityEngine.Component{
		GameObject temp;
		int i, j;

		for (i=0; i < objectList.Count; i++) {
			for (j = 0; j < count; j++) {
				temp = Instantiate (objectList [i], transform);
                poolList.Add (temp.GetComponent<T> ());
			}
		}
	} //end function

    void ReturnToPool(Car car){ //make IPoolable later?
        car.MoveToPool(this);
    }
}