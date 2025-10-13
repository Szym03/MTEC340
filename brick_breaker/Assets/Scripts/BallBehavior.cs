using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;

    [SerializeField] private float _paddleInfluence = 0.4f;
    
    private Rigidbody2D _rb;
    
    private AudioSource _source;
    [SerializeField] AudioClip _wallHit;
    [SerializeField] AudioClip _paddleHit;
    [SerializeField] AudioClip _brickHit;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        
        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;
        
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }

            _source.clip = _paddleHit;
            _source.Play();
        }else if (other.gameObject.CompareTag("Wall"))
        {
            _source.clip = _wallHit;
            _source.Play();
        }else if (other.gameObject.CompareTag("Brick"))
        {
            _source.clip = _brickHit;
            _source.Play();
        }
    }

    float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;

        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
    }
}
