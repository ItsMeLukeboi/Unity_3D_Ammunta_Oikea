using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public static float eteenpain_nopeus = 1.0f;

    private float horisontaalinenPyorinta = 0;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        Vector3 nopeus = new Vector3(0, 0, eteenpain_nopeus);



        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        hahmokontrolleri.SimpleMove(nopeus);

    }

    void OnCollisionEnter(Collision collision)
    {
         //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Wall")
        {
        // Random _random = new Random();

            int kaanos = 180;
            kaanos = Random.Range(90, 270);

            //If the GameObject has the same tag as specified, output this message in the console
            horisontaalinenPyorinta += kaanos;
        }
    }
}
