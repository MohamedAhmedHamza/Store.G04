using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Entities
{
	public class BaseEntites<TKey>
	{
		public TKey Id { get; set; }
		public DateTime CreatAt { get; set; } = DateTime.Now;

	}
}
