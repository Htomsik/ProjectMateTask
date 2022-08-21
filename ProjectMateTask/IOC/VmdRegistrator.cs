﻿using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.CloseNavigationServices;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;
using ProjectMateTask.VMD.AppInfrastructure;
using ProjectMateTask.VMD.Pages;
using ProjectMateTask.VMD.Pages.AdditionalPages;
using ProjectMateTask.VMD.Pages.EntityPages;
using ProjectMateTask.VMD.Pages.SelectEntityPages;

namespace ProjectMateTask.IOC;

internal static class VmdRegistrator
{
    public static IServiceCollection VmdRegistration(this IServiceCollection services)
    {
        services.AddSingleton(CreateMainWindowVmd);

        services.AddTransient(CreateMainMenuVmd);

        services.AddTransient<MainPageVmd>();

        #region EditEntity Vmds

        services.AddTransient<ManagersPageVmd>();

        services.AddTransient<ClientsPageVmd>();

        services.AddTransient<ProductPageVmd>();

        services.AddTransient<ClientStatusesPageVmd>();

        services.AddTransient<ProductTypePageVmd>();

        #endregion

        #region SelectEntity Vmds

        services.AddTransient<ClientSelectPageVmd>();

        services.AddTransient<ManagerSelectPageVmd>();

        services.AddTransient<ProductSelectPageVmd>();

        services.AddTransient<ProductTypeSelectPageVmd>();

        services.AddTransient<ClientStatusSelectPageVmd>();

        #endregion


        #region Additional Vmds

        services.AddTransient<SettingsAdditionalPageVmd>();

        #endregion
        
        services.AddTransient(CreateMainPageNavigationServices);


        return services;
    }


    #region MainEntityPageVmdsNavigationServices

    private static INavigationService CreateMainPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<MainPageVmd>);
    }

    private static INavigationService CreateManagersPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ManagersPageVmd>);
    }

    private static INavigationService CreateClientsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ClientsPageVmd>);
    }

    private static INavigationService CreateProductsPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ProductPageVmd>);
    }

    private static INavigationService CreateClientStatusesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ClientStatusesPageVmd>);
    }

    private static INavigationService CreateProductTypesPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new MainEntityPageNavigationService(serviceProvider.GetRequiredService<MainEntityPageNavigationStore>(),
            serviceProvider.GetRequiredService<ProductTypePageVmd>);
    }

    #endregion

    #region AdditionalPdgeVmdsNavigationServices

    private static INavigationService CreateSettingsAdditionalPageNavigationServices(IServiceProvider serviceProvider)
    {
        return new AdditionalPageNavigationService(serviceProvider.GetRequiredService<AdditionalPageNavigationStore>(),
            serviceProvider.GetRequiredService<SettingsAdditionalPageVmd>);
    }
        
  

    #endregion

    #region Vmds

    private static MainMenuVmd CreateMainMenuVmd(IServiceProvider s)
    {
        return new MainMenuVmd(CreateManagersPageNavigationServices(s),
            CreateClientsPageNavigationServices(s),
            CreateProductsPageNavigationServices(s),
            CreateMainPageNavigationServices(s),
            CreateClientStatusesPageNavigationServices(s),
            CreateProductTypesPageNavigationServices(s));
    }

    private static MainWindowVmd CreateMainWindowVmd(IServiceProvider s)
    {
        return new MainWindowVmd(
            s.GetRequiredService<MainEntityPageNavigationStore>(),
            s.GetRequiredService<MainMenuNavigationStore>(),
            s.GetRequiredService<AdditionalPageNavigationStore>(),CreateSettingsAdditionalPageNavigationServices(s));
    }

    
    #endregion
}