namespace Modules.Interfaces
{
    public interface ISceneService
    {
        public void LoadSceneAsync(string name);
        public void LoadScene(string name);
        public void UnloadSceneAsync(string name);
    }
}