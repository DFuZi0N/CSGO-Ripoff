using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;


[RequireComponent(typeof(player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] Disable;
    [SerializeField]
    Camera sceneCam;
    [SerializeField]
    string remoteLayerName = "RemotePlayer";


    private void Start()
    {
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

        GetComponent<player>().Setup();

    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        player _player = GetComponent<player>();

        GameManager.RegisterPlayer(_netID, _player);
    }


    private void OnDisable()
    {
        if (sceneCam != null)
        {
            sceneCam.gameObject.SetActive(true);
            GameManager.UnRegisterPlayer(transform.name);
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



