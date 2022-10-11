using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed;
    Animator animatorController;


    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    public void movimientoBola()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a,b,speed);
    }

    public void animacionBola()
    {
        animatorController.SetTrigger("Start");
    }


    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movimientoBola();
        animacionBola();
    }
    // funcion para destruir el pahjaro al entrar en colision con el jugador

}
