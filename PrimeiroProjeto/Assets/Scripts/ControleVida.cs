using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVida : MonoBehaviour {
	
	public GameObject Vida;
	public int MaxVida;
	private int VidaAtual;  
	private Animator animator;
	public Transform spritePlayer;


	void Start () {
		//Vida
		VidaAtual = MaxVida; // no início do jogo a vida atual é igual ao máximo de vida 
		Vida.GetComponent<GUIText> ().color = new Vector4 (0.25f, 0.5f, 0.25f, 1f); //vida 100% fica verde
		Vida.GetComponent<GUIText> ().text = "Vida: " + VidaAtual + "/" + MaxVida; // frase do box da vida (altera quando perder vida)
	}
	void Update () {
		
	}
			
	public void PerdeVida(int dano) {
		
		VidaAtual -= dano;  //a vida atual diminui quando levar o dano (colisão)

		if ((VidaAtual * 100 / MaxVida) < 30) {    // se a vida atual for menor que 30 coloca a cor vermelha
			Vida.GetComponent<GUIText> ().color = Color.red;
			Vida.GetComponent<GUIText> ().text = "Vida: " + VidaAtual + "/" + MaxVida; //atualiza o valor da vida dps do dano 
		}
	}

	void OnTriggerEnter2D(BoxCollider2D colisor) {
		if (colisor.gameObject.tag == "Inimigo")
		{
			Monstro Monstro = new Monstro ();
			PerdeVida(Monstro.Dano);
			//colisor.gameObject.transform.Translate(-Vector2.right);
		}
	}




}