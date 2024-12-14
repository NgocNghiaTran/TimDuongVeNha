using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VaCham : MonoBehaviour
{

    public Animator playerAnimator;  // Animator của Player
    public RuntimeAnimatorController player2Controller;  // Animator Controller cho Player2 (di chuyển bình thường)
    public RuntimeAnimatorController playerFlyController;

    public MonoBehaviour diChuyenScript;
    public MonoBehaviour playerFlyScript;
    public Animator anim;
    public GameObject wing;

    public int heath = 5;
    public Image anhOver;
    public Image anhWin;
       private audio music;
  private void Awake()
  {
    music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();

        if (playerAnimator == null)
        {
            playerAnimator = GetComponent<Animator>();
        }
    }
    void Start()
    {

        Time.timeScale = 1;
     anhOver.gameObject.SetActive(false);
      anhWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //t.text = d.ToString();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (other.tag == "thuhoang")
        {
            heath = heath - 1;
              music.PlaySfnhac(music.nhactrudiem);
        }
        if (other.tag == "nuoc")
        {
            heath = heath - 1;
            music.PlaySfnhac(music.nhactrudiem);
        }
        if (heath == 0)
        {
            Time.timeScale = 0;
            anhOver.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneName);
            music.StopG();
            music.PlaySfnhac(music.nhacOver);
        }
        if (other.tag == "win")
        {
            Time.timeScale = 0;
            anhWin.gameObject.SetActive(true);
              music.StopG();
            music.PlaySfnhac(music.nhacWin);
        }

        if (other.tag == "Wing")
        {

            Destroy(other.gameObject);
            // Tắt script DiChuyen
            diChuyenScript.enabled = false;

            // Bật script PlayerFly
            playerFlyScript.enabled = true;
            wing.SetActive(true);
            playerAnimator.runtimeAnimatorController = playerFlyController;

            StartCoroutine(TurnOnDiChuyen());

        }
    }

    IEnumerator TurnOnDiChuyen()
    {
        yield return new WaitForSeconds(10);
        diChuyenScript.enabled = true;
        anim.enabled = true;
        playerAnimator.runtimeAnimatorController = player2Controller;

        // Tắt script PlayerFly khi ra khỏi vùng va chạm
        playerFlyScript.enabled = false;
        wing.SetActive(false);

    }
}
