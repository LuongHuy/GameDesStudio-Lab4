using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Singleton set up
    static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else {
            _instance = this;
        }
    }

    // Audio mixer
    [SerializeField] AudioMixer audioMixer;
    // volumn slider
    [SerializeField] Slider bgMusicSlider;
    [SerializeField] Slider vfxSlider;
    [SerializeField] Slider masterSlider;
    // audio source
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource vfx;

    // Maybe move this to game master.
    void Start()
    {
        playBackground();
    }

    // Script to adjust volumn using slider. Attach to slider
    public void AdjustMusicVolumn()
    {
        Debug.Log("Adjust Background volumn");
        float volumn = Mathf.Log10(bgMusicSlider.value)*20;
        audioMixer.SetFloat("Music",volumn);
    }

    public void AdjustVfxVolumn()
    {
        Debug.Log("Adjust VFX volumn");
        float volumn = Mathf.Log10(vfxSlider.value)*20;
        audioMixer.SetFloat("VFX",volumn);
    }
    public void AdjustMasterVolumn()
    {
        Debug.Log("Adjust Master volumn");
        float volumn = Mathf.Log10(masterSlider.value)*20;
        audioMixer.SetFloat("MasterSound",volumn);
    }

    // Script to play music or vfx
    public void playBackground()
    {
        bgMusic.loop = true;
        AdjustMusicVolumn();
        bgMusic.Play();
    }

    public void playVFX(AudioClip audioClip, Transform spamTrans)
    {
        // spam in game object
        AudioSource sound_eff = Instantiate(vfx, spamTrans.position, Quaternion.identity);

        // assign audio clip
        sound_eff.clip = audioClip;
        AdjustVfxVolumn(); 
        sound_eff.Play();

        // Destroy new game object after sound is played.
        float clipLength = sound_eff.clip.length;
        Destroy(sound_eff.gameObject, clipLength+0.5f);
    }
}
