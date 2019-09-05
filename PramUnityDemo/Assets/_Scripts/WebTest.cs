using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Pram;

public class WebTest : MonoBehaviour
{
    string url = "http://127.0.0.1:5000/run_simulation";

    // Use this for initialization
    IEnumerator Start() {
        // Create a form object for sending data to the server
        WWWForm form = new WWWForm();

        Dictionary<string, string> g1Attributes = new Dictionary<string, string>();
        Dictionary<string, string> g2Attributes = new Dictionary<string, string>();
        Dictionary<string, string> g3Attributes = new Dictionary<string, string>();

        g1Attributes.Add("flu-status", "s");
        g2Attributes.Add("flu-status", "i");
        g3Attributes.Add("flu-status", "r");

        Group g1 = new Group(g1Attributes, "", 1000);
        Group g2 = new Group(g2Attributes, "", 0);
        Group g3 = new Group(g3Attributes, "", 0);

        RunRequest stuff = new RunRequest(new GroupJsonifiable[] { new GroupJsonifiable(g1), new GroupJsonifiable(g2), new GroupJsonifiable(g3) }, new string[] { "Simple Flu Progress Rule" }, 1);

        form.AddField("runInfo", JsonUtility.ToJson(stuff));

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
