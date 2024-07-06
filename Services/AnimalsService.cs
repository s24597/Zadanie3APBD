using Zadanie3APBD.Entities;
using Zadanie3APBD.Repositories;

namespace Zadanie3APBD.Services;

public class AnimalsService : IAnimalsService

{
    private IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderValue)
    {
        return _animalsRepository.GetAnimals(orderValue);
    }

    public Animal? GetAnimal(int idAnimal)
    {
        return _animalsRepository.GetAnimal(idAnimal);
    }
    
    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }
    
    public int UpdateAnimal(Animal animal)
    {
        return _animalsRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
    
    
    
    
}