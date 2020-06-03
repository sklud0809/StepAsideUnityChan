using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnityChanController : MonoBehaviour {
    private Animator myAnimator; //アニメーターの取得
    private Rigidbody myRigidbody;//リジッドボディの取得
    private float forwardForce = 800.0f;//前進する速度
    private float turnForce = 500.0f;//左右へ移動する速度
    private float movableRange = 3.4f;//左右へ移動できる範囲
    private float UpForce = 500.0f; //ジャンプ力
    private float coefficient = 0.95f;
    private bool isEnd = false;

    private GameObject StateText;
    private GameObject ScoreText;
    int Score = 0;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;


    void Start ()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("Speed", 1f);

        myRigidbody = GetComponent<Rigidbody>();

        this.StateText = GameObject.Find("GameResultText");
        this.ScoreText = GameObject.Find("ScoreText");
	}
	
	
	void Update ()
    {
        //ゲーム終了ならUnityちゃんの動きを減速させる。
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.UpForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        //前に前進する処理
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);


        //左右への移動処理　+　範囲設定
        if((Input.GetKey(KeyCode.LeftArrow) || isLButtonDown)&&  -this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if((Input.GetKey(KeyCode.RightArrow) || isRButtonDown)&& this.transform.position.x < this.movableRange)
        {
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            myAnimator.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.Space) && this.transform.position.y <0.5f)
        {
            myAnimator.SetBool("Jump", true);
            myRigidbody.AddForce(this.transform.up * this.UpForce);
        }

        
	}

    private void OnTriggerEnter(Collider other)
    {

        //　Car　Cone Coin Goalと衝突した際の処理
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.StateText.GetComponent<Text>().text = "GAME OVER";
        }
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.StateText.GetComponent<Text>().text = "CLEAR!!";
        }
        if(other.gameObject.tag == "CoinTag")
        { 
            // パーティクルの再生
            GetComponent<ParticleSystem>().Play();

            this.Score += 10;
            this.ScoreText.GetComponent<Text>().text = "Score" + this.Score + "pt";
                //コインオブジェクトの破壊
            Destroy(other.gameObject);
        }
    }

    public void GetMyJumpButtonDown()
    {
        if(this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.UpForce);
        }
    }

    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}