using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float offset = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InitBalls(50);
    }

    private void InitBalls(int numBalls){
        if(!ballPrefab){
            Debug.LogWarning("Please specify the ball prefab");
            return;
        }
        Vector3 currentPosition = transform.position;
        Vector3 offsetVector = new Vector3(offset, 0, 0);
        for(int i = 0; i < numBalls; i++){
            var ballGo = Instantiate(ballPrefab);
            var ballT = ballGo.transform;
            ballT.position = currentPosition;
            var ball = ballGo.GetComponent<BouncingBall>();
            if(!ball){
                Debug.LogWarning("Please agg the 'BouncingBall' component to your ball prefab");
                break;
            }

            ball.SetIndex(i);
            ball.StartBouncing(currentPosition);
            currentPosition += offsetVector;
        }
    }
}
