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

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            RestartLevel();
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(levelIndex.value);
    }
    public void LoadNextLevel()
    {
        levelIndex.value++;
        if (levelIndex.value >= MaxLevelIndex.value)
        {
            SceneManager.LoadScene("GameCompleted");
        }
    }
}
