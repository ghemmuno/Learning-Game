using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject bean;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        BeanMovement.updateBean(1);
    }
}
