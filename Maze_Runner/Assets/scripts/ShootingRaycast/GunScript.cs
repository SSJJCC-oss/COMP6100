using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
   // public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    private AudioSource gunAudio;

   // private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Start() {
        gunAudio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           // nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzle.Play();
        gunAudio.Play();

        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}