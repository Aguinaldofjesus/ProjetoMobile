using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private GerenciadorDoJogo GJ;

    //Tempo e velocidade do jogo para o celular
    private float Tempo = 0;
    private float tempoStella = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        GJ =GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorDoJogo>();
    }

    // Update is called once per frame
    void Update()
    {

            if (GJ.EstadoDoJogo() == true)
            {
               Temporizador();
            }
    }


    void Movimentar()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 posPersonagem = new Vector3(posMouse.x, posMouse.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, posPersonagem,tempoStella);
        }
    }

    //Tempo
    void Temporizador()
    {
        Tempo += Time.deltaTime;

        if (Tempo > 0.1f)
        {
            Movimentar();
        }
    }

}
