namespace Models
{
    public class BaseError
    {
        public const int FAIL_SAVE_DATA = 1;
        public const int FAIL_LOAD_DATA = 2;
        public const int FAIL_CREATE_FILE = 3;
        public const int FAIL_OPEN_FILE = 4;
        
        
        public int errorCode;
        public string errorMessage;

        public BaseError(int errorCode, string errorMessage)
        {
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;
        }
    }
}
