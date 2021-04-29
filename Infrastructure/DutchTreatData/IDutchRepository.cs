using System.Collections.Generic;
using helloworld.Infrastructure.Data.Entities;

namespace helloworld.Infrastructure.Data
{
  public interface IDutchRepository
  {
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> GetProductsByCategory(string category);

    bool SaveAll();
  }
}