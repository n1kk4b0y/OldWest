using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoController : MonoBehaviour
{
    public Transform player;  // Referência ao transform do jogador
    public float velocidade = 5.0f;  // Velocidade de movimento do inimigo
    public int vida = 3;  // Vida do inimigo

    private Rigidbody rb;

    void Start()
    {
        // Encontra o jogador automaticamente pelo tag "Player"
        player = GameObject.FindWithTag("Player").transform;

        // Obtém o Rigidbody do inimigo para movimentação física
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Se o player estiver atribuído e o inimigo estiver vivo
        if (player != null && vida > 0)
        {
            // Calcula a direção para o jogador
            Vector3 direcao = (player.position - transform.position).normalized;

            // Move o inimigo em direção ao jogador
            rb.MovePosition(transform.position + direcao * velocidade * Time.deltaTime);

            // Faz o inimigo olhar para o jogador
            transform.LookAt(player);
        }
    }

    // Detecta colisões do inimigo
    void OnCollisionEnter(Collision collision)
    {
        // Se o inimigo colidir com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Inimigo colidiu com o jogador!");
            // Adicionar lógica de dano ao jogador ou outra ação
        }

        // Se o inimigo for acertado por um objeto com a tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Diminui a vida do inimigo
            vida -= 1;
            Debug.Log("Inimigo foi acertado! Vida restante: " + vida);

            // Destroi a bala ao colidir com o inimigo
            Destroy(collision.gameObject);

            // Verifica se o inimigo ainda tem vida
            if (vida <= 0)
            {
                Morrer();
            }
        }
    }

    // Função que define a morte do inimigo
    void Morrer()
    {
        Debug.Log("Inimigo morreu!");

        // Encontra o jogador e incrementa a pontuação
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Incrementa a variável de pontos no PlayerController
                playerController.pontos += 1;
                Debug.Log("Pontos do jogador: " + playerController.pontos);
            }
        }

        // Destrói o inimigo
        Destroy(gameObject);
    }
}
