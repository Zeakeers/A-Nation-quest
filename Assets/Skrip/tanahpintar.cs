using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanahpintar : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            collider.enabled = false;
        }
        if (Player.transform.position.y > transform.position.y)
        {
            collider.enabled = true;
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            collider.enabled = false;
        }


    }
}
