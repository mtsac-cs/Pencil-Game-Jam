using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public ScriptableInt LevelIndex;
    public ScriptableInt MaxLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        LevelIndex.value++;
        if(LevelIndex.value>=MaxLevelIndex.value){
            LevelIndex.value=2;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            RestartLevel();
        } 
    }
    public void RestartLevel()
    {
        LevelIndex.value--;
        SceneManager.LoadScene(LevelIndex.value);
    }
    public void LoadNextLevel()
    {
        if (LevelIndex.value > MaxLevelIndex.value)
        {
            SceneManager.LoadScene("GameComplete");
        }else{
            SceneManager.LoadScene(LevelIndex.value);
        }
    }
}
