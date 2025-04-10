using UnityEngine;

public class ProtagAnimator : MonoBehaviour
{
    Vector3 lastPosition;
    Vector3 deltaPosition;
    
    [SerializeField]
    private GameObject spriteObject;
    
    [SerializeField]
    private GameObject bodyObject;
    
    float timeAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = bodyObject.transform.position;   
        deltaPosition = Vector3.zero;
        
        timeAnim = 0;
    }



    // Update is called once per frame
    void Update()
    {
        deltaPosition = bodyObject.transform.position - lastPosition;
        lastPosition = bodyObject.transform.position;
        float deltaTimeAnim = deltaPosition.magnitude;
        float speed = 4f;
        float positionMagnitude = 1f/8f;
        float rotationMagnitude = 1f/16f;
        timeAnim += deltaTimeAnim * speed;

        Vector3 positionOffset = Vector3.zero;
        positionOffset.y = Mathf.Sin(timeAnim) * positionMagnitude;

        Vector3 rotationOffset = Vector3.zero;
        rotationOffset.z = Mathf.Sin((timeAnim + 0.5f) * 0.5f) * rotationMagnitude * Mathf.Rad2Deg;

        spriteObject.transform.position = bodyObject.transform.position + positionOffset; 
        spriteObject.transform.rotation = bodyObject.transform.rotation * Quaternion.Euler(rotationOffset);
        
    }
}
