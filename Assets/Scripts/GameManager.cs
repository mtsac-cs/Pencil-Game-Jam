using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public ScriptableInt levelIndex;
    public ScriptableInt MaxLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        levelIndex.value++;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            levelIndex.value--;
            RestartLevel();
        } 
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(levelIndex.value);
    }
    public void LoadNextLevel()
    {
        if (levelIndex.value > MaxLevelIndex.value)
        {
            SceneManager.LoadScene("GameComplete");
        }else{
            SceneManager.LoadScene(levelIndex.value);
        }
    }
}
