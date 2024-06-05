using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class FPSShootingScript : MonoBehaviour
{

    // Sets Damage of gun
    [SerializeField] int gunDamage = 1;
    // sets gun fire rate
    [SerializeField] float fireRate = 0.25f;
    // Raycast Range
    [SerializeField] float range = 50;
    //Force applied to objects rigidbody
    [SerializeField] float hitForce = 15;
    //Amount of time the laser will be active for
    [SerializeField] float waitTime = 0.1f;

    [Header("Transforms")]
    [SerializeField] Transform gunEnd;
    [SerializeField] Camera fpsCam;

    AudioSource audioSource;
    LineRenderer lr;

    float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();

        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            // adds cooldowns so player can not spam
            nextFire = Time.time + fireRate;
            //triggers audio and visual effects for laser
            StartCoroutine(shootingEffects());
            // Sends Raycast & Sets Line renderer position to gun end
            SendRaycast();

            
        }
    }

    IEnumerator shootingEffects()
    {
        audioSource.Play();
        lr.enabled = true;
        yield return new WaitForSeconds(waitTime);

        lr.enabled = false;
    }

    void SendRaycast()
    {
        // returns center point of camera relative to viewport
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        lr.SetPosition(0, gunEnd.position);

        // fires ray from ray origin towards forward of fps camera with a capped range
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
        {
            lr.SetPosition(1, hit.point);

            ShootableBox enemy = hit.transform.GetComponent<ShootableBox>();
            
            if (enemy != null)
            {
                enemy.Damage(gunDamage);
            }

            /*if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce, ForceMode.Impulse);
            }*/
        }
        else
        {
            lr.SetPosition(1, gunEnd.transform.forward * 99999);
        }
    }
}
