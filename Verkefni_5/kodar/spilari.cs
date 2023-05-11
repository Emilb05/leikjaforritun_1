using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spilari : MonoBehaviour
{
    // Hraði sem spilarinn getur færst á
    public float speed = 5.0f;

    public float jump = 1.5f;// hæðin sem spilari hoppar

    public int maxHealth = 5;// líf spilara

    public GameObject projectilePrefab;// byssukúla

    public int health { get { return currentHealth; } }
    int currentHealth;//núverandi líf

    public float timeInvincible = 2.0f;//spilari er ódrepanlegur í 2 sekúndur
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public float timeJumpDelay = 1.5f;//getur ekki hoppað í 1.5 sekúndur
    bool isJumpDelay;
    float JumpDelayTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(horizontal, vertical); // 'vector2' er tvær tölur

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible) // ef 'isInvincible' er 'True'
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (isJumpDelay) // ef 'isJumpDelay' er 'True'
        {
            JumpDelayTimer -= Time.deltaTime;
            if (JumpDelayTimer < 0)
                isJumpDelay = false;
        }

        if (Input.GetKeyDown(KeyCode.C))//skjóta
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))//Tala
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))//hoppa
        {
            if (isJumpDelay == false)
            {
                transform.position += transform.up * jump;
                isJumpDelay = true;
                JumpDelayTimer = timeJumpDelay;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)// breyti lífinu á spilara
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        if (currentHealth == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Launch()// skít byssukúlunni
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}