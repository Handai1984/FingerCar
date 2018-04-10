using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundMap : MonoBehaviour
{
	public GameObject mid;
//中间圆
	private Transform[] roadTransform;
	public GameObject[] road;
//路
	private List<Transform> aaa;

	void Start ()
	{
		
		roadTransform =new Transform[mid.GetComponentsInChildren<Transform>().Length];
		aaa = new List<Transform> ();
		for (int i = 1; i < roadTransform.Length; i++) {
			roadTransform [i] = mid.GetComponentsInChildren<Transform>()[i];
			aaa.Add (roadTransform[i]);
		}
		print (aaa.Count);
		for (int i = 0; i < aaa.Count; i++) {
			print (aaa[i].name);
		}
		print (road.Length);
		RandLoad ();
	}



	void RandLoad ()
	{
		int a = aaa.Count;
		for (int i = 0; i < road.Length; i++) {
			int b = Random.Range (0,	a);
			Instantiate (road [i], aaa [i].position, Quaternion.identity);

//			aaa.Remove (aaa [b]);
			a--;
		}
	}
	 
}
