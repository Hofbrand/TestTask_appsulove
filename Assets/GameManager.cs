using Assets.Scripts.Controllers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PrefabsStorage storage;
    private AbstractSpawner<GameObject> circleSpawner;
    private AbstractSpawner<GameObject> squareSpawner;
    private InputManager input;
    private CircleView circle;
    private CircleController circleController;
    private Vector2 target;

    void Start()
    {
        circleSpawner = GetComponent<CircleSpawner>();
        squareSpawner = GetComponent<SquareSpawner>();

        input = new InputManager(); 
        circle = circleSpawner.Spawn(storage.CirclePrefab).GetComponent<CircleView>();
        circleController = new CircleController( new CircleModel(), circle);
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
        squareSpawner.Spawn(storage.SquarePrefab);
    }
}
