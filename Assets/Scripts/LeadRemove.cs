using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadRemove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            other.GetComponent<PencilLeadStat>().SetValue(Mathf.Clamp(other.GetComponent<PencilLeadStat>().StatValue-1,0,100));
        }
    }
}
