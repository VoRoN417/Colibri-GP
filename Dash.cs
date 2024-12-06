using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistance = 5f; // Дистанция рывка
    public float dashCooldown = 2f; // Время между рывками
    public float dashDuration = 0.2f; // Длительность рывка

    private Vector2 dashDirection;
    private bool isDashing = false;
    private float dashTime;
    private float lastDashTime;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastDashTime + dashCooldown)
        {
            StartDash();
        }

        if (isDashing)
        {
            HandleDash();
        }
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Передвижение персонажа, если не в рывке
        if (!isDashing)
        {
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }
    }

    void StartDash()
    {
        isDashing = true;
        lastDashTime = Time.time;
        dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Если игрок не нажал стрелки, то даем рывок в текущем направлении
        if (dashDirection.magnitude < 0.1f)
        {
            dashDirection = Vector2.right; // Или любое другое направление по умолчанию
        }

        dashTime = dashDuration;
    }

    void HandleDash()
    {
        if (dashTime > 0)
        {
            rb.MovePosition(rb.position + dashDirection * dashDistance * Time.fixedDeltaTime / dashDuration);
            dashTime -= Time.fixedDeltaTime;
        }
        else
        {
            isDashing = false; // Завершение рывка
        }
    }
}