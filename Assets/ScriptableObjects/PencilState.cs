using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PencilState")]
public class PencilState : ScriptableObject
{
    public int bodyTypeID;
    public bool hasEraserModel;
    public bool hasLeadModel;
}