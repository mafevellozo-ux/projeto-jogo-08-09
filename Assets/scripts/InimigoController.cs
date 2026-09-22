using UnityEngine;
public class InimigoController : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public float velocity;

    private bool SeguindoPost1 = true;
    private Rigidbody2D rb;

    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
       if(this.gameObject.transform.position.x>position1.position.x){
          rb.linearVelocity = new Vector2 (-velocity,
          rb.linearVelocity.y);
       }else{
        rb.linearVelocity = new Vector2 (velocity,
          rb.linearVelocity.y);

       } 
    }
}
