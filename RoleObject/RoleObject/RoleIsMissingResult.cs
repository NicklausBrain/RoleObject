namespace RoleObject
{
    public class RoleIsMissingResult<T> : Result<T, string>
    {
        public RoleIsMissingResult(string error) : base(error)
        {
        }
    }
}
