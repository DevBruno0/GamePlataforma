using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour
{
    public bool GameLigado = false;


    // Start is called before the first frame update
    void Start()
    {
        GameLigado = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool EstadoDoJogo()
        
    {
        return GameLigado; 
    }
    public void LigarJogo()
    {
        GameLigado = true;
        Time.timeScale = 1;
    }
        
     public void PersonagemMorreu()

    {
        Reiniciar();
    }
    void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }

}
