using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    //Variavel Texto de Valor do cora��o
    public Text ValorCoracao;

    //Informa��o do Banco

    private Banco MeuBanco;



    // Start is called before the first frame update
    void Start()
    {
        MeuBanco = GameObject.FindGameObjectWithTag("GameController").GetComponent<Banco>();
    }

    // Update is called once per frame
    void Update()
    {
        //informa��o do Nivel do Cora��o
        int VidasCompradas = PlayerPrefs.GetInt("NivelVida")+1;
        int custo = (VidasCompradas * 10);
;       ValorCoracao.text = "Vida N�vel: " + VidasCompradas.ToString() + "$: " + custo.ToString();

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
            //N�o conseguiu comprar
        }
    }
}
