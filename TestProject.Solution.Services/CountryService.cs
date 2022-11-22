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
    public interface ICountryService
    {
        ResultDto GetCountryList();
        ResultDto GetCountryById(long countryId);
        ResultDto AddOrUpdateCountry(CountryDto country);

        ResultDto DeleteCountry(long countryId);
    }
    public class CountryService : ICountryService
    {
        private readonly TestProjectContext _context;
        public CountryService(TestProjectContext context)
        {
            _context = context;
        }
        public ResultDto AddOrUpdateCountry(CountryDto country)
        {
            var result=new ResultDto();
            try
            {
                if(country == null)
                {
                    result.IsSuccess = false;
                    result.SuccessObject = country;
                    result.Message = "Empty object found";
                }
                else
                {
                    var countryExists = _context.Countries.FirstOrDefault(x => x.Id == country.Id);
                    if(countryExists != null)
                    {
                        countryExists.Code = country.Code;
                        countryExists.ContinentName = country.ContinentName;
                        countryExists.Name = country.Name;
                        _context.SaveChanges();
                        result.IsSuccess = true;
                        result.SuccessObject = country;
                        result.Message = "Update Successfully";
                    }
                    else
                    {
                        var countrydetails = new Country()
                        {
                            Code = country.Code,
                            ContinentName = country.ContinentName,
                            Name = country.Name,
                        };
                        _context.Countries.Add(countrydetails);
                        _context.SaveChanges();
                        result.IsSuccess = true;
                        result.SuccessObject = countrydetails;
                        result.Message = "Add Successfully";
                    }
                }
            }catch(Exception ex)
            {
                result.IsSuccess = false;
                result.SuccessObject = country;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto DeleteCountry(long countryId)
        {
            var result = new ResultDto();
            try
            {
                var country = _context.Countries.FirstOrDefault(_ => _.Id==countryId);
                if (country==null)
                {
                    result.IsSuccess = false;
                    result.Message = "Country Id Not Found";
                }
                else
                {
                    _context.Countries.Remove(country);
                    _context.SaveChanges();
                    result.IsSuccess = true;
                    result.SuccessObject = country;
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

        public ResultDto GetCountryById(long countryId)
        {
            var result = new ResultDto();
            try
            {
                var country = _context.Countries.FirstOrDefault(_ => _.Id==countryId);
                if (country==null)
                {
                    result.IsSuccess = false;
                    result.Message = "Country Id Not Found";
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

        public ResultDto GetCountryList()
        {
            var result = new ResultDto();
            try
            {
                var countries = _context.Countries.Select(_ => new CountryDto() { 
                        Code=_.Code,
                        Name=_.Name,
                        ContinentName=_.ContinentName,
                        Id=_.Id
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
                
            }catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;

        }
    }
}
