using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown = 2f;
    float time=0;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.Log("GameManager in spike doesnt exist please drag a GameManager into the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            if(Time.time-time>cooldown){
                time = Time.time;
                gameManager.RestartLevel();
            }
        }
    }
}
