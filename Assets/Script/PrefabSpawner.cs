using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {
	private float nextSpawn = 0;
	private float startTime;
	
	public Transform PrefabSpawn;
	public AnimationCurve SpawnCurve;
	public float CurveLengthInSecs = 30;
	public float jitter = 0.5f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
		{
			Instantiate(PrefabSpawn,transform.position, Quaternion.identity);
			//nextSpawn = Time.time + SpawnRate + Random.Range(0,RandomDelay);
			
			float curvePos = (Time.time - startTime) / CurveLengthInSecs;
			if (curvePos > 1f)
			{
				curvePos = 1;
				startTime = Time.time;
			}
			nextSpawn = Time.time + SpawnCurve.Evaluate(curvePos) + Random.Range(-jitter,jitter);
		}
	}
}
