using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;

namespace ConsoleAppDataBase.Services;

internal class ManufactureService
{
    private readonly ManufactureRepository _manufactureRepository;
    public ManufactureService(ManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public ManufactureEntity CreateManufactureName(string manufactureName)
    {
        var ManufactureEntity = _manufactureRepository.Get(x => x.ManufactureName == manufactureName);
        ManufactureEntity ??= _manufactureRepository.Create(new ManufactureEntity { ManufactureName = manufactureName });
        return ManufactureEntity;
    }

    public ManufactureEntity GetManufactureyByName(string manufactureName)
    {
        var manufactureEntity = _manufactureRepository.Get(x => x.ManufactureName == manufactureName);
        return manufactureEntity;
    }

    public IEnumerable<ManufactureEntity> GetAllManufactures()
    {
        var manufactures = _manufactureRepository.GetAll();
        return manufactures;
    }

    public ManufactureEntity GetManufactureById(int id)
    {
        var manufactureEntity = _manufactureRepository.Get(x => x.Id == id);
        return manufactureEntity;
    }

    public ManufactureEntity UpdateManufacture(ManufactureEntity ManufactureEntity)
    {
        var manufactureUpdated = _manufactureRepository.Update(x => x.Id == ManufactureEntity.Id, ManufactureEntity);
        return manufactureUpdated;
    }

    public void DeleteManufacture(int id)
    {
        _manufactureRepository.Delete(x => x.Id == id);
    }


}
