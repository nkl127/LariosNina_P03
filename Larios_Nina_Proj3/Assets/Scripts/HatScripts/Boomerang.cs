using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

    bool go;
    GameObject _player;
    GameObject _hat;
    Transform itemToRotate;
    Vector3 locationInFrontOfPlayer;

    private void Start()
    {
        go = false;
        _player = GameObject.Find("Player");
        _hat = GameObject.Find("Hat");

        _hat.GetComponent<MeshRenderer>().enabled = false;
        itemToRotate = gameObject.transform.GetChild(0);

        locationInFrontOfPlayer = new Vector3(_player.transform.position.x, _player.transform.position.y , _player.transform.position.z) + _player.transform.forward * 5f;

        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }

    private void Update()
    {
        itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);

        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40);
        }
        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y , _player.transform.position.z), Time.deltaTime * 40);
        }

        if (!go && Vector3.Distance(_player.transform.position, transform.position) < 1.5)
        {
            _hat.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
