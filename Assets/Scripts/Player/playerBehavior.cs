using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    #region publics
    public LayerMask mask;
    public GameObject board;
    public Timer timer;
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
            if (playerController.woodCount > -1)
            {
                if(timer.getTime() < 0.2f)
                {
                    board = Instantiate(board, new Vector3(transform.position.x, transform.position.y - 1.05f, transform.position.z), Quaternion.identity);
                    board.SetActive(true);
                    transform.GetChild(0).GetChild(playerController.woodCount).gameObject.SetActive(false);
                    playerController.woodCount--;
                    timer.setTime(0.5f);
                }
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
