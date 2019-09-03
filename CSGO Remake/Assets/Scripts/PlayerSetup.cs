using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;


[RequireComponent(typeof(player))]
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    private Behaviour[] Disable;
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
            
            if (Camera.main.gameObject != null)
            {
                Camera.main.gameObject.SetActive(false);
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
        if (Camera.main.gameObject != null)
        {
            Camera.main.gameObject.SetActive(true);
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