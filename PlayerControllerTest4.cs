﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Character2DTopDown : MonoBehaviour {

    public float speed = 1.5f;
    public float acceleration = 100;

    private Vector3 direction;
    private Rigidbody2D body;

    void Start () 
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.gravityScale = 0;
    }

    void FixedUpdate()
    {
        body.AddForce(direction * body.mass * speed * acceleration);
		
        if(Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
        }
		
        if(Mathf.Abs(body.velocity.y) > speed)
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed);
        }
    }

    void LookAtCursor()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        lookPos = lookPos - transform.position;
        float angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update () 
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        LookAtCursor();
    }
    
    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        
            body.MovePosition(body.position + movement * Time.deltaTime);
    }
    /*public bool dead = false; добавляемв начало две переменных
    public GameObject Butt; сюда кидаем объёкт баттон, на котором код рестарт
    private void Dead()
{
    if(dead == true)
    {
        Time.timeScale = 0; время останавливается
        Butt.transform.position = new Vector2(0, 0); появляется баттон
    }
}
    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("PointSpawn"))
    {
        Debug.Log("Снаряд столкнулся с объектом: " + other.name);

        EnemySpawn point = other.gameObject.GetComponent<EnemySpawn>();
        if (point != null)
        {
            point.Destroy();
        }

    }
}*/

}
