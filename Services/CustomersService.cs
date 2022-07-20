using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRM;
using CRM.Models;
namespace CRM.Services;

public class CustomersService : ICustomersService
{
    private readonly IConfiguration _configuration;

    public CustomersService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<JsonResult> Get()
    {
        string query = $"select * from dbo.CustomerDB";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Post(Customer customer)
    {
        string query = $"insert into dbo.CustomerDB values ('{customer.CustomerName}', '{customer.InterestProduct}','{customer.AsignedSeller}')";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Put(Customer customer)
    {
        string query = $"update dbo.CustomerDB set CustomerName='{customer.CustomerName}', InteresProduct='{customer.InterestProduct}', AsignedSeller='{customer.AsignedSeller}' where CustomerId={customer.CustomerId}";
        return new JsonResult(Query(query));
    }

    public async Task<JsonResult> Delete(int id)
    {
        string query = $"delete from dbo.CustomerDB where CustomerId={id}";
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

public interface ICustomersService
{
    Task<JsonResult> Get();
    Task<JsonResult> Post(Customer customer);
    Task<JsonResult> Put(Customer customer);
    Task<JsonResult> Delete(int id);
}