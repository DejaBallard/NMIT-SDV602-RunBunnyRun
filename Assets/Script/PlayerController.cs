using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float JumpHeight = 500;
	public Text TxtScore;

	private Rigidbody2D rigidBody;
	private Collider2D collider;
	private Animator animator;
	private float playerHurtTime = -1;
	private float startTime;
	private int jumpLeft = 2;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();		
		animator = GetComponent<Animator>();
		collider = GetComponent<Collider2D>();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHurtTime == -1)
		{
			if (Input.GetButtonUp("Jump") && jumpLeft > 0){
				if (rigidBody.velocity.y < 0)
				{
					rigidBody.velocity = Vector2.zero;
				}
			rigidBody.AddForce(transform.up * JumpHeight);
				jumpLeft --;
			}
			animator.SetFloat("Velocity",rigidBody.velocity.y);
			TxtScore.text = (Time.time - startTime).ToString("0.0");
		}
	else
	{
		if (Time.time > playerHurtTime + 2)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
			{
				spawner.enabled = false;
			}
			foreach (EnemyBehaviour enemyBehavior in FindObjectsOfType<EnemyBehaviour>())
			{
				enemyBehavior.enabled = false;
			}
			playerHurtTime = Time.time;
			animator.SetBool("Hurt",true);
			rigidBody.velocity = Vector2.zero;
			rigidBody.AddForce(transform.up * JumpHeight);
			collider.enabled = false;
		}
		else if (collision.collider.gameObject.layer ==LayerMask.NameToLayer("Ground"))
		{
			jumpLeft =2;
		}
	}
}
