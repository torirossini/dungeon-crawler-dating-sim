using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;
using FMODUnity;


public class UseMemberFromParty : MonoBehaviour, IPointerClickHandler
{

    public NPC trackedMember;

    // destroy the item in its inventory as well as its UI representation when clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponentInParent<PartyDisplay>().charToTrack.GetComponent<Party>().RemoveMember(trackedMember);
        // play the npc removal sound from the FMOD StudioEventEmitter component that should be attached to this GO
        GetComponent<FMODCustomEvent>().SetEventParam("event:/Interface Sounds/PartyMenu", "PartyManipulation", 1);
        GetComponent<FMODCustomEvent>().PlayEvent("event:/Interface Sounds/PartyMenu");
        Destroy(gameObject);
    }
}
