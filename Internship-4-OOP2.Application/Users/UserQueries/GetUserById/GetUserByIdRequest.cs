namespace Internship_4_OOP2.Application.Users.UserQueries.GetUserById
{
    public class GetUserByIdRequest
    {
        public int Id { get; set; }

        public GetUserByIdRequest(int id)
        {
            Id = id;
        }

        public GetUserByIdRequest()
        {
            
        }
    }
}
