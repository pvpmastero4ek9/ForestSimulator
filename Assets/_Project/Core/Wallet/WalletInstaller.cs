using UnityEngine;
using Zenject;

namespace Core.Wallets
{
    public class WalletInstaller : MonoInstaller
    {
        public Wallet MainWallet { get; private set; } = new();
        public override void InstallBindings()
        {
            MainWallet = new();
            Container
                .Bind<Wallet>()
                .FromInstance(MainWallet)
                .AsSingle();
        }
    }
}
