using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarilManager : MonoBehaviour
{
    public GameObject objectToDestroy;
    public int domageCollision = 1; 
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealfManager player = collision.transform.GetComponent<PlayerHealfManager>();
            player.TakeDomage(domageCollision);
            Destroy(objectToDestroy);
        }
    }
}
