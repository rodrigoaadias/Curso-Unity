using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contabilidade : MonoBehaviour
{
    public Carro carro;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Preço com juros: R$" + Veiculo.PrecoComJuros(carro.ObterPreco(), 0.1f));
    }
}
