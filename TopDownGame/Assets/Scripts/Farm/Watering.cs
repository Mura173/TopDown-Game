using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    private bool detectingPlayer;
    [SerializeField] private int waterValue;

    private PlayerItens player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.MaxWater(waterValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
