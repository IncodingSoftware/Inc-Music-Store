namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(User))]
    public class When_user_new_cart
    {
        #region Estabilish value

        static User original;

        static Cart oldCart;

        #endregion

        Establish establish = () =>
                                  {
                                      oldCart = Pleasure.Generator.Invent<Cart>(dsl => dsl.Callback(cart => cart.AddItem(Pleasure.Generator.Invent<CartItem>())));
                                      original = Pleasure.Generator.Invent<User>(dsl => dsl.Tuning(r => r.Cart, oldCart));
                                  };

        Because of = () => original.NewCart();

        It should_not_be_old_cart = () => original.Cart.IsEqualWeak(oldCart).ShouldBeFalse();

        It should_be_new_cart = () => original.Cart.ShouldEqualWeak(new
                                                                        {
                                                                                Items = Pleasure.ToReadOnly<CartItem>(), 
                                                                        }, dsl => dsl.IgnoreBecauseNotUse(r => r.User));
    }
}