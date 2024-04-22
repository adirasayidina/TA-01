using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;
using System;

public class SupabaseDataInsertion : MonoBehaviour
{
    public void InsertDataToSupabase()
    {
        DateTime currentTime = DateTime.UtcNow;

        string waktuMulai = currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "+00";
        WWWForm form = new WWWForm();
        form.AddField("nama", "novita");
        form.AddField("materi", "ginjal");
        form.AddField("nilai", 92);
        form.AddField("waktu_mulai", waktuMulai);
        form.AddField("no_1", "true");
        form.AddField("jawaban_no_1", "a"); // terserah mau nyimpen isi pilihannya juga atau engga
        form.AddField("no_2", "false");
        form.AddField("jawaban_no_2", "b");
        form.AddField("no_3", "false");
        form.AddField("jawaban_no_3", "c");
        form.AddField("no_4", "true");
        form.AddField("jawaban_no_4", "d");
        form.AddField("no_5", "true");
        form.AddField("jawaban_no_5", "a");
        form.AddField("no_6", "false");
        form.AddField("jawaban_no_6", "b");
        form.AddField("no_7", "true");
        form.AddField("jawaban_no_7", "a");
        form.AddField("no_8", "true");
        form.AddField("jawaban_no_8", "d");
        form.AddField("no_9", "true");
        form.AddField("jawaban_no_9", "c");
        form.AddField("no_10", "false");
        form.AddField("jawaban_no_10", "a");


        UnityWebRequest webRequest = UnityWebRequest.Post("https://rfifnkbwxbvvapcgpuzn.supabase.co/rest/v1/hasil_kuis", form);
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