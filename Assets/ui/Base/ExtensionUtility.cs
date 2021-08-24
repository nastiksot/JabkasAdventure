namespace UI.Base
{
    public class ExtensionUtility
    {
        public static bool TryToFindObjectOfType<T>(out T result) where T : UnityEngine.Object
        {
            result = UnityEngine.Object.FindObjectOfType<T>();
            return result != null;
        }
    }
}