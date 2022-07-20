using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRM;
using CRM.Models;
namespace CRM.Services;

public class SellersService : ISellersService
{
    private readonly IConfiguration _configuration;

    public SellersService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<JsonResult> Get()
    {
        string query = $"select * from dbo.SellersDB";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Post(Seller seller)
    {
        string query = $"insert into dbo.SellersDB values ('{seller.SellerName}')";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Put(Seller seller)
    {
        string query = $"update dbo.SellersDB set SellerName='{seller.SellerName}' where SellerId={seller.SellerId}";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Delete(int id)
    {
        string query = $"delete from dbo.SellersDB where SellerId={id}";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Query(string query)
    {
        DataTable dataTable = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("CrmDatabase");
        SqlDataReader mReader;
        using(SqlConnection mCon = new SqlConnection(sqlDataSource))
        {
            mCon.Open();
            using(SqlCommand mCommand = new SqlCommand(query, mCon))
            {
                mReader = mCommand.ExecuteReader();
                dataTable.Load(mReader);

                mReader.Close();
                mCon.Close();
            }
        }

        return new JsonResult(dataTable);
    }

   
}

public interface ISellersService
{
    Task<JsonResult> Get();
    Task<JsonResult> Post(Seller seller);
    Task<JsonResult> Put(Seller seller);
    Task<JsonResult> Delete(int id);
}