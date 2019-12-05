using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatCol : MonoBehaviour {

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _hat;
    [SerializeField] GameObject _playerCam;
    [SerializeField] GameObject _otherCam;

    bool test = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hat")
        {
            Debug.Log("Hit");
            //make player inactive
            _player.SetActive(false);
            //activate movement controls for object that it collided with
            _hat.SetActive(true);
            _playerCam.SetActive(false);
            _otherCam.SetActive(true);

            test = true;

            gameObject.GetComponent<FPSInputP>().enabled = true;
            gameObject.GetComponent<FPSMotorP>().enabled = true;
            gameObject.GetComponent<PlayerControllerP>().enabled = true;
            gameObject.GetComponent<TurnP>().enabled = true;
        }
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Q))
            {
            if (test == true)
            {
                _player.SetActive(true);
                _hat.SetActive(false);

                _playerCam.SetActive(true);
                _otherCam.SetActive(false);

                gameObject.GetComponent<FPSInputP>().enabled = false;
                gameObject.GetComponent<FPSMotorP>().enabled = false;
                gameObject.GetComponent<PlayerControllerP>().enabled = false;
                gameObject.GetComponent<TurnP>().enabled = false;

                _player.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

                test = false;
            }
        }
    }
}
