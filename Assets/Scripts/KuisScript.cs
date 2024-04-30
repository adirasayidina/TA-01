using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class KuisScript : MonoBehaviour
{
    public Button[] buttonsPilihan;
    public GameObject PilihJawaban;
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public Sprite btnCorrect;
    public Sprite btnWrong;
    [SerializeField] private TMPro.TextMeshProUGUI pertanyaan;
    [SerializeField] private TMPro.TextMeshProUGUI soalBenar;
    [SerializeField] private TMPro.TextMeshProUGUI soalSalah;
    [SerializeField] private TMPro.TextMeshProUGUI pembahasan;

    [SerializeField] private TMPro.TextMeshProUGUI[] nomor;
    [SerializeField] private TMPro.TextMeshProUGUI[] pilganPertanyaan;
    [SerializeField] private TMPro.TextMeshProUGUI nilai;
    [SerializeField] private TMPro.TextMeshProUGUI abjadBenar;
    [SerializeField] private TMPro.TextMeshProUGUI pilganBenar;
    [SerializeField] private TMPro.TextMeshProUGUI abjadBenarPnlSalah;
    [SerializeField] private TMPro.TextMeshProUGUI pilganBenarPnlSalah;
    [SerializeField] private TMPro.TextMeshProUGUI abjadSalah;
    [SerializeField] private TMPro.TextMeshProUGUI pilganSalah;
    [SerializeField] private TMPro.TextMeshProUGUI judulKuis;
    [SerializeField] private TMPro.TextMeshProUGUI infoQuizMateri;
    public Button[] btnPembahasanAll;
    public GameObject pnlBenar;
    public GameObject pnlSalah;
    public GameObject pnlPertanyaan;
    public GameObject pnlNilai;

    // Panel Pembahasan Akhir
    public GameObject pnlPembahasan;
    public GameObject pnlPembahasanAkhirBnr;
    public GameObject pnlPembahasanAkhirSlh;
    [SerializeField] private TMPro.TextMeshProUGUI[] txtNomorPnlAkhir;
    [SerializeField] private TMPro.TextMeshProUGUI txtAbjadBenarPnlAkhirBenar;
    [SerializeField] private TMPro.TextMeshProUGUI txtPilganBenarPnlAkhirBenar;
    [SerializeField] private TMPro.TextMeshProUGUI txtPembahasanPnlAkhirBenar;
    [SerializeField] private TMPro.TextMeshProUGUI txtPilganBenarPnlAkhirSalah;
    [SerializeField] private TMPro.TextMeshProUGUI txtAbjadBenarPnlAkhirSalah;
    [SerializeField] private TMPro.TextMeshProUGUI txtPilganSalahPnlAkhirSalah;
    [SerializeField] private TMPro.TextMeshProUGUI txtAbjadSalahPnlAkhirSalah;
    [SerializeField] private TMPro.TextMeshProUGUI txtPembahasanPnlAkhirSalah;
    [SerializeField] private TMPro.TextMeshProUGUI[] txtPertanyaanSelanjutnya;

    public GameObject[] contentsHeight;
    public GameObject contentsPembHeight;
    void Start()
    {
        print("hi kuis");
        print(StaticClass.quizCode);
        print(StaticClass.quizNomor);

        StaticClass.pilganNormalSprite = normalSprite;
        StaticClass.pilganSelectedSprite = selectedSprite;
        StaticClass.quizNomor = 0;

        print("ini masuk");
        pertanyaan.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];
        infoQuizMateri.text = "Materi: " + StaticClass.quizCode;
        judulKuis.text = "Kuis - " + StaticClass.quizCode;
        foreach (GameObject ct in contentsHeight)
            ct.GetComponent<RectTransform>().sizeDelta = new Vector2(0, StaticInfoKuis.height[StaticClass.quizCode][StaticClass.quizNomor]);
        for (int i = 0; i < 4; i++)
            pilganPertanyaan[i].text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][i];
    }

    public void initTime()
    {
        StaticKuis.mulai = DateTime.Now;
    }

    public void ChangeImage(Button button)
    {
        if (button.image.sprite == StaticClass.pilganNormalSprite)
        {
            foreach (Button btn in buttonsPilihan)
            {
                if (btn.image.sprite == StaticClass.pilganSelectedSprite)
                    btn.image.sprite = StaticClass.pilganNormalSprite;
            }
            button.image.sprite = StaticClass.pilganSelectedSprite;
            PilihJawaban.SetActive(true);
        }
        else
        {
            button.image.sprite = StaticClass.pilganNormalSprite;
            PilihJawaban.SetActive(false);
        }
    }

    public void OpenPembahasanAkhir(int nomorSoal)
    {
        foreach (TMPro.TextMeshProUGUI txt in txtNomorPnlAkhir)
            txt.text = nomorSoal + 1 + "/10";
        string materi = StaticClass.quizCode;
        string abjadPilganBenar = StaticKuis.jawabanFlag[nomorSoal] ? StaticKuis.jawaban[nomorSoal] : StaticInfoKuis.jawabanKuis[materi][nomorSoal];
        string pilganBenar = StaticInfoKuis.pilgan[materi][nomorSoal][char.Parse(abjadPilganBenar) - 65];
        string pembahasan = StaticInfoKuis.pembahasan[materi][nomorSoal];
        string pertanyaan = StaticInfoKuis.soal[materi][nomorSoal];

        contentsPembHeight.GetComponent<RectTransform>().sizeDelta = new Vector2(0, StaticInfoKuis.height["Pemb"+StaticClass.quizCode][StaticClass.quizNomor]);
        txtPilganBenarPnlAkhirBenar.text = pilganBenar;
        txtAbjadBenarPnlAkhirBenar.text = abjadPilganBenar;
        txtPilganBenarPnlAkhirSalah.text = pilganBenar;
        txtAbjadBenarPnlAkhirSalah.text = abjadPilganBenar;
        txtPembahasanPnlAkhirBenar.text = pertanyaan + "\n\nPenbahasan:\n" + pembahasan;
        txtPembahasanPnlAkhirSalah.text = pertanyaan + "\n\nPenbahasan:\n" + pembahasan;


        if (!StaticKuis.jawabanFlag[nomorSoal])
        {
            string abjadPilganSalah = StaticKuis.jawaban[nomorSoal]; // jawaban pengguna yg salah untuk panel pembahasan salah
            string pilganSalah = StaticInfoKuis.pilgan[materi][nomorSoal][char.Parse(abjadPilganSalah) - 65];
            txtPilganSalahPnlAkhirSalah.text = pilganSalah;
            txtAbjadSalahPnlAkhirSalah.text = abjadPilganSalah;
            pnlPembahasanAkhirSlh.SetActive(true);
        }
        else
            pnlPembahasanAkhirBnr.SetActive(true);
        pnlPembahasan.SetActive(false);
    }

    public void TutupPembahasanSoal()
    {
        if (StaticKuis.jawabanFlag[StaticClass.quizNomor])
            pnlBenar.SetActive(true);
        else
            pnlSalah.SetActive(true);
    }

    public void PertanyaanSelanjutnya()
    {
        if (StaticClass.quizNomor == 9)
        {
            // foreach (TMPro.TextMeshProUGUI selanjutnya in txtPertanyaanSelanjutnya)
            // {
            //     selanjutnya.txt = 'Lihat Nilai';
            // }
            pnlPertanyaan.SetActive(false);
            pnlBenar.SetActive(false);
            pnlSalah.SetActive(false);
            pnlNilai.SetActive(true);
        }
        else
        {
            foreach (Button btn in buttonsPilihan)
                btn.image.sprite = StaticClass.pilganNormalSprite;

            StaticClass.quizNomor++;
            foreach (GameObject ct in contentsHeight)
                ct.GetComponent<RectTransform>().sizeDelta = new Vector2(0, StaticInfoKuis.height[StaticClass.quizCode][StaticClass.quizNomor]);
            foreach (TMPro.TextMeshProUGUI nmr in nomor)
                nmr.text = StaticClass.quizNomor + 1 + "/10";
            pertanyaan.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];

            for (int i = 0; i < 4; i++)
                pilganPertanyaan[i].text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][i];
        }
    }
    public void CekJawaban()
    {
        string jawaban = "X";
        foreach (Button btn in buttonsPilihan)
        {
            if (btn.image.sprite == StaticClass.pilganSelectedSprite)
            {
                jawaban = btn.name[3..];
                break;
            }
        }
        print("ini jawaban " + jawaban);
        StaticKuis.jawaban[StaticClass.quizNomor] = jawaban;
        pnlPertanyaan.SetActive(false);

        if (jawaban.Equals(StaticInfoKuis.jawabanKuis[StaticClass.quizCode][StaticClass.quizNomor]))
        {
            StaticKuis.jawabanFlag[StaticClass.quizNomor] = true;
            soalBenar.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];
            abjadBenar.text = jawaban;
            pilganBenar.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(jawaban) - 65];
            pnlBenar.SetActive(true);
        }
        else
        {
            StaticKuis.jawabanFlag[StaticClass.quizNomor] = false;
            soalSalah.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];
            abjadSalah.text = jawaban;
            abjadBenarPnlSalah.text = StaticInfoKuis.jawabanKuis[StaticClass.quizCode][StaticClass.quizNomor];
            pilganBenarPnlSalah.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(abjadBenarPnlSalah.text) - 65];
            pilganSalah.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(jawaban) - 65];
            pnlSalah.SetActive(true);
        }
        pembahasan.text = StaticInfoKuis.pembahasan[StaticClass.quizCode][StaticClass.quizNomor];
        PilihJawaban.SetActive(false);

        if (StaticClass.quizNomor == 9)
        {
            print(StaticKuis.jawaban);
            print(StaticKuis.jawabanFlag);

            int totalNilai = 0;
            foreach (bool flag in StaticKuis.jawabanFlag)
            {
                if (flag)
                    totalNilai++;
            }

            StaticKuis.nilai = totalNilai * 10;
            nilai.text = StaticKuis.nilai + "/100";

            for (int i = 0; i < 10; i++)
            {
                if (StaticKuis.jawabanFlag[i])
                    btnPembahasanAll[i].image.sprite = btnCorrect;
                else
                    btnPembahasanAll[i].image.sprite = btnWrong;
            }

            foreach (TMPro.TextMeshProUGUI selanjutnya in txtPertanyaanSelanjutnya)
                selanjutnya.text = "Lihat Nilai";
            StaticKuis.selesai = DateTime.Now;
            TimeSpan difference = (StaticKuis.selesai).Subtract(StaticKuis.mulai);
            StaticKuis.durasi = Convert.ToInt32(difference.TotalSeconds);
            StartCoroutine(insertDataToSupabase());
        }
    }

    public IEnumerator insertDataToSupabase()
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", PlayerPrefs.GetString("Nama"));
        form.AddField("materi", StaticClass.quizCode);
        form.AddField("nilai", StaticKuis.nilai);
        form.AddField("waktu_mulai", StaticKuis.mulai.ToString("yyyy-MM-dd HH:mm:ss") + "+00");
        form.AddField("waktu_selesai", StaticKuis.selesai.ToString("yyyy-MM-dd HH:mm:ss") + "+00");
        form.AddField("durasi", StaticKuis.durasi);
        for (int i = 0; i < 10; i++)
        {
            form.AddField("no_" + (i + 1), StaticKuis.jawabanFlag[i].ToString());
            form.AddField("jawaban_no_" + (i + 1), StaticKuis.jawaban[i]);
        }

        UnityWebRequest webRequest = UnityWebRequest.Post("https://rfifnkbwxbvvapcgpuzn.supabase.co/rest/v1/hasil_kuis", form);
        webRequest.SetRequestHeader("apikey", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJmaWZua2J3eGJ2dmFwY2dwdXpuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI3MTc0NzcsImV4cCI6MjAyODI5MzQ3N30.51_kdsYavU44NwNEgGyvGx96_7v9V7dR7Y0AsdnqIBg");

        // Send the request
        yield return webRequest.SendWebRequest();

        // Wait until the request is done
        while (!webRequest.isDone) { }

        Debug.Log("API response: " + webRequest.downloadHandler.text);

        // Clean up the request
        webRequest.Dispose();
    }
}

