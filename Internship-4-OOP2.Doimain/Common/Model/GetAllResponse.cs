namespace Internship_4_OOP2.Doimain.Common.Model
{
    public class GetAllResponse<TValue>
    {
        public IEnumerable<TValue> Values { get; init; }
    }
}
