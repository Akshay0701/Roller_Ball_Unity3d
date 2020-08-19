using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distroy : MonoBehaviour {
    public GameObject player;
    public GameObject controles;
    public GameObject gameoverui;

    void OnCollisionEnter(Collision col)
    {

        Destroy(player);
        Destroy(controles);
        gameoverui.SetActive(true);


    }
    // Update is called once per frame
    void Update () {
		
	}
}
