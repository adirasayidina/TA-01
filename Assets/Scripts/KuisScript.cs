using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class KuisScript : MonoBehaviour
{
    public Button[] buttonsPilihan;
    public GameObject PilihJawaban;
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public Sprite btnCorrect;
    public Sprite btnWrong;
    [Tooltip("[Soal] Gambar buat soal")]
    public UnityEngine.UI.Image imageSoal;
    [Tooltip("[Soal] Gambar soal buat pembahasan benar")]
    public UnityEngine.UI.Image imageSoalPembahasanBenar;
    [Tooltip("[Soal] Gambar soal buat pembahasan salah")]
    public UnityEngine.UI.Image imageSoalPembahasanSalah;
    [Tooltip("[Pembahasan] Gambar buat pembahasan, ini beda sama gambar soal")]
    public UnityEngine.UI.Image imageSoalPembahasanContent;
    [Tooltip("[Soal] Gambar soal buat pembahasan akhir benar, ini gambar soal tapi buat yang di pembahasan akhir")]
    public UnityEngine.UI.Image imageSoalPembahasanAkhirBenar;
    [Tooltip("[Soal] Gambar soal buat pembahasan akhir salah, ini gambar soal tapi buat yang di pembahasan akhir")]
    public UnityEngine.UI.Image imageSoalPembahasanAkhirSalah;
    [Tooltip("[Pembahasan] Gambar pembahasan buat pembahasan akhir benar, sama kyk imageSoalPembahasanContent")]
    public UnityEngine.UI.Image imageSoalPembahasanAkhirBenarContent;
    [Tooltip("[Pembahasan] Gambar pembahasan buat pembahasan akhir salah, sama kyk imageSoalPembahasanContent")]
    public UnityEngine.UI.Image imageSoalPembahasanAkhirSalahContent;
    [SerializeField] private TMPro.TextMeshProUGUI pertanyaan;
    [SerializeField] private TMPro.TextMeshProUGUI soalBenar;
    [SerializeField] private TMPro.TextMeshProUGUI soalSalah;
    [SerializeField] private TMPro.TextMeshProUGUI pembahasan;

    [SerializeField] private TMPro.TextMeshProUGUI[] nomor;
    [SerializeField] private TMPro.TextMeshProUGUI[] pilganPertanyaan;
    [SerializeField] private TMPro.TextMeshProUGUI nilai;
    [SerializeField] private TMPro.TextMeshProUGUI durasiTotal;
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
    [SerializeField] private TMPro.TextMeshProUGUI[] txtDurasiPerSoal;

    public GameObject[] contentsHeight;
    public GameObject contentsPembHeight;
    public GameObject[] contentsPembHeight2;
    public ScrollRect[] scrollViewAll;
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
        setGambarSoal(imageSoal, pertanyaan, -355f, 50f, StaticInfoKuis.soalGambar[StaticClass.quizCode][StaticClass.quizNomor]);
        foreach (GameObject ct in contentsHeight)
            ct.GetComponent<RectTransform>().sizeDelta = new Vector2(0, StaticInfoKuis.height[StaticClass.quizCode][StaticClass.quizNomor]);
        for (int i = 0; i < 4; i++)
            pilganPertanyaan[i].text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][i];
    }

    public void initTime()
    {
        StaticKuis.mulai = DateTime.Now;
        StaticKuis.tempTime = DateTime.Now;
        StaticKuis.durasi_soal_saja = 0;
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
        int height = StaticInfoKuis.height["Pemb" + StaticClass.quizCode][nomorSoal];

        contentsPembHeight.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
        foreach (GameObject ct in contentsPembHeight2)
            ct.GetComponent<RectTransform>().sizeDelta = new Vector2(718, height);
        txtPilganBenarPnlAkhirBenar.text = pilganBenar;
        txtAbjadBenarPnlAkhirBenar.text = abjadPilganBenar;
        txtPilganBenarPnlAkhirSalah.text = pilganBenar;
        txtAbjadBenarPnlAkhirSalah.text = abjadPilganBenar;
        txtPembahasanPnlAkhirBenar.text = pertanyaan + "\n\nPembahasan:\n" + pembahasan;
        txtPembahasanPnlAkhirSalah.text = pertanyaan + "\n\nPembahasan:\n" + pembahasan;
        if (materi == "Otak" && (nomorSoal == 2 || nomorSoal == 4)) {
            txtPembahasanPnlAkhirBenar.text = pertanyaan + "\n\nA." + StaticInfoKuis.pilgan[materi][nomorSoal][0]+ "\nB." + StaticInfoKuis.pilgan[materi][nomorSoal][1] + "\nC." + StaticInfoKuis.pilgan[materi][nomorSoal][2] + "\nD." + StaticInfoKuis.pilgan[materi][nomorSoal][3] + "\n\nPembahasan:\n" + pembahasan;
            txtPembahasanPnlAkhirSalah.text = pertanyaan + "\n\nA." + StaticInfoKuis.pilgan[materi][nomorSoal][0]+ "\nB." + StaticInfoKuis.pilgan[materi][nomorSoal][1] + "\nC." + StaticInfoKuis.pilgan[materi][nomorSoal][2] + "\nD." + StaticInfoKuis.pilgan[materi][nomorSoal][3] + "\n\nPembahasan:\n" + pembahasan;
        }
        setGambarSoal(imageSoalPembahasanAkhirBenar, txtPembahasanPnlAkhirBenar, -425f, 0f, StaticInfoKuis.soalGambar[StaticClass.quizCode][nomorSoal]);
        setGambarSoal(imageSoalPembahasanAkhirSalah, txtPembahasanPnlAkhirSalah, -425f, 0f, StaticInfoKuis.soalGambar[StaticClass.quizCode][nomorSoal]);
        setGambarPembahasan(imageSoalPembahasanAkhirBenarContent, -height + 820, StaticInfoKuis.pembahasanGambar[StaticClass.quizCode][nomorSoal]);
        setGambarPembahasan(imageSoalPembahasanAkhirSalahContent, -height + 820, StaticInfoKuis.pembahasanGambar[StaticClass.quizCode][nomorSoal]);
        foreach (ScrollRect scr in scrollViewAll)
        {
            scr.verticalNormalizedPosition = 1f;
        }
        foreach (TMPro.TextMeshProUGUI durasiPerSoal in txtDurasiPerSoal)
        {
            durasiPerSoal.text = "Durasi pengerjaan: " + StaticKuis.durasi_per_soal[nomorSoal] + " detik";
        }

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
            pnlPertanyaan.SetActive(false);
            pnlBenar.SetActive(false);
            pnlSalah.SetActive(false);
            pnlNilai.SetActive(true);
        }
        else
        {
            StaticKuis.tempTime = DateTime.Now;
            foreach (Button btn in buttonsPilihan)
                btn.image.sprite = StaticClass.pilganNormalSprite;
            StaticClass.quizNomor++;
            setGambarSoal(imageSoal, pertanyaan, -355f, 50f, StaticInfoKuis.soalGambar[StaticClass.quizCode][StaticClass.quizNomor]);
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
        TimeSpan difference = (DateTime.Now).Subtract(StaticKuis.tempTime);
        StaticKuis.durasi_per_soal[StaticClass.quizNomor] = Convert.ToInt32(difference.TotalSeconds);

        foreach (ScrollRect scr in scrollViewAll)
            scr.verticalNormalizedPosition = 1f;
        
        if (jawaban.Equals(StaticInfoKuis.jawabanKuis[StaticClass.quizCode][StaticClass.quizNomor]))
        {
            StaticKuis.jawabanFlag[StaticClass.quizNomor] = true;
            soalBenar.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];
            abjadBenar.text = jawaban;
            pilganBenar.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(jawaban) - 65];
            setGambarSoal(imageSoalPembahasanBenar, soalBenar, -405f, 0f, StaticInfoKuis.soalGambar[StaticClass.quizCode][StaticClass.quizNomor]);
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
            setGambarSoal(imageSoalPembahasanSalah, soalSalah, -405f, 0f, StaticInfoKuis.soalGambar[StaticClass.quizCode][StaticClass.quizNomor]);
            pnlSalah.SetActive(true);
        }
        pembahasan.text = StaticInfoKuis.pembahasan[StaticClass.quizCode][StaticClass.quizNomor];
        // Sebenarnya set gambar pembahasan, tapi lebih relevan pake method ini
        setGambarSoal(imageSoalPembahasanContent, pembahasan, -605f, 0f, StaticInfoKuis.pembahasanGambar[StaticClass.quizCode][StaticClass.quizNomor]);
        contentsPembHeight.GetComponent<RectTransform>().sizeDelta = new Vector2(0, StaticInfoKuis.height["PembTengah" + StaticClass.quizCode][StaticClass.quizNomor]);
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
                StaticKuis.durasi_soal_saja += StaticKuis.durasi_per_soal[i];
                if (StaticKuis.jawabanFlag[i])
                    btnPembahasanAll[i].image.sprite = btnCorrect;
                else
                    btnPembahasanAll[i].image.sprite = btnWrong;
            }
            durasiTotal.text = "Durasi pengerjaan:\n" + StaticKuis.durasi_soal_saja + " detik";

            foreach (TMPro.TextMeshProUGUI selanjutnya in txtPertanyaanSelanjutnya)
                selanjutnya.text = "Lihat Nilai";
            StaticKuis.selesai = DateTime.Now;
            TimeSpan difference2 = (StaticKuis.selesai).Subtract(StaticKuis.mulai);
            StaticKuis.durasi_keseluruhan = Convert.ToInt32(difference2.TotalSeconds);
            StartCoroutine(insertDataToSupabase());
        }
    }

    private void setGambarSoal(UnityEngine.UI.Image img, TMPro.TextMeshProUGUI txt, float yPosImg, float yPosNoImg, string imgPath)
    {
        if (imgPath != null)
        {
            img.gameObject.SetActive(true);
            img.sprite = Resources.Load<Sprite>(imgPath);
            RectTransform rectTransform = txt.rectTransform;
            rectTransform.localPosition = new Vector3(0f, yPosImg, 0f);
        }
        else
        {
            img.gameObject.SetActive(false);
            RectTransform rectTransform = txt.rectTransform;
            rectTransform.localPosition = new Vector3(0f, yPosNoImg, 0f);
        }
    }

    private void setGambarPembahasan(UnityEngine.UI.Image img, float yPosImg, string imgPath)
    {
        print(imgPath);
        if (imgPath != null)
        {
            img.gameObject.SetActive(true);
            img.sprite = Resources.Load<Sprite>(imgPath);
            RectTransform rectTransform = img.rectTransform;
            rectTransform.localPosition = new Vector3(0f, yPosImg, 0f);
        }
        else
        {
            img.gameObject.SetActive(false);
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
        form.AddField("durasi_keseluruhan", StaticKuis.durasi_keseluruhan);
        for (int i = 0; i < 10; i++)
        {
            form.AddField("no_" + (i + 1), StaticKuis.jawabanFlag[i].ToString());
            form.AddField("jawaban_no_" + (i + 1), StaticKuis.jawaban[i]);
            form.AddField("durasi_no_" + (i + 1), StaticKuis.durasi_per_soal[i]);
        }
        form.AddField("durasi_soal_saja", StaticKuis.durasi_soal_saja);
        form.AddField("attempt_no", PlayerPrefs.GetInt("QuizAttempt" + StaticClass.quizCode));
        PlayerPrefs.SetInt("QuizAttempt" + StaticClass.quizCode, PlayerPrefs.GetInt("QuizAttempt" + StaticClass.quizCode) + 1);

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

