using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    private AudioSource gunAudio;

    // Update is called once per frame
    void Start() {
        gunAudio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Plays the audio and the muzzleflash
        muzzle.Play();
        gunAudio.Play();
        
        //Storing information about what object gets hit using the ray
        RaycastHit hitInfo;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }

            if(hitInfo.rigidbody != null) {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            //Instantiating the shot impact at the hit point
            GameObject impact = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            Destroy(impact, 2f);
        }
    }
}
