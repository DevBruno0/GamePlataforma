using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Persogens_Atira : MonoBehaviour
{
    const float lifeTime = 2;
    public float speed = 2;
    private bool pode_atira = true;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Inimigo") 
        { 
           Aranha aranha = colisao.gameObject.GetComponent<Aranha>();
           Cachorro cachorro = colisao.gameObject.GetComponent<Cachorro>();
            
            if (aranha != null )
            {
                aranha.Dano();
            }
            else if (cachorro !=null )
            {
                cachorro.Dano();
            }

            Destroy(this.gameObject);
        }

        
        
        /*if (colisao.gameObject.tag == "Aranha")
        {
            colisao.gameObject.GetComponent<Aranha>().Dano();
            //inimigoObj.TomaDano(1);
        }

        if (colisao.gameObject.tag == "Cachorro")
        {
            colisao.gameObject.GetComponent<Cachorro>().Dano();
            //inimigoObj.TomaDano(1);
        }*/
    }

    
       
        

        
}