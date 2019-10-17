using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 120;
    public int score = 0;
    public int health;
    public int lives = 1;
    public System.DateTime invincible;
    public bool vulnerable;
    public Text ui_score;
    public Text ui_health;
    public Text ui_lives;


    public GameObject deathEffect;
    public GameObject EndGameScreen;

    private void Start()
    {
        health = maxHealth;
        invincible = System.DateTime.Now;
        vulnerable = true;
        SetScore(0);
        updateLives();
        EndGameScreen = GameObject.FindWithTag("EndGame");
        EndGameScreen.SetActive(false);
    }

private void Update()
    {
        if (System.DateTime.Compare(invincible, System.DateTime.Now) < 0)
        {
            vulnerable = true;
        }
        CheckWin();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DisplayHealth(health);
        if (health <= 0)
        {
            Die();
            return;
        }
        InvincibilityReset(1);
    }

    void InvincibilityReset(int seconds)
    {
        invincible = System.DateTime.Now.AddSeconds(seconds);
        vulnerable = false;
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        if (lives > 0)
        {
            health = maxHealth;
            DisplayHealth(health);
            transform.position = GameObject.Find("PlayerRespawn").transform.position;
            lives -= 1;
            updateLives();
            InvincibilityReset(6);
        }
        else
        {
            DisplayHealth(0);
            Destroy(gameObject);
            EndGameScreen.SetActive(true);
            EndGameScreen.transform.Find("VictoryMenu").gameObject.SetActive(false);
        }

    }

    void CheckWin()
    {
        if (score >= 3000)
        {
            Debug.Log("WIN");
            Destroy(gameObject);
            EndGameScreen.SetActive(true);
            EndGameScreen.transform.Find("GameOverMenu").gameObject.SetActive(false);
        }
    }

    public void SetScore(int points)
    {
        score += points;
        ui_score.text = "Score: " + score.ToString();
    }
    void updateLives()
    {
        ui_lives.text = "Lives: " + lives.ToString();
    }
    void DisplayHealth(int healthPoints)
    {
        ui_health.text = "Health: " + healthPoints.ToString();
    }
}
