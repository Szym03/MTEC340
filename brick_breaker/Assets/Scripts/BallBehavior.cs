using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public float Speed = 5;

    private int _xDir;
    private int _yDir;


    void Start()
    {

        _yDir = Random.value >= 0.5 ? 1 : -1;
        _xDir = Random.value >= 0.5 ? 1 : -1;

    }
    void Update()
    {
        transform.position += new Vector3(
            Speed * Time.deltaTime * _xDir,
            Speed * Time.deltaTime * _yDir,
            0.0f);
    }
}
