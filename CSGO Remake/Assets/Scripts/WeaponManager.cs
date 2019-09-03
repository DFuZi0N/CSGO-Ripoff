using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour {


    [SerializeField]
    private PlayerWeapons primary;
    private PlayerWeapons currentWeapon;
    [SerializeField]
    private Transform weaponHolder;
    private string layerName = "Weapon";

	void Start () {

        equipWeapon(primary);
        // In future, add weapon selection GUI		
	}


   public PlayerWeapons getCurrentWeapon()
    {
        return currentWeapon;
    }


    void equipWeapon(PlayerWeapons next)
    {
        currentWeapon = next;
        GameObject WeaponInst = (GameObject)Instantiate(next.graphics, weaponHolder.position, weaponHolder.rotation);
        WeaponInst.transform.SetParent(weaponHolder);
        if(isLocalPlayer)
        {
            WeaponInst.layer = LayerMask.NameToLayer(layerName);
            WeaponInst.tag = layerName;
        }
    }
}
