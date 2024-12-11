using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmout; // Quantidade de escavacao
    [SerializeField] private int waterAmout; // Total de agua para nascer uma cenoura    
    
    [SerializeField] private bool detecting;

    private int initialDigAmout;
    private float currentWater;

    private bool dugHole;

    private PlayerItens playerItens;

    private void Start()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        initialDigAmout = digAmout;
    }

    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            // Encheu total de agua necessario
            if (currentWater >= waterAmout)
            {
                spriteRenderer.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerItens.totalCarrots++;
                    spriteRenderer.sprite = hole;
                    currentWater = 0f;
                }
            }
        }       
    }

    public void OnHit()
    {
        digAmout--;

        if (digAmout <= initialDigAmout / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

        /* if (digAmout <= 0)
        {
            // Plantar cenoura
        } */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dig"))
        {
            OnHit();
        }

        if (other.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
