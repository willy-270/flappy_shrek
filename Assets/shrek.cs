using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class shrek : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    public pipe pipeS;
    public movingpipe movingPipeS;
    public titlescreen titlescreen;
    public AdsManager adsManager;
    public Sprite shrekSprite;
    public Sprite donkeySprite;
    public Sprite pussSprite;
    public Sprite kingSprite;
    bool i = false;
    bool j = false;
    public Rigidbody2D myRigidbody;
    public float jumpstrength;
    public logic logic;
    public bool shrekalive = true;
    public int lifeTimeJumps = 0;
    public int lifeTimeDeaths = 0;

    public AudioMixerGroup music;
    public AudioMixerGroup sfx;

    public AudioSource source;
    public AudioClip clip;
    public AudioSource source2;
    public AudioClip clip2;
    public AudioSource source3;
    public AudioClip clip3;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimeJumps = PlayerPrefs.GetInt("lifeTimeJumps");
        lifeTimeDeaths = PlayerPrefs.GetInt("lifeTimeDeaths");

        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();

        source2.outputAudioMixerGroup = sfx;

        music.audioMixer.SetFloat("MusicVol", 0f);
        sfx.audioMixer.SetFloat("SfxVol", -5f);
        sfx.audioMixer.SetFloat("distort", 0);

        string LoadedCurrentIcon = PlayerPrefs.GetString("currentIcon");

        if(LoadedCurrentIcon == "shrek") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shrekSprite;
        }
        if(LoadedCurrentIcon == "donkey") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = donkeySprite;
        }
        if(LoadedCurrentIcon == "puss") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pussSprite;
        }
        if(LoadedCurrentIcon == "kingShrek") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = kingSprite;
        }

        pipeS.moveSpeed = 7f;
        movingPipeS.moveSpeed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !adsManager.adShowing) {
            jump();
            if(j == false) {
                titlescreen.startgame();
                j = true;
            }
        }

        if(shrekalive == false && i == false) {
            PlayerPrefs.SetInt("lifeTimeJumps", lifeTimeJumps);
            lifeTimeDeaths += 1;
            PlayerPrefs.SetInt("lifeTimeDeaths", lifeTimeDeaths);

            myRigidbody.velocity = Vector2.up * Random.Range(-200, 200) +  
                                   Vector2.right * Random.Range(-200, 200);
    
            myRigidbody.angularVelocity = 360;
            
            music.audioMixer.SetFloat("MusicVol", -500f);
            sfx.audioMixer.SetFloat("distort", 0.7f);

            source2.PlayOneShot(clip2);
            i = true;

            pipeS.moveSpeed = 6f;
            movingPipeS.moveSpeed = 6f;
        }

         if(transform.position.y < -12) {
            logic.gameOver();
            shrekalive = false;
        }
    }
    public void jump() {

        if(shrekalive && !pausebutton.isPaused) {
            
        myRigidbody.velocity = Vector2.up * jumpstrength;
        myRigidbody.angularVelocity = 180;
        lifeTimeJumps += 1;
        source.PlayOneShot(clip);

        Collect();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
        shrekalive = false;

    }
    public void Collect() {
        collectParticle.Play();
    }
}




       


