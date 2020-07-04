using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float turnSpeed;
    public float fireRate;
    public GameObject ball;

   // public static PlayerController control;

    private GameObject wind;
    private Rigidbody rig;
    private float windForce;
    private Quaternion windDir;
	private float rotationZ;
	private float rotationX;
	private float portNextfire;
	private float starboardNextfire;
    private float speedFactor;
    private float baseTurnSpeed = 10.0f;
    private AudioSource[] audios;
    private AudioSource cannonFireSound; 
    private Transform[] portGuns;
    private Transform[] starboardGuns;
    private int coins;


    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Speed: " + speed);
        GUI.Label(new Rect(10, 30, 100, 30), "Fire rate: " + fireRate);
    }

    void Awake() {
        //if(control == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //    control = this;
        //}
        //else if (control != this)
        //{
        //    Destroy(gameObject);
        //}

        portGuns = GetComponentsInChildren<Transform>();
        starboardGuns = GetComponentsInChildren<Transform>();
        wind = GameObject.FindGameObjectWithTag("Wind");
        rig = GetComponent<Rigidbody>();
        speedFactor = 0.0f;
        audios = GetComponents<AudioSource>();
        cannonFireSound = audios[1];
        
    }

    void Update()
    {
		if (Input.GetButton("Fire1") && Time.time > portNextfire)
        {
            cannonFireSound.Play();
			portNextfire = Time.time + fireRate;
            foreach (Transform go in portGuns)
            {
                if (go.tag == "PortGuns")
                {
                    Instantiate(ball, go.transform.position, go.transform.rotation);
                }
            }            
        }
		if (Input.GetButton("Fire2") && Time.time > starboardNextfire)
        {
            cannonFireSound.Play();
            starboardNextfire = Time.time + fireRate;
            foreach (Transform go in starboardGuns)
            {
                if (go.tag == "StarBoradGuns")
                {
                    Instantiate(ball, go.transform.position, go.transform.rotation);
                }
            }
        }
    }
		

    void FixedUpdate()
    {
		limiteRotation ();

        //wind force
        if (wind != null)
        {
            windForce = wind.GetComponent<WindZone>().windMain;
            windDir = wind.GetComponent<Transform>().rotation;
            rig.AddRelativeForce(new Vector3(windDir.x, 0.0f, windDir.z) * windForce, ForceMode.Force);
        }
        //steering force
        if (Input.GetKeyUp(KeyCode.W) && speedFactor < 3)
        {
            speedFactor += 1;
            Debug.Log(speedFactor);
        }

        if (Input.GetKeyUp(KeyCode.S) && speedFactor > 0)
        {
            speedFactor -= 1;
            Debug.Log(speedFactor);
        }
        rig.AddRelativeForce(Vector3.forward * speed * speedFactor);
        turnSpeed = (speedFactor + 1.0f) * baseTurnSpeed;
        transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);


        

        //rigidbody.AddRelativeTorque(Vector3.forward * Input.GetAxis("Horizontal") * tilt);
    }

	void limiteRotation(){
		rotationX = transform.localEulerAngles.x;
		rotationZ = transform.localEulerAngles.z;
		if (rotationX != 0 || rotationZ != 0) {
			rotationX = 0;
			rotationZ = 0;
		}
		transform.localEulerAngles = new Vector3 (rotationX, transform.localEulerAngles.y, rotationZ);
	}

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public bool HasCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        return false;
    }

    public int getCoins()
    {
        return coins;
    }

    public void Upgrade()
    {
        if (coins > 20)
        {
            coins -= 20;
            fireRate -= 0.1f;
            speed += 10.0f;
            baseTurnSpeed += 1.0f;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.coins = coins;
        data.fireRate = fireRate;
        data.speed = speed;
        data.baseTurnSpeed = baseTurnSpeed;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            coins = data.coins;
            fireRate = data.fireRate;
            speed = data.speed;
            baseTurnSpeed = data.baseTurnSpeed;
        }
    }

}

[Serializable]
class PlayerData
{
    public int coins;
    public float fireRate;
    public float speed;
    public float baseTurnSpeed;
}