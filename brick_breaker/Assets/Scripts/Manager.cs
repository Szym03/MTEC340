using UnityEngine;
using TMPro;


public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private int _score = 0;

    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private TMP_Text _messagesUI;

    private Utilities.GameState _state;
    public Utilities.GameState State
    {
        get => _state;
        set
        {
            _state = value;
            _messagesUI.enabled = State == Utilities.GameState.Pause;
        }
    }


    private void Awake()
    {
        // Instance is null when no Manager has been initialized
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized...");

            DontDestroyOnLoad(gameObject);
        }

        // We evaluate this portion when trying to initialize a new instance
        // when one already exists
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
    }



    private void Start()
    {
        State = Utilities.GameState.Play;

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameState.Play ?
                Utilities.GameState.Pause :
                Utilities.GameState.Play;
        }
        
        Time.timeScale = State == Utilities.GameState.Play ? 1 : 0;
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }
}