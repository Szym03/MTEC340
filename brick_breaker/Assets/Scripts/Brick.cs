using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private int _life = 2;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.green;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _life -= 1;

            if (_life == 1)
            {
                _spriteRenderer.color = Color.red;
            }
            else if (_life >= 0)
            {
                Manager.Instance.Score += 1;
                Destroy(gameObject);
            }

        }
    }
}
