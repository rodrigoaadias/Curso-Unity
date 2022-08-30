using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : Veiculo
{
    // Start is called before the first frame update
    void Start()
    {
        rodas = 4;
        SetPreco(10000);

        Debug.Log(ObterPreco());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
