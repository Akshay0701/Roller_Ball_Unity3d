using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelobstcal : MonoBehaviour {
    public GameObject objecttodestroy;
    void OnCollisionEnter(Collision col)
    {
   
            Destroy(objecttodestroy);
        

    }
}
