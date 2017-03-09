using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdController : MonoBehaviour {

	[Header("Velocity")]
	public float flappyVelocity;

	[Header("FlappyBird states")]
	public bool isDead = false;

	private Animator animator;
	private Rigidbody2D rigidBody2d;
	private Sheep_Sounds my_sounds;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rigidBody2d = GetComponent<Rigidbody2D> ();
		my_sounds = GetComponent<Sheep_Sounds> ();

		// Convertendo de coordenadas de Tela para Mundo
		Vector3 startPos = 
			Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.8f));

		startPos.z = -1.58f; // Para garantir visibilidade do FlappyBird

		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;


		if (Input.GetButtonDown("Jump")) {
			my_sounds.PlayJump ();
			FlappyWings ();
		}

		Vector3 angles = transform.eulerAngles;
		angles.z = Mathf.Clamp (rigidBody2d.velocity.y * 4f, -90f, 45f);
		transform.eulerAngles = angles;

		if (transform.position.y <= -4.5f)
		{
			StartCoroutine (ReloadLevel ());
		}
	}

	// Faz o FlappyBird bater asas
	void FlappyWings() {
		// Anima o FlappyBird
		animator.SetTrigger ("Flappy");
		// Movimenta o FlappyBird
		rigidBody2d.velocity = Vector2.up * flappyVelocity;

	}

	void OnCollisionEnter2D(Collision2D collision) {
		// Se for pipe entao mata o FlappyBird

		if (collision.collider.CompareTag ("Pipe")) {
			// Mooorreu :(
			StartCoroutine (ReloadLevel ());
		}
	}

	IEnumerator ReloadLevel()
	{
		isDead = true;
		my_sounds.PlayDeath ();
		GetComponent<Collider2D> ().isTrigger = true;
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("Game");
	}
}
