using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;

    public List<GameObject> lives;

    [SerializeField]
    private ParticleSystem flares;

    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Transform spawnArea;

    [SerializeField]
    private AudioSource laserSound;

    void Start()
    {
        rBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FireLaser();
        bool goForward = Input.GetKey(KeyCode.W);
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);

        if (goForward)
        {
            rBody.AddForce(this.transform.up);
            flares.Emit(1);
        }
        else if (turnLeft)
        {
            rBody.AddTorque(5000 * Time.deltaTime);
        }
        else if (turnRight)
        {
            rBody.AddTorque(-5000 * Time.deltaTime);
        }
    }

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            laserSound.Play();
            GameObject laserClone =
                Instantiate(laser, spawnArea.position, spawnArea.rotation);

            laserClone
                .GetComponent<Rigidbody2D>()
                .AddForce(this.transform.up * 200);
            Destroy(laserClone, 2.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            Destroy(lives[0].gameObject);
            lives.Remove(lives[0]);
        }
        if (collision.gameObject.tag == "asteroid" && lives.Count == 0)
        {
            AudioSource explosionSound =
                GameObject.Find("GameManager").GetComponent<AudioSource>();
            explosionSound.Play();
            this.gameObject.SetActive(false);
            GameObject explosionClone =
                Instantiate(explosion,
                gameObject.transform.position,
                gameObject.transform.rotation);
            Destroy(explosionClone, 1f);
        }
    }
}
