using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameObject completeLevelUI;
    void OnTriggerEnter ()
	{
        completeLevelUI.SetActive(true);
    }

}
