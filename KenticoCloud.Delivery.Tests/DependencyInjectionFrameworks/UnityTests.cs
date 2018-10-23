﻿using KenticoCloud.Delivery.Tests.DIFrameworks.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KenticoCloud.Delivery.Tests.DIFrameworks
{
    public class UnityTests
    {
        [Fact]
        public void DeliveryClientIsSuccessfullyResolvedFromUnityContainer()
        {
            var provider = DependencyInjectionFrameworksHelper
                .GetServiceCollection()
                .BuildUnityServiceProvider();

            var client = (DeliveryClient)provider.GetService<IDeliveryClient>();

            client.AssertDefaultDependencies();
        }

        [Fact]
        public void DeliveryClientIsSuccessfullyResolvedFromUnityContainer_CustomCodeFirstModelProvider()
        {
            var provider = DependencyInjectionFrameworksHelper
                .GetServiceCollection()
                .AddScoped<ICodeFirstModelProvider, FakeModelProvider>()
                .BuildUnityServiceProvider();

            var client = (DeliveryClient)provider.GetService<IDeliveryClient>();

            client.AssertDefaultDependenciesWithCustomCodeFirstModelProvider<FakeModelProvider>();
        }
    }
}