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

    public float lerpTime;
    private float currentLerpTime;

    void Awake()
    {
        GameManager.StartIntro += SpeedDownToZero;
        GameManager.StartGame += SpeedUpFromZero;
        GameManager.EndGame += Stop;
    }

    void OnDestroy()
    {
        GameManager.StartIntro -= SpeedDownToZero;
        GameManager.StartGame -= SpeedUpFromZero;
        GameManager.EndGame -= Stop;
    }

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

    void FixedUpdate() {
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

    void SpeedDownToZero()
    {
        StartCoroutine("_SpeedDown", 0);
    }

    void SpeedUpFromZero()
    {
        StartCoroutine("_SpeedUp", 0);
    }

    void Stop()
    {
        speed = 0;
    }

    IEnumerator _SpeedDown(float endSpeed){

        if (scrollSpeed != 0) {
            float perc=0;

            while (perc < 1) {
                currentLerpTime += Time.deltaTime;
                perc = currentLerpTime / lerpTime;
                speed = Mathf.Lerp(scrollSpeed, endSpeed, perc);
                yield return new WaitForSeconds(0.05f);
            }

            perc = 0;
            currentLerpTime = 0;
        }
        yield return null;

    }

    IEnumerator _SpeedUp(float startSpeed)
    {
        if (scrollSpeed != 0){
            float perc = 0;

            while (perc < 1)
            {
                currentLerpTime += Time.deltaTime;
                perc = currentLerpTime / (lerpTime/2);
                speed = Mathf.Lerp(startSpeed, scrollSpeed, perc);
                yield return new WaitForSeconds(0.05f);
            }

            perc = 0;
            currentLerpTime = 0;
        }
        yield return null;
    }

}
