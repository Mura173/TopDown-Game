using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");

        if (treeHealth <= 0)
        {
            // Cria o toco e instancia os drops (madeira)
            anim.SetTrigger("cut");        
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
