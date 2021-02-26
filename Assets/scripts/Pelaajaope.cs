using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelaajaope : MonoBehaviour
{

    public float nopeus = 5.0f;

    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public float hyppyvoima = 30f;
    public float painovoima = 5f;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    private bool isGrounded;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * 5;
        float vertical = Input.GetAxis("Vertical") * 5;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * 3;

        xRotation = vertikaalinenPyorinta;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        hahmokontrolleri.SimpleMove(nopeus);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            print("space key was pressed");
            nopeus.y = hyppyvoima;
        }


        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        nopeus.y -= painovoima * Time.deltaTime;
        hahmokontrolleri.Move(nopeus * Time.deltaTime);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}