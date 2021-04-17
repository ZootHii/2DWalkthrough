using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private Camera camera;
    private bool isBallMoving;
    private Rigidbody2D ballRigidBody;
    [SerializeField] private Transform transformBall;
    [SerializeField] private Vector3 positionBase;
    
    public void Start()
    {
        isBallMoving = false;
        camera = Camera.main;
        positionBase = transform.position;
        ballRigidBody = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
    }
    
    public void Update()
    {
        BallMoves();
        BaseMoves();
    }

    private void BaseMoves()
    {
        var mousePosition = Input.mousePosition;
        var mouseWorldPosition = camera.ScreenToWorldPoint(mousePosition);

        if (mouseWorldPosition.x >= -10 && mouseWorldPosition.x <= 10)
        {
            transform.position = new Vector3(mouseWorldPosition.x, -5.5f, 0);
        }
    }

    private void BallMoves()
    {
        if (!isBallMoving)
        {
            positionBase = transform.position;
            var positionBall = new Vector3(positionBase.x, -4.9f, 0);
            transformBall.position = positionBall;

            if (Input.GetMouseButtonDown(0))
            {
                ballRigidBody.velocity = Vector2.up * BallController.Instance.ballSpeed;
                isBallMoving = true;
            }
        }
    }
}
