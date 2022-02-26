using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulineManager : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer Graphics;
    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            Graphics.flipX = !Graphics.flipX;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealfManager player = collision.transform.GetComponent<PlayerHealfManager>();
            player.Win();
        }
    }
}
