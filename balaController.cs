using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaController : MonoBehaviour
{
    private float tempo = 0;

    void Start()
    {

    }

    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= 3f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        

        // Destroi o projétil após a colisão
        Destroy(this.gameObject);
    }
}
