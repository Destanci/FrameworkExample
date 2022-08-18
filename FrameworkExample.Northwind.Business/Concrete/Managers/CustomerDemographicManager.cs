using FrameworkExample.Business.ReturnData;
using FrameworkExample.Core.Utilities.Enum;
using FrameworkExample.Northwind.Business.Abstract;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Concrete.Managers
{
    public class CustomerDemographicManager : ICustomerDemographicService
    {
        private readonly ICustomerDemographicDal _customerDemographicDal;
        public CustomerDemographicManager(ICustomerDemographicDal customerDemographicDal)
        {
            _customerDemographicDal = customerDemographicDal;
        }

        public StatusData<IList<CustomerDemographic>> GetList(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            var returnData = new StatusData<IList<CustomerDemographic>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.GetList(filter);
                if (returnData.Entity.Count == 0)
                {
                    returnData.Message = "Data Not Found";
                    returnData.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Message = "Process Successful";
                    returnData.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<CustomerDemographic> Get(Expression<Func<CustomerDemographic, bool>> filter)
        {
            var returnData = new StatusData<CustomerDemographic>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.Get(filter);

                if (returnData.Entity == null)
                {
                    returnData.Message = "Data Not Found";
                    returnData.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Message = "Process Successful";
                    returnData.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<CustomerDemographic> Add(CustomerDemographic entity)
        {
            var returnData = new StatusData<CustomerDemographic>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.Add(entity);

                returnData.Message = "Process Successful";
                returnData.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<CustomerDemographic> Update(CustomerDemographic entity)
        {
            var returnData = new StatusData<CustomerDemographic>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.Update(entity);

                returnData.Message = "Process Successful";
                returnData.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<CustomerDemographic> Delete(Expression<Func<CustomerDemographic, bool>> filter)
        {
            var returnData = new StatusData<CustomerDemographic>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _customerDemographicDal.Get(filter);
                _customerDemographicDal.Delete(entity);

                returnData.Message = "Process Successful";
                returnData.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<CustomerDemographic> GetRelated(Expression<Func<CustomerDemographic, bool>> filter)
        {

            var returnData = new StatusData<CustomerDemographic>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.GetWithAllRelated(filter);

                if (returnData.Entity == null)
                {
                    returnData.Message = "Data Not Found";
                    returnData.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Message = "Process Successful";
                    returnData.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<IList<CustomerDemographic>> GetListRelated(Expression<Func<CustomerDemographic, bool>> filter = null)
        {
            var returnData = new StatusData<IList<CustomerDemographic>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _customerDemographicDal.GetListWithAllRelated(filter);
                if (returnData.Entity.Count == 0)
                {
                    returnData.Message = "Data Not Found";
                    returnData.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Message = "Process Successful";
                    returnData.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Message = "An Error Occurred";
                returnData.Exception = ex;
                returnData.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
    }
}
