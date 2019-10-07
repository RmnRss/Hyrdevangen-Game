using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAI : MonoBehaviour
{
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            float movePerc = Random.Range(0, 100);
            if (movePerc > 97)
            {
                Vector3 direction = new Vector3(0.5f, 0, 0);

                if (movePerc % 2 == 0)
                {
                    direction = -direction;
                }

                Vector3 target = transform.position + direction;

                transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
            }
        }
        else
        {
            if(!GetComponent<AudioSource>().isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Kill()
    {
        if(isAlive)
        {
            isAlive = false;

            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
