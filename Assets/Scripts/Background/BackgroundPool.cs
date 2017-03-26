using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPool : MonoBehaviour {

    public Pool<Poolable> cloudPool;
    public Pool<Poolable> buildingPool;
    public Pool<Poolable> pavementPool;
    public Pool<Poolable> lampPool;

    public List<GameObject> clouds;
    public List<GameObject> buildings;
    public List<GameObject> pavement;
    public List<GameObject> lamps;

    void Awake()
    {
        cloudPool = new Pool<Poolable>(3);
        buildingPool = new Pool<Poolable>(3);
        pavementPool = new Pool<Poolable>(3);
        lampPool = new Pool<Poolable>(3);

        Spawner<Poolable>(clouds, cloudPool.pool, cloudPool.count);
        Spawner<Poolable>(buildings, buildingPool.pool, buildingPool.count);
        Spawner<Poolable>(pavement, pavementPool.pool, pavementPool.count);
        Spawner<Poolable>(lamps, lampPool.pool, lampPool.count);

        foreach (Poolable obj in cloudPool.pool){
            obj.LeaveScreenAction += ReturnToPool;
        }
        foreach (Poolable obj in buildingPool.pool)
        {
            obj.LeaveScreenAction += ReturnToPool;
        }
        foreach (Poolable obj in pavementPool.pool)
        {
            obj.LeaveScreenAction += ReturnToPool;
        }
        foreach (Poolable obj in lampPool.pool)
        {
            obj.LeaveScreenAction += ReturnToPool;
        }

    }

    void Spawner<T>(List<GameObject> objectList, List<T> poolList, int count) where T : UnityEngine.Component {
        GameObject temp;
        int i, j;

        for (i = 0; i < objectList.Count; i++)
        {
            for (j = 0; j < count; j++)
            {
                temp = Instantiate(objectList[i], transform);
                poolList.Add(temp.GetComponent<T>());
            }
        }
    } //end function

    void ReturnToPool(Poolable obj)
    { 
        obj.MoveToPool<BackgroundPool>(this);
    }
}
