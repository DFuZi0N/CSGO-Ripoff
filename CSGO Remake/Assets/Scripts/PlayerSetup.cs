using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    public Behaviour[] Disable;
    [SerializeField]
    Camera sceneCam;
    [SerializeField]
    string remoteLayerName = "RemotePlayer";


    private void Start()
    {
        GetComponent<FreeLookCam>().enabled = false;
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            sceneCam = Camera.main;
            if (sceneCam != null)
            {
                sceneCam.gameObject.SetActive(false);
            }
        }

        RegisterPlayer();
        
    }

    void RegisterPlayer()
    {
        string ID = "Player" + GetComponent<NetworkIdentity>().netId;
        transform.name = ID;
    }

    private void OnDisable()
    {
        if (sceneCam != null)
        {
            sceneCam.gameObject.SetActive(true);
        }
    }

    private void DisableComponents()
    {
            
                for (int i = 0; i < Disable.Length; i++)
                {
                    Disable[i].enabled = false;
                }
            

            
            
                
            
        }
    
    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

}



