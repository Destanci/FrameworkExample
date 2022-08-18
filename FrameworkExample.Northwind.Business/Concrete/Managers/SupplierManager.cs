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
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierDal _supplierDal;
        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public StatusData<IList<Supplier>> GetList(Expression<Func<Supplier, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Supplier>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.GetList(filter);
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

        public StatusData<Supplier> Get(Expression<Func<Supplier, bool>> filter)
        {
            var returnData = new StatusData<Supplier>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.Get(filter);

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

        public StatusData<Supplier> Add(Supplier entity)
        {
            var returnData = new StatusData<Supplier>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.Add(entity);

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

        public StatusData<Supplier> Update(Supplier entity)
        {
            var returnData = new StatusData<Supplier>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.Update(entity);

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

        public StatusData<Supplier> Delete(Expression<Func<Supplier, bool>> filter)
        {
            var returnData = new StatusData<Supplier>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _supplierDal.Get(filter);
                _supplierDal.Delete(entity);

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

        public StatusData<Supplier> GetRelated(Expression<Func<Supplier, bool>> filter)
        {

            var returnData = new StatusData<Supplier>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.GetWithAllRelated(filter);

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

        public StatusData<IList<Supplier>> GetListRelated(Expression<Func<Supplier, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Supplier>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _supplierDal.GetListWithAllRelated(filter);
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
