﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;

public class UseMemberFromParty : MonoBehaviour, IPointerClickHandler
{

    public NPC trackedMember;

    // destroy the item in its inventory as well as its UI representation when clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponentInParent<PartyDisplay>().charToTrack.GetComponent<Party>().RemoveMember(trackedMember);
        Destroy(gameObject);
    }
}
