using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    string url = "http://127.0.0.1:5000/test-post";

    // Use this for initialization
    IEnumerator Start() {
        // Create a form object for sending data to the server
        WWWForm form = new WWWForm();
        form.AddField("test", "hi");

        // Create a download object
        var download = UnityWebRequest.Post(url, form);

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError) {
            print("Error downloading: " + download.error);
        } else {
            Debug.Log(download.downloadHandler.text);
        }
    }

}
