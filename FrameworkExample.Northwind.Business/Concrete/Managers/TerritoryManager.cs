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
    public class TerritoryManager : ITerritoryService
    {
        private readonly ITerritoryDal _territoryDal;
        public TerritoryManager(ITerritoryDal territoryDal)
        {
            _territoryDal = territoryDal;
        }

        public StatusData<IList<Territory>> GetList(Expression<Func<Territory, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Territory>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.GetList(filter);
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

        public StatusData<Territory> Get(Expression<Func<Territory, bool>> filter)
        {
            var returnData = new StatusData<Territory>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.Get(filter);

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

        public StatusData<Territory> Add(Territory entity)
        {
            var returnData = new StatusData<Territory>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.Add(entity);

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

        public StatusData<Territory> Update(Territory entity)
        {
            var returnData = new StatusData<Territory>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.Update(entity);

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

        public StatusData<Territory> Delete(Expression<Func<Territory, bool>> filter)
        {
            var returnData = new StatusData<Territory>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _territoryDal.Get(filter);
                _territoryDal.Delete(entity);

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

        public StatusData<Territory> GetRelated(Expression<Func<Territory, bool>> filter)
        {

            var returnData = new StatusData<Territory>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.GetWithAllRelated(filter);

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

        public StatusData<IList<Territory>> GetListRelated(Expression<Func<Territory, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Territory>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _territoryDal.GetListWithAllRelated(filter);
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
