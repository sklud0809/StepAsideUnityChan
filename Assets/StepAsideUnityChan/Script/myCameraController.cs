using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCameraController : MonoBehaviour {
    private GameObject unitycahn;
    private float defference;

   

    void Start ()
    {
        // Unityちゃんのオブジェクトを取得
        this.unitycahn = GameObject.Find("unitychan");

        //Unityちゃんとカメラの位置の差を求める
        this.defference = unitycahn.transform.position.z - this.transform.position.z;
       
	}
	
	
	void Update ()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, unitycahn.transform.position.z - defference);

       
	}
}
