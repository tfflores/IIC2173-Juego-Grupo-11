using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 120;
    public int score = 0;
    public int health;
    public int lives = 5;
    public System.DateTime invincible;
    public bool vulnerable;
    public Text ui_score;
    public Text ui_health;
    public Text ui_lives;
    public Text ui_gameover;


    public GameObject deathEffect;

    private void Start()
    {
        health = maxHealth;
        invincible = System.DateTime.Now;
        vulnerable = true;
        SetScore(0);
        LivesCounter(0);
    }

    private void Update()
    {
        if (System.DateTime.Compare(invincible, System.DateTime.Now) < 0)
        {
            vulnerable = true;
        }

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
            LivesCounter(-1);
            InvincibilityReset(6);
        }
        else
        {
            DisplayHealth(0);
            ui_gameover.text = "GAME OVER";
            Destroy(gameObject);
        }

    }

    public void SetScore(int points)
    {
        score += points;
        ui_score.text = "Score: " + score.ToString();
    }
    void LivesCounter(int modifier)
    {
        lives += modifier;
        ui_lives.text = "Lives: " + lives.ToString();
    }
    void DisplayHealth(int healthPoints)
    {
        ui_health.text = "Health: " + healthPoints.ToString();
    }
}
