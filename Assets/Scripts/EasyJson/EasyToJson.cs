using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace EasyJson
{
    public static class EasyToJson
    {
        /**
         * <summary>
         * Json 파일로 저장
         * </summary>
         * <param name="obj">Json으로 저장할 객체</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void ToJson<T>(T obj, string jsonFileName, bool prettyPrint = false)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = JsonUtility.ToJson(obj, prettyPrint);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 객체로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 객체</returns>
         */
        public static T FromJson<T>(string jsonFileName)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = File.ReadAllText(path);
            T obj = JsonUtility.FromJson<T>(json);
            return obj;
        }
        
        /**
         * <summary>
         * List를 Json 파일로 저장
         * </summary>
         * <param name="list">Json으로 저장할 리스트</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void ListToJson<T>(List<T> list, string jsonFileName, bool prettyPrint = false)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = JsonConvert.SerializeObject(list, prettyPrint ? Formatting.Indented : Formatting.None);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 List로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 List</returns>
         */
        public static List<T> ListFromJson<T>(string jsonFileName)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = File.ReadAllText(path);
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(json);
            return obj;
        }

        /**
         * <summary>
         * Dictionary를 Json 파일로 저장
         * </summary>
         * <param name="dictionary">Json으로 저장할 Dictionary</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void DictionaryToJson<T, U>(Dictionary<T, U> dictionary, string jsonFileName, bool prettyPrint = false)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = JsonConvert.SerializeObject(dictionary, prettyPrint ? Formatting.Indented : Formatting.None);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 Dictionary로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 Dictionary</returns>
         */
        public static Dictionary<T, U> DictionaryFromJson<T, U>(string jsonFileName)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = File.ReadAllText(path);
            Dictionary<T, U> obj = JsonConvert.DeserializeObject<Dictionary<T, U>>(json);
            Debug.Log(json);
            return obj;
        }

        /**
         * <summary>
         * Queue를 Json 파일로 저장
         * </summary>
         * <param name="queue">Json으로 저장할 Stack</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void QueueToJson<T>(Queue<T> queue, string jsonFileName, bool prettyPrint = false)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = JsonConvert.SerializeObject(queue, prettyPrint ? Formatting.Indented : Formatting.None);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }

        /**
         * <summary>
         * Json 파일을 읽어서 Queue로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 Stack</returns>
         */
        public static Queue<T> QueueFromJson<T>(string jsonFileName)
        {
            string path = Path.Combine(Application.dataPath, jsonFileName + ".json");
            string json = File.ReadAllText(path);
            Queue<T> obj = JsonConvert.DeserializeObject<Queue<T>>(json);
            Debug.Log(json);
            return obj;
        }
    }
}
