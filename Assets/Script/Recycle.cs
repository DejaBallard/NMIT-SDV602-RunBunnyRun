using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour {
	public Transform StartPoint;
	public Transform EndPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < EndPoint.position.x)
		{
			float gap = EndPoint.position.x - transform.position.x;
			transform.position = new Vector3(StartPoint.position.x - gap,transform.position.y,transform.position.z);
		}
	}
}
