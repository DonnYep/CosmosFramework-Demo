﻿using System.Text;
using UnityEngine;
using Cosmos;
using Cosmos.Network;
using UnityEngine.UI;

public class MultiNetworkServer : MonoBehaviour
{
    TcpServerChannel tcpServerChannel;
    KCPServerChannel kcpServerChannel;

    [Header("TCP")]
    [SerializeField] Button btnTcpStartServer;
    [SerializeField] Button btnTcpStopServer;
    [Header("KCP")]
    [SerializeField] Button btnKcpStartServer;
    [SerializeField] Button btnKcpStopServer;

    void Start()
    {
        tcpServerChannel = new TcpServerChannel("TEST_TCP_SERVER", MultiNetworkConstants.TCP_PORT);
        kcpServerChannel = new KCPServerChannel("TEST_KCP_SERVER", MultiNetworkConstants.KCP_PORT);

        tcpServerChannel.OnConnected += TcpServer_OnConnected;
        tcpServerChannel.OnDisconnected += TcpServer_OnDisconnected;
        tcpServerChannel.OnDataReceived += TcpServer_OnDataReceived;

        kcpServerChannel.OnConnected += KcpServer_OnConnected;
        kcpServerChannel.OnDataReceived += KcpServer_OnDataReceived;
        kcpServerChannel.OnDisconnected += KcpServer_OnDisconnected;
        //channel的TickRefresh函数可自定义管理轮询，networkManager的作用是存放通道并调用TickRefresh。
        //由于存在多种网络方案的原因，通道对应的具体事件需要由使用者自定义解析，框架不提供具体数据。
        //这里将server加入networkManager，由networkManager管理通道的轮询
        CosmosEntry.NetworkManager.AddChannel(kcpServerChannel);
        CosmosEntry.NetworkManager.AddChannel(tcpServerChannel);

        btnTcpStartServer?.onClick.AddListener(TcpStartServer);
        btnTcpStopServer?.onClick.AddListener(TcpStopServer);

        btnKcpStartServer?.onClick.AddListener(KcpStartServer);
        btnKcpStopServer?.onClick.AddListener(KcpStopServer);
    }

    #region TCP_SERVER
    void TcpStartServer()
    {
        tcpServerChannel.StartServer();
    }
    void TcpStopServer()
    {
        tcpServerChannel.StopServer();
    }
    void TcpServer_OnConnected(int conv)
    {
        Utility.Debug.LogInfo($"TCP_SERVER conv: {conv} Connected", DebugColor.yellow);
    }
    void TcpServer_OnDataReceived(int conv, byte[] data)
    {
        Utility.Debug.LogInfo($"TCP_SERVER receive data from conv: {conv} . Data: { Encoding.UTF8.GetString(data)}", DebugColor.yellow);
    }
    void TcpServer_OnDisconnected(int conv)
    {
        Utility.Debug.LogInfo($"TCP_SERVER conv: {conv} Disconnected", DebugColor.red);
    }
    #endregion

    #region KCP_SERVER
    void KcpStartServer()
    {
        kcpServerChannel.StartServer();
    }
    void KcpStopServer()
    {
        kcpServerChannel.StopServer();
    }
    void KcpServer_OnConnected(int conv)
    {
        Utility.Debug.LogInfo($"KCP_SERVER conv: {conv} Connected");
    }
    void KcpServer_OnDataReceived(int conv, byte[] data)
    {
        Utility.Debug.LogInfo($"KCP_SERVER receive data from conv: {conv} . Data: { Encoding.UTF8.GetString(data)}");
    }
    void KcpServer_OnDisconnected(int conv)
    {
        Utility.Debug.LogInfo($"KCP_SERVER conv: {conv} Disconnected", DebugColor.red);
    }
    #endregion
}
