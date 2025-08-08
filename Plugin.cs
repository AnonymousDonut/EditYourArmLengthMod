using UnityEngine;
using BepInEx;
using System;
using Photon.Pun;


namespace EditArmLength
{


    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private bool inRoom;

        void Start()
        {

        }
        void OnGameInitialized(object sender, EventArgs e)
        {

        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        void Update()
        {
            if (PhotonNetwork.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED"))
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0 && canDoMore)
                {
                    GTPlayer.Instance.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
                    if (GTPlayer.Instance.transform.localScale >= 3)
                    {
                        canDoMore = false;
                    }
                }
                 if (ControllerInputPoller.instance.leftControllerIndexFloat > 0 && canDoLess)
                 {
                    GTPlayer.Instance.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
                    if (GTPlayer.Instance.transform.localScale < 0.2f)
                    {
                        canDoLess = false;
                    }
                }
            }
            else if (PhotonNetwork.InRoom && !NetworkSystem.Instance.GameModeString.Contains("MODDED"))
            {
                OnDisable();
            }
        }
    }
}
