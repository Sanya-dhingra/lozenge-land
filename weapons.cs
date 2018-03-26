using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource; 
    public float range = 1000f;
    public int bulletsPerMag = 30;
    public int bulletsLeft = 200;
    public int currentBullets;
    public Transform shootPoint;
    public float fireRate = 0.1f;
    public AudioClip shootSound;
    public ParticleSystem muzzleFlash;
    float fireTimer;
    private bool isReloading;

    public float damage=20f;
    public GameObject hitParticles;
    public GameObject bulletImpact;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;
    }
    void Update()
    {
        if(Input.GetButton("Fire1"))
    {
            if (currentBullets >0)
                Fire();
            else
                Doreload();

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && bulletsLeft > 0)
                Doreload();
        }
        if(fireTimer < fireRate)
    fireTimer += Time.deltaTime;
    }
    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        isReloading = info.IsName("Reload");
        if(info.IsName("Fire"))
     anim.SetBool("Fire", false);
    }
    private void Fire()
    {
        if(fireTimer < fireRate || currentBullets<=0 || isReloading)
        return;
        RaycastHit hit;
        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
    {
            Debug.Log(hit.transform.name +" found!");
            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));

            Destroy(hitParticleEffect, 1f);
            Destroy(bulletHole, 2f);

            if(hit.transform.GetComponent<destroying>())
            {
                hit.transform.GetComponent<destroying>().applyDamage(damage);
            }
        }
        anim.CrossFadeInFixedTime("Fire", 0.1f);
        muzzleFlash.Play();
        PlayShootSound();
        //anim.SetBool("Fire", true);
        currentBullets--;
        fireTimer = 0.0f;
    }
    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
        //audioSource.clip = shootSound;
       // audioSource.Play();
    }
    public void Reload()
    {
        if (bulletsLeft <= 0) return;
        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;
        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }
    private void Doreload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (isReloading) return;
        anim.CrossFadeInFixedTime("Reload", 0.01f);

    }
}



