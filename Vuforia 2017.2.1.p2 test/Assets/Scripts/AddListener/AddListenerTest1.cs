using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListenerTest1 : MonoBehaviour
{

    //private Button testButton;
    //public Text ResultText_;
    public Slider mainSlider;
    private float tmpTime1 = 0;
    private float interval = 1f;

    void Update()
    {
        //Connectコルーチンの実行
        tmpTime1 += Time.deltaTime;
        if (tmpTime1 >= interval)
        {
            StartCoroutine(Connect());
            tmpTime1 = 0;
        }
    }

    private IEnumerator Connect()
    {
        string url = "http://192.168.0.2:80/ADB_watch_connection1.php";

        //WWWForm:WWWクラスを使用してwebサーバにポストするフォームデータを生成するヘルパークラス
        WWWForm wwwForm = new WWWForm();

        //AddFieldでfieldに値を格納                
        wwwForm.AddField("id", "7");

        //WWWオブジェクトにURL,WWWFormをセットすることでPOST,GETを行える。
        WWW www = new WWW(url, wwwForm);

        //実行
        yield return www;
        if (www.isDone)
        {
            //送られてきたデータをテキストに反映
            Debug.Log(www.text);
            mainSlider.value = float.Parse(www.text);
        }
    }
}