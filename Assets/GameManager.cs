using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour
{
    private PhotonView PV;
    public static GameManager GM;
    public Transform[] startingLocations = new Transform[2];
    public GameObject[] planets = new GameObject[2];
    public GameObject CameraHolder;

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
        GameObject Player = PhotonNetwork.Instantiate(Path.Combine("Prefab","Player 1"), Vector3.zero, Quaternion.identity, 0);
        int PlayerNumber = Player.GetComponent<PhotonView>().Owner.ActorNumber - 1;
        Player.transform.position = startingLocations[PlayerNumber].position;
        Player.GetComponent<TutorialPlayer>().Planet = planets[PlayerNumber];
        Player.GetComponent<TutorialPlayer>().PlayerPlaceholder = CameraHolder.gameObject;
        CameraHolder.GetComponent<TutorialPlayerPlaceholder>().Player = Player;
        CameraHolder.GetComponent<TutorialPlayerPlaceholder>().Planet = planets[PlayerNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
