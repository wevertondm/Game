using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Velocidade;

	public float forcaPulo = 100f;
	public Rigidbody2D rb;
	private Animator animator;
	public Transform spritePlayer;

	public int VidaAtual;
	public GameObject Vida;
	public int MaxVida;
	public bool colisao = false;

	public int DanoMonstro;

	public LayerMask Piso;
	public bool estaNoChao;	

	public Vector2 pontoColisaoPiso = Vector2.zero;
	public float raio;
	public Color debugCorColisao = Color.red;


/// Declaraçoes
/// //////////////////////////////////////////////////////////////////////////////////////////////////////
/// Start e Update

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator>();

		VidaAtual = MaxVida; 
		Vida.GetComponent<GUIText> ().color = new Vector4 (0.25f, 0.5f, 0.25f, 1f); 


	}
	// Update is called once per frame
	void Update () {
		
		Movimentacao();
		EstaNoChao ();
		ControlarEntrada ();


		Vida.GetComponent<GUIText> ().text = "Vida: " + VidaAtual + "/" + MaxVida;
	}

/// Start e Update
/// ////////////////////////////////////////////////////////////////////////////////////////////////////
/// Movimentacao
	 
	void Movimentacao() {
		animator.SetFloat ("Movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.Translate (Vector2.right * Velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * Velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}	
		animator.SetBool ("chao", estaNoChao);

	}

/// Movimentacao
/// //////////////////////////////////////////////////////////////////////////////////////////////////////

	private void EstaNoChao()
	{
		var pontoPosicao = pontoColisaoPiso;
		pontoPosicao.x += transform.position.x;
		pontoPosicao.y += transform.position.y;
		estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, Piso);
	}

	void Pular()
	{
		if(estaNoChao && rb.velocity.y <= 0)
		{
			rb.AddForce (new Vector2( 0, forcaPulo));	
		}
	}

	private void ControlarEntrada()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			Pular();
		}			
	}

	void OnDrawGizmos()
	{
		Gizmos.color = debugCorColisao;
		var pontoPosicao = pontoColisaoPiso;
		pontoPosicao.x += transform.position.x;
		pontoPosicao.y += transform.position.y;
		Gizmos.DrawWireSphere (pontoPosicao, raio);
	}

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////
/// </summary>

	public void PerdeVida(int dano) {

		VidaAtual -= dano;


		if ((VidaAtual * 100 / MaxVida) < 30) {    // se a vida atual for menor que 30 coloca a cor vermelha
			Vida.GetComponent<GUIText> ().color = Color.red;
			Vida.GetComponent<GUIText> ().text = "Vida: " + VidaAtual + "/" + MaxVida; //atualiza o valor da vida dps do dano 
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Inimigo") 
		{
			colisao = true;
			PerdeVida(DanoMonstro);

		}

		if (other.gameObject.tag == "Buraco") 
		{
			colisao = true;
			PerdeVida(VidaAtual);

		}

		if (VidaAtual <= 0) {
			
		}
	}
		
}    	 	 	 	