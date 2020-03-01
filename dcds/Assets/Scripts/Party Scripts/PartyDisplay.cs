using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;


public class PartyDisplay : MonoBehaviour
{
    // gameObject with an party to track
    public GameObject charToTrack;
    // generic party member prefab to instantiate and then modify with member values
    [SerializeField]
    GameObject partyMemberPrefab;

    // when the parent panel is activated, grab a reference to the character's party and display its icon GameObject
    void OnEnable()
    {
        foreach (NPC i in charToTrack.GetComponent<Party>().party)
        {
            if (i) // make sure an member is filling this slot
            {
                // create the prefab in the scene, then modify its contents based on the member in question
                GameObject memberInstance = Instantiate(partyMemberPrefab, gameObject.transform);
                memberInstance.GetComponent<UseMemberFromParty>().trackedMember = i;
                //memberInstance.GetComponent<Image>().sprite = i.Icon; //NEED THIS IN NPC CLASS!
                // handle the title text contained within the prefab appropriately
                memberInstance.GetComponentInChildren<Text>().text = i.Name;
            }
        }
    }

    // when the parent panel is deactivated, delete the member representations
    void OnDisable()
    {
        // can't loop through a gameObject, so loop through its transform component instead
        Transform panelTransform = gameObject.transform;
        foreach (Transform child in panelTransform)
        {
            Destroy(child.gameObject);
        }
    }
}