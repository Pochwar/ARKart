﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetApiData : MonoBehaviour {

	// Set the url where you get the data
	private string url = "http://localhost:9999/";

	// set the interval for fetching data
	private float interval = 0.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(GetData(interval));
	}

	// Update is called once per frame
	void Update () {}

	private IEnumerator GetData(float waitTime) {
		while (true)
		{
			// wait
			yield return new WaitForSeconds(waitTime);
			Debug.Log("Get Data");

			WWW www = new WWW(url);

			while(!www.isDone && string.IsNullOrEmpty(www.error)) {
				//this.GetComponent<TextMesh>().text = "Loading..."; //Show progress
				yield return null;
			}

			Data data = JsonUtility.FromJson<Data>(www.text);

			if(string.IsNullOrEmpty(www.error)) this.GetComponent<TextMesh>().text = data.date;
		}
	}
}


public class Data
{
	public string date;
}