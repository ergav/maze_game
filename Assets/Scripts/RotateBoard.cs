using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateBoard : MonoBehaviour
{
    private bool waiting = true;
    
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float maxRotation = 45f, minRotation = -45f;
    private float angleX = 0f, angleY = 0f;

    private InputAction resetInput;

    private Ball ball;
    
    private void Update()
    {
        if (waiting)
        {
            return;
        }
        
        angleX += Mouse.current.delta.x.ReadValue() * rotateSpeed * Time.deltaTime;
        angleY += Mouse.current.delta.y.ReadValue() * rotateSpeed * Time.deltaTime;
        angleX = Mathf.Clamp(angleX, minRotation, maxRotation);
        angleY = Mathf.Clamp(angleY, minRotation, maxRotation);

        transform.rotation = Quaternion.Euler(angleX, 0, angleY);
    }

    public void ResetInput(InputAction.CallbackContext ctx)
    {
        ball.gameObject.SetActive(true);
        transform.eulerAngles = new Vector3(0, 0, 0);
        ball.Reset();
        angleX = 0f;
        angleY = 0f;
    }
    
    IEnumerator Start()
    {
        ball = FindObjectOfType<Ball>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(1);
        waiting = false;
    }
}