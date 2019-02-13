using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float speed = 1f;

    private Transform tf;
    private float rotation = 0f;
    
    void Start()
    {
        tf = this.GetComponent<Transform>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(tf.rotation, Quaternion.Euler(0f, rotation, 0f), Time.deltaTime * speed);
    }

    public void Rotate(bool direction)
    {
        if(direction)
        {
            rotation-=90f;
        }
        else
        {
            rotation+=90f;
        }
    }
}
