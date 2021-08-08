using DI;
using UI.Base;

namespace ui.Games.progressScreen
{
    public class ProgressScreenImpl : BaseMono
    {
        void Start()
        {
            OpenMainGame();
        }

        void OpenMainGame()
        {
            StartCoroutine( startWithDelay(6,()=>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().StartMainLevel(); 
            }));
        }
    }
}
