using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
		private readonly RepositoryContext _context;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_context = repositoryContext;	
		}

		public void SaveChanges() => _context.SaveChanges();

		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        
    }
}
