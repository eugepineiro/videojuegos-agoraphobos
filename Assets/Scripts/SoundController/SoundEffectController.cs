using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.
[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour, IListenable
{
    #region IListenable_Properties
    // El audio quedará asignado por inspector
    public AudioClip AudioClip => _audioClip;
    /// SerializeField nos permite exponer una propiedad privada en el inspector
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip _victoryClip;
    [SerializeField] private AudioClip _defeatClip;
    [SerializeField] private AudioClip _puzzleSolvedClip;
    
    [SerializeField] private AudioClip _doorOpenedClip;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    #endregion

    #region IListenable_Methods
    public void InitAudioSource()
    {
        // Asignar el componente AudioSource
        _audioSource = GetComponent<AudioSource>();
        // Asignamos el audio clip al AudioSource
        _audioSource.clip = AudioClip;
    }

    // Reproducir de esta manera evita tener que asignar un clip al source
    public void PlayOnShot(AudioClip clip) => AudioSource.PlayOneShot(clip);

    // Esta reproducción necesita tener que asignar un clip al source
    public void Play() => AudioSource.Play();

    // Detiene un clip si esta asignado y en reproducción
    public void Stop() => AudioSource.Stop();
    #endregion

    #region Unity_Events
    // Start is called before the first frame update
    void Start()
    {
        InitAudioSource();
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnPuzzleSolved += OnPuzzleSolved;
        EventsManager.instance.OnDoorOpened += OnDoorOpened;
    }

    // Update is called once per frame
    void Update()
    {
        // Al presionar una tecla le damos play al audio clip
        if (Input.GetKeyDown(KeyCode.E)) PlayOnShot(_audioClip);
        //if (Input.GetKeyDown(KeyCode.P)) Play();
    }
    #endregion

    #region ACTION_GAMEOVER
    private void OnGameOver(bool isVictory)
    {
        if (isVictory)  PlayOnShot(_victoryClip);
        else            PlayOnShot(_defeatClip);
    }

    private void OnPuzzleSolved(PuzzleProperties puzzleProperties) 
    {
        PlayOnShot(_puzzleSolvedClip);
    }
    
    private void OnDoorOpened() 
    {
        PlayOnShot(_doorOpenedClip);
    }
    #endregion
}

