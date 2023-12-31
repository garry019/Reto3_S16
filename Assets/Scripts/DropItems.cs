using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    GameObject gmObject;
    GameManager gameManager;
    private bool canDrop;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gameManager = gmObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canDrop && gameManager.score == 5)
        {
            canDrop = false;
            DropTrash();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "TrashCan" && gameManager.score == 5)
        {
            canDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canDrop = false;
    }

    private void DropTrash()
    {
        gameManager.onPollution = false;
        gameManager.score = 0;
        gameManager.trashDrop = true;
    }
}
