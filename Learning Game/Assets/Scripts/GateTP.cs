using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gate TP function for lvl 1-3

public class GateTP : MonoBehaviour
{
    public GameObject bean;
    private void OnTriggerEnter(Collider other){
        bean.transform.position = new Vector3(-22f, .5f, 0f);
    }
    
}
