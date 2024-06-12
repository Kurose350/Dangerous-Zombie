using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float speedZ = 0.5f;
    float rangeZ = 1f;
    float speedY = 0.5f;
    float rangeY = 1f;
    public Transform objectLeft;
    public Transform objectRight;
    public Transform objectUp;
    public Transform objectDown;
    private bool isMovingLeft = true;
    private bool isMovingRight = true;
    private bool isMovingUp = true;
    private bool isMovingDown = true;
    private void Update()
    {
        MoveObject(objectLeft, ref isMovingLeft, Vector3.back, speedZ, rangeZ); 
        MoveObject(objectRight, ref isMovingRight, Vector3.forward, speedZ, rangeZ);
        MoveObject(objectUp, ref isMovingUp, Vector3.up, speedY, rangeY);
        MoveObject(objectDown, ref isMovingDown, Vector3.down, speedY, rangeY);
    }
    private void MoveObject(Transform obj, ref bool isMoving, Vector3 direction, float speed, float range)
    {
        if (obj != null)
        {
            float movement = Mathf.PingPong(Time.time * speed, range * 2) - range;
            obj.Translate(direction * movement * Time.deltaTime);
            if (Mathf.Approximately(movement, range))
            {
                isMoving = !isMoving;
            }
        }
    }
}
