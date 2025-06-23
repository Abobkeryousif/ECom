namespace Ecom.Api.helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFromStatusCode(statusCode);
        }

        private string GetMessageFromStatusCode(int StatusCode) 
        {
            return StatusCode switch
            { 
                200 => "Ok",
                400 => "Bad Request",
                401 => "Un Authorized",
                500 => "Server Error",
            };
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
