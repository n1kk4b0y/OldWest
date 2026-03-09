using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject[] posicoes;
    private float timer = 0;
    public GameObject[] inimigos;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            int num = Random.Range(0, 1);
            Debug.Log(num);
            int num2 = Random.Range(0, 8);
            Instantiate(inimigos[num], posicoes[num2].transform.position, Quaternion.identity);
        }
    }

}
