using Zadanie3APBD.Entities;
using Zadanie3APBD.Services;

namespace Zadanie3APBD.Controllers;

public static class Animals

{

    public static IEndpointRouteBuilder AnimalEndpoints(this IEndpointRouteBuilder endpoints)

    {
        endpoints.MapGet("api/animals", (IAnimalsService ias, string? order) => TypedResults.Ok(ias.GetAnimals(order)));
        endpoints.MapGet("api/animals/{id:int}", (IAnimalsService ias, int id) => TypedResults.Ok(ias.GetAnimal(id)));
        endpoints.MapPost("api/animals", (IAnimalsService ias, Animal animal) => TypedResults.Created("", ias.CreateAnimal(animal)));
        endpoints.MapPut("api/animals/{id:int}", (IAnimalsService ias, int id, Animal animal) => {
            animal.IdAnimal = id;
            ias.UpdateAnimal(animal);
            return TypedResults.NoContent();
        });
        endpoints.MapDelete("api/animals/{id:int}", (IAnimalsService ias, int id) => {
            ias.DeleteAnimal(id);
            return TypedResults.NoContent();
        });

        return endpoints;

    }
    
}