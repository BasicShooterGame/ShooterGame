using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Gun equippedGun;
    [SerializeField] private Transform weaponHold;
    [SerializeField] private Gun startingGun;

    private void Start()
    {
        equipWeapon(startingGun);
    }
    void equipWeapon(Gun gunToEquip) {
        if (equippedGun != null)
        {
            Destroy(equippedGun);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void shoot() {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
