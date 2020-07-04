using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int initialHealth = 1000;
    public int currentHealth;
    public ParticleSystem shipExplotion;
    public GameObject gameOverMenu;

    private Slider healthBar;
    private Text coins;
    private PlayerController playerController;
    private bool isDead;   

    void Awake()
    {
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        coins = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        playerController = GetComponent<PlayerController>();
        currentHealth = initialHealth;
        healthBar.maxValue = initialHealth;
        healthBar.value = initialHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            playerController.enabled = false;
            Instantiate(shipExplotion, transform.position, transform.rotation);
        }
    }

    public void Repair(int amount) {
        if(playerController.HasCoins(amount) && currentHealth < initialHealth)
        {
            currentHealth += amount;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {
        coins.text = "Coins: " + playerController.getCoins().ToString();
        if (isDead)
        {
            SinkShip();
            Destroy(gameObject, 5);
            
             
            if (gameOverMenu != null)
            {
                gameOverMenu.SetActive(true);
            }
            else
            {
                gameOverMenu = GameObject.Find("GameOver");
                gameOverMenu.SetActive(true);
            }
        }
    }

    void SinkShip()
    {
        Quaternion currentAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Quaternion sunkAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180.0f);
        transform.rotation = Quaternion.Slerp(currentAngle, sunkAngle, 0.5f);
    }
}
