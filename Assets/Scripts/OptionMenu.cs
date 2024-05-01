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
            string[] jantung = { "C", "A", "D", "C", "A", "B", "A", "B", "D", "B" };

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
                "Pembuluh darah yang membawa darah yang tidak mengandung oksigen dari jantung ke paru-paru disebut…",
                "Nama bagian jantung yang ditunjuk adalah…",
                "Bagian jantung mana yang bertanggung jawab untuk memompa darah yang mengandung oksigen ke paru-paru?",
                "Vena besar yang membawa darah yang tidak mengandung oksigen dari bagian bawah tubuh kembali ke jantung adalah…",
                "Nama bagian jantung yang ditunjuk adalah…",
                "Bagian berikut merupakan bagian dari Aorta, kecuali…",
                "Darah yang mengalir melalui vena cava inferior berasal dari vena-vena berikut, kecuali…",
                "Bagian jantung mana yang bertanggung jawab untuk menerima darah yang mengandung oksigen dari paru-paru?",
                "Apa yang dibawa oleh vena cava superior?",
                "Nama bagian jantung yang ditunjuk adalah…"
            };

            StaticInfoKuis.soal.Add("Ginjal", soalGinjal);
            StaticInfoKuis.soal.Add("Otak", soalOtak);
            StaticInfoKuis.soal.Add("Jantung", soalJantung);

            string[] soalGambarGinjal = {
                null, // no 1
                null, // no 2
                null, // no 3
                null, // no 4
                null, // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                null, // no 10
            };
            string[] soalGambarOtak = {
                null, // no 1
                null, // no 2
                null, // no 3
                null, // no 4
                null, // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                null, // no 10
            };
            string[] soalGambarJantung = {
                null, // no 1
                "Jantung No 2", // no 2
                null, // no 3
                null, // no 4
                "Jantung No 5", // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                "Jantung No 10", // no 10
            };

            StaticInfoKuis.soalGambar.Add("Ginjal", soalGambarGinjal);
            StaticInfoKuis.soalGambar.Add("Otak", soalGambarOtak);
            StaticInfoKuis.soalGambar.Add("Jantung", soalGambarJantung);

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
                "Arteri pulmonalis adalah pembuluh darah yang membawa darah yang tidak mengandung oksigen dari jantung menuju paru-paru. Arteri pulmonalis merupakan satu-satunya arteri yang tidak mengandung oksigen pada tubuh manusia. Setelah mencapai paru-paru, darah melepaskan karbon dioksida dan mengambil oksigen, menjadi teroksigenasi sebelum kembali ke jantung melalui vena-vena paru-paru.",
                "Nama bagian jantung yang ditunjuk adalah arteri pulmonalis. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian jantung.",
                "Serambi kiri jantung bertanggung jawab menerima darah yang kaya oksigen dari paru-paru melalui vena pulmonalis dan memompanya ke bilik kiri untuk didistribusikan ke seluruh tubuh.\n\nBilik kiri jantung berperan dalam memompa darah kaya oksigen ke seluruh tubuh melalui aorta, sehingga memberikan oksigen dan nutrisi yang dibutuhkan oleh jaringan dan organ tubuh.\n\nSerambi kanan jantung menerima darah yang mengandung karbon dioksida dari seluruh tubuh melalui vena cava superior dan inferior, lalu memompanya ke bilik kanan untuk dipompa ke paru-paru untuk proses pertukaran gas.\n\nBilik kanan jantung bertugas memompa darah yang mengandung karbon dioksida ke paru-paru melalui arteri pulmonalis untuk dipenuhi kembali dengan oksigen dan melepaskan karbon dioksida melalui proses pernapasan.",
                "Vena cava inferior adalah vena besar yang membawa darah yang tidak mengandung oksigen dari bagian bawah tubuh kembali ke jantung. Vena cava inferior mengumpulkan darah dari bagian bawah tubuh, termasuk kaki, panggul, dan organ-organ dalam rongga perut, dan membawanya ke atrium kanan jantung. \nSedangkan vena besar yang membawa darah yang tidak mengandung oksigen dari bagian atas tubuh kembali ke jantung adalah vena cava superior. Vena ini menerima darah yang kembali dari kepala, lengan, dan bagian atas tubuh lainnya.",
                "Nama bagian jantung yang ditunjuk adalah serambi kanan. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian jantung.",
                "Aorta adalah arteri terbesar di tubuh manusia. Bagian-bagian utama aorta adalah ascending aorta, arkus aorta, dan descending aorta. Ascending aorta dimulai dari katup aorta ventrikel kiri dan memiliki panjang sekitar 5 cm. Ascending aorta bertanggung jawab membawa darah langsung dari jantung dan memberikan sirkulasi ke hampir seluruh jaringan tubuh. Arkus aorta (aortic arch) melengkung di atas jantung dan mengeluarkan cabang-cabang yang memasok darah ke kepala, leher, dan anggota tubuh bagian atas. Descending Aorta merupakan lanjutan dari arkus aorta yang berlanjut ke bawah melalui daerah dada dan perut dan akan memasok darah ke seluruh tubuh.",
                "Vena cava inferior adalah vena besar yang membawa darah yang tidak mengandung oksigen dari bagian bawah tubuh (perut, panggul, dan kaki) kembali ke serambi kanan jantung. Darah yang mengalir melalui vena cava inferior berasal dari berbagai vena di bagian bawah tubuh. Namun, vena subklavia tidak termasuk salah satunya.",
                "Bilik kiri jantung berperan dalam memompa darah kaya oksigen ke seluruh tubuh melalui aorta, sehingga memberikan oksigen dan nutrisi yang dibutuhkan oleh jaringan dan organ tubuh.\n\nSerambi kiri jantung bertanggung jawab menerima darah yang kaya oksigen dari paru-paru melalui vena pulmonalis dan memompanya ke bilik kiri untuk didistribusikan ke seluruh tubuh.\n\nBilik kanan jantung bertugas memompa darah yang mengandung karbon dioksida ke paru-paru melalui arteri pulmonalis untuk dipenuhi kembali dengan oksigen dan melepaskan karbon dioksida melalui proses pernapasan.\n\nSerambi kanan jantung menerima darah yang mengandung karbon dioksida dari seluruh tubuh melalui vena cava superior dan inferior, lalu memompanya ke bilik kanan untuk dipompa ke paru-paru untuk proses pertukaran gas.",
                "Vena cava superior adalah vena besar yang membawa darah yang mengandung oksigen dari tubuh bagian atas kembali ke jantung, tepatnya ke atrium kanan jantung. Darah yang mengalir melalui vena cava superior berasal dari bagian atas tubuh, seperti kepala, lengan, dan dada atas.",
                "Nama bagian jantung yang ditunjuk adalah vena pulmonalis. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian jantung."
            };

            StaticInfoKuis.pembahasan.Add("Ginjal", pembahasanGinjal);
            StaticInfoKuis.pembahasan.Add("Otak", pembahasanOtak);
            StaticInfoKuis.pembahasan.Add("Jantung", pembahasanJantung);
            
            string[] pembahasanGambarGinjal = {
                null, // no 1
                null, // no 2
                null, // no 3
                null, // no 4
                null, // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                null, // no 10
            };
            string[] pembahasanGambarOtak = {
                null, // no 1
                null, // no 2
                null, // no 3
                null, // no 4
                null, // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                null, // no 10
            };
            string[] pembahasanGambarJantung = {
                null, // no 1
                "Jantung Pembahasan", // no 2
                null, // no 3
                null, // no 4
                "Jantung Pembahasan", // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                "Jantung Pembahasan", // no 10
            };

            StaticInfoKuis.pembahasanGambar.Add("Ginjal", pembahasanGambarGinjal);
            StaticInfoKuis.pembahasanGambar.Add("Otak", pembahasanGambarOtak);
            StaticInfoKuis.pembahasanGambar.Add("Jantung", pembahasanGambarJantung);
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

        string[] jantung1 = { "Aorta", "Vena pulmonalis", "Arteri pulmonalis", "Vena cava superior" };
        string[] jantung2 = { "Arteri pulmonalis", "Vena pulmonalis", "Vena cava superior", "Vena cava inferior" };
        string[] jantung3 = { "Serambi Kiri", "Bilik Kiri", "Serambi Kanan", "Bilik Kanan" };
        string[] jantung4 = { "Vena cava superior", "Vena pulmonalis", "Vena cava inferior", "Arteri pulmonalis" };
        string[] jantung5 = { "Serambi kanan", "Serambi kiri", "Bilik kanan", "Bilik kiri" };
        string[] jantung6 = { "Descending Aorta", "Inferior Aorta", "Arkus Aorta", "Ascending Aorta" };
        string[] jantung7 = { "Vena subklavia", "Vena ginjal", "Vena adrenal", "Vena hepatik" };
        string[] jantung8 = { "Bilik Kiri", "Serambi Kiri", "Bilik Kanan", "Serambi Kanan" };
        string[] jantung9 = { "Darah kaya oksigen dari paru-paru", "Darah kaya oksigen dari aorta", "Darah mengandung oksigen dari tubuh bagian bawah", "Darah mengandung oksigen dari tubuh bagian atas" };
        string[] jantung10 = { "Arteri pulmonalis", "Vena pulmonalis", "Vena cava superior", "Vena cava inferior" };
        string[][] pilganJantung = { jantung1, jantung2, jantung3, jantung4, jantung5, jantung6, jantung7, jantung8, jantung9, jantung10 };

        StaticInfoKuis.pilgan.Add("Ginjal", pilganGinjal);
        StaticInfoKuis.pilgan.Add("Otak", pilganOtak);
        StaticInfoKuis.pilgan.Add("Jantung", pilganJantung);

        // height soal biasa
        // normal height = 540.8
        int[] heightGinjal = {738,540,540,540,540,540,540,540,540,540};
        int[] heightOtak = {540,540,540,540,540,540,653,617,1071,540};
        int[] heightJantung = {540,617,540,540,617,540,540,540,540,617};
        StaticInfoKuis.height.Add("Ginjal", heightGinjal);
        StaticInfoKuis.height.Add("Otak", heightOtak);
        StaticInfoKuis.height.Add("Jantung", heightJantung);

        // height pembahasan tengah (yang habis jawab soal)
        // normal height 1061
        int[] heightPembTengahGinjal = { 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061 };
        int[] heightPembTengahOtak = { 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061, 1061 };
        int[] heightPembTengahJantung = { 1061, 1061, 1321, 1061, 1061, 1061, 1061, 1321, 1061, 1061 };
        StaticInfoKuis.height.Add("PembTengahGinjal", heightPembTengahGinjal);
        StaticInfoKuis.height.Add("PembTengahOtak", heightPembTengahOtak);
        StaticInfoKuis.height.Add("PembTengahJantung", heightPembTengahJantung);

        // height pembahasan akhir (pertanyaan+pembahasan)
        // normal height 657 (yg pnl salah, ambil min)
        int[] heightPembGinjal = {657,657,657,657,657,657,657,657,657,657};
        int[] heightPembOtak = {657,657,657,657,657,657,657,657,657,657};
        int[] heightPembJantung = {757,1390,1457,990,1390,990,657,1457,657,1390};
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
