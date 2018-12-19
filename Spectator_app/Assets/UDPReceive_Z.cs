﻿using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;



public class UDPReceive_Z : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port_Z = 26001;
    string strReceiveUDP = "";
    //Player strReceiveUDP;
    string LocalIP = String.Empty;
    string hostname;

    public void Start()
    {
        Application.runInBackground = true;
        init();
    }
    // init
    private void init()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
        hostname = Dns.GetHostName();
        IPAddress[] ips = Dns.GetHostAddresses(hostname);
        if (ips.Length > 0)
        {
            LocalIP = ips[0].ToString();
        }
    }

    void OnGUI()
    {
        Rect rectObj = new Rect(10, 10, 400, 200);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        //GUI.Box(rectObj, hostname + " MY IP : " + LocalIP + " : " + strReceiveUDP, style);

        //移動
        Vector3 pos = transform.position;
        pos.z = float.Parse(strReceiveUDP);
        transform.position = pos;
        //
    }

    private void ReceiveData()
    {
        client = new UdpClient(port_Z);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, port_Z);
                //IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);
                strReceiveUDP = text;
                Debug.Log(strReceiveUDP);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    public string UDPGetPacket()
    {
        return strReceiveUDP;
    }

    void OnDisable()
    {
        if (receiveThread != null) receiveThread.Abort();
        client.Close();
    }
}