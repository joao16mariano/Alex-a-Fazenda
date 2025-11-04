using UnityEngine;

public class ColetavelSimples : MonoBehaviour
{
    [Header("Configurações do Coletável")]
    public string tipoColetavel = "Moeda"; // Moeda, Laranja, Uva

    private GerenciadorColetaveis gerenciador;
    private bool foiColetado = false;

    private void Start()
    {
        // 🔹 Encontra o gerenciador automaticamente
        gerenciador = FindObjectOfType<GerenciadorColetaveis>();

        if (gerenciador == null)
        {
            Debug.LogError("[COLETAVEL] GerenciadorColetaveis não encontrado na cena!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !foiColetado && gerenciador != null)
        {
            foiColetado = true;

            // 🔹 Chama o gerenciador centralizado
            gerenciador.ColetarItem(tipoColetavel, transform.position);

            // 🔹 Destroi este objeto
            Destroy(gameObject);
        }
    }
}