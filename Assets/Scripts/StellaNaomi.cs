using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StellaNaomi : MonoBehaviour
{
    //VIDA
    private int vida = 1;
    public int Moeda = 0;

    //Variavel De Tiro
    private float MeuTempo = 0;
    public GameObject Tiro;


    //Barra De Hp
    public GameObject Vida05;
    public GameObject Vida04;
    public GameObject Vida03;
    public GameObject Vida02;
    public GameObject Vida01;
    public GameObject Vida00;

    //GerenciadorDoJogo
    private GerenciadorDoJogo GJ;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("NivelVida",0);
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorDoJogo>();
         
    }

    //Inicializar
    public void Inicializar()
    {
        int vidas_compradas = PlayerPrefs.GetInt("NivelVida");
        vida = vida + vidas_compradas;
    }


    // Update is called once per frame
    void Update()
    {
        VerificarVida();
        if (GJ.EstadoDoJogo() == true)
        {
            Temporizador();
        }
    }


    //Para Criar Tiros
    void Temporizador()
    {
        MeuTempo += Time.deltaTime;

        if (MeuTempo > 1f)
        {
            CriarTiro();
            MeuTempo = 0;
        }
    }

    void CriarTiro()
    {
        //Posição do Tiro
        Vector3 PosTiro= new Vector3(transform.position.x + 0.65f ,transform.position.y - 0.166f, transform.position.z);
        GameObject NovoTiro = Instantiate(Tiro,PosTiro,Quaternion.identity);
        Destroy(NovoTiro, 3f);
    }


    //Ativa somente a vida necessaria
    void VerificarVida()
    {
        if (vida == 5)
        {
            DesligarVida();
            Vida05.SetActive(true);
        }
        if (vida == 4)
        {
            DesligarVida();
            Vida04.SetActive(true);
        }
        if(vida == 3)
        {
            DesligarVida();
            Vida03.SetActive(true);
        }
        if (vida == 2)
        {
            DesligarVida();
            Vida02.SetActive(true);
        }
        if (vida == 1)
        {
            DesligarVida();
            Vida01.SetActive(true);
        }
        if (vida == 0)
        {
            DesligarVida();
            Vida00.SetActive(true);
        }
    }

    //Desligar todas vidas
    void DesligarVida()
    {
        Vida05.SetActive(false);
        Vida04.SetActive(false);
        Vida03.SetActive(false);
        Vida02.SetActive(false);
        Vida01.SetActive(false);
        Vida00.SetActive(false);
    }




    void OnCollisionEnter2D(Collision2D collision)
    {

        //Colisão com Inimigo
        if(collision.gameObject.tag == "inimigos")
        {
            Destroy(collision.gameObject);
            vida--;

            if(vida <= 0)
            {
                GJ.ReceberMoedaMorreu(Moeda);
                GJ.Morreu();
            }

        }

        if (collision.gameObject.tag == "Mago_Roxo")
        {
            Destroy(collision.gameObject);
            vida--;

            if (vida <= 0)
            {
                GJ.ReceberMoedaMorreu(Moeda);
                GJ.Morreu();
            }

        }

        //Colisão com Energia
        if (collision.gameObject.tag == "energia")
        {
            Destroy (collision.gameObject);
            vida++;

            if (vida >= 5)
            {
                vida = 5;
                Debug.Log("Vida Cheia");
            }
        }

        //Colisão com Moedas
        if (collision.gameObject.tag == "moedas")
        {
            Destroy(collision.gameObject);
            Moeda++;

        }


    }
}
