using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    [SerializeField] private GameObject ballPrefab;
    public int ballSpeed;
    public int ballCount;
    public GameObject currentBall;

    private Rigidbody2D ballRigidBody;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var ballVelocity = ballRigidBody.velocity;
        if (ballVelocity.magnitude != ballSpeed)
        {
            ballRigidBody.velocity = new Vector2(ballVelocity.x, ballVelocity.y).normalized * ballSpeed;
        }
    }

    public void IncreaseBallAmount(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            ballCount++;
            GameObject ball;
            //if (currentBall == null)
            //{
                if (Random.Range(0,2) == 1)
                {
                    ball = Instantiate(ballPrefab, transform.position + Vector3.left, Quaternion.identity);
                    currentBall = ball;
                }
                else
                {
                    ball = Instantiate(ballPrefab, transform.position + Vector3.right, Quaternion.identity);
                    currentBall = ball;
                }
            //}
            /*else
            {
                if (Random.Range(0,2) == 1)
                {
                    ball = Instantiate(currentBall, transform.position + Vector3.left, Quaternion.identity);
                    currentBall = ball;
                }
                else
                {
                    ball = Instantiate(currentBall, transform.position + Vector3.right, Quaternion.identity);
                    currentBall = ball;
                }
            }*/
            
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
            
        }
    }

    public int GetBallCount()
    {
        return ballCount;
    }

    public void SetBallCount(int value)
    {
        ballCount = value;
    }
}