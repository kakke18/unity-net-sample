﻿using System.Collections;
using System.Net;
using UnityEngine;

public class NetConnector : MonoBehaviour {
	private string myIP = "";
	private string servIP = "";
	private bool isConnected = false;
	public string  textField = "";

	// Use this for initialization
	void Start () {
		string hostname = Dns.GetHostName();

		IPAddress[] adrList = Dns.GetHostAddresses(hostname);
		foreach (IPAddress address in adrList) {
			myIP = address.ToString();
			servIP= myIP;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		if (!isConnected) {
			if (GUI.Button(new Rect(10, 10, 200, 30), "ゲームサーバーになる")) {
				if (Network.Connect(servIP, 25000) == NetworkConnectionError.NoError) {
					procConnect();
				}
				else {
					Debug.Log("接続エラー");
				}
			}

			servIP = GUI.TextField(new Rect(10, 50, 200, 30), servIP);

			if (GUI.Button(new Rect(10, 80, 200, 30), "上のゲームサーバーに接続")) {
				if (Network.InitializeServer(20, 25000, false) == NetworkConnectionError.NoError) {
					procConnect();
				}
				else {
					Debug.Log("ゲームサーバー初期化エラー");
				}
			}
		}
		else {
			textField = GUI.TextField(new Rect(10, 30, 200, 30), textField);

			if (GUI.Button(new Rect(10, 70, 200, 30), "送信")) {
				if(textField != "") {
					Debug.Log(textField);
				}
				else{
					Debug.Log("No");
				}
			}
		}
	}

	private void procConnect() {
		isConnected = true;
	}
}
