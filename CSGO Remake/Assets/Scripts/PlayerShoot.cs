using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    private const string PTag = "Player";

    private PlayerWeapons currentWeapon;
    private WeaponManager WeaponManager;
    public GameObject sceneCam;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    LayerMask mask;

    private bool locked;

    private void Start()
    {
        WeaponManager = GetComponent<WeaponManager>();
        locked = true;
    }

    private void Update()
    {
        currentWeapon = WeaponManager.getCurrentWeapon();

        if (Input.GetMouseButtonDown(0)) {
            if (currentWeapon.fireRate <= 0)
            {
                Shoot();
            }
            else
            {
                    InvokeRepeating("Shoot", 0f, 1f / currentWeapon.fireRate);   
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Shoot");
        }
            
            
            
          
        if (locked)

        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                if (!locked)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    locked = true;
                }
            }
        }
    }

    



    [Client] 
    void Shoot()
    {

        Debug.Log("SHOOT!");

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, currentWeapon.range, mask))
        {
            if(hit.collider.tag == PTag)
            {
                CmdPlayerShot(hit.collider.name, currentWeapon.damage);
            }

            Debug.Log(hit.distance + hit.collider.name);    
        }
    }

    [Command]
    public void CmdPlayerShot(string _PlayerID, int dmg)
    {

        dmg = currentWeapon.damage;
        Debug.Log(_PlayerID + "Has Been Shot!");

        player _Player = GameManager.GetPlayer(_PlayerID);
        _Player.RpcTakeDamage(dmg);
    }

    
}
