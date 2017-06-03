using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{	
	public float Velocidade;
	public bool Direcao;
	public float DuracaoDirecao;
	public int Dano;

	private float tempoNaDirecao;
	private Animator animator; 


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Direcao) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * Velocidade * Time.deltaTime);

		tempoNaDirecao += Time.deltaTime;
		if (tempoNaDirecao >= DuracaoDirecao) {
			tempoNaDirecao = 0;
			Direcao = !Direcao;
		}
	}


}