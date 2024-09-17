using System.Collections.Generic;
using System.Linq;
using Managers.QuestManager;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private IEnumerable<WaterableEntityBehaviour> waterBehaviours;
    [SerializeField] private List<QuestData> Quests;
    [SerializeField] private Quest questPrefab;
    [SerializeField] private Canvas tabletCanvas;

    private void Start()
    {
        Quest previousQuest = null;

        for (var i = 0; i < Quests.Count; i++)
        {
            var quest = Quests[i];
            var instance = Instantiate(questPrefab, tabletCanvas.transform);
            instance.Initialize(quest, previousQuest, i == Quests.Count - 1);

            if (previousQuest != null)
            {
                instance.gameObject.SetActive(false);
            }

            previousQuest = instance;

            // Update nextQuest for the current instance

        }
    }
}