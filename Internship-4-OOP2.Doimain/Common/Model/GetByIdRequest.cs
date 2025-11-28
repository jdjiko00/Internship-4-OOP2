using System.Globalization;

namespace Internship_4_OOP2.Doimain.Common.Model
{
    public class GetByIdRequest
    {
        public int Id { get; init; }

        public GetByIdRequest(int id)
        {
            Id = id;
        }

        public GetByIdRequest()
        {
            
        }
    }
}
