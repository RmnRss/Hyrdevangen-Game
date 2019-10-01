using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

            //transform.Translate(direction);
            transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
            Debug.Log("Moving");
        }
    }
}
