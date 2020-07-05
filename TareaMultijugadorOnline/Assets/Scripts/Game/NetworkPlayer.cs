using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour, IPunObservable, IPunInstantiateMagicCallback
{
    [SerializeField] private PlayerStyle playerStyle;
    [SerializeField] private PlayerController playerController;

    private Vector3 _position;
    private Quaternion _rotation;
    private PhotonView _photonView;

    public int Id { get; private set; }
    public string NickName { get; private set; }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        var player = info.Sender;
        var name = player.NickName;
        NickName = name;
        _photonView = info.photonView;
        player.TryGetColor(out int color);

        playerStyle.SetData(name, color);

        Debug.Log($"{name} {info.photonView.IsMine}");

        if (_photonView.IsMine)
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
            _position = (Vector3)stream.ReceiveNext();
            _rotation = (Quaternion)stream.ReceiveNext();

            float lag = (float)(PhotonNetwork.Time - info.SentServerTimestamp);
        }
    }

    void Update()
    {
        if (!_photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, Time.deltaTime * 10);
        }
    }
}
