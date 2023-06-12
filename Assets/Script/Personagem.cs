using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float velocidade;
    public SpriteRenderer ImagePersonagem;
    public int qtd_pulo = 2;
    public GameObject bullet;
    public LayerMask groundLayer;
    Animator animator;

    
    //vida do personagem
    public int vida = 20;
    private float meuTempoDano = 0;
    private bool pode_dano = true;

    //barra de hp
    private Image barrahp;

    //moeda 
    public int moeda = 0;
    private Text Moeda_texto;

    //disparo da bala
    public int municao = 5;
    private Text Municao_texto;

    // Start is called before the first frame update
    void Start()
    {   
        //GJ = GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GerenciadorJogo>();
        animator= GetComponent<Animator>();
        barrahp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        Moeda_texto = GameObject.FindGameObjectWithTag("Moeda_texto_tag").GetComponent<Text>();
        Municao_texto = GameObject.FindGameObjectWithTag("Municao_texto_tag").GetComponent<Text>();
        Municao_texto.text = municao.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
        Apontar();
        Shoot();
        Dano();
        
    }

    void Mover()
    {
        
        velocidade = Input.GetAxis("Horizontal") * 4;
        Corpo.velocity = new Vector2(velocidade, Corpo.velocity.y);
        if (Mathf.Abs(velocidade) > 0)
        {
            animator.SetBool("corre", true);
        }
        else 
        {
            animator.SetBool("corre", false);
        }
    }

    void Apontar()
    {
        if (velocidade > 0)
        {
            ImagePersonagem.flipX = false;
        }
        else if (velocidade < 0)
        {
            ImagePersonagem.flipX = true;
        }
    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            qtd_pulo++;
            if (qtd_pulo >=0 && qtd_pulo <= 2)
                AcaoPulo();
        }
    }
    void AcaoPulo()
    {
        Corpo.AddForce(transform.up * 250f);
    }

    //Gatilhos 
    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "Pisavel")
        {
            qtd_pulo = 0;
        }
        if (gatilho.gameObject.tag == "moeda")
        {
            Destroy(gatilho.gameObject);
            moeda++;
            Moeda_texto.text = moeda.ToString();
        }

        if (gatilho.gameObject.tag == "Nova_municao")
        {
            municao = municao = 5;
            Municao_texto.text = municao.ToString();
            Destroy (gatilho.gameObject);
        }
    }

    //ATIRAR 
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (municao > 0)
            {
                municao--;
                Municao_texto.text = municao.ToString();
                GameObject go = Instantiate(bullet, this.transform.position, this.transform.rotation);
                Persogens_Atira pa = go.GetComponent<Persogens_Atira>();
                if (!ImagePersonagem.flipX)
                {
                    pa.speed *= -1;
                }
            }

          
            
        }
    }

    void Dano()
    {
        if (pode_dano == false)
        {
            temporizadorDano();
        }
    }


    //verificar dano
    //colisões físicas 
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Inimigo") { 

            if (pode_dano == true)
            {
                vida--;
                Perderhp();
                pode_dano = false;
                ImagePersonagem.color= UnityEngine.Color.red;
                meuTempoDano = 0;
                //só morro se minha vida for menor ou igual a 0
                if (vida <=0)
                {
                    Morrer();
                }
            }
        }


    }

    void temporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.25f)
        
        {
            pode_dano = true;
            meuTempoDano = 0;
            ImagePersonagem.color = UnityEngine.Color.white;
            

        }
    }

    void Perderhp()
    {
        
        int vida_parabarra = vida * 1;
        barrahp.rectTransform.sizeDelta = new Vector2(vida_parabarra, 30);
    }

    void Morrer()
        
    {
        SceneManager.LoadScene(1);

    }

   
}
