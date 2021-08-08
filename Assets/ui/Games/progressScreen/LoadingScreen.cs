using DI;
using UI.Base;

namespace ui.Games.progressScreen
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
                MainDependency.GetInstance().GetUIManager().GetNavigator().StartMainLevel(); 
            }));
        }
    }
}
