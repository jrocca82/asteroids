using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision) {
        TextBehaviour updateScore = GameObject.Find("GameManager").GetComponent<TextBehaviour>();
        AudioSource explosionSound = GameObject.Find("GameManager").GetComponent<AudioSource>();
        
        if(this.gameObject.tag == "laser" && collision.gameObject.tag == "asteroid"){
            Destroy(gameObject);
        }

        if(this.gameObject.tag == "asteroid" && collision.gameObject.tag == "laser"){
            updateScore.score += 1;
            explosionSound.Play();
            Destroy(gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 0.5f);
        }
    }
}
