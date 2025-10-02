using UnityEngine;

public class Brick : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Manager.Instance.Score += 1;
            Destroy(gameObject);
        }
    }
}
