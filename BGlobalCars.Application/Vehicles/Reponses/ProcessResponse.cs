namespace BGlobalCars.Application.Vehicles.Reponses
{
    public class ProcessResponse
    {
        public ProcessResponse(bool status, string? message = null)
        {
            Status = status;
            Message = message;
        }
        public bool Status { get; set; }
        public string? Message { get; set; }
    };
}
