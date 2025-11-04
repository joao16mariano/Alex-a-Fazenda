using UnityEngine;

public class DetectorColetaveis : MonoBehaviour
{
    private GerenciadorColetaveis gerenciador;

    private void Start()
    {
        gerenciador = FindObjectOfType<GerenciadorColetaveis>();
    }

    // 🔹 Coloque este script no PLAYER para detectar coletáveis automaticamente
    private void OnTriggerEnter(Collider other)
    {
        if (gerenciador == null) return;

        // 🔹 Detecta automaticamente pelas tags
        if (other.CompareTag("Moeda") || other.CompareTag("Laranja") || other.CompareTag("Uva"))
        {
            gerenciador.ColetarItem(other.tag, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}