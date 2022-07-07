using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    float DelayTime = 0.45f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Invoke("Direi_StartGame", DelayTime);

      
    }
    public void Direi_StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void TitleSene()
    {
        Invoke("Direi_TitleSene", DelayTime);

      
    }
    public void Direi_TitleSene()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }




    public void Scene_transition(string snene)
    {
        SceneManager.LoadScene(snene, LoadSceneMode.Single);
    }
   



}
