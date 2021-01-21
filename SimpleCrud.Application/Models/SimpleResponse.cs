namespace SimpleCrud.Application.Models
{
    public class SimpleResponse : Response
    {
        public SimpleResponse(int status, int code, string response)
        {
            Status = status;
            Code = code;
            Response = response;
        }
        
        public string Response { get; set; }
    }
}