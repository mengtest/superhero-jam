using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void Del();
    public static Del StartGame;
    public static Del EndGame;

    void Awake()
    {
        EndGame += Reload;
    }

    void OnDestroy()
    {
        EndGame -= Reload;
    }

    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void UnloadMenu(){
        Invoke("_UnloadMenu", 3);
    }

    private void _UnloadMenu(){
        SceneManager.UnloadSceneAsync("Menu");
    }

    public void Reload(){
        Invoke("_Reload", 8);
    }

    private void _Reload(){
        SceneManager.LoadScene("Game");
    }
}
