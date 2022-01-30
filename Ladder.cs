using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private bool is_in_range;
    private PlayerManager playerMovement;
    public Tilemap niveau;
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_in_range && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            niveau.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            is_in_range = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            is_in_range = false;
            playerMovement.isClimbing = false;
            niveau.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
