using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;


namespace ConsoleAppDataBase.Services;

internal class RoleService
{
    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public RoleEntity CreateRole(string roleName)
    {
        var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });
        return roleEntity;
    }

    public RoleEntity GetRoleByName(string roleName)
    {
        var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        return roleEntity;
    }

    public IEnumerable<RoleEntity> GetAllRoles()
    {
        var categories = _roleRepository.GetAll();
        return categories;
    }

    public RoleEntity GetRoleById(int id)
    {
        var roleEntity = _roleRepository.Get(x => x.Id == id);
        return roleEntity;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var roleUpdated = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return roleUpdated;
    }

    public void DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
    }
}
