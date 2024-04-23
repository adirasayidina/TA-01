using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private TMPro.TextMeshProUGUI pilganSalah;
    [SerializeField] private TMPro.TextMeshProUGUI pilganBenar;
    [SerializeField] private TMPro.TextMeshProUGUI jawabanBenar;
    [SerializeField] private TMPro.TextMeshProUGUI pilganBenarPnlSalah;
    [SerializeField] private TMPro.TextMeshProUGUI jawabanBenarPnlSalah;
    [SerializeField] private TMPro.TextMeshProUGUI jawabanSalah;
    [SerializeField] private TMPro.TextMeshProUGUI judulKuis;
    [SerializeField] private TMPro.TextMeshProUGUI infoQuizMateri;
    public Button[] btnPembahasanAll;
    public GameObject pnlBenar;
    public GameObject pnlSalah;
    public GameObject pnlPertanyaan;
    public GameObject pnlNilai;
    public GameObject btnLihatHasilBenar;
    public GameObject btnLihatHasilSalah;

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
        for (int i = 0; i < 4; i++)
        {
            print("test masuk");
            pilganPertanyaan[i].text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][i];
        }
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

        txtPilganBenarPnlAkhirBenar.text = pilganBenar;
        txtPilganBenarPnlAkhirSalah.text = pilganBenar;
        txtPembahasanPnlAkhirBenar.text = pembahasan;
        txtPembahasanPnlAkhirSalah.text = pembahasan;

        if (!StaticKuis.jawabanFlag[nomorSoal])
        {
            string abjadPilganSalah = StaticKuis.jawaban[nomorSoal]; // jawaban pengguna yg salah untuk panel pembahasan salah
            string pilganSalah = StaticInfoKuis.pilgan[materi][nomorSoal][char.Parse(abjadPilganSalah) - 65];
            txtPilganSalahPnlAkhirSalah.text = pilganSalah;
            txtAbjadSalahPnlAkhirSalah.text = abjadPilganSalah;
            pnlPembahasanAkhirSlh.SetActive(true);
        }
        else
        {
            pnlPembahasanAkhirBnr.SetActive(true);
        }
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
            print(StaticKuis.jawaban);
            print(StaticKuis.jawabanFlag);

            int totalNilai = 0;
            foreach (bool flag in StaticKuis.jawabanFlag)
            {
                if (flag)
                    totalNilai++;

            }

            nilai.text = (totalNilai * 10) + "/100";

            for (int i = 0; i < 10; i++)
            {
                if (StaticKuis.jawabanFlag[i])
                {
                    btnPembahasanAll[i].image.sprite = btnCorrect;
                }
                else
                {
                    btnPembahasanAll[i].image.sprite = btnWrong;
                }
            }

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
            foreach (TMPro.TextMeshProUGUI nmr in nomor)
            {
                nmr.text = StaticClass.quizNomor + 1 + "/10";
            }
            pertanyaan.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];

            for (int i = 0; i < 4; i++)
            {
                pilganPertanyaan[i].text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][i];
            }
        }
    }
    public void CekJawaban()
    {

        if (StaticClass.quizNomor == 9)
        {
            btnLihatHasilBenar.SetActive(true);
            btnLihatHasilSalah.SetActive(true);
        }
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
            pilganBenar.text = jawaban;
            jawabanBenar.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(jawaban) - 65];
            pnlBenar.SetActive(true);
        }
        else
        {
            StaticKuis.jawabanFlag[StaticClass.quizNomor] = false;
            soalSalah.text = StaticInfoKuis.soal[StaticClass.quizCode][StaticClass.quizNomor];
            pilganSalah.text = jawaban;
            pilganBenarPnlSalah.text = StaticInfoKuis.jawabanKuis[StaticClass.quizCode][StaticClass.quizNomor];
            jawabanBenarPnlSalah.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(pilganBenarPnlSalah.text) - 65];
            jawabanSalah.text = StaticInfoKuis.pilgan[StaticClass.quizCode][StaticClass.quizNomor][char.Parse(jawaban) - 65];
            pnlSalah.SetActive(true);
        }
        pembahasan.text = StaticInfoKuis.pembahasan[StaticClass.quizCode][StaticClass.quizNomor];
        PilihJawaban.SetActive(false);
    }
}

