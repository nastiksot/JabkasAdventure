using DI;
using UI.Base;

namespace UI.Games.progressScreen
{
    public class LoadingScreen : BaseMono
    {
        void Start()
        {
            OpenMainGame();
        }

        void OpenMainGame()
        {
            StartCoroutine( startWithDelay(5,()=>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainLevel(); 
            }));
        }
    }
}
