using System.Data.SqlClient;
using Zadanie3APBD.Entities;

namespace Zadanie3APBD.Repositories;

public class AnimalsRepository : IAnimalsRepository

{
    private IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string? order)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY " + (order == null ? "Name" : order);
        
        var sdr = comm.ExecuteReader();
        var animals = new List<Animal>();
        while (sdr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)sdr["IdAnimal"],
                Name = (string)sdr["Name"],
                Description = sdr["Description"].ToString(),
                Category = (string)sdr["Category"],
                Area = (string)sdr["Area"]
            };
            animals.Add(animal);
        }
        
        return animals;
    }

    public Animal? GetAnimal(int idAnimal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal = @IdAnimal";
        comm.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var sdr = comm.ExecuteReader();
        
        if (!sdr.Read()) return null;
        
        var animal = new Animal
        {
            IdAnimal = (int)sdr["IdAnimal"],
            Name = (string)sdr["Name"],
            Description = sdr["Description"].ToString(),
            Category = (string)sdr["Category"],
            Area = (string)sdr["Area"]
        };
        
        return animal;
    }
    
    public int CreateAnimal(Animal animal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "INSERT INTO Animal VALUES(@Name, @Description, @Category, @Area)"; 
        comm.Parameters.AddWithValue("@Name", animal.Name);
        comm.Parameters.AddWithValue("@Description", animal.Description);
        comm.Parameters.AddWithValue("@Category", animal.Category);
        comm.Parameters.AddWithValue("@Area", animal.Area);
        
        var count = comm.ExecuteNonQuery();
        return count;
    }
    
    public int UpdateAnimal(Animal animal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        comm.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        comm.Parameters.AddWithValue("@Name", animal.Name);
        comm.Parameters.AddWithValue("@Description", animal.Description);
        comm.Parameters.AddWithValue("@Category", animal.Category);
        comm.Parameters.AddWithValue("@Area", animal.Area);
        
        var count = comm.ExecuteNonQuery();
        return count;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        comm.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var count = comm.ExecuteNonQuery();
        return count;
    }
    
}