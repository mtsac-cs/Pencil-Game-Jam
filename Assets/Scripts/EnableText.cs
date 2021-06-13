using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableText : MonoBehaviour
{
    public GameObject interactText;


    // Start is called before the first frame update
    void Start()
    {
        if(interactText==null){
            Debug.Log("interactText in EnableText Script is null please add a text object to it");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(false);
        }
    }

}
