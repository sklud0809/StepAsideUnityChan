using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour {

	
	void Start ()
    {
		
	}


    void Update()
    {
        if (Camera.main.transform.position.z >= this.transform.position.z)
        {

           // Debug.Log("コーン　消滅");
            Destroy(this.gameObject);


        }
    }
}
