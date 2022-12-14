using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_Stella : MonoBehaviour
{

    private float MeuTempo = 0;

    private GerenciadorDoJogo GJ;
    

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorDoJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Temporizador();
        }
    }


    void Temporizador()
    {
        MeuTempo+=Time.deltaTime;

        if(MeuTempo > 0.005f)
        {
            //Faz o tiro ir para frente
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y,transform.position.z);
            MeuTempo = 0;
        }
    }


    //Relativo a Colisão do Tiro com os Inimigos
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "inimigos")
        {
            Destroy(colisao.gameObject);
            Destroy(this.gameObject);
        }

        if(colisao.gameObject.tag == "Mago_Roxo")
        {
            colisao.gameObject.GetComponent<Mago_Roxo_codico>().perdeHP(1);
            Destroy(this.gameObject);
        }
    }
}
