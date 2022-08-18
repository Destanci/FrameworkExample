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
    public class ShipperManager : IShipperService
    {
        private readonly IShipperDal _shipperDal;
        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }

        public StatusData<IList<Shipper>> GetList(Expression<Func<Shipper, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Shipper>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.GetList(filter);
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

        public StatusData<Shipper> Get(Expression<Func<Shipper, bool>> filter)
        {
            var returnData = new StatusData<Shipper>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.Get(filter);

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

        public StatusData<Shipper> Add(Shipper entity)
        {
            var returnData = new StatusData<Shipper>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.Add(entity);

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

        public StatusData<Shipper> Update(Shipper entity)
        {
            var returnData = new StatusData<Shipper>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.Update(entity);

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

        public StatusData<Shipper> Delete(Expression<Func<Shipper, bool>> filter)
        {
            var returnData = new StatusData<Shipper>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _shipperDal.Get(filter);
                _shipperDal.Delete(entity);

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

        public StatusData<Shipper> GetRelated(Expression<Func<Shipper, bool>> filter)
        {

            var returnData = new StatusData<Shipper>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.GetWithAllRelated(filter);

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

        public StatusData<IList<Shipper>> GetListRelated(Expression<Func<Shipper, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Shipper>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _shipperDal.GetListWithAllRelated(filter);
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
