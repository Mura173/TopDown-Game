using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalDropWood;

    [SerializeField] private ParticleSystem leafs;

    private bool isCut;

    public void OnHit()
    {
        treeHealth--;
        leafs.Play();

        anim.SetTrigger("isHit");

        if (treeHealth <= 0)
        {
            // Cria o toco e instancia os drops (madeira)
            for (int i = 0; i < totalDropWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }           
            anim.SetTrigger("cut");

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
