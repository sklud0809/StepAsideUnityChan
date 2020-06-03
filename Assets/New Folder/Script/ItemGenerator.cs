using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject carPrefab;
    public GameObject CoinPrefab;
    public GameObject conePrefab;
    private int StartPos = -160; //スタート地点
    private int GoorlPos = 120;　//ゴール地点
    private float PosRange = 3.4f;//アイテムを出すx方向の範囲

	void Start ()
    {
        //一定の距離にアイテムを出現
		for (int i = StartPos; i < GoorlPos; i += 15)
        {
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else for (int j = -1; j <= 1; j++)
                {
                    int Item = Random.Range(1,11);

                    int offsetZ = Random.Range(-5, 6);

                    if(1 < Item && Item <= 6)
                    {
                        GameObject coin = Instantiate(CoinPrefab) as GameObject;
                        coin.transform.position = new Vector3(PosRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if(7 <= Item && Item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(PosRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
        }
	}
	
	
	void Update ()
    {
		
	}
}
