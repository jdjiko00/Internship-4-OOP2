namespace Internship_4_OOP2.Application.Common.Model
{
    public class SuccessPostResponse : SuccessResponse
    {
        public int? Id { get; init; }

        public SuccessPostResponse(bool isSuccess, int? id) : base (isSuccess)
        {
            Id = id;
        }

        public SuccessPostResponse()
        {
            
        }
    }
}
