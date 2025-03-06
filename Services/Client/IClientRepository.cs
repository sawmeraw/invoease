public interface IClientRepository
{
    Task<ClientDTO> Create(ClientDTO clientDTO);

    Task<ClientDTO?> GetById(int id);
    Task<IEnumerable<ClientDTO>> GetAll();
    Task Delete(int id);
    Task<ClientDTO> Update(ClientDTO clientDTO);

}