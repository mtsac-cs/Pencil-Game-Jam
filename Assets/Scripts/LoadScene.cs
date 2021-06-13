using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public ScriptableInt levelIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        SceneManager.LoadScene(levelIndex.value);
    }

    public void endGame(){
        Debug.Log("exited game");
        Application.Quit();
    }

    public void ResetGame(){
        if(levelIndex==null){
            Debug.Log("levelIndex in LoadScene is null");
        }else{
            levelIndex.value = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
