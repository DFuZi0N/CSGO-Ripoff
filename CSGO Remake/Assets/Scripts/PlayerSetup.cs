using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;


[RequireComponent(typeof(player))]
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    private Behaviour[] Disable;
    [SerializeField]
    string remoteLayerName = "RemotePlayer";
    [SerializeField]
    Camera cam;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            
            if (cam.gameObject != null)
            {
                cam.gameObject.SetActive(false);
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
        if (cam.gameObject != null)
        {
           cam.gameObject.SetActive(true);
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