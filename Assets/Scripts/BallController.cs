using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    [SerializeField] private float ballSpeed;
    [SerializeField] private int ballCount;

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
        AvoidBallStuckAndSlow();
    }

    public void AvoidBallStuckAndSlow()
    {
        var ballVelocity = ballRigidBody.velocity;
        float verticalDot = Vector3.Dot(ballVelocity.normalized, Vector3.up);
        float horizontalDot = Vector3.Dot(ballVelocity.normalized, Vector3.right);
        if (ballVelocity.magnitude != ballSpeed)
        {
            ballRigidBody.velocity = new Vector2(ballVelocity.x, ballVelocity.y).normalized * ballSpeed;
        }
        if (verticalDot > 0.98 || verticalDot < -0.98) {
            var loosenedVelocity = Random.insideUnitCircle * ballSpeed;
            ballRigidBody.velocity += loosenedVelocity;
        }
        if (horizontalDot > 0.98 || horizontalDot < -0.98) {
            var loosenedVelocity = Random.insideUnitCircle * ballSpeed;
            ballRigidBody.velocity += loosenedVelocity;
        }
    }
    
    public void IncreaseBallAmount(Vector3 position, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            ballCount++;
            var ball = Instantiate(gameObject, position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
        }
    }

    public void IncreaseBallSpeed(float amount)
    {
        ballSpeed += amount;
    }
    
    public float GetBallSpeed()
    {
        return ballSpeed;
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