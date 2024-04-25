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
            string[] ginjal = { "A", "C", "D", "A", "B", "C", "A", "C", "D", "A" };
            string[] otak = { "A", "C", "D", "A", "B", "C", "A", "C", "D", "A" };
            string[] jantung = { "A", "C", "D", "A", "B", "C", "A", "C", "D", "A" };

            StaticInfoKuis.jawabanKuis.Add("Ginjal", ginjal);
            StaticInfoKuis.jawabanKuis.Add("Otak", otak);
            StaticInfoKuis.jawabanKuis.Add("Jantung", jantung);

            string[] soalGinjal = {
                "soal pendek 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla purus eros, eleifend ut congue mollis, mattis id justo. Nam malesuada, diam eget varius gravida, augue libero sagittis odio, at tristique enim nisi eu nibh. Integer sollicitudin cursus volutpat. Suspendisse tempus, metus quis scelerisque auctor, libero justo laoreet leo, ac iaculis augue turpis vel nibh. Praesent ultrices tincidunt arcu vel volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla placerat hendrerit lacus, in rhoncus elit ullamcorper eget. Nunc congue ullamcorper suscipit. Etiam quam mi, dignissim ac sodales in, rhoncus eget ipsum. Proin eu neque velit. Praesent eu neque at lorem eleifend vulputate vitae at augue. Nam malesuada ligula turpis. Ut et tellus in felis facilisis sodales in vel tortor.",
                "soal 3",
                "soal 4",
                "soal 5",
                "soal 6",
                "soal 7",
                "soal 8",
                "soal 9",
                "soal 10"
            };
            string[] soalOtak = {
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

        string[] ginjal1 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal2 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal3 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal4 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal5 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal6 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal7 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal8 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal9 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] ginjal10 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[][] pilganGinjal = {ginjal1, ginjal2, ginjal3, ginjal4, ginjal5, ginjal6, ginjal7, ginjal8, ginjal9, ginjal10};

        string[] otak1 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak2 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak3 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak4 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak5 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak6 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak7 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak8 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak9 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] otak10 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[][] pilganOtak = {otak1, otak2, otak3, otak4, otak5, otak6, otak7, otak8, otak9, otak10};

        string[] jantung1 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung2 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung3 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung4 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung5 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung6 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung7 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung8 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung9 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[] jantung10 = {"pilganA", "pilganB", "pilganC", "pilganD"};
        string[][] pilganJantung = {jantung1, jantung2, jantung3, jantung4, jantung5, jantung6, jantung7, jantung8, jantung9, jantung10};

        StaticInfoKuis.pilgan.Add("Ginjal", pilganGinjal);
        StaticInfoKuis.pilgan.Add("Otak", pilganOtak);
        StaticInfoKuis.pilgan.Add("Jantung", pilganJantung);
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
