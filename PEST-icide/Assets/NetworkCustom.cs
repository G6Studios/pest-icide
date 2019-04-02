using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkCustom : NetworkManager
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Transform startPos = GetStartPosition();
        GameObject player;
        switch (playerControllerId)
        {
            case 0:
                {
                player = Instantiate(character1, startPos.position, startPos.rotation);
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
                break;
                }
            case 1:
                {
                player = Instantiate(character2, startPos.position, startPos.rotation);
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
                break;
                }
            case 2:
                {
                player = Instantiate(character3, startPos.position, startPos.rotation);
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
                break;
                }
            case 3:
                {
                    player = Instantiate(character4, startPos.position, startPos.rotation);
                    NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
                    break;
                }
            default:
                player = null;
                break;
        }
    }


}
