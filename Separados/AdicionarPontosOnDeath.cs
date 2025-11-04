using UnityEngine;
using TMPro;
using Gamekit3D;

public class AdicionarPontosOnDeath : MonoBehaviour
{
    [Header("Textos da UI")]
    public TextMeshProUGUI textoPontosInimigos;
    public TextMeshProUGUI textoPontosMoedas;
    public TextMeshProUGUI textoPontosFrutas;

    [Header("Valores dos Inimigos")]
    public int valorDoInimigo = 10;

    private static int totalPontosInimigos = 0;
    private static int totalPontosMoedas = 0;
    private static int totalPontosFrutas = 0;

    void Start()
    {
        Damageable damageable = GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.OnDeath.AddListener(SomarPontosInimigos);
        }

        AtualizarTextos();
    }

    public void SomarPontosInimigos()
    {
        totalPontosInimigos += valorDoInimigo;
        AtualizarTextos();
        Debug.Log($"Inimigo morto: +{valorDoInimigo} pontos. Total Inimigos: {totalPontosInimigos}");
    }

    public static void ColetarMoeda(int valorMoeda)
    {
        totalPontosMoedas += valorMoeda;
        AtualizarTextosEmTodasInstancias();
        Debug.Log($"Moeda coletada: +{valorMoeda} pontos. Total Moedas: {totalPontosMoedas}");
    }

    public static void ColetarFruta(int valorFruta)
    {
        totalPontosFrutas += valorFruta;
        AtualizarTextosEmTodasInstancias();
        Debug.Log($"Fruta coletada: +{valorFruta} pontos. Total Frutas: {totalPontosFrutas}");
    }

    private void AtualizarTextos()
    {
        if (textoPontosInimigos != null)
            textoPontosInimigos.text = totalPontosInimigos.ToString();

        if (textoPontosMoedas != null)
            textoPontosMoedas.text = totalPontosMoedas.ToString();

        if (textoPontosFrutas != null)
            textoPontosFrutas.text = totalPontosFrutas.ToString();
    }

    private static void AtualizarTextosEmTodasInstancias()
    {
        AdicionarPontosOnDeath[] todasInstancias = FindObjectsOfType<AdicionarPontosOnDeath>();
        foreach (AdicionarPontosOnDeath instancia in todasInstancias)
        {
            if (instancia != null)
            {
                instancia.AtualizarTextos();
            }
        }
    }

    public static int GetTotalPontosInimigos() => totalPontosInimigos;
    public static int GetTotalPontosMoedas() => totalPontosMoedas;
    public static int GetTotalPontosFrutas() => totalPontosFrutas;
    public static int GetTotalPontos() => totalPontosInimigos + totalPontosMoedas + totalPontosFrutas;
}
