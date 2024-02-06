using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;
    int hitCounter = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        PositionBall(isStartingPlayer1);
        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = direction * (movementSpeed + hitCounter * extraSpeedPerHit);
    }

    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
