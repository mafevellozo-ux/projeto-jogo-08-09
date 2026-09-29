using UnityEngine;
using UnityEngine.SceneManagement;

public class FugaParkour : MonoBehaviour
{
    public string nomeCenaVitoria = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Fuga alcançada! O jogador venceu.");

        if (!string.IsNullOrEmpty(nomeCenaVitoria))
            SceneManager.LoadScene(nomeCenaVitoria);
    }
}
