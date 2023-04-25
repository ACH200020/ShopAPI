using Common.Domain;

namespace Domain.ProductAgg;

public class ProductImages : BaseEntity
{
    public ProductImages( string imageName, int sequence)
    {
       
        ImageName = imageName;
        Sequence = sequence;
    }
    public long ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int Sequence { get; private set; }
}