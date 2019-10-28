namespace RoleObject
{
    public class Result<TValue, TError>
    {
        public Result(TValue value)
        {
            Value = value;
            IsSuccess = true;
        }

        public Result(TError error)
        {
            Error = error;
            IsSuccess = false;
        }

        public TValue Value { get; }

        public TError Error { get; }

        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;
    }
}
