using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using  UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidade = 200f;
    public int vida = 3;
    public TMP_Text textoVida;
    public TMP_Text temporizador;
    public TMP_Text textoPontos;
    public int pontos =0;
    Rigidbody rb;   
    public float tempo = 0;
    public GameObject arma;
    public GameObject bala;
    public bool invencivel = false;
    float tempoInvencivel = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal= Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movment * velocidade);

        textoVida.text = vida.ToString();

        tempo += Time.deltaTime;


        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60); 

        temporizador.text = minutos + ":" + segundos;

        textoPontos.text = pontos.ToString();


        if(Input.GetMouseButtonDown(0)){


            GameObject clone = Instantiate(bala, arma.transform.position, arma.transform.rotation);
            Rigidbody ri = clone.GetComponent<Rigidbody>();
            ri.velocity = transform.forward * 40;

            Debug.Log("oi");

        }

        if(vida <= 0){

            SceneManager.LoadScene(1);
        }

        tempoInvencivel += Time.deltaTime;

        if(tempoInvencivel >=3){

            invencivel = false;
            tempoInvencivel = 0;
        }       


    
        
    }

    

    void OnCollisionEnter(Collision other){

        if(other.gameObject.tag == "Velocidade"){
            velocidade = 400f;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Vida"){
            vida++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Moeda"){

            pontos++;
            Destroy(other.gameObject);
            
        }

        
        
        
        
    }
    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "Inimigo" && invencivel == false){

            
            vida--;
            invencivel = true;
            tempoInvencivel = 0;
        }
    }
}
