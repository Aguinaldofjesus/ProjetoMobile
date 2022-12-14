using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    //Variavel Texto de Valor do coração
    public Text ValorCoracao;

    //Informação do Banco

    private Banco MeuBanco;



    // Start is called before the first frame update
    void Start()
    {
        MeuBanco = GameObject.FindGameObjectWithTag("GameController").GetComponent<Banco>();
    }

    // Update is called once per frame
    void Update()
    {
        //informação do Nivel do Coração
        int VidasCompradas = PlayerPrefs.GetInt("NivelVida")+1;
        int custo = (VidasCompradas * 10);
;       ValorCoracao.text = "Vida Nível: " + VidasCompradas.ToString() + "$: " + custo.ToString();

    }

    //Realizar Comprar
    public void CompraCoracao()
    {
        int VidasCompradas = PlayerPrefs.GetInt("NivelVida") + 1;
        int custo = (VidasCompradas * 10);
        if (MeuBanco.Pagar(custo) == true)
        {
            //Conseguiu Comprar
            PlayerPrefs.SetInt("NivelVida", VidasCompradas);
        }
        else
        {
            //Não conseguiu comprar
        }
    }
}
