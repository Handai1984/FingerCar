using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D m_rigid;//增加刚体
    public float speed=0.5f;//移动速度
	public float rotateSpeed=1f; //旋转速度
    private Vector3 prepos;//之前的位置
    private Vector3 curretpos;//现在的位置
  
    private float endpos;

    private Wheel wheel;//方向盘


    private void Start()
    {
         // m_rigid = this.GetComponent<Rigidbody2D>();
        wheel = GameObject.Find("Wheel").GetComponent<Wheel>();
    }

    

    private void Update()
    {
        if (!GM.instante.isGameOver)
        {

			transform.Translate(Vector2.up * speed*Time.deltaTime);
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey("d"))
        {
				
            transform.Rotate(-Vector3.forward);
        }

        if (wheel.isMouseDown)
        {
				
				transform.Rotate(wheel.a.transform.forward*rotateSpeed *Time.deltaTime,Space.Self);
            
          

        }
        GM.instante.AddScore();	//增加分数
            GM.instante.ShowScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))//如果碰到地图边缘，游戏结束
        {
            GM.instante.isGameOver = true;
            GM.instante.reStart.SetActive(true);
            GM.instante.highScoreText.gameObject.SetActive(true);
            GM.instante.ShowHihgScore();

			GM.instante.GADInterstitalShow ();//广告播放
            this.gameObject.SetActive(false);
        }

		if (collision.gameObject.CompareTag ("Win")) {
			GM.instante.isGameOver = true;
			GM.instante.win.SetActive (true);
			GM.instante.highScoreText.gameObject.SetActive(true);
			GM.instante.ShowHihgScore();
			GM.instante.GADInterstitalShow ();
//			GM.instante.GameStart ();
		}
    }
}
