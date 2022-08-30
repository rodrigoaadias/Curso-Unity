using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Veiculo : MonoBehaviour
{
    private string nome;
    private float preco;

    protected int rodas;

    public float ObterPreco()
    {
        return preco;
    }

    public string ObterNome()
    {
        return nome;
    }

    protected void SetPreco(float newPreco)
    {
        preco = newPreco;
    }

    public static float PrecoComJuros(float precoAtual, float juros)
    {
        float novoPreco = precoAtual * (1 + juros);
        return novoPreco;
    }
}