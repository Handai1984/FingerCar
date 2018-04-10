using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Wheel : MonoBehaviour {
    public  bool isMouseDown = false;//鼠标或手指有没有按住方向盘
    public  RectTransform uiWheel;//获取UI方向盘
	public  float totalAngle;
	private Vector3 prePos;
    public bool isleft;


	public GameObject  a;

    private void Start()
    {
        uiWheel = GetComponent<RectTransform>();
            
    }

    private void Update()
    {
        if (isMouseDown )
        {
			uiWheel.rotation = Quaternion .Lerp (uiWheel.rotation , Quaternion.Euler(0, 0, rotateAngle ()),5*Time.deltaTime);
            Debug.Log(rotateAngle());
			Quaternion b = a.transform.rotation;
		
			print ("a的z是"+b.z); 
			a.transform.rotation =Quaternion .Slerp (a.transform .rotation , Quaternion.Euler(0, 0, rotateAngle ()+totalAngle),5*Time.deltaTime);

			totalAngle = 0;
        }
        else
        {
            //方向盘回正
			totalAngle = rotateAngle ();
            uiWheel.rotation = Quaternion.Lerp(uiWheel.rotation, Quaternion.Euler(Vector3.zero), 5*Time.deltaTime);

        }
    }

    public void MouseDown()
    {
		
        isMouseDown = true;
        Debug.Log(isMouseDown);
    }

    public void MouseUp()
    {
        isMouseDown = false;
        Debug.Log(isMouseDown);
    }

    float rotateAngle()
    {
        //方向盘旋转 用当前的鼠标位置-原来位置得到方向向量，由方向向量得到角度 tag()=y/x,然后转成四元数
        Vector3 mouse = Input.mousePosition;
        Vector3 newPos = new Vector2(uiWheel.position.x, uiWheel.position.y);
        Vector3 temp = (mouse - newPos).normalized;

        float agle = Mathf.Atan2(temp.x, temp.y) * Mathf.Rad2Deg;
		   return -agle;
    }

}  

