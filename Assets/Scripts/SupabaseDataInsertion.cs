using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;

public class SupabaseDataInsertion : MonoBehaviour
{
    public void InsertDataToSupabase()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "nama");
        form.AddField("score", 92);

        UnityWebRequest webRequest = UnityWebRequest.Post("https://rfifnkbwxbvvapcgpuzn.supabase.co/rest/v1/quiz_score", form);
        webRequest.SetRequestHeader("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJmaWZua2J3eGJ2dmFwY2dwdXpuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI3MTc0NzcsImV4cCI6MjAyODI5MzQ3N30.51_kdsYavU44NwNEgGyvGx96_7v9V7dR7Y0AsdnqIBg");

        // Send the request
        webRequest.SendWebRequest();

        // Wait until the request is done
        while (!webRequest.isDone) { }
    
        Debug.Log("API response: " + webRequest.downloadHandler.text);

        // Clean up the request
        webRequest.Dispose();
    }
}