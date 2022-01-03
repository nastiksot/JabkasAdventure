// using System;
// using DI;
// using UI.Base;
// using UI.Navigation;
// using UI.Timer;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace UI.Games.Menus
// {
//     public class PauseMenu : BaseMono
//     {
//         [SerializeField] private CanvasGroup background;
//
//         [Header("Buttons")] [SerializeField] private Button continueButton;
//         [SerializeField] private Button exitButton;
//
//         private TimeUIManager timeUIManager;
//         private NavigationMenu navigationMenu;
//         
//         public CanvasGroup Background => background;
//         public Button ContinueButton => continueButton;
//         public Button ExitButton => exitButton;
//
//         private void Start()
//         {
//             GetNavigationMenu();
//             GetTimerManager();
//             SetPauseMenuVisibility(false);
//
//             continueButton.onClick.AddListener(() =>
//             {
//                 timeUIManager.Unpause();
//                 timeUIManager.SetTimerManagerUIVisibility(true);
//                 navigationMenu.SetNavigationMenuVisibility(true);
//                 SetPauseMenuVisibility(false);
//             });
//
//             exitButton.onClick.AddListener(() =>
//             {
//                 timeUIManager.Unpause();
//                 MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
//             });
//         }
//
//         /// <summary>
//         /// Set pause menu visibility
//         /// </summary>
//         /// <param name="state"></param>
//         public void SetPauseMenuVisibility(bool state)
//         {
//             CanvasTool.State(ref background, state);
//         }  
//
//         /// <summary>
//         /// Get timer manager
//         /// </summary>
//         private void GetTimerManager()
//         {
//             MainDependency.GetInstance().GetReferenceManager().GetTimerManager(
//                 timerManager => { timeUIManager = timerManager; },
//                 error => { ToastUtility.ShowToast(error.errorMessage); });
//         }
//
//         /// <summary>
//         /// Get navigation menu
//         /// </summary>
//         private void GetNavigationMenu()
//         {
//             MainDependency.GetInstance().GetReferenceManager().GetNavigationMenu(menu => { this.navigationMenu = menu; },
//                 error => { ToastUtility.ShowToast(error.errorMessage); });
//         }
//     }
// }