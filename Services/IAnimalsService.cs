using Zadanie3APBD.Entities;

namespace Zadanie3APBD.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderValue);
    Animal? GetAnimal(int idAnimal);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}