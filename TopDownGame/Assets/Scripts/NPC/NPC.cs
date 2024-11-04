using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float initialSpeed;

    private int index;

    private Animator anim;

    public Transform[] paths;

    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueControl.instance.IsShowing)
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        // MoveTowards(): Retorna o Vector2 pra uma direcao
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

           // Subtracao da posicao do NPC e a posicao do path
        if (Vector2.Distance(transform.position, paths[index].position) < 0.01f)
        {
            if (index < paths.Length - 1)
            {
                //index++;
                index = UnityEngine.Random.Range(0, paths.Length - 1);
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
