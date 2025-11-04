using UnityEngine;

public class GerenciadorColetaveis : MonoBehaviour
{
    [System.Serializable]
    public class ConfiguracaoFruta
    {
        public string tag = "Coletavel";
        public int valorPontos = 100;
        public AudioClip somColetar;
        public GameObject efeitoVisual;
    }

    [Header("Configurações das Frutas")]
    public ConfiguracaoFruta moeda = new ConfiguracaoFruta { tag = "Moeda", valorPontos = 100 };
    public ConfiguracaoFruta laranja = new ConfiguracaoFruta { tag = "Laranja", valorPontos = 75 };
    public ConfiguracaoFruta uva = new ConfiguracaoFruta { tag = "Uva", valorPontos = 150 };

    [Header("Sons Padrão")]
    public AudioClip somMoedaPadrao;
    public AudioClip somLaranjaPadrao;
    public AudioClip somUvaPadrao;

    private void Start()
    {
        // Configurar sons padrão
        if (moeda.somColetar == null) moeda.somColetar = somMoedaPadrao;
        if (laranja.somColetar == null) laranja.somColetar = somLaranjaPadrao;
        if (uva.somColetar == null) uva.somColetar = somUvaPadrao;
    }

    // 🔹 Método público para ser chamado pelos coletáveis
    public void ColetarItem(string tag, Vector3 posicao)
    {
        ConfiguracaoFruta config = GetConfiguracaoPorTag(tag);

        if (config != null)
        {
            Debug.Log($"[GERENCIADOR] {tag} coletada: +{config.valorPontos} pontos");

            // Criar efeito visual
            if (config.efeitoVisual != null)
                Instantiate(config.efeitoVisual, posicao, Quaternion.identity);

            // Tocar som
            if (config.somColetar != null)
                AudioSource.PlayClipAtPoint(config.somColetar, Camera.main.transform.position);

            // Adicionar pontos de forma separada
            if (tag == "Moeda")
                AdicionarPontosOnDeath.ColetarMoeda(config.valorPontos);
            else
                AdicionarPontosOnDeath.ColetarFruta(config.valorPontos);
        }
        else
        {
            Debug.LogWarning($"[GERENCIADOR] Tag '{tag}' não configurada!");
        }
    }

    private ConfiguracaoFruta GetConfiguracaoPorTag(string tag)
    {
        switch (tag)
        {
            case "Moeda": return moeda;
            case "Laranja": return laranja;
            case "Uva": return uva;
            default: return null;
        }
    }

    // 🔹 Método opcional para adicionar novos tipos dinamicamente
    public void AdicionarNovaFruta(string tag, int pontos, AudioClip som = null)
    {
        Debug.Log($"Nova fruta adicionada: {tag} - {pontos} pontos");
    }
}
