using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    Renderer targetrenderer;
    public GameObject Camera;
	void Start ()
    {
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        targetrenderer = GetComponent<Renderer>();
    }
	
	
	void Update ()
    {
        this.transform.Rotate(0, 3, 0);

       
	}

    private void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}
