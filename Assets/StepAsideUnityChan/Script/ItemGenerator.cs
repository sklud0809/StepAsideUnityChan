using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject carPrefab;
    public GameObject CoinPrefab;
    public GameObject conePrefab;
    public Transform unityChan;
    private Renderer _renderer;
    private int StartPos = -160; //スタート地点
    private int GoalPos = 120;　//ゴール地点
    private float PosRange = 3.4f;//アイテムを出すx方向の範囲
    
    private float RastGenerator; //最後に生成されたオブジェクトの位置
    private bool Cheakin;　//アイテム生成のオンオフ切り替え

    void Start()
    {
        Cheakin = true;

    }

    void Update ()
    {
        
      
        if (unityChan.transform.position.z <= StartPos - 50) //スタート地点よりも前では何もしない
        {
           // Debug.Log("何もしない");
        }
        else if(unityChan.transform.position.z <= StartPos)//スタート地点からアイテム生成開始
        {  
           if(Cheakin == true)
            {
                Generator();
               // Debug.Log("チェックポイント通過1 アイテム生成");
                Cheakin = false;
            }
           else if(Cheakin == false)
            {
               // Debug.Log("アイテム生成 終了");
            }
        }
        else if(unityChan.transform.position.z >= RastGenerator && unityChan.transform.position.z <= GoalPos - 60)//最後にアイテム生成された位置から再度アイテム生成　ゴール前では生成をやめる
        {
           // Debug.Log(RastGenerator + "の一定距離");
            if(Cheakin == false)
            {
                Generator();
               // Debug.Log("チェックポイント通過2 アイテム生成");
                Cheakin = true;
            }
            else if(Cheakin == true)
            {
                Generator();
               // Debug.Log("チェックポイント通過３　アイテム生成");
                Cheakin = true;    
            }
        }
        else if(unityChan.transform.position.z <= GoalPos -60)　//ゴール前（ｚ軸100）からは何もしない
        {
           // Debug.Log("何もしない");
        }
        

    }

    public void Generator()
    {

        //一定の距離にアイテムを出現
        for (float i = unityChan.transform.position.z + 30; i < unityChan.transform.position.z + 60; i +=10)
        {
            RastGenerator = i;
            ////どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 10);
            if (num <= 2)
            {
                // //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else for (int j = -1; j <= 1; j++) ////レーンごとにアイテムを生成
            {
                    // //アイテムの種類を決める
                    int Item = Random.Range(1, 11);
                    ////アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);

                    if (1 < Item && Item <= 6) // //60%コイン配置:30%車配置:10%何もなし
                    {
                        GameObject coin = Instantiate(CoinPrefab) as GameObject;
                        coin.transform.position = new Vector3(PosRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= Item && Item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(PosRange * j, car.transform.position.y, i + offsetZ);
                        
                    }

            }
           
        }
    }
}
