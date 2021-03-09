
using UnityEngine;


public class MoveWall : MonoBehaviour
{
   // [SerializeField]
    private GameObject obj;
    public float moveSpeed;
    private float oldPosition;
    private float minY;
    private float maxY;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 8;
        moveSpeed = 5;
        minY = -1;
        maxY = 1;

    }

    // Update is called once per frame

    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ResetWall"))
        {
           // Debug.Log("Wall");
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY), 0);
        }
    }
}
