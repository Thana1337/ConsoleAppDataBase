using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;

namespace ConsoleAppDataBase.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntity CreateAdress(string streetName, string city, string postalCode, string country)
    {
        var adressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode && x.Country == country);
        adressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city, Country = country });
        return adressEntity;
    }

    public AddressEntity GetAdress(string streetName, string city, string postalCode, string country)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode && x.Country == country);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAllAdresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    public AddressEntity GetAdressById(int id)
    {
        var adressEntity = _addressRepository.Get(x => x.Id == id);
        return adressEntity;
    }

    public AddressEntity UpdateAdress(AddressEntity addressEntity)
    {
        var AddressUpdated = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return AddressUpdated;
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }

}
