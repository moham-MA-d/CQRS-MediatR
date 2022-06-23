namespace CQRS_MediatR.DTO
{
    public class CreateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CreateProductRequest(string name)
        {
            Name = name;
        }
    }

    public class GetProdoctRequest
    {
        public int Id { get; set; }
    }

}
