using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract
{
	public interface IGenericRepository<TEntity , Tkey> where TEntity : BaseEntites<Tkey>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetAsync(Tkey id);
		void AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);


	}
}
