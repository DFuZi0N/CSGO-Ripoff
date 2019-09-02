using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    private const string PTag = "Player";

    public PlayerWeapons weapon;
    public GameObject sceneCam;
    public UniversalHP hp;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    LayerMask mask;

    private bool locked;

    private void Start()
    {
        locked = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (locked)

        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
            else if (!locked)
            {
                if(Input.GetMouseButtonDown(0))
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
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            if(hit.collider.tag == PTag)
            {
                CmdPlayerShot(hit.collider.name, weapon.damage);
            }

            Debug.Log(hit.distance + hit.collider.name);    
        }
    }

    [Command]
    public void CmdPlayerShot(string _PlayerID, int dmg)
    {

        dmg = weapon.damage;
        Debug.Log(_PlayerID + "Has Been Shot!");

        player _Player = GameManager.GetPlayer(_PlayerID);
        _Player.RpcTakeDamage(dmg);
    }

    
}
