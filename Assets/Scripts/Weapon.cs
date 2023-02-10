using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;            // spawn pos for the bullet

    public int curAmmo;                 // current amount of ammo
    public int maxAmmo;                 // maximum amount of ammo we can get
    public bool infiniteAmmo;           // do we have infinite ammo?

    public float bulletSpeed;           // initial velocity of the bullet

    public float shootRate;             // min time between shots
    private float lastShootTime;        // last time we shot a bullet
    private bool isPlayer;              // are we the player's weapon?

    public AudioClip shootSfx;
    private AudioSource audioSource;

    public void UpdateStats()
        {
            if (isPlayer)
            {
                if (Player.WeaponLevel == 2)
                {
                    shootRate = 0.2f;
                    maxAmmo = 300;
                    curAmmo = maxAmmo;
                shootSfx = Resources.Load<AudioClip>("Level 2");
                GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
            }
                else if (Player.WeaponLevel == 3)
                {
                    shootRate = 0.5f;
                    maxAmmo = 400;
                    curAmmo = maxAmmo;
                shootSfx = Resources.Load<AudioClip>("Level 3");
                GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
            }
                else if (Player.WeaponLevel == 4)
                {
                    shootRate = 1f;
                    maxAmmo = 50;
                    curAmmo = maxAmmo;
                shootSfx = Resources.Load<AudioClip>("Level 4");
                GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
            }
                else if (Player.WeaponLevel == 5)
                {
                    shootRate = 0.4f;
                    maxAmmo = 1;
                    curAmmo = maxAmmo;
                    GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
                shootSfx = Resources.Load<AudioClip>("Level 5");
                infiniteAmmo = true;
                }
            }
        }
    void Awake ()
    {
        // are we attached to the player?
        if(GetComponent<Player>())
            isPlayer = true;

        audioSource = GetComponent<AudioSource>();
    }

    // can we shoot a bullet?
    public bool CanShoot ()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    // called when we want to shoot a bullet
    public void Shoot ()
    {
        lastShootTime = Time.time;
        curAmmo--;

        if((isPlayer)&& (!infiniteAmmo))
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);

        audioSource.PlayOneShot(shootSfx);

        GameObject bullet = bulletPool.GetObject();

        bullet.transform.SetPositionAndRotation(muzzle.position, muzzle.rotation);

        // set the velocity
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}