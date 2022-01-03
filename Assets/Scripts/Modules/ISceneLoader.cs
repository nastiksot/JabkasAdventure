namespace Modules
{
    public interface ISceneLoader
    {
        public void LoadSceneAsync(string name);
        public void LoadScene(string name);
        public void UnloadSceneAsync(string name);
    }
}