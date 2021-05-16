using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject gameOver, gameNext;

    public static bool GameIsOver = false;
    public static bool GameIsNext = false;

    public float timeBetweenAttacks;

    bool alreadyAttacked;

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        gameOver.gameObject.SetActive(false);
        gameNext.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Over();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spike")
        {
            TakeDamage(1);
            Debug.Log("Spike Damage");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (!alreadyAttacked)
            {
                TakeDamage(1);
                Debug.Log("Enemy Attacked");

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        else if (other.gameObject.tag == "Finish")
        {
            Next();
        }
        else if (other.gameObject.tag == "Bottle")
        {
            if (currentHealth > 0 && currentHealth < 5)
            {
                currentHealth += 1;
                healthBar.SetHealth(currentHealth);
                Destroy(GameObject.FindWithTag("Bottle"));
                Debug.Log("Got Health");
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Over()
    {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Next()
    {
        gameNext.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsNext = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
