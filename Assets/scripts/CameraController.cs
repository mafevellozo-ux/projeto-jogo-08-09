using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 playerPosition;

    void Start()
    {
         if(playerTransform!=null){
            playerPosition = playerTransform.position;
            transform.position =  new Vector3(playerPosition.x,
                                              playerPosition.y,
                                              -10);
    }
    }
   
    void Update()
    {
        if(playerTransform!=null){
            playerPosition = playerTransform.position;
            transform.position =  new Vector3(playerPosition.x,
                                              playerPosition.y,
                                              -10);
        }
    }
}
