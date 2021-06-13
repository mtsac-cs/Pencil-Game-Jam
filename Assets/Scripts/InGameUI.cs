using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    public Text pencilLeadText;
    public Text pencilEraserText;

    private void Awake()
    {
        instance = this;
    }
}
