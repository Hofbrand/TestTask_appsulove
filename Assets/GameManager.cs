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
    private 

    void Start()
    {
        circleSpawner = GetComponent<CircleSpawner>();
        input = new InputManager(); 
        circle = circleSpawner.Spawn(storage.CirclePrefab, Vector3.zero).GetComponent<CircleView>();
        circleController = new CircleController( new CircleModel(), circle);
        
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
}
