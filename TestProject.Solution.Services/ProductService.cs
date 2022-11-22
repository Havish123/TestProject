using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Solution.Data.DatabaseContext;
using TestProject.Solution.Data.Entity;
using TestProject.Solution.DTO;

namespace TestProject.Solution.Services
{
    public interface IProductService
    {
        ResultDto GetProductList();
        ResultDto GetProductById(long productId);
        ResultDto AddOrUpdateProduct(ProductDto product);

        ResultDto DeleteProduct(long productId);
    }
    public class ProductService : IProductService
    {
        private readonly TestProjectContext _context;
        public ProductService(TestProjectContext context)
        {
            _context = context;
        }
        public ResultDto AddOrUpdateProduct(ProductDto product)
        {
            var result = new ResultDto();
            try
            {
                if (product == null)
                {
                    result.IsSuccess = false;
                    result.SuccessObject = product;
                    result.Message = "Empty object found";
                }
                else
                {
                    var productExists = _context.Products.FirstOrDefault(x => x.Id == product.Id);
                    if (productExists != null)
                    {
                        productExists.Name = product.Name;
                        productExists.Status = product.Status;
                        productExists.Price = product.Price;
                        productExists.Created = DateTime.Now;
                        productExists.MerchantId = product.MerchantId;
                        _context.SaveChanges();
                        result.IsSuccess = true;
                        result.SuccessObject = product;
                        result.Message = "Update Successfully";
                    }
                    else
                    {
                        var productInput = new Product()
                        {
                            Name = product.Name,
                            Status = product.Status,
                            Price = product.Price,
                            Created = DateTime.Now,
                            MerchantId = product.MerchantId,
                        };
                        _context.Products.Add(productInput);
                        _context.SaveChanges();
                        result.IsSuccess = true;
                        result.SuccessObject = productInput;
                        result.Message = "Add Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.SuccessObject = product;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto DeleteProduct(long productId)
        {
            var result = new ResultDto();
            try
            {
                var product = _context.Products.FirstOrDefault(_ => _.Id == productId);
                if (product == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Product Id Not Found";
                }
                else
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    result.IsSuccess = true;
                    result.SuccessObject = product;
                    result.Message = "Delete Successfully.";
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto GetProductById(long productId)
        {
            var result = new ResultDto();
            try
            {
                var country = _context.Products.FirstOrDefault(_ => _.Id == productId);
                if (country == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Product Id Not Found";
                }
                else
                {
                    result.IsSuccess = true;
                    result.SuccessObject = country;
                    result.Message = "Country Id found.";
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto GetProductList()
        {
            var result = new ResultDto();
            try
            {
                var countries = _context.Countries.Select(_ => new CountryDto()
                {
                    Code = _.Code,
                    Name = _.Name,
                    ContinentName = _.ContinentName,
                    Id = _.Id
                }).ToList();
                if (!countries.Any())
                {
                    result.IsSuccess = false;
                    result.Message = "Country List is Empty";
                }
                else
                {
                    result.IsSuccess = true;
                    result.SuccessObject = countries;
                    result.Message = "List Found.";
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;

        }
    }
}
