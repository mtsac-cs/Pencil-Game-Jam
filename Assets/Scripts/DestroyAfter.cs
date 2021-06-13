using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public GameObject playerCamera;
    void Awake()
    {
        playerCamera = GameObject.Find("PlayerCamera");
        playerCamera.SetActive(false);
        Invoke("DieAfter",1f);
    }
    void DieAfter(){
        playerCamera.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
