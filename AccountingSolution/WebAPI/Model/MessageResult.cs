namespace WebAPI.Model
{
    public class MessageResult<T>
    {
        public T Data { get; set; }
         
        public string Message { get; set; }
        /// <summary>
        /// فقط در حالت دیباگ پر میشود
        /// </summary>
        public string StackTrace { get; set; }

        public int StatusCode { get; set; }

    }
}
