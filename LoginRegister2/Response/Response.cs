using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Response
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }  
        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                IsSuccess = true,
                Data = data
            };
        }
        public static Response<T> SuccessI()
        {
            return new Response<T>
            {
                IsSuccess = true,
                Data = default(T)
            };
        }
        public static Response<T> Fail(IEnumerable<string> errors )
        {
            return new Response<T>
            {
                Errors = errors,
                IsSuccess = false 
                
            };
        }
        public static Response<T> Fail(string v)
        {
            return new Response<T>
            {
                IsSuccess = false,
                 
                  
            };
        }

    }
}
