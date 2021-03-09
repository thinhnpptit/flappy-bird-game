
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator anim;
    private GameObject obj;
    GameObject gameController;
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;

    private float flyPower = 20;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();

        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (gameController.GetComponent<GameController>().isFirstStart)
                audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetScore();
    }

    // Gameover
    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }

    private void EndGame()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
        anim.SetBool("isDead", true);
        gameController.GetComponent<GameController>().EndGame();
    }
}
