using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criador : MonoBehaviour
{
    //Rercusos
    public GameObject coracao;
    public GameObject Moeda;

    //Inimigos
    public GameObject inimigo;
    public GameObject Mago_Roxo;


    //Velocidade e Tempo
    public float meutempo = 0;
    public float velocidade = 0;


    //GerenciadorDoJogo
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


    //Tempo
    void Temporizador()
    {
        meutempo += Time.deltaTime;
        if(meutempo > 0.5)
        {
            meutempo = 0;

            float chance = Random.Range(0, 10);

            if(chance <= 3)
            {
                Criainimigos();
            }
            else if( chance <= 5)
            {
                CriaVidas();
                
            }
            else if (chance <= 7)
            {
                CriarMagoRoxo();

            }
            else
            {
                CriarMoedas();
            }
        }
    }


    //============Criador Inimigos==================:::

    //Criador Inimigos
    void Criainimigos()
    {

        float posX = Random.Range(12f,12f);
        float posY = Random.Range(3.181f, -4.50f);
        Vector3 posInicial = new Vector3(posX, posY, 0);
        GameObject MeuInimigo = Instantiate(inimigo,posInicial, Quaternion.identity);
        //Destroy(MeuInimigo, 50f);
    }

    void CriarMagoRoxo()
    {

        float posX = Random.Range(12f, 12f);
        float posY = Random.Range(3.181f, -4.50f);
        Vector3 posInicial = new Vector3(posX, posY, 0);
        GameObject MeuMagoRoxo = Instantiate(Mago_Roxo, posInicial, Quaternion.identity);
        //Destroy(MeuInimigo, 50f);
    }


    //============Criador Recursos==================:::

    //Criar Vidas
    void CriaVidas()
    {
        float posX = Random.Range(12f, 12f);
        float posY = Random.Range(3.181f, -4.50f);
        Vector3 posInicial = new Vector3(posX, posY, 0);
        GameObject MeuItem = Instantiate(coracao, posInicial, Quaternion.identity);
        //Destroy(MeuItem, 50f);

    }

    //Criar Moedas
    void CriarMoedas()
    {
        float posX = Random.Range(12f, 12f);
        float posY = Random.Range(3.181f, -4.50f);
        Vector3 posInicial = new Vector3(posX, posY, 0);
        GameObject MinhaMoeda = Instantiate(Moeda, posInicial, Quaternion.identity);
        Destroy(MinhaMoeda, 100f);

    }

}
