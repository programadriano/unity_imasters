using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCai : MonoBehaviour
{

    public float duracaoCair;
    private float tempo;
    private bool pisou;

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            pisou = true;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pisou)
        {
            tempo += Time.deltaTime;

            if (tempo >= duracaoCair)
            {
                gameObject.AddComponent<Rigidbody2D>();
                Destroy(gameObject, 2f);
            }
        }
    }
}
