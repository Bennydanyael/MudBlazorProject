namespace Service.ViewModels.Account
{
    public record APIResponse(bool _isSuccess, string? _message = null)
    {
        public static APIResponse Success() => new(true, null);
        public static APIResponse Failed(string? _message) => new(false, _message);
    }
    public record APIResponse<TData>(bool _isSuccess, TData _data, string? _message = null)
    {
        public static APIResponse<TData> Success(TData _data) => new(true, _data, null);
        public static APIResponse<TData> Failed(string? _message) => new(false, default!, _message);
    }
    public record class APIRequest
    {
    }
}
