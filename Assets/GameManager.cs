using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    private PhotonView PV;
    public static GameManager GM;
    public Transform[] startingLocations = new Transform[2];
    public GameObject[] planets = new GameObject[2];

    private void Awake()
    {
        if (GM != null)
        {        
            Destroy(GM);
        }
        GM = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        GameObject Player = PhotonNetwork.Instantiate("Prefab/Player", Vector3.zero, Quaternion.identity, 0);
        int PlayerNumber = Player.GetComponent<PhotonView>().Owner.ActorNumber - 1;
        Player.transform.position = startingLocations[PlayerNumber].position;
        Player.GetComponent<TutorialPlayer>().Planet = planets[PlayerNumber];


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
