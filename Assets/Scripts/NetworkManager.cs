using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    public Text txt_status;

    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        // Input para criar a sala
        if (Input.GetKeyDown(KeyCode.C)) {
            PhotonNetwork.CreateRoom("Sala_Man");
            txt_status.text = "Criou a sala!";
            txt_status.color = Color.yellow;
        }

        // Input para entrar na sala
        if (Input.GetKeyDown(KeyCode.E)) {
            PhotonNetwork.JoinRoom("Sala_Man");
        }

        // Instanciar os players
        if (Input.GetKeyDown(KeyCode.E)) {
            PhotonNetwork.Instantiate("player", new Vector3(5, 5, 5), Quaternion.identity, 0);
            txt_status.text = "Instanciou o player";
            txt_status.color = Color.green;
        }
    }
    void OnJoinedRoom() {
        txt_status.text = "Entrou na Sala_Man!";
        txt_status.color = Color.magenta;
    }
    void OnJoinLobby() {
        txt_status.text = "Tamo no Lobby galera!";
        txt_status.color = Color.green;
    }
    void ConnectToPhoton() {
        try {
            PhotonNetwork.ConnectUsingSettings("v1.0");
            txt_status.text = "Conectou na bagaça";
            txt_status.color = Color.blue;
        } catch(UnityException error) {
            Debug.Log (error);
        }
    }
}
