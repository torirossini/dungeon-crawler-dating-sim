using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    // very basic party backend that allows members to be added/removed from a list
    public class Party : MonoBehaviour
    {
        public int partySize = 4;
        public List<NPC> party;
        

        public void AddMember(NPC memberToAdd)
        {
            if (party.Count < partySize)
            {
                party.Add(memberToAdd);
                
            }
            else
            {
                Debug.Log("Party is full, can't add this person!");
            }

        }
        public void RemoveMember(NPC memberToRemove)
        {
            party.Remove(memberToRemove);
        }
    }
}
