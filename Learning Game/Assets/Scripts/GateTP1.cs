using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gate TP function for lvl 1-4

public class GateTP1 : MonoBehaviour
{
    public GameObject bean;
    private void OnTriggerEnter(Collider other){
        bean.transform.position = new Vector3(-24f, 3f, -33f);
    }
    
}
