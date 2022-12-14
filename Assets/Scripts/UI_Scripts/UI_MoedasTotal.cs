using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MoedasTotal : MonoBehaviour
{
    private Banco MeuBanco;
    private Text MeuTexto;

    // Start is called before the first frame update
    void Start()
    {
        MeuBanco = GameObject.FindGameObjectWithTag("GameController").GetComponent<Banco>();
        MeuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MeuTexto.text = MeuBanco.InformarValorNoBanco().ToString();
    }
}
