namespace UI.Base
{
    public class ExtensionUtility
    {
        /// <summary>
        /// Trying to find object on scene that was inherited from T
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void TryToFindObjectOfType<T>(out T result) where T : UnityEngine.Object
        {
            result = UnityEngine.Object.FindObjectOfType<T>();
        }
    }
} 