using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour, IInteractable
{
    GameManager gameManager;
    bool inRange = false;
    public GameObject interactText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.Log("GameManager in spike doesnt exist please drag a GameManager into the scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(false);
            inRange=false;
        }
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact(GameObject owner, GameObject interactable)
    {
        if(owner.GetComponent<PencilLeadStat>().StatValue>0&&owner.GetComponent<PencilEraserStat>().StatValue>0&&Input.GetKey(KeyCode.E)){
            gameManager.LoadNextLevel();
        }
    }
}
