using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private readonly float _velocidade = 5;
    private readonly float _forcaPulo = 250;
    private bool verificaChao;
    public Transform chaoVerificador;

    public Transform spritePlayer;
    private Animator _animator;


    // Use this for initialization
    void Start()
    {
        _animator = spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));

        _animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * _velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * _velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }


        if (Input.GetButtonDown("Jump") && verificaChao)
        {

            GetComponent<Rigidbody2D>().AddForce(transform.up * _forcaPulo);
        }


    }
}
