using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
	public bool finSala;

	//Declaro la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
	private Rigidbody rb;

	//Declaro la variable pública velocidad para poder modificarla desde la Inspector window
	[Range(1, 10)]
	[SerializeField] float velocidad = 3;
	[SerializeField] float velocidadN = 4;
	[SerializeField] float velocidadDistinta = 2.5f;
	private Vector2 direccion;
	public float sensibilidad = .5f;
	float turn;
	Vector3 parado;
	bool isd;
	float dsp = 60;
	public float timedash = 3;
	bool mando;
	public GameObject modPers;
	Animator anim;
	public GameObject particulasAndar;
	Vector3 lp;
	Vector3 ai;
	public bool mejoraDash;
	void Start()
	{

		//Capturo el rigidbody del jugador al iniciar el juego
		rb = GetComponent<Rigidbody>();
		sensibilidad = 1000;
		finSala = false;
		mando = false;
		anim = modPers.GetComponent<Animator>();
		particulasAndar.SetActive(false);
		mejoraDash = false;
	}

	void Update()
	{
		Vector3 movimiento;
		//Capturo el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
		//direccion = (Vector2)(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		//turn = Mathf.Atan2(direccion.y-direccion.x, direccion.x+direccion.y) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(-turn,Vector3.up);
		

		transform.rotation = Quaternion.Euler(new Vector3(0, -turn, 0));
		if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
		{
			velocidad = velocidadDistinta;
		}
		else { velocidad = velocidadN; }
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
		{
			velocidad = velocidadN;
		}
		//Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
		float jx = Input.GetAxis("JyX");
		float jy = Input.GetAxis("JyY");
		if ((jx == 0 && jy == 0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
			mando = false;
		}
		if ((jx != 0 && jy != 0) && (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0))
        {
			Vector3 move = new Vector3(+jx - (-jy), 0, -jy + (+jx));
			ai = new Vector3(move.x, 0f, move.z);
			lp = transform.position + ai;

			mando = true;

		}
		if (mando == true)
		{
			Cursor.visible = false;
			lp = transform.position + ai;
			transform.LookAt(lp);


		}
		else
		{
			Cursor.visible = true;
			Vector3 ps = Camera.main.WorldToViewportPoint(transform.localPosition);
			Vector3 cs = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
			direccion = cs - ps;
			turn = Mathf.Atan2(direccion.y - direccion.x, direccion.x + direccion.y) * Mathf.Rad2Deg;
		}
		movimiento = new Vector3((movimientoH + movimientoV) * velocidad, 0.0f, (movimientoV - movimientoH) * velocidad);
		//Aplico ese movimiento al RigidBody del jugador
		rb.velocity = movimiento;
		if (rb.velocity != parado)
		{
			anim.SetBool("corriendo", true);
			particulasAndar.SetActive(true);
			if(Input.GetKey(KeyCode.W))
            {
				anim.SetBool("frente", true);
			}
			if (!Input.GetKey(KeyCode.W))
			{
				anim.SetBool("frente", false);
			}
			if (Input.GetKey(KeyCode.A))
			{
				anim.SetBool("izq", true);
			}
			if (!Input.GetKey(KeyCode.A))
			{
				anim.SetBool("izq", false);
			}
			if (Input.GetKey(KeyCode.S))
			{
				anim.SetBool("atras", true);
			}
			if (!Input.GetKey(KeyCode.S))
			{
				anim.SetBool("atras", false);
			}
			if (Input.GetKey(KeyCode.D))
			{
				anim.SetBool("der", true);
			}
			if (!Input.GetKey(KeyCode.D))
			{
				anim.SetBool("der", false);
			}
		}
		if (rb.velocity == parado)
        {
			anim.SetBool("corriendo", false);
			particulasAndar.SetActive(false);
		}
		
		timedash -= Time.deltaTime;
		if(mejoraDash == true)
        {
			if (Input.GetKey(KeyCode.Space) || Input.GetButtonDown("L1") == true)
			{

				isd = true;
				dash();
			}
		}
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "SiguienteSala")
		{
			finSala = true;
		}
	}
	void dash()
	{
		if (isd && timedash <= 0)
		{
			float movimientoH = Input.GetAxis("Horizontal");
			float movimientoV = Input.GetAxis("Vertical");
			if (movimientoH != 0 && movimientoV != 0)
			{
				dsp = 30;
			}
			else
			{
				dsp = 80;
			}
			Vector3 v = new Vector3((movimientoH + movimientoV), transform.forward.y, (movimientoV - movimientoH));
			rb.AddForce(v * dsp, ForceMode.VelocityChange);
			isd = false;
			timedash = 3;
		}
	}
}