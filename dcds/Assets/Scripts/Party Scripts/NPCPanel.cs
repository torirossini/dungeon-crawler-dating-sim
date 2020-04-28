using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCPanel : MonoBehaviour
{
    [SerializeField]
    NPC m_npc;

    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    SpriteRenderer headIcon;

    [SerializeField]
    Button removeButton;

    public SpriteRenderer HeadIcon { get => headIcon; }
    public TextMeshProUGUI Name { get => name; }
    public NPC Npc { get => m_npc; set => m_npc = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        if(m_npc)
        {
            name.text = m_npc.Name;
            headIcon.sprite = m_npc.HeadSprite;
            removeButton.onClick.AddListener(RemovePartyMember);
        }
        else
        {
            Debug.LogWarning("NPC Panel does not have an NPC assigned. Disabling this panel...");
            gameObject.SetActive(false);
        }

    }

    void RemovePartyMember()
    {
        Player.Instance.Party.RemoveMember(m_npc);
        gameObject.SetActive(false);
        Debug.Log("Removed " + name + " from party.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
