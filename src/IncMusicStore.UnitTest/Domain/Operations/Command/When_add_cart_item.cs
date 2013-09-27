namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    #endregion

    [Subject(typeof(AddCartItemCommand))]
    public class When_add_cart_item
    {
        #region Estabilish value

        static MockMessage<AddCartItemCommand, object> mockCommand;

        static Album album;

        static Mock<Cart> cart;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<AddCartItemCommand>();

                                      cart = Pleasure.Mock<Cart>();
                                      var user = Pleasure.MockStrictAsObject<User>(mock => mock.SetupGet(r => r.Cart).Returns(cart.Object));
                                      album = Pleasure.Generator.Invent<Album>();

                                      mockCommand = MockCommand<AddCartItemCommand>
                                              .When(command)
                                              .StubGetById(IncMusicStorePleasure.TheUserId(), user)
                                              .StubGetById(command.AlbumId, album);
                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_add_item = () =>
                                    {
                                        Action<ICompareFactoryDsl<CartItem, AddCartItemCommand>> setting = dsl => dsl.IgnoreBecauseRoot(r => r.Cart)
                                                                                                                     .ForwardToAction(r => r.Album, item => item.Album.ShouldEqualWeak(album));
                                        cart.Verify(r => r.AddItem(Pleasure.MockIt.IsWeak(mockCommand.Original, setting)));
                                    };
    }
}