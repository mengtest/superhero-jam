using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour {

    public float startPosX;
    public float distance;

    public float scrollSpeed;
    private float speed;

    public string poolName;
    public BackgroundPool backgroundPool;

    private Pool<Poolable> pool;

    void Start(){
        pool = (Pool<Poolable>)typeof(BackgroundPool).GetField(poolName).GetValue(backgroundPool);
        speed = scrollSpeed;

        foreach (Poolable obj in pool.pool){
            obj.HalfScreenAction += Spawn;

            if (scrollSpeed < 0){
                obj.rightMode = true;
            }
        }

        Spawn();
    }

    void Update() {
        Scroll();
    }

    public void Spawn() {
        TakeFromPool(pool).MoveToPosition(this);
        startPosX += distance;
    }

    public void Spawn(Poolable obj)
    {
        TakeFromPool(pool).MoveToPosition(this);
        startPosX += distance;
    }

    private void Scroll(){
        transform.position -= new Vector3(1, 0.0f, 0.0f) * speed * Time.deltaTime;
    }

    /**
	 Randomly takes an inactive thing from the pool
	 **/
    private Poolable TakeFromPool(Pool<Poolable> pool)
    { 
        int i = 0;
        int j = 0;

        while (pool.pool[i].gameObject.activeInHierarchy)
        {
            i = Random.Range(0, pool.pool.Count);
        }
        pool.pool[i].gameObject.SetActive(true);

        return pool.pool[i];
    }

}
