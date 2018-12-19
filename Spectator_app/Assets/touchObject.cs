using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class touchObject : MonoBehaviour, IPointerClickHandler
{
    public Transform target;
    public static Vector3 pos;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touched");
        //static シーン間で共有　座標を持っていく　観客側アプリ
        pos = transform.position;
        SceneManager.LoadScene("app");
    }
    public static Vector3 getPos()
    {
        return pos;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
