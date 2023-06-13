using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textAmmo;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform aim;
    [SerializeField] ParticleSystem ps;
    [SerializeField] AudioClip shotClip;
    AudioSource audios;

    public int maxAmmo = 3;
    private int currentAmmo;
    public float reloadTime = 1f;

    private bool isReloading = false;

    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }

    void Start()
    {
        
        currentAmmo = maxAmmo;
        textAmmo.text = currentAmmo.ToString();
    }

   
    void Update()
    {
        if(isReloading)
        {
            return;
        }
        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
           
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        textAmmo.text = "Reloading";
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        textAmmo.text = currentAmmo.ToString();
        isReloading = false;
    }
    void Shoot()
    {
        currentAmmo--;
        textAmmo.text = currentAmmo.ToString();

        GameObject bullet = Instantiate(prefab, aim.position, transform.rotation);

        ps.Play();
        audios.PlayOneShot(shotClip);
        
        
    }
}
