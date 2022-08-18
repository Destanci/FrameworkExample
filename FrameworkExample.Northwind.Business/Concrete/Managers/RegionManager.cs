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
    public class RegionManager : IRegionService
    {
        private readonly IRegionDal _regionDal;
        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        public StatusData<IList<Region>> GetList(Expression<Func<Region, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Region>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.GetList(filter);
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

        public StatusData<Region> Get(Expression<Func<Region, bool>> filter)
        {
            var returnData = new StatusData<Region>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.Get(filter);

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

        public StatusData<Region> Add(Region entity)
        {
            var returnData = new StatusData<Region>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.Add(entity);

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

        public StatusData<Region> Update(Region entity)
        {
            var returnData = new StatusData<Region>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.Update(entity);

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

        public StatusData<Region> Delete(Expression<Func<Region, bool>> filter)
        {
            var returnData = new StatusData<Region>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _regionDal.Get(filter);
                _regionDal.Delete(entity);

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

        public StatusData<Region> GetRelated(Expression<Func<Region, bool>> filter)
        {

            var returnData = new StatusData<Region>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.GetWithAllRelated(filter);

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

        public StatusData<IList<Region>> GetListRelated(Expression<Func<Region, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Region>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _regionDal.GetListWithAllRelated(filter);
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
