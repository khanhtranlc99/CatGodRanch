using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCalf : MonoBehaviour
{
    
 

   
    void Update()
    {
        this.transform.position += new Vector3(0, 1, 0) ;

        if (this.transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }    
    }




    

}
