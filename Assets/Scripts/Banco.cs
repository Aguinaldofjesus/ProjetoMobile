using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{

    private int ValorBanco;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarNoBanco(int NovoValor)
    {
        //Recebo o que eu já tenho no banco
        ValorBanco = PlayerPrefs.GetInt("MinhasMoedas");

        //Somo com o novo Valor
        ValorBanco = ValorBanco + NovoValor;

        //Guardo o valor total
        PlayerPrefs.SetInt("MinhasMoedas", ValorBanco);
    }

    //Informa a quatidade de dinheiro que eu possuo
    public int InformarValorNoBanco()
    {
        ValorBanco = PlayerPrefs.GetInt("MinhasMoedas");
        return ValorBanco;
    }



    //Retirada
    public void RetirarDoBanco(int NovoValor)
    {
        //Recebo o que eu já tenho no banco
        ValorBanco = PlayerPrefs.GetInt("MinhasMoedas");

        //Subtrair o novo valor
        ValorBanco = ValorBanco - NovoValor;

        //Guardo o valor total
        PlayerPrefs.SetInt("MinhasMoedas", ValorBanco);
    }



    //Voce pode pagar?
    public bool Pagar(int Custo)
    {
        int DinheiroBanco = InformarValorNoBanco();
        if (DinheiroBanco >= Custo)
        {
            //Puder pagar e paguei
            RetirarDoBanco(Custo);
            return true;
        }
        else
        {
            //Não pude pagar
            return false;
        }
    }
}
