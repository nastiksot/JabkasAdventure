using Models.ConstantValues;

namespace Models.ClassModels
{
    public class BaseError
    { 
        public int ErrorCode;
        public string errorMessage;

        public BaseError(BaseErrorCode errorCode, string errorMessage)
        {
            this.ErrorCode = (int)errorCode;
            this.errorMessage = errorMessage;
        }
    }
}