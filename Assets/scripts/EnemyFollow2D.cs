using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollow2D : MonoBehaviour
{
    [Header("Jogador")]
    public Transform alvo;

    [Header("Movimento")]
    public float velocidade = 4f;
    public float forcaPulo = 10f;

    [Header("Chão")]
    public Transform groundCheck;
    public float raioChao = 0.2f;
    public LayerMask camadaChao;

    [Header("Detecção de Obstáculo")]
    public Transform wallCheck;
    public float distanciaParede = 0.5f;

    private Rigidbody2D rb;
    private bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        VerificarChao();
        VerificarPulo();
    }

    void FixedUpdate()
    {
        SeguirJogador();
    }

    void SeguirJogador()
    {
        if (alvo == null)
            return;

        float distanciaX = alvo.position.x - transform.position.x;

        if (Mathf.Abs(distanciaX) > 0.5f)
        {
            float direcao = Mathf.Sign(distanciaX);

            rb.linearVelocity = new Vector2(
                direcao * velocidade,
                rb.linearVelocity.y
            );
        }
        else
        {
            rb.linearVelocity = new Vector2(
                0,
                rb.linearVelocity.y
            );
        }
    }

    void VerificarChao()
    {
        if (groundCheck == null)
            return;

        estaNoChao = Physics2D.OverlapCircle(
            groundCheck.position,
            raioChao,
            camadaChao
        );
    }

    void VerificarPulo()
    {
        if (!estaNoChao)
            return;

        if (alvo == null)
            return;

        float distanciaX = alvo.position.x - transform.position.x;

        bool jogadorAcima =
            alvo.position.y > transform.position.y + 0.5f;

        bool obstaculoNaFrente = DetectarObstaculo();

        // Pula se o jogador estiver acima
        // OU se existir uma parede/obstáculo na frente.
        if (jogadorAcima || obstaculoNaFrente)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );
        }
    }

    bool DetectarObstaculo()
    {
        if (wallCheck == null)
            return false;

        float direcao = 1f;

        if (alvo != null)
        {
            direcao = Mathf.Sign(
                alvo.position.x - transform.position.x
            );
        }

        RaycastHit2D hit = Physics2D.Raycast(
            wallCheck.position,
            Vector2.right * direcao,
            distanciaParede,
            camadaChao
        );

        return hit.collider != null;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(
                groundCheck.position,
                raioChao
            );
        }

        if (wallCheck != null)
        {
            Gizmos.DrawRay(
                wallCheck.position,
                Vector2.right * distanciaParede
            );
        }
    }
}