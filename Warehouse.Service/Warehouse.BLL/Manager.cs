// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Manager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Manager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Warehouse.BLL.Contract;
    using Warehouse.BLL.Transform;
    using Warehouse.BLL.Validator.Common;
    using Warehouse.BLL.Validator.Contract;
    using Warehouse.Common.Container;
    using Warehouse.DAL.Contract;
    using Warehouse.Domain;
    using Warehouse.DTO;

    /// <inheritdoc />
    /// <summary>
    /// The manager.
    /// </summary>
    public class Manager : IManager
    {
        /// <summary>
        /// The delivery repository.
        /// </summary>
        private readonly IRepository<Delivery> deliveryRepository;

        /// <summary>
        /// The goods repository.
        /// </summary>
        private readonly IRepository<Goods> goodsRepository;

        /// <summary>
        /// The goods category repository.
        /// </summary>
        private readonly IRepository<GoodsCategory> goodsCategoryRepository;

        /// <summary>
        /// The goods class repository.
        /// </summary>
        private readonly IRepository<GoodsClass> goodsClassRepository;

        /// <summary>
        /// The goods of delivery repository.
        /// </summary>
        private readonly IRepository<GoodsOfDelivery> goodsOfDeliveryRepository;

        /// <summary>
        /// The provider repository.
        /// </summary>
        private readonly IRepository<Provider> providerRepository;

        /// <summary>
        /// The sale repository.
        /// </summary>
        private readonly IRepository<Sale> saleRepository;

        /// <summary>
        /// The state repository.
        /// </summary>
        private readonly IRepository<State> stateRepository;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// The warehouse repository.
        /// </summary>
        private readonly IRepository<Warehouse> warehouseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        public Manager()
        {
            this.deliveryRepository = DIContainer.Resolve<IRepository<Delivery>>("Delivery");
            this.goodsRepository = DIContainer.Resolve<IRepository<Goods>>("Goods");
            this.goodsCategoryRepository = DIContainer.Resolve<IRepository<GoodsCategory>>("GoodsCategory");
            this.goodsClassRepository = DIContainer.Resolve<IRepository<GoodsClass>>("GoodsClass");
            this.goodsOfDeliveryRepository = DIContainer.Resolve<IRepository<GoodsOfDelivery>>("GoodsOfDelivery");
            this.providerRepository = DIContainer.Resolve<IRepository<Provider>>("Provider");
            this.saleRepository = DIContainer.Resolve<IRepository<Sale>>("Sale");
            this.stateRepository = DIContainer.Resolve<IRepository<State>>("State");
            this.userRepository = DIContainer.Resolve<IRepository<User>>("User");
            this.warehouseRepository = DIContainer.Resolve<IRepository<Warehouse>>("Warehouse");
        }

        /// <inheritdoc />
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Int32" />.
        /// </returns>
        /// <exception cref="T:System.Exception">
        /// </exception>
        public int SystemEnter(UserLogin userLogin)
        {
            var validator = DIContainer.Resolve<IValidator<UserLogin>>("UserLogin");
            var resultValidation = validator.Validate(userLogin);
            switch (resultValidation.ValidationStatus)
            {
                case ValidationStatus.Success:
                    break;
                case ValidationStatus.Fail:
                    throw new Exception(resultValidation.AttachedInfo);
            }

            var user = SimpleTransformer.Transform<UserLogin, User>(userLogin);
            var userList = this.userRepository.SelectAll();
            return userList.First(x => x.Login == user.Login && x.Password == user.Password).UserId;
        }

        /// <inheritdoc />
        /// <summary>
        /// The registration.
        /// </summary>
        /// <param name="userRegistration">
        /// The user registration.
        /// </param>
        /// <exception cref="T:System.Exception">
        /// </exception>
        public void Registration(UserRegistration userRegistration)
        {
            var validator = DIContainer.Resolve<IValidator<UserRegistration>>("UserRegistration");
            var resultValidation = validator.Validate(userRegistration);
            switch (resultValidation.ValidationStatus)
            {
                case ValidationStatus.Success:
                    break;
                case ValidationStatus.Fail:
                    throw new Exception(resultValidation.AttachedInfo);
            }

            var user = SimpleTransformer.Transform<UserRegistration, User>(userRegistration);
            this.userRepository.Insert(user);
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all warehouse goods.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<WarehouseGoods> GetAllWarehouseGoods()
        {
            var warehouseCollection = this.warehouseRepository.SelectAll();
            var goodsOfDeliveryCollection = this.goodsOfDeliveryRepository.SelectAll();
            var deliveryCollection = this.deliveryRepository.SelectAll();
            var goodsCollection = this.goodsRepository.SelectAll();
            var providerCollection = this.providerRepository.SelectAll();
            var goodsCategoryCollection = this.goodsCategoryRepository.SelectAll();
            var goodsClassCollection = this.goodsClassRepository.SelectAll();
            var goodsStateCollection = this.stateRepository.SelectAll();

            var result = from warehouse in warehouseCollection
                         from goodsOfDelivery in goodsOfDeliveryCollection
                         from delivery in deliveryCollection
                         from goods in goodsCollection
                         from provider in providerCollection
                         from goodsCategory in goodsCategoryCollection
                         from goodsClass in goodsClassCollection
                         from state in goodsStateCollection
                         where warehouse.GoodsOfDeliveryId == goodsOfDelivery.GoodsOfDeliveryId
                         where goodsOfDelivery.DeliveryId == delivery.DeliveryId
                         where goodsOfDelivery.GoodsId == goods.GoodsId
                         where goods.ProviderId == provider.ProviderId
                         where goods.GoodsCategoryId == goodsCategory.GoodsCategoryId
                         where goods.GoodsClassId == goodsClass.GoodsClassId
                         where warehouse.StateId == state.StateId
                         select new WarehouseGoods
                                    {
                                        GoodsId = goods.GoodsId,
                                        Title = goods.Title,
                                        Provider = SimpleTransformer.Transform<Provider, ProviderDto>(provider),
                                        GoodsCategory = SimpleTransformer.Transform<GoodsCategory, GoodsCategoryDto>(goodsCategory),
                                        GoodsClass = SimpleTransformer.Transform<GoodsClass, GoodsClassDto>(goodsClass),
                                        Amount = goodsOfDelivery.Amount,
                                        DateTimeDelivery = delivery.DateTimeDelivery,
                                        State = state.Title
                         };

            return result;
        }

        public IEnumerable<ProviderDto> GetAllProvider()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseGoods> GetWarehouseGoodsByProviderId(int providerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsClassDto> GetAllGoodsClass()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsCategoryDto> GetAllGoodsCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDto> GetGoodsByProviderId(int providerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDto> GetGoodsByClassId(int classId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDto> GetGoodsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void AddWarehouseGoods(IEnumerable<WarehouseGoods> warehouseGoods)
        {
            throw new NotImplementedException();
        }

        public void AddGoodsOfProvider(GoodsDto goods)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDto> GetAllGoods()
        {
            throw new NotImplementedException();
        }

        public void UpdateGoods(GoodsDto goods)
        {
            throw new NotImplementedException();
        }

        public void UpdateProvider(ProviderDto provider)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseGoods> GetGoodsByClassAndPeriod(int classId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportDto> GetReportByPeriodAndType(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Sale(WarehouseGoods warehouseGoods, int amount)
        {
            throw new NotImplementedException();
        }
    }
}