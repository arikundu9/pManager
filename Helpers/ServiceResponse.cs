using pMan.DAL.Enums;

namespace pMan.Helpers {
    public class ApiResponse<T>
    {
        public Boolean success { get; set; }
        APIResponseCode code;
        string message;
        public T? data { get; set; }
        public string[]? error { get; set; }
    }
}
