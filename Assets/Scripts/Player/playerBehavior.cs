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

    public GameObject gameOver;
    public GameObject retryButton;
    #endregion

    #region privates
    private RaycastHit hit;
    private PlayerController playerController;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, mask))
        {
            if (playerController.woodCount > 0)
            {

                board = Instantiate(board, new Vector3(transform.position.x, transform.position.y - 1.05f, transform.position.z), Quaternion.identity);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10, Color.yellow);
                transform.GetChild(0).GetChild(playerController.woodCount).gameObject.SetActive(false);
                playerController.woodCount--;

                
                test.Add(board);
            }
            else
            {
                GameManager.isStarted = false;
                gameOver.SetActive(true);
                retryButton.SetActive(true);
            }
        }
    }
}
