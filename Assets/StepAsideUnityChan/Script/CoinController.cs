using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    Renderer targetrenderer;
   // public GameObject Camera;
    

	void Start ()
    {
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        targetrenderer = GetComponent<Renderer>();
    }
	
	
	void Update ()
    {
        this.transform.Rotate(0, 3, 0);
        
        if(Camera.main.transform.position.z >= this.transform.position.z)
        { 
            
          //  Debug.Log("コイン　消滅");
            Destroy(this.gameObject);
        }
	}


}
