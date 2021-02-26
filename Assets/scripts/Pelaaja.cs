using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelaaja : MonoBehaviour
{
    // Start is called before the first frame update

    public float nopeus = 5.0f;

   // private Rigidbody rb;
    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public Animator anim;


    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    private bool isGrounded;

    public float hyppyvoima = 100f;
    public float painovoima = 50f;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        CharacterController hahmokontrolleri = GetComponent<CharacterController>();

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * 3;

        xRotation = vertikaalinenPyorinta;
        xRotation = Mathf.Clamp(xRotation, -35f, 35f);


        float horizontal = Input.GetAxis("Horizontal") * 10;
        float vertical = Input.GetAxis("Vertical") * 10;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        transform.localRotation = Quaternion.Euler(xRotation * 3, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        hahmokontrolleri.SimpleMove(nopeus);


        if (Input.GetKeyDown("space") && isGrounded) ;


        if (Input.GetKeyDown ("space"))
        {
            print("space key was pressed");
            nopeus.y = hyppyvoima;


        }

        if (Input.GetAxis("Vertical") !=0)
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
        
