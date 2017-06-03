using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float Velocidade;
	public Transform spritePlayer;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		Movimentacao();
	}

	void Movimentacao() {

		if (GameObject.FindGameObjectWithTag ("MainCamera").transform.position != GameObject.FindGameObjectWithTag ("Player").transform.position) 
		{
			var aux = (GameObject.FindGameObjectWithTag ("Player").transform.position.x);
			Vector3 temp = new Vector3 (aux, transform.position.y, transform.position.z);
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = temp;
		}

		else {

			if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.Translate (Vector2.right * Velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
			}

			if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector2.left * Velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
			}	
		}

	}
}