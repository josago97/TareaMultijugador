using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour, IPunObservable, IPunInstantiateMagicCallback
{
    [SerializeField] private PlayerStyle playerStyle;
    [SerializeField] private PlayerController playerController;

    public int Id { get; private set; }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        var player = info.Sender;
        var name = player.NickName;
        player.TryGetColor(out int color);

        playerStyle.SetData(name, color);

        Debug.Log($"{name} {info.photonView.IsMine}");

        if (info.photonView.IsMine)
            playerController.Activate();
        else
            playerController.Deactivate();

        Id = player.ActorNumber;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();

            float lag = (float)(PhotonNetwork.Time - info.SentServerTimestamp);
        }
    }
}
