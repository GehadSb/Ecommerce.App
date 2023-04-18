namespace Ecommerce.Application.Common.Dtos
{
    public class LookupDto<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }

        protected LookupDto()
        {

        }
        public LookupDto(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
