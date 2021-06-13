using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour
{
    public ScriptableInt value;
    public Text targetText;
    public void updateText(int value){
        targetText.text = "x"+ Mathf.Clamp(value+this.value.value,0,10);
    }
}
