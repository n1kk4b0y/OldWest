using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update



    public void IniciarJogo(){

        SceneManager.LoadScene(1);

    }

    public void EncerrarJogo(){

        Application.Quit();

    }
    public void VoltarMenu()
    {

        SceneManager.LoadScene(0);

    }

    void Start()
    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
