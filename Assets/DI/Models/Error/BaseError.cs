namespace DI.Models
{
    public class BaseError
    { 
        public int errorCode;
        public string errorMessage;

        public BaseError(BaseErrorCode errorCode, string errorMessage)
        {
            this.errorCode = (int)errorCode;
            this.errorMessage = errorMessage;
        }
    }
}
