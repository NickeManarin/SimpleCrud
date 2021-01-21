using SimpleCrud.Application.Interfaces;

namespace SimpleCrud.Application.Models
{
    public class Response : IResponse
    {
        public int Status { get; set; }
        
        public int Code { get; set; }
    }
}