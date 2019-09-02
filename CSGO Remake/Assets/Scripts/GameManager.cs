using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const string PREFIX = "Player";

    private static Dictionary<string, player> Players = new Dictionary<string, player>();

    public static void RegisterPlayer(string netID, player _player)
    {
        string _PlayerID = PREFIX + netID;
        Players.Add(_PlayerID, _player);
        _player.transform.name = _PlayerID;
    }

    public static void UnRegisterPlayer(string _PLayerID)
    {
        Players.Remove(_PLayerID);
    }

    public static player GetPlayer(string _PlayerID)
    {
        return Players[_PlayerID];
    }

   // private void OnGUI()
    //{
     //   GUILayout.BeginArea(new Rect(200, 200, 200, 500));
     //   GUILayout.BeginVertical();
    //
    //    foreach(string _PlayerID in Players.Keys)
     //   {
    //        GUILayout.Label(_PlayerID + " - " + Players[_PlayerID].transform.name);
    //    }
//
  //      GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}

} 
