namespace DI.Models
{
    public class BaseError
    {
        public const int FAIL_SAVE_DATA = 1;
        public const int FAIL_LOAD_DATA = 2;
        public const int FAIL_CREATE_FILE = 3;
        public const int FAIL_OPEN_FILE = 4;
        public const int FAIL_LOAD_PLAYER = 5;
        public const int FAIL_LOAD_MAIN_MENU = 6;
        public const int FAIL_LOAD_INTRO_LEVEL = 4;
        public const int FAIL_LOAD_MARIO_LEVEL = 4;
        public const int FAIL_LOAD_FINAL_LEVEL = 4;
        public const int FAIL_LOAD_LODING_SCREEN = 4;
        public const int FAIL_LOAD_NAVIGATION_MENU = 4;
        public const int FAIL_LOAD_PAUSE_MENU = 4;
        public const int FAIL_LOAD_GAME_OVER_MENU = 4;
        public const int FAIL_LOAD_STATISTICS_DATA = 4;
        
        public int errorCode;
        public string errorMessage;

        public BaseError(int errorCode, string errorMessage)
        {
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;
        }
    }
}
