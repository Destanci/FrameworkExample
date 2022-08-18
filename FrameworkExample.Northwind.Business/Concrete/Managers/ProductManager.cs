using FrameworkExample.Business.ReturnData;
using FrameworkExample.Core.Aspects.PostSharp.TransactionScopeAspects;
using FrameworkExample.Core.Aspects.PostSharp.ValidationAspects;
using FrameworkExample.Core.Utilities.Enum;
using FrameworkExample.Northwind.Business.Abstract;
using FrameworkExample.Northwind.Business.ValidationRules.FluentValidation;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal) => _productDal = productDal;

        public StatusData<IList<Product>> GetList(Expression<Func<Product, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Product>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.GetList(filter);
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

        public StatusData<Product> Get(Expression<Func<Product, bool>> filter)
        {
            var returnData = new StatusData<Product>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.Get(filter);

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

        [FluentValidationAspect(typeof(ProductValidator))]
        public StatusData<Product> Add(Product entity)
        {
            var returnData = new StatusData<Product>();
            try
            {
                //ValidatorTool.FluentValidate(new ProductValidator(), entity);

                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.Add(entity);

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

        public StatusData<Product> Update(Product entity)
        {
            var returnData = new StatusData<Product>();
            try
            {
                //ValidatorTool.FluentValidate(new ProductValidator(), entity);

                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.Update(entity);

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

        public StatusData<Product> Delete(Expression<Func<Product, bool>> filter)
        {
            var returnData = new StatusData<Product>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();

                var entity = _productDal.Get(filter);
                _productDal.Delete(entity);

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

        public StatusData<Product> GetRelated(Expression<Func<Product, bool>> filter)
        {

            var returnData = new StatusData<Product>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.GetWithAllRelated(filter);

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

        public StatusData<IList<Product>> GetListRelated(Expression<Func<Product, bool>> filter = null)
        {
            var returnData = new StatusData<IList<Product>>();
            try
            {
                returnData.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _productDal.GetListWithAllRelated(filter);
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


        [TransactionScopeAspect]
        /// <summary>
        /// Only for Transaction Test. To be removed. TEMPORARY
        /// </summary>
        /// <param name="p1">Products to add</param>
        /// <param name="p2">Product to Update the p1</param>
        /// <returns>Id of the Added & Updated Product</returns>
        public int TransactionalOperation(Product p1, Product p2)
        {
            var res = Add(p1);

            p2.ProductID = res.Entity.ProductID;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var res2 = Update(p2);
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            throw new Exception(); // An Error Happened.

#pragma warning disable CS0162 // Unreachable code detected
            return res2.Entity.ProductID;
#pragma warning restore CS0162 // Unreachable code detected
        }


    }
}
