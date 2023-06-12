using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachorro : MonoBehaviour
{
    public int vida = 2;
    public float velocidade = 0.01f;
    public float distinicial;
    public float distfinal;
    private SpriteRenderer imagemMob;
 




    // Start is called before the first frame update
    void Start()
    {
        imagemMob = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        Andar();

    }

    void Apontar()
    {
        if (velocidade > 0)
        {
            imagemMob.flipX = false;
        }
        else if (velocidade < 0)
        {
            imagemMob.flipX = true;
        }
    }

    void Andar()
    {
        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
        if (transform.position.x >= distfinal)
        {
            velocidade = velocidade * -1;
            imagemMob.flipX = true;
        }
        else if (transform.position.x <= distinicial)
        {
            velocidade = velocidade * -1;
            imagemMob.flipX = false;
        }
    }
    public void Dano()
    {
        vida--;
        if (vida < 0)
        {
            Destroy(gameObject);
        }
    }

}
