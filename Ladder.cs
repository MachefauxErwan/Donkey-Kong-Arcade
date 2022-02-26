using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private bool is_in_range;
    private PlayerMovementManager player;
    public Tilemap niveau;
    private Text InteractUI;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementManager>();
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        if (is_in_range && player.isClimbing == true && (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow)) )
        {
            player.isClimbing = false;
            niveau.GetComponent<TilemapCollider2D>().enabled = true;
            Debug.Log("descente");
            return;
        }
        if (is_in_range && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            player.isClimbing = true;
            niveau.GetComponent<TilemapCollider2D>().enabled = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.enabled = true;
            is_in_range = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.enabled = false;
            is_in_range = false;
            player.isClimbing = false;
            niveau.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
