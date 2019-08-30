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
                CmdPlayerShot(hit.collider.name);
            }

            Debug.Log(hit.distance + hit.collider.name);    
        }
    }

    [Command]
   public void CmdPlayerShot(string ID)
    {
        Debug.Log(ID + "Has Been Shot!");

        GameObject otherPlayer = GameObject.Find(ID);
        otherPlayer.gameObject.GetComponent<UniversalHP>().hp -= weapon.damage;

        if(otherPlayer.GetComponent<UniversalHP>().hp <= 0)
        {
           hp.KillPlayer(otherPlayer);

        }


    }

    
}
