using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public enum PlayerType
{
    Red,
    Green,
    Yellow,
    Blue
}
public enum PlayerPos
{
    Up,
    Center,
    Down
}

public class Player : MonoBehaviour
{
    public PlayerType playerType;
    public PlayerPos playerPosEnum;
    public float playerDistance;
    public Action OnPlayerClear;
    
    [HideInInspector] public KeyCode[] upKeyCodes = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P};
    [HideInInspector] public KeyCode[] centerKeyCodes = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L };
    [HideInInspector] public KeyCode[] downKeyCodes = { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M };

    [SerializeField] private GameObject[] playerPos;
    [SerializeField] private AudioSource audioSource;
    public AudioSource AudioSource => audioSource;
    
    [HideInInspector] public Animator animator;
    
    SongSucces songSucces;

    public GameObject[] notes;
    public GameObject firstNote;
    public float shortDis;
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private bool collisionEnter = false;
    
    bool isMusicStart = false;

    private void Awake()
    {
        #region GetComponents
        animator = GetComponent<Animator>();
        songSucces = FindObjectOfType<SongSucces>();
        audioSource = FindObjectOfType<AudioSource>();
        #endregion

        #region PlayerPos
        playerPos[0] = GameObject.Find("=====Position=====").transform.GetChild(1).gameObject;
        playerPos[1] = GameObject.Find("=====Position=====").transform.GetChild(0).gameObject;
        playerPos[2] = GameObject.Find("=====Position=====").transform.GetChild(2).gameObject;
        transform.position = playerPos[1].transform.position;
        #endregion
        
        animator.SetBool(IsRun, true);
    }

    private void Update()
    {
        #region PlayerPos
        if (Input.anyKeyDown)
            animator.SetTrigger("Kick");
        foreach (var item in upKeyCodes)
        {
            if(Input.GetKeyDown(item) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                transform.position = playerPos[0].transform.position;
                playerPosEnum = PlayerPos.Up;
            }
        }
        foreach (var item in centerKeyCodes)
        {
            if (Input.GetKeyDown(item) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                transform.position = playerPos[1].transform.position;
                playerPosEnum = PlayerPos.Center;
            }
        }

        foreach (var item in downKeyCodes)
        {
            if (Input.GetKeyDown(item) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                transform.position = playerPos[2].transform.position;
                playerPosEnum = PlayerPos.Down;
            }
        }
        #endregion

        notes = GameObject.FindGameObjectsWithTag("Note");
        if (notes[0] != null)
        {
            shortDis = Vector3.Distance(gameObject.transform.position, notes[0].transform.position);
        }

        firstNote = notes[0]; // 첫번째를 먼저 
 
        foreach (var found in notes)
        {
            var distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
 
            if (distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                firstNote = found;
                shortDis = distance;
            }
        }
        if(Vector3.Distance(transform.position, firstNote.transform.position) < playerDistance && Input.anyKeyDown && collisionEnter && !firstNote.GetComponent<Note>().IsHit 
           && firstNote.GetComponent<Note>().notePos.ToString() == playerPosEnum.ToString())
        {
            firstNote.GetComponent<Note>().MoveEnd();
            UIManager.Instance.UpdateJudgeText(JudgeType.Perfect);
        }
        Clear();
    }
    
    private void Clear()
    {
        if(audioSource.time >= audioSource.clip.length)
        {
            OnPlayerClear?.Invoke();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        { 
            collisionEnter = true;
        }
    }
}
