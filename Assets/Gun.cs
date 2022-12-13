using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform gunBarrelTransform;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public AudioClip clip;
    public AudioSource audioSource;

    public int maxAmmo = 10;
    public int currentAmmo = 10;
    public float reloadTime = 5f;
    private bool isReloading = false;

    public TMP_Text bulletText;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        bulletText.text = currentAmmo.ToString() + "/10";
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            bulletText.text = "Reloading...";
            return;
        } else
        {
            bulletText.text = currentAmmo.ToString() + "/10";
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        currentAmmo--; 
        muzzleFlash.Play();
        audioSource.Play();
        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null && !enemy.IsDead)
            {
                enemy.TakeDamage(damage);
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;

    }
}
