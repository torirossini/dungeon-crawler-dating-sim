using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public enum TimeOfDay
{
    Morning = 1, Midday = 2, Evening = 3, Night = 4
}
public class GameManager : Singleton<GameManager>
{


    /*
    [Header("Important Objects")]
    [SerializeField]
    Player player;

    [SerializeField]
    CameraManager playerCamera;


    [SerializeField]
    Canvas screenCanvas;

    [SerializeField]
    GameObject interactIcons;

    /*[SerializeField]
    LightManager lightManager;

    // List of NPCs to be managed
    [SerializeField]
    List<NPC> npcs;

    [Header("Time Vars")]

    [SerializeField]
    const int MAX_TIME_POINTS = 5;

    [SerializeField]
    int m_currentTimePoints;

    float m_timeIncrements;

    TimeOfDay m_currentTime;

    //[SerializeField]
    //TownManager townManager;


    #region Getters/Setters
    public Player Player { get => player; set => player = value; }
    //public CameraManager PlayerCamera { get => playerCamera; set => playerCamera = value; }
    public Canvas ScreenCanvas { get => screenCanvas; }
    public int CurrentTimePoints { get => m_currentTimePoints; set => m_currentTimePoints = value; }
    public List<NPC> NPCs { get => npcs; set => npcs = value; }
    public GameObject InteractIcons { get => interactIcons; set => interactIcons = value; }

    //public TownManager TownManager { get => townManager; set => townManager = value; }

    #endregion



    void Awake()
    {
        m_currentTimePoints = 0;
        m_currentTime = TimeOfDay.Morning;
        m_timeIncrements = MAX_TIME_POINTS / Enum.GetNames(typeof(TimeOfDay)).Length;
    }

    /*

  /// <summary>
  /// Expends timepoints if possible. 
  /// Also changes time UI, and triggers any lighting changes.
  /// </summary>
  /// <param name="numberToUse"></param>
  /// <returns></returns>
  public bool ExpendTimePoints(int numberToUse)
  {
      if (m_currentTimePoints + numberToUse > MAX_TIME_POINTS)
      {
          Debug.Log("Cannot perform this action - Not enough time left!");
          return false;
      }
      m_currentTimePoints += numberToUse;

      if (m_currentTimePoints >= m_timeIncrements * (int)m_currentTime)
      {
          if (m_currentTime == TimeOfDay.Night)
          {
              ChangeTimeOfDay(TimeOfDay.Morning);
              m_currentTimePoints = 0;
          }
          else
          {
              ChangeTimeOfDay(m_currentTime + 1);
          }
          Debug.Log("Changing time to " + m_currentTime);
      }

      if (m_currentTimePoints >= MAX_TIME_POINTS)
      {
          ResetDay();
      }
      return true;


  }


  /// <summary>
  /// Updates anything which changes when the time changes
  /// </summary>
  /// <param name="toTime"></param>
  public void ChangeTimeOfDay(TimeOfDay toTime)
  {
      m_currentTime = toTime;
      CanvasManager.Instance.TimeDisplay.SetText(toTime.ToString() + "\nTime Left: " + (MAX_TIME_POINTS - (int)toTime)
          + "\nTime Points: " + (int)toTime);
      lightManager.UpdateLighting((int)toTime);
      UpdateNPCs();

  }

  /// <summary>
  /// Anything which should be run when the day ends should be run here.
  /// </summary>
  private void ResetDay()
  {
      Debug.Log("Day ended. Resetting time points...");
      m_currentTimePoints = 0;
      // Reroll each npc's mood for the new day
      foreach (NPC npc in npcs)
      {
          npc.MoodOfTheDay();
      }
  }

    /// <summary>
    /// Updates variables for each NPC whenever the time is updated.
    /// This may need to change to every frame, with this specific check moved to when the time is updated.
    /// </summary>
    public void UpdateNPCs()
    {
        foreach (NPC npc in npcs)
        {
            npc.UpdateTransitionCondition();
        }
    }

    private void FindNPCsInScene()
    {
        GameObject[] npcObjs;
        npcObjs = GameObject.FindGameObjectsWithTag("NPC");
        npcs.Clear();
        foreach (GameObject npc in npcObjs)
        {
            npcs.Add(npc.GetComponent<NPC>());
        }
    }
    */
}
