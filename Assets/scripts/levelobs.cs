using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelobs : MonoBehaviour {
    public GameObject obstcal;
	// Use this for initialization
	void Start () {
        obstcal.SetActive(false);
	}
	
	// Update is called once per frame
	void OnCollisionenter (Collision col) {
        obstcal.SetActive(true);

	}
}
