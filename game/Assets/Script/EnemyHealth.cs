using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int initialHealth = 50;
    public int currentHealth;
    public Slider healthBar;
    public GameObject CBTPrefab;
    public GameObject barrerl;
    public GameObject DepthCharge;

    private Transform[] barrelSpawnPos;
    private Transform[] lootSpawnPos;
    private float nextSpawn;
    private bool isDead;
   

    void Awake()
    {
        if(healthBar == null)
        {
            healthBar = GetComponentInChildren<Slider>();
        }
        currentHealth = initialHealth;
        healthBar.maxValue = initialHealth;
        healthBar.value = initialHealth;
        lootSpawnPos = GetComponentsInChildren<Transform>();
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
        }
        initialCBT(amount.ToString());
    }


    void Update()
    {
        if (isDead)
        {           
            foreach (Transform trs in lootSpawnPos)
            {
                if(trs.tag == "LootSpawn")
                {
                    Instantiate(barrerl, trs.position, trs.rotation);
                }
            }
            //SinkShip();
            Destroy(gameObject);
        }
    }

    void SinkShip()
    {
        Quaternion currentAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Quaternion sunkAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180.0f);
        transform.rotation = Quaternion.Slerp(currentAngle, sunkAngle, 0.5f);
    }

    void initialCBT(string text)
    {
        GameObject clone = Instantiate(CBTPrefab) as GameObject;
        RectTransform rect = clone.GetComponent<RectTransform>();
        clone.transform.SetParent(transform.FindChild("EnemyInfo"));
        rect.transform.localPosition = CBTPrefab.transform.localPosition;
        rect.transform.localScale = CBTPrefab.transform.localScale;
        rect.transform.localRotation = CBTPrefab.transform.localRotation;

        clone.GetComponent<Text>().text = text;
        clone.GetComponent<Animator>().SetTrigger("Hit");
        Destroy(clone.gameObject, 2);
    }

    public void SpawnBarrel()
    {
        barrelSpawnPos = GetComponentsInChildren<Transform>();
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + 3.0f;
            foreach (Transform trs in barrelSpawnPos)
            {
                if (trs.tag == "BarrelSpawn")
                {
                    Instantiate(DepthCharge, trs.position, trs.rotation);
                }
            }
        }
    }
}