using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    #region publics
    public LayerMask mask;
    public GameObject board;
    public Timer timer;
    List<GameObject> test;
    #endregion

    #region privates
    private RaycastHit hit;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)*10 , Color.yellow);
                board = Instantiate(board, new Vector3(transform.position.x, transform.position.y-1.05f, transform.position.z), Quaternion.identity);
                test.Add(board);
        }
    }
}
