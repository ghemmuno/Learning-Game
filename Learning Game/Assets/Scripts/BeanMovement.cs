using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMovement : MonoBehaviour
{
    public GameObject bean;
    public static int beanName = 1;
    
    public static int updateBean(int i){
        beanName += i;
        return beanName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(zDir/65, 0.0f, -xDir/65);
        if(bean.name == beanName.ToString()){
            transform.position += moveDir;
        }
            
    }
}
