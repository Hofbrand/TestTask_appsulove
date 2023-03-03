using Assets.Scripts.Controllers;
using Assets.Scripts.Views;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PrefabsStorage storage;
    [SerializeField] private ScoreView scoreView; 
    private AbstractSpawner<GameObject> circleSpawner;
    private AbstractSpawner<GameObject> squareSpawner;
    private ScoreManager score;
    private InputManager input;
    private CircleView circle;
    private CircleController circleController;
    private Vector2 target;

    void Start()
    {
        circleSpawner = GetComponent<CircleSpawner>();
        squareSpawner = GetComponent<SquareSpawner>();
        score = new ScoreManager(scoreView);
        input = new InputManager(); 
        circle = circleSpawner.Spawn(storage.CirclePrefab).GetComponent<CircleView>();
        circleController = new CircleController( new CircleModel(), circle, score);
        InvokeRepeating(nameof(SpawnSquare), 3f, 3f);
        
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            circleController.StartMovemnt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void FixedUpdate()
    {

        circleController.MoveCircle(Time.deltaTime);
    }

    private void SpawnSquare()
    {
        
        Debug.LogError("should spawn");
        var view = squareSpawner.Spawn(storage.SquarePrefab).GetComponent<SquareView>() ;
        SquareController square = new SquareController(view, new SquareModel(10), score);
        square.OnDestroy += ((SquareSpawner)squareSpawner).RemoveFromList;
    }
}
