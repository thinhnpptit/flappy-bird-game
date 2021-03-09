
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject obj;
    public float moveSpeed;
    public float moveRange;
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));
    
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
