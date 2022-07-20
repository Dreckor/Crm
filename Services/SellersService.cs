using CRM.Models;
namespace CRM.Services;

public class SellersService : ISellersService
{
    CRMContext sellerContext;
    public SellersService(CRMContext sellerContext)
    {
        this.sellerContext = sellerContext;
    }
    public IEnumerable<Seller> Get()
    {
        
        return sellerContext.Sellers;
    }

    public async Task Add(Seller seller)
    {
        sellerContext.Add(seller);
        await sellerContext.SaveChangesAsync();
    }

    public async Task Update(int id, Seller seller)
    {
        var currentSeller = sellerContext.Sellers.Find(id);
        if(currentSeller != null){
            currentSeller.SellerName = seller.SellerName;
            await sellerContext.SaveChangesAsync();
        }
        
    }

    public async Task Delete(int id)
    {
        var currentSeller = sellerContext.Sellers.Find(id);
        if(currentSeller != null){
            sellerContext.Remove(currentSeller);
            await sellerContext.SaveChangesAsync();
        }
   
    }
    public async Task CreateTable()
    {
        sellerContext.Database.EnsureCreated();
        
    }
}

public interface ISellersService
{
    IEnumerable<Seller> Get();
    Task Add(Seller seller);
    Task Update(int id, Seller seller);
    Task Delete(int id);
    Task CreateTable();
}