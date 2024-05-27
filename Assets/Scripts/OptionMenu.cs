using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UI.Image;
using UnityEngine.XR.ARFoundation;

public class OptionMenu : MonoBehaviour
{

    public GameObject Menu;
    public GameObject PanelInputKode;
    public GameObject SalahKode;
    public GameObject BtnMulai;
    public InputField InputKode;
    public Image imgMateri;
    public Sprite imgOtak;
    public Sprite imgJantung;
    public GameObject PanelStart;
    [SerializeField] private TMPro.TextMeshProUGUI txtJudulMateri;

    [SerializeField]
    private ARSession _arSession;

    [SerializeField] private TMPro.TextMeshProUGUI nama;

    void Start()
    {
        nama.text = "Halo, "+ PlayerPrefs.GetString("Nama")  + "!\nYuk belajar anatomi!";
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (StaticInfoKuis.jawabanKuis.Count < 1)
        {
            string[] ginjal = { "C", "D", "C", "B", "B", "A", "A", "A", "D", "B" };
            string[] otak = { "C", "A", "B", "D", "D", "C", "C", "A", "A", "C" };
            string[] jantung = { "C", "A", "D", "C", "A", "B", "A", "B", "D", "B" };

            StaticInfoKuis.jawabanKuis.Add("Ginjal", ginjal);
            StaticInfoKuis.jawabanKuis.Add("Otak", otak);
            StaticInfoKuis.jawabanKuis.Add("Jantung", jantung);

            string[] soalGinjal = {
                "Berikut pernyataan mengenai ginjal\n\nA. Membantu menjaga keseimbangan bahan kimia (seperti natrium, kalium, dan kalsium) dalam tubuh.\nB. Menyaring limbah dan air berlebih pada darah dan berfungsi sebagai tempat penyimpanan urine yang nantinya akan langsung dikeluarkan dari tubuh\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Nama bagian ginjal yang ditunjuk adalah...",
                "Pembuluh/saluran yang berfungsi untuk menyalurkan urin ke kandung kemih adalah...",
                "Pembuluh darah yang membawa darah yang akan disaring menuju ginjal adalah...",
                "Fungsi bagian ginjal yang ditunjuk adalah...",
                "Jumlah nefron pada setiap ginjal adalah...",
                "Fungsi dari lengkung henle adalah...",
                "Berikut pernyataan mengenai nefron\n\nA. Terletak mulai dari korteks hingga medula\nB. Unit penyaringan pada nefron adalah glomerulus\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Bagian ginjal yang berfungsi untuk mengatur konsentrasi urin adalah...",
                "Nama bagian ginjal yang ditunjuk adalah..."
            };
            string[] soalOtak = {
                "Bagian otak yang menghubungkan hemisfer kiri dan hemisfer kanan disebut...",
                "Nama bagian otak besar yang ditunjuk adalah...",
                "Berikut fungsi dari lobus oksipital,",
                "Bagian otak ini terletak pada bagian bawah otak, di bawah lobus parietal dan bagian belakang lobus frontal.",
                "Berikut fungsi dari lobus parietal,",
                "Salah satu fungsi bagian otak ini adalah mengolah informasi visual (optik) yang tiba di kedua belahan otak menjadi visual dalam satu kesatuan.",
                "Berikut pernyataan mengenai lobus frontal\n\nA. Lobus frontal merupakan bagian otak besar yang memiliki ukuran paling besar.\nB. Lobus frontal berfungsi untuk mengendalikan fungsi intelektual, tetapi tidak untuk mengendalikan kepribadian.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Bagian dari otak besar yang paling rawan mengalami cedera otak traumatis adalah...",
                "Berikut pernyataan mengenai lobus parietal\n\nA. Berfungsi untuk merasakan suhu dan pengartikulasian emosi serta pikiran.\nB. Pada lobus parietal terdapat area sensorik penting yang disebut girus postsentralis.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
                "Berikut pernyataan tentang otak\n\nA. Otak besar adalah bagian terbesar dari otak dan mengontrol pemikiran, pembelajaran, pemecahan masalah, emosi, memori, ucapan, membaca, menulis, dan gerakan sukarela.\nB. Otak kecil mengontrol gerakan motorik halus, keseimbangan, dan postur. otak kecil menghubungkan otak dengan sumsum tulang belakang karena terletak di belakang otak.\nC. Batang otak mengontrol pernapasan, detak jantung, serta saraf dan otot yang digunakan untuk melihat, mendengar, berjalan, berbicara, dan makan.\n\nPilih jawaban yang sesuai dengan pernyataan di atas.",
            };
            string[] soalJantung = {
                "Pembuluh darah yang membawa darah yang tidak mengandung oksigen dari jantung ke paru-paru disebut...",
                "Nama bagian jantung yang ditunjuk adalah...",
                "Bagian jantung mana yang bertanggung jawab untuk memompa darah yang mengandung karbon dioksida ke paru-paru?",
                "Vena besar yang membawa darah yang tidak mengandung oksigen dari bagian bawah tubuh kembali ke jantung adalah...",
                "Nama bagian jantung yang ditunjuk adalah...",
                "Bagian berikut merupakan bagian dari Aorta, kecuali...",
                "Darah yang mengalir melalui vena cava inferior berasal dari vena-vena berikut, kecuali...",
                "Bagian jantung mana yang bertanggung jawab untuk menerima darah yang mengandung oksigen dari paru-paru?",
                "Apa yang dibawa oleh vena cava superior?",
                "Nama bagian jantung yang ditunjuk adalah..."
            };

            StaticInfoKuis.soal.Add("Ginjal", soalGinjal);
            StaticInfoKuis.soal.Add("Otak", soalOtak);
            StaticInfoKuis.soal.Add("Jantung", soalJantung);

            string[] soalGambarGinjal = {
                null, // no 1
                "GinjalSoal1", // no 2
                null, // no 3
                null, // no 4
                "GinjalSoal3", // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                "GinjalSoal2", // no 10
            };
            string[] soalGambarOtak = {
                null, // no 1
                "OtakSoal", // no 2
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
                "Fungsi dari ginjal adalah membantu menjaga keseimbangan bahan kimia (seperti natrium, kalium, dan kalsium) dalam tubuh dengan menyaring limbah dan air berlebih pada darah yang nantinya akan disalurkan melalui ureter menuju kandung kemih yang akan menampung urine sebelum dikeluarkan dari tubuh.\n\nGinjal akan menampung urine untuk disalurkan ke kandung kemih",
                "Nama bagian ginjal yang ditunjuk adalah medula. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian ginjal.",
                "Ureter berfungsi untuk menyalurkan urin ke kandung kemih.\n\nSedangkan, vena ginjal berfungsi untuk membawa darah dari ginjal dan ureter ke vena cava inferior, arteri ginjal berfungsi untuk membawa darah yang akan disaring menuju ginjal, dan uretra merupakan saluran pada kandung kemih untuk mengeluarkan urine dari tubuh.",
                "Arteri ginjal berfungsi untuk membawa darah yang akan disaring menuju ginjal.\n\nSedangkan vena ginjal berfungsi untuk membawa darah dari ginjal dan ureter ke vena cava inferior, ureter berfungsi untuk menyalurkan urin ke kandung kemih, dan uretra merupakan saluran pada kandung kemih untuk mengeluarkan urine dari tubuh.",
                "Nama bagian ginjal yang ditunjuk adalah korteks yang berfungsi untuk mengelilingi dan melindungi organ ginjal dan melakukan penyaringan darah (menyaring cairan berlebih dari darah) yang disebut ultrafiltrasi. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian ginjal.",
                "Dalam satu ginjal terdapat kurang lebih sebanyak satu juta nefron yang berfungsi untuk penyaringan darah.",
                "Lengkung henle yang berada pada medula memiliki fungsi untuk melakukan reabsorpsi atau proses penyerapan kembali air dan natrium klorida dari cairan urine.",
                "Nefron sebagai organ yang melakukan penyaringan darah terletak dari nefron hingga medula dan memiliki glomerulus sebagai unit penyaringan darah.",
                "Fungsi utama medula adalah mengatur konsentrasi urin dengan cara melakukan reabsorpsi atau proses penyerapan kembali air dan natrium klorida dari cairan urine yang dilakukan oleh lengkung henle yang ada pada medula.",
                "Nama bagian ginjal yang ditunjuk adalah arteri ginjal. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian ginjal."
            };
            string[] pembahasanOtak = {
                "Fungsi dari corpus callosum adalah bertindak sebagai jalur utama untuk menghubungkan hemisfer kiri dan hemisfer kanan.\n\nCorpus callosum mentransfer informasi dari satu hemisfer ke hemisfer lainnya dengan menghubungkan lobus frontal, parietal, dan oksipital dari kedua hemisfer.",
                "Nama bagian otak besar yang ditunjuk adalah lobus frontal. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian otak besar.",
                "Lobus oksipital berfungsi mengendalikan input visual dan prosesnya. Proses visual meliputi warna, ukuran, jarak, kedalaman, bentuk, dan pengenalan wajah dengan menghubungkan gambar visual dengan dan rangsangan sensorik lainnya (seperti sentuhan dan pendengaran).\n\nLobus oksipital juga mengintegrasikan gerakan mata dengan mengarahkan dan memfokuskan mata.",
                "Lobus temporal terletak pada bagian bawah otak, di bawah lobus parietal dan bagian belakang lobus frontal. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian otak besar.",
                "Lobus parietal (parietal lobe) berfungsi mengendalikan sensasi, seperti sentuhan, tekanan, rasa sakit, suhu, dan tekstur.\n\nSelain itu, lobus parietal juga berfungsi dalam memahami pembicaraan dan mengartikulasikan pikiran dan emosi.\n\nLobus parietal juga menginterpretasikan tekstur saat objek tersebut dipegang.",
                "Fungsi dari corpus callosum adalah bertindak sebagai jalur utama untuk menghubungkan hemisfer kiri dan hemisfer kanan.\n\nCorpus callosum mentransfer informasi dari satu hemisfer ke hemisfer lainnya dengan menghubungkan lobus frontal, parietal, dan oksipital dari kedua hemisfer.\n\nContoh dari tugas corpus callosum adalah mengolah informasi visual (optik) yang tiba di kedua belahan otak menjadi visual dalam satu kesatuan.",
                "Lobus frontal adalah lobus terbesar di otak manusia yang memiliki fungsi untuk mengendalikan kontrol motorik yang tepat (gerakan terencana, gerakan mata), ucapan ekspresif, perilaku, memori, emosi, kepribadian, dan berperan dalam fungsi intelektual (proses berpikir, penalaran, pemecahan masalah yang kompleks, pengambilan keputusan, penilaian, dan perencanaan).\n\nSelain itu, lobus frontal memulai impuls motorik volunter untuk pergerakan otot rangka, menganalisis pengalaman sensorik, dan memberikan respons yang berkaitan dengan kepribadian.",
                "Lobus frontal adalah lobus terbesar di otak manusia dan juga merupakan wilayah yang paling umum menyebabkan cedera otak traumatis.",
                "Lobus parietal (parietal lobe) berfungsi mengendalikan sensasi, seperti sentuhan, tekanan, rasa sakit, suhu, dan tekstur.\n\nPada lobus parietal terdapat area sensorik penting yang disebut girus postsentralis.\n\nGirus postsentralis akan memberikan respon rangsangan dari reseptor kulit dan otot di seluruh tubuh.\n\nSelain itu, lobus parietal juga berfungsi dalam memahami pembicaraan dan mengartikulasikan pikiran dan emosi.\n\nLobus parietal juga menginterpretasikan tekstur saat objek tersebut dipegang.",
                "Otak terdiri dari tiga bagian utama: otak besar, otak kecil, dan batang otak.\n\nOtak besar adalah bagian terbesar dari otak dan mengontrol pemikiran, pembelajaran, pemecahan masalah, emosi, memori, ucapan, membaca, menulis, dan gerakan sukarela.\n\nOtak kecil mengontrol gerakan motorik halus, keseimbangan, dan postur.\n\nBatang otak mengontrol pernapasan, detak jantung, serta saraf dan otot yang digunakan untuk melihat, mendengar, berjalan, berbicara, dan makan. Batang otak menghubungkan otak dengan sumsum tulang belakang. Otak dan sumsum tulang belakang membentuk sistem saraf pusat."
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
                "Vena cava superior adalah vena besar yang membawa darah yang tidak mengandung oksigen dari tubuh bagian atas kembali ke jantung, tepatnya ke atrium kanan jantung. Darah yang mengalir melalui vena cava superior berasal dari bagian atas tubuh, seperti kepala, lengan, dan dada atas.",
                "Nama bagian jantung yang ditunjuk adalah vena pulmonalis. Kamu dapat mengacu pada gambar berikut untuk mempelajari kembali bagian-bagian jantung."
            };

            StaticInfoKuis.pembahasan.Add("Ginjal", pembahasanGinjal);
            StaticInfoKuis.pembahasan.Add("Otak", pembahasanOtak);
            StaticInfoKuis.pembahasan.Add("Jantung", pembahasanJantung);

            string[] pembahasanGambarGinjal = {
                null, // no 1
                "GinjalPemb", // no 2
                null, // no 3
                null, // no 4
                "GinjalPemb", // no 5
                null, // no 6
                null, // no 7
                null, // no 8
                null, // no 9
                "GinjalPemb", // no 10
            };
            string[] pembahasanGambarOtak = {
                null, // no 1
                "OtakPemb", // no 2
                null, // no 3
                "OtakPemb", // no 4
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
        string[] ginjal2 = { "Ureter", "Korteks", "Vena ginjal", "Medula" };
        string[] ginjal3 = { "Vena ginjal", "Arteri ginjal", "Ureter", "Uretra" };
        string[] ginjal4 = { "Vena ginjal", "Arteri ginjal", "Ureter", "Uretra" };
        string[] ginjal5 = { "Tempat penyimpanan urine", "Ultrafiltrasi", "Reabsorpsi", "Penyaluran urine dari ginjal ke vena cava" };
        string[] ginjal6 = { "1 juta", "Milyaran", "10 juta", "2 juta" };
        string[] ginjal7 = { "Reabsorpsi", "Penyaluran urine ke ginjal", "Menampung urine", "Penyaluran urine dari ginjal" };
        string[] ginjal8 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] ginjal9 = { "Ureter", "Korteks", "Nefron", "Medula" };
        string[] ginjal10 = { "Ureter", "Arteri ginjal", "Vena ginjal", "Medula" };
        string[][] pilganGinjal = { ginjal1, ginjal2, ginjal3, ginjal4, ginjal5, ginjal6, ginjal7, ginjal8, ginjal9, ginjal10 };

        string[] otak1 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak2 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak3 = { "Menyimpan memori visual", "Memproses pengenalan wajah", "Menyatukan input visual pada kedua hemisfer", "Semua benar" };
        string[] otak4 = { "Hemisfer", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak5 = { "Mengendalikan rasa sentuhan", "Merasakan tekstur", "Merasakan suhu", "Semua benar" };
        string[] otak6 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak7 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] otak8 = { "Lobus frontal", "Lobus oksipital", "Corpus callosum", "Lobus temporal" };
        string[] otak9 = { "A dan B benar", "A salah, B benar", "A benar, B salah", "A dan B salah" };
        string[] otak10 = { "A, B, dan C benar", "A dan B benar, C salah", "A dan C benar, B salah", "B dan C benar, A salah" };
        string[][] pilganOtak = { otak1, otak2, otak3, otak4, otak5, otak6, otak7, otak8, otak9, otak10 };

        string[] jantung1 = { "Aorta", "Vena pulmonalis", "Arteri pulmonalis", "Vena cava superior" };
        string[] jantung2 = { "Arteri pulmonalis", "Vena pulmonalis", "Vena cava superior", "Vena cava inferior" };
        string[] jantung3 = { "Serambi Kiri", "Bilik Kiri", "Serambi Kanan", "Bilik Kanan" };
        string[] jantung4 = { "Vena cava superior", "Vena pulmonalis", "Vena cava inferior", "Arteri pulmonalis" };
        string[] jantung5 = { "Serambi kanan", "Serambi kiri", "Bilik kanan", "Bilik kiri" };
        string[] jantung6 = { "Descending Aorta", "Inferior Aorta", "Arkus Aorta", "Ascending Aorta" };
        string[] jantung7 = { "Vena subklavia", "Vena ginjal", "Vena adrenal", "Vena hepatik" };
        string[] jantung8 = { "Bilik Kiri", "Serambi Kiri", "Bilik Kanan", "Serambi Kanan" };
        string[] jantung9 = { "Darah kaya oksigen dari paru-paru", "Darah kaya oksigen dari aorta", "Darah mengandung CO2 dari tubuh bagian bawah", "Darah mengandung CO2 dari tubuh bagian atas" };
        string[] jantung10 = { "Arteri pulmonalis", "Vena pulmonalis", "Vena cava superior", "Vena cava inferior" };
        string[][] pilganJantung = { jantung1, jantung2, jantung3, jantung4, jantung5, jantung6, jantung7, jantung8, jantung9, jantung10 };

        StaticInfoKuis.pilgan.Add("Ginjal", pilganGinjal);
        StaticInfoKuis.pilgan.Add("Otak", pilganOtak);
        StaticInfoKuis.pilgan.Add("Jantung", pilganJantung);

        // height soal biasa
        // normal height = 540.8
        int[] heightGinjal = { 800, 610, 540, 540, 610, 540, 540, 540, 540, 610 };
        int[] heightOtak = { 540, 590, 540, 540, 540, 540, 693, 540, 767, 1271 };
        int[] heightJantung = { 540, 617, 540, 540, 617, 540, 540, 540, 540, 617 };
        StaticInfoKuis.height.Add("Ginjal", heightGinjal);
        StaticInfoKuis.height.Add("Otak", heightOtak);
        StaticInfoKuis.height.Add("Jantung", heightJantung);

        // height pembahasan tengah (yang habis jawab soal)
        // normal height 1061
        int[] heightPembTengahGinjal = { 1061, 1061, 1061, 1061, 1161, 1061, 1061, 1061, 1061, 1061 };
        int[] heightPembTengahOtak = { 1061, 1061, 1011, 1061, 1011, 1061, 1061, 1061, 1161, 1251 };
        int[] heightPembTengahJantung = { 1061, 1061, 1621, 1061, 1061, 1161, 1061, 1621, 1061, 1061 };
        StaticInfoKuis.height.Add("PembTengahGinjal", heightPembTengahGinjal);
        StaticInfoKuis.height.Add("PembTengahOtak", heightPembTengahOtak);
        StaticInfoKuis.height.Add("PembTengahJantung", heightPembTengahJantung);

        // height pembahasan akhir (pertanyaan+pembahasan)
        // normal height 656 (yg pnl salah, ambil min)
        int[] heightPembGinjal = { 1404, 1420, 787, 787, 1700, 656, 656, 737, 656, 1450 };
        int[] heightPembOtak = { 707, 1490, 1050, 1190, 980, 1050, 1557, 656, 1607, 2187 };
        int[] heightPembJantung = { 877, 1490, 1657, 1020, 1490, 1190, 707, 1657, 656, 1490 };
        StaticInfoKuis.height.Add("PembGinjal", heightPembGinjal);
        StaticInfoKuis.height.Add("PembOtak", heightPembOtak);
        StaticInfoKuis.height.Add("PembJantung", heightPembJantung);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "ArGinjal" || SceneManager.GetActiveScene().name == "ArOtak" || SceneManager.GetActiveScene().name == "ArJantung")
            {
                _arSession.Reset();
                SceneManager.LoadScene("Menu");
            } else if (SceneManager.GetActiveScene().name == "Quiz" && PanelStart != null && PanelStart.activeSelf)
            {
                SceneManager.LoadScene("Ar"+ StaticClass.quizCode);
            } else if (SceneManager.GetActiveScene().name == "Menu" && PanelInputKode.activeSelf) 
            {
                PanelInputKode.SetActive(false);
                Menu.SetActive(true);
            }
            else if (SceneManager.GetActiveScene().name == "Menu")
            {
                UnityEngine.Application.Quit();
            }
        }
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
            if (PlayerPrefs.HasKey("UnlockOtak"))
                SceneManager.LoadScene("ArOtak");
            else
            {
                imgMateri.sprite = imgOtak;
                txtJudulMateri.text = "Otak";
                PanelInputKode.SetActive(true);
                Menu.SetActive(false);
            }
        }
        else if (codeScene == 2)
        {
            StaticClass.quizCode = "Jantung";
            if (PlayerPrefs.HasKey("UnlockJantung"))
                SceneManager.LoadScene("ArJantung");
            else
            {
                imgMateri.sprite = imgJantung;
                txtJudulMateri.text = "Jantung";
                PanelInputKode.SetActive(true);
                Menu.SetActive(false);
            }
        }
    }

    public void OnChangeInput()
    {
        SalahKode.SetActive(false);
        if (InputKode.text.Length > 0)
            BtnMulai.SetActive(true);
        else
            BtnMulai.SetActive(false);
    }

    public void OnClickInput()
    {
        if (StaticClass.quizCode == "Jantung" && InputKode.text == "SMAN104JAKARTA")
        {
            PlayerPrefs.SetInt("UnlockJantung", 1);
            Menu.SetActive(true);
            PanelInputKode.SetActive(false);
            SceneManager.LoadScene("ArJantung");
        }
        else if (StaticClass.quizCode == "Jantung")
        {
            SalahKode.SetActive(true);
            BtnMulai.SetActive(false);
        }
        else if (StaticClass.quizCode == "Otak" && InputKode.text == "SMAN104JAKARTA")
        {
            PlayerPrefs.SetInt("UnlockOtak", 1);
            Menu.SetActive(true);
            PanelInputKode.SetActive(false);
            SceneManager.LoadScene("ArOtak");
        }
        else if (StaticClass.quizCode == "Otak")
        {
            SalahKode.SetActive(true);
            BtnMulai.SetActive(false);
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
        //todo
        _arSession.Reset();

        SceneManager.LoadScene("Quiz");
    }

    public void TutorialMenu()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void HomeMenu()
    {
        _arSession.Reset();

        SceneManager.LoadScene("Menu");
    }
}
