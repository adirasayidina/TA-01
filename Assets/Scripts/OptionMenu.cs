using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (StaticInfoKuis.jawabanKuis.Count < 1)
        {
            string[] ginjal = { "C", "C", "B", "A", "A", "D", "A", "C", "D", "A" };
            string[] otak = { "C", "B", "D", "D", "C", "A", "C", "A", "C", "B" };
            string[] jantung = { "A", "C", "D", "A", "B", "C", "A", "C", "D", "A" };

            StaticInfoKuis.jawabanKuis.Add("Ginjal", ginjal);
            StaticInfoKuis.jawabanKuis.Add("Otak", otak);
            StaticInfoKuis.jawabanKuis.Add("Jantung", jantung);

            string[] soalGinjal = {
                "Berikut pernyataan mengenai ginjal\n\nA. Membantu menjaga keseimbangan bahan kimia (seperti natrium, kalium, dan kalsium) dalam tubuh.\nB. Menyaring limbah dan air berlebih pada darah dan berfungsi sebagai tempat penyimpanan urin sebelum dikeluarkan dari tubuh\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Pembuluh/saluran yang berfungsi untuk menyalurkan urin ke kandung kemih adalah",
                "Pembuluh darah yang membawa darah yang akan disaring menuju ginjal adalah",
                "Jumlah nefron pada setiap ginjal adalah",
                "Berikut pernyataan mengenai nefron\n\nA. Terletak mulai dari korteks hingga medula\nB. Unit penyaringan pada nefron adalah glomerulus\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Bagian ginjal yang berfungsi untuk mengatur konsentrasi urin adalah",
                "Fungsi dari lengkung henle adalah",
                "soal 8",
                "soal 9",
                "soal 10"
            };
            string[] soalOtak = {
                "Bagian otak yang menghubungkan hemisfer kiri dan hemisfer kanan disebut…",
                "Berikut fungsi dari lobus oksipital,",
                "Bagian otak ini terletak pada bagian bawah otak, di bawah lobus parietal dan bagian belakang lobus frontal.",
                "Berikut fungsi dari lobus parietal,",
                "Salah satu fungsi bagian otak ini adalah mengolah informasi visual (optik) yang tiba di kedua belahan otak menjadi visual dalam satu kesatuan.",
                "Bagian dari otak besar yang paling rawan mengalami cedera otak traumatis adalah",
                "Berikut pernyataan mengenai lobus frontal\n\nA. Lobus frontal merupakan bagian otak besar yang memiliki ukuran paling besar.\nB. Lobus frontal berfungsi untuk mengendalikan fungsi intelektual, tetapi tidak untuk mengendalikan kepribadian.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Berikut pernyataan mengenai lobus parietal\n\nA. Berfungsi untuk merasakan suhu dan pengartikulasian emosi serta pikiran.\nB. Pada lobus parietal terdapat area sensorik penting yang disebut girus postsentralis.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Berikut pernyataan tentang otak\n\nA. Otak besar adalah bagian terbesar dari otak dan mengontrol pemikiran, pembelajaran, pemecahan masalah, emosi, memori, ucapan, membaca, menulis, dan gerakan sukarela.\nB. Otak kecil mengontrol gerakan motorik halus, keseimbangan, dan postur. otak kecil menghubungkan otak dengan sumsum tulang belakang karena terletak di belakang otak.\nC. Batang otak mengontrol pernapasan, detak jantung, serta saraf dan otot yang digunakan untuk melihat, mendengar, berjalan, berbicara, dan makan.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "soal 10"
            };
            string[] soalJantung = {
                "soal pendek 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor.",
                "soal 3",
                "soal 4",
                "soal 5",
                "soal 6",
                "soal 7",
                "soal 8",
                "soal 9",
                "soal 10"
            };

            StaticInfoKuis.soal.Add("Ginjal", soalGinjal);
            StaticInfoKuis.soal.Add("Otak", soalOtak);
            StaticInfoKuis.soal.Add("Jantung", soalJantung);

            string[] pembahasanGinjal = {
                "pembahasan pendek 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor.",
                "pembahasan 3",
                "pembahasan 4",
                "pembahasan 5",
                "pembahasan 6",
                "pembahasan 7",
                "pembahasan 8",
                "pembahasan 9",
                "pembahasan 10"
            };
            string[] pembahasanOtak = {
                "pembahasan pendek 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor.",
                "pembahasan 3",
                "pembahasan 4",
                "pembahasan 5",
                "pembahasan 6",
                "pembahasan 7",
                "pembahasan 8",
                "pembahasan 9",
                "pembahasan 10"
            };
            string[] pembahasanJantung = {
                "pembahasan pendek 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor.",
                "pembahasan 3",
                "pembahasan 4",
                "pembahasan 5",
                "pembahasan 6",
                "pembahasan 7",
                "pembahasan 8",
                "pembahasan 9",
                "pembahasan 10"
            };

            StaticInfoKuis.pembahasan.Add("Ginjal", pembahasanGinjal);
            StaticInfoKuis.pembahasan.Add("Otak", pembahasanOtak);
            StaticInfoKuis.pembahasan.Add("Jantung", pembahasanJantung);
        }

        string[] ginjal1 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] ginjal2 = { "Vena ginjal", "Arteri ginjal", "Ureter", "Uretra" };
        string[] ginjal3 = { "Vena ginjal", "Arteri ginjal", "Ureter", "Uretra" };
        string[] ginjal4 = { "1 juta", "Milyaran", "10 juta", "2 juta" };
        string[] ginjal5 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] ginjal6 = { "Ureter", "Korteks", "Nefron", "Medula" };
        string[] ginjal7 = { "Reabsorpsi", "Penyaluran urine ke ginjal", "Menampung urine", "Penyaluran urine dari ginjal" };
        string[] ginjal8 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] ginjal9 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] ginjal10 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[][] pilganGinjal = { ginjal1, ginjal2, ginjal3, ginjal4, ginjal5, ginjal6, ginjal7, ginjal8, ginjal9, ginjal10 };

        string[] otak1 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak2 = { "Menyimpan memori visual", "Memproses pengenalan wajah", "Menyatukan input visual pada kedua hemisfer", "Semua benar" };
        string[] otak3 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak4 = { "Mengendalikan rasa sentuhan", "Merasakan tekstur", "Merasakan suhu", "Semua benar" };
        string[] otak5 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak6 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak7 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] otak8 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] otak9 = { "A, B, dan C benar", "A dan B benar, C salah", "A dan C benar, B salah", "B dan C benar, A salah" };
        string[] otak10 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[][] pilganOtak = { otak1, otak2, otak3, otak4, otak5, otak6, otak7, otak8, otak9, otak10 };

        string[] jantung1 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung2 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung3 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung4 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung5 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung6 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung7 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung8 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung9 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[] jantung10 = { "pilganA", "pilganB", "pilganC", "pilganD" };
        string[][] pilganJantung = { jantung1, jantung2, jantung3, jantung4, jantung5, jantung6, jantung7, jantung8, jantung9, jantung10 };

        StaticInfoKuis.pilgan.Add("Ginjal", pilganGinjal);
        StaticInfoKuis.pilgan.Add("Otak", pilganOtak);
        StaticInfoKuis.pilgan.Add("Jantung", pilganJantung);

        // height soal biasa
        // normal height = 556.88
        int[] heightGinjal = {738,557,557,557,557,557,557,557,557,557};
        int[] heightOtak = {557,557,557,557,557,557,653,617,1071,557};
        int[] heightJantung = {557,557,557,557,557,557,557,557,557,557};
        StaticInfoKuis.height.Add("Ginjal", heightGinjal);
        StaticInfoKuis.height.Add("Otak", heightOtak);
        StaticInfoKuis.height.Add("Jantung", heightJantung);

        // height pembahasan akhir (pertanyaan+pembahasan)
        // normal height 657 (yg pnl salah, ambil min)
        int[] heightPembGinjal = {657,657,657,657,657,657,657,657,657,657};
        int[] heightPembOtak = {657,657,657,657,657,657,657,657,657,657};
        int[] heightPembJantung = {657,657,657,657,657,657,657,657,657,657};
        StaticInfoKuis.height.Add("PembGinjal", heightPembGinjal);
        StaticInfoKuis.height.Add("PembOtak", heightPembOtak);
        StaticInfoKuis.height.Add("PembJantung", heightPembJantung);
    }
    public void ObjectMenu(int codeScene)
    {
        if (codeScene == 0)
        {
            StaticClass.quizCode = "Ginjal";
            SceneManager.LoadScene("ArGinjal");
        }
        else if (codeScene == 1)
        {
            StaticClass.quizCode = "Otak";
            SceneManager.LoadScene("ArOtak");
        }
        else if (codeScene == 2)
        {
            StaticClass.quizCode = "Jantung";
            SceneManager.LoadScene("ArJantung");
        }
    }

    public void KembaliKeAR()
    {
        if (StaticClass.quizCode == "Ginjal")
        {
            SceneManager.LoadScene("ArGinjal");
        }
        else if (StaticClass.quizCode == "Otak")
        {
            SceneManager.LoadScene("ArOtak");
        }
        else if (StaticClass.quizCode == "Jantung")
        {
            SceneManager.LoadScene("ArJantung");
        }
    }

    public void QuizMenu(int codeScene)
    {
        // print(codeScene);
        // if (codeScene == 0)
        // {
        //     StaticClass.quizCode = "Ginjal";
        // }
        // else if (codeScene == 1)
        // {
        //     StaticClass.quizCode = "Jantung";
        // }
        // else
        // {
        //     StaticClass.quizCode = "Otak";
        // }
        SceneManager.LoadScene("Quiz");
    }

    public void TutorialMenu()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
