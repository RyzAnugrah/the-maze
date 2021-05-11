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
        else if (other.gameObject.tag == "Finish")
        {
            Next();
        }
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
