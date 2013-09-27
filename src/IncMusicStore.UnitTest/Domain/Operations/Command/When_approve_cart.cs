namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Collections.ObjectModel;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    #endregion

    [Subject(typeof(ApproveCartCommand))]
    public class When_approve_cart
    {
        #region Estabilish value

        static MockMessage<ApproveCartCommand, object> mockCommand;

        static Mock<User> user;

        static ReadOnlyCollection<CartItem> cartItems;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<ApproveCartCommand>();

                                      user = Pleasure.Mock<User>(mockUser =>
                                                                     {
                                                                         cartItems = Pleasure.ToReadOnly(Pleasure.Generator.Invent<CartItem>(dsl => dsl.GenerateTo<Album>(r => r.Album)));
                                                                         var cart = Pleasure.MockAsObject<Cart>(mockCart => mockCart.SetupGet(r => r.Items).Returns(cartItems));
                                                                         mockUser.SetupGet(r => r.Cart).Returns(cart);
                                                                     });

                                      mockCommand = MockCommand<ApproveCartCommand>
                                              .When(command)
                                              .StubGetById(IncMusicStorePleasure.TheUserId(), user.Object);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_add_order = () =>
                                     {
                                         Action<Order> predicateOrderItem = order => order.Items.ShouldEqualWeakEach(cartItems, (dsl, i) => dsl.ForwardToValue(r => r.UnitPrice, cartItems[i].Album.Price)
                                                                                                                                               .ForwardToAction(r => r.Order, item => item.Order.ShouldNotBeNull()));
                                         Action<ICompareFactoryDsl<Order, ApproveCartCommand>> predicateOrder = dsl => dsl.IgnoreBecauseRoot(r => r.User)
                                                                                                                          .ForwardToAction(r => r.Items, predicateOrderItem)
                                                                                                                          .ForwardToAction(r => r.PaymentInfo, order => order.PaymentInfo.ShouldEqualWeak(mockCommand.Original))
                                                                                                                          .ForwardToAction(r => r.CreateDt, order => order.CreateDt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-10)));
                                         user.Verify(r => r.AddOrder(Pleasure.MockIt.IsWeak(mockCommand.Original, predicateOrder)));
                                     };

        It should_be_new_cart = () => user.Verify(r => r.NewCart());
    }
}