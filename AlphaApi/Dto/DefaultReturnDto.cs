namespace AlphaApi.Dto
{
    public class DefaultReturnDto<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static DefaultReturnDto<T> ToDto(int status, string message, T Data)
        {
            return new DefaultReturnDto<T>()
            {
                Status = status,
                Message = message,
                Data = Data
            };
        }
    }
}
