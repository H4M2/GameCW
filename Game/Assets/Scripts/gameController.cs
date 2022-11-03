using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    //Audio Variables
    public AudioSource staticAudio;
    public AudioSource chaseMusic;

    //Player Variables
    
    playerController playerScript;
    public GameObject player;
    Rect rect = new Rect(Screen.width / 2, Screen.height / 2, 200, 25);


    //Enemy Variables
    public GameObject enemy;
    public bool isAngry;
    bool toggle;

    //Game states
    public bool hidden;
    public bool dead;
    public bool generator = false;
    bool showDeathGUI = false;

    // Start is called before the first frame update
    void Start()
    {
        //staticAudio.Play();
        toggle = false;
        playerScript = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(FadeTrack());
        //StartCoroutine(deathScene());

    }
    IEnumerator FadeTrack()
    {
        isAngry = enemy.GetComponent<EnemyAi>().angry;

        float timeToFade = 1f;
        float timeElapsed = 0f;

        staticAudio.loop = isAngry;
        if (isAngry && !toggle)
        {
            staticAudio.Play();
            chaseMusic.Play();
            toggle = true;
            while (timeElapsed < timeToFade)
            {
                staticAudio.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                chaseMusic.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);

                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        if (toggle && !isAngry)
        {
            while(timeElapsed < timeToFade)
            {
                staticAudio.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                chaseMusic.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            staticAudio.Stop();
            chaseMusic.Stop();
            toggle = false;
            
        }
        
    }
    IEnumerator deathScene()
    {
        if (dead)
        {
            showDeathGUI = true;

            playerScript.lockPlayerMovement();
            playerScript.mouseSensitivity = 0f;

            yield return new WaitForSeconds(2);

            player.GetComponent<Transform>().position = new Vector3(12f, 1.25f, 35f);

            playerScript.ResetWalkspeed();
            playerScript.ResetMouse();

            showDeathGUI = false;
            dead = false;
        }
        yield return null;
    }
    private void OnGUI()
    {
        if (showDeathGUI)
        {
            GUI.Box(rect, "You are Dead");
        }
    }
    public void deathSceneRunner()
    {
        StartCoroutine(deathScene());
    }
}
