using UnityEngine;
using System.Collections.Generic;

public static class SkillDefLoader
{
    [System.Serializable]
    public class SkillDefResource
    {
        public string id;
        public string timelineId;
        public SkillDefResourceValue cost;
        public SkillDefResourceValue condition;
        public bool autoLearn;
    }

    [System.Serializable]
    public class SkillDefResourceValue
    {
        public int hp;
        public int ammo;
        public int stamina;
    }

    public static SkillModel LoadSkillFromResource(string resourcePath)
    {
        TextAsset jsonAsset = Resources.Load<TextAsset>(resourcePath);
        if (jsonAsset == null)
        {
            Debug.LogWarning("SkillDefLoader: missing resource " + resourcePath);
            return default;
        }

        SkillDefResource def = JsonUtility.FromJson<SkillDefResource>(jsonAsset.text);
        if (def == null || string.IsNullOrEmpty(def.id) || string.IsNullOrEmpty(def.timelineId))
        {
            Debug.LogWarning("SkillDefLoader: invalid skill definition " + resourcePath);
            return default;
        }

        if (DesingerTables.Timeline.data.ContainsKey(def.timelineId) == false)
        {
            Debug.LogWarning("SkillDefLoader: timeline not found " + def.timelineId);
            return default;
        }

        ChaResource cost = ToChaResource(def.cost);
        ChaResource condition = ToChaResource(def.condition);
        return new SkillModel(def.id, cost, condition, def.timelineId, null);
    }

    public static List<SkillDefResource> LoadAllDefsFromFolder(string folderPath)
    {
        List<SkillDefResource> defs = new List<SkillDefResource>();
        TextAsset[] assets = Resources.LoadAll<TextAsset>(folderPath);
        for (int i = 0; i < assets.Length; i++)
        {
            if (assets[i] == null || string.IsNullOrEmpty(assets[i].text))
            {
                continue;
            }
            SkillDefResource def = JsonUtility.FromJson<SkillDefResource>(assets[i].text);
            if (def == null || string.IsNullOrEmpty(def.id) || string.IsNullOrEmpty(def.timelineId))
            {
                Debug.LogWarning("SkillDefLoader: invalid skill definition in " + folderPath + "/" + assets[i].name);
                continue;
            }
            defs.Add(def);
        }
        return defs;
    }

    public static SkillModel ToSkillModel(SkillDefResource def)
    {
        if (def == null || string.IsNullOrEmpty(def.id) || string.IsNullOrEmpty(def.timelineId))
        {
            return default;
        }
        if (DesingerTables.Timeline.data.ContainsKey(def.timelineId) == false)
        {
            Debug.LogWarning("SkillDefLoader: timeline not found " + def.timelineId);
            return default;
        }
        return new SkillModel(def.id, ToChaResource(def.cost), ToChaResource(def.condition), def.timelineId, null);
    }

    private static ChaResource ToChaResource(SkillDefResourceValue value)
    {
        if (value == null)
        {
            return ChaResource.Null;
        }
        return new ChaResource(value.hp, value.ammo, value.stamina);
    }
}
